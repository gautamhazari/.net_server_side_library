using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace GSMA.MobileConnect.Demo.Universal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MobileConnectInterface _mobileConnect;
        private MobileConnectConfig _config;
        private string _state;
        private string _nonce;
        private Discovery.DiscoveryResponse _discoveryResponse;

        public MainPage()
        {
            _mobileConnect = MobileConnectFactory.MobileConnect;
            _config = MobileConnectFactory.Config;

            this.InitializeComponent();
        }

        #region MobileConnect Methods

        private async Task HandleRedirect(Uri url)
        {
            var response = await _mobileConnect.HandleUrlRedirectAsync(url, _discoveryResponse, _state, _nonce);
            await HandleResponse(response);
        }

        private async Task HandleResponse(MobileConnectStatus response)
        {
            System.Diagnostics.Debug.WriteLine(response.ResponseType);
            if (response.ResponseType == MobileConnectResponseType.OperatorSelection || response.ResponseType == MobileConnectResponseType.Authorization)
            {
                web.Navigate(new Uri(response.Url));
            }
            else if (response.ResponseType == MobileConnectResponseType.StartAuthorization)
            {
                await StartAuthorization(response);
            }
            else if (response.ResponseType == MobileConnectResponseType.Complete)
            {
                System.Diagnostics.Debug.WriteLine(response.TokenResponse.ResponseData.AccessToken);
                Complete(response.TokenResponse.ResponseData.AccessToken);
            }
            else if (response.ResponseType == MobileConnectResponseType.Error)
            {
                HandleError(response);
            }
        }

        private void HandleError(MobileConnectStatus response)
        {
            errorText.Text = response.ErrorMessage;
            progress.Visibility = Visibility.Collapsed;
        }

        private async Task StartAuthorization(MobileConnectStatus response)
        {
            _state = Guid.NewGuid().ToString("N");
            _nonce = Guid.NewGuid().ToString("N");
            _discoveryResponse = response.DiscoveryResponse;
            var newResponse = _mobileConnect.StartAuthorization(_discoveryResponse,
                response.DiscoveryResponse.ResponseData.subscriber_id, _state, _nonce, new MobileConnectRequestOptions());

            await HandleResponse(newResponse);
        }

        private async Task StartDiscovery(string msisdn)
        {
            var response = await _mobileConnect.AttemptDiscoveryAsync(msisdn, null, null, new MobileConnectRequestOptions());
            await HandleResponse(response);
        }

        private void Complete(string token)
        {
            _state = null;
            _nonce = null;
            _discoveryResponse = null;

            accessToken.Text = string.Format("Access Token: {0}", token);

            loginPanel.Visibility = Visibility.Collapsed;
            loggedPanel.Visibility = Visibility.Visible;
        }

        #endregion

        #region Event Handlers

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string msisdnVal = null;
            if (toggle.IsChecked == true)
            {
                msisdnVal = msisdn.Text;
            }

            progress.Visibility = Visibility.Visible;

            await StartDiscovery(msisdnVal);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            msisdn.Visibility = Visibility.Visible;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            msisdn.Visibility = Visibility.Collapsed;
        }

        private async void WebView_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            Debug.WriteLine(args.Uri.AbsoluteUri);
            web.Visibility = Visibility.Collapsed;

            if (args.Uri.AbsoluteUri.StartsWith(_config.RedirectUrl))
            {
                //cancel navigation to prevent final redirect from loading, navigate to blank to prevent previous redirect reloading
                args.Cancel = true;
                sender.Source = new Uri("about:blank");
                await HandleRedirect(args.Uri);
            }
        }

        private void web_LoadCompleted(object sender, NavigationEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Uri.Host) && !e.Uri.AbsoluteUri.StartsWith(_config.RedirectUrl))
            {
                web.Visibility = Visibility.Visible;
            }
        }

        #endregion
    }
}
