using GSMA.MobileConnect.Demo.Universal;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace GSMA.MobileConnect.Demo.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MobileConnectInterface _mobileConnect;
        private MobileConnectConfig _config;
        private string _state;
        private string _nonce;
        private Discovery.DiscoveryResponse _discoveryResponse;

        public MainWindow()
        {
            _mobileConnect = MobileConnectFactory.MobileConnect;
            _config = MobileConnectFactory.Config;

            InitializeComponent();
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
                _discoveryResponse = response.DiscoveryResponse;
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
            errorText.Text = response?.ErrorMessage;
            progress.Visibility = Visibility.Collapsed;
            submit.IsEnabled = true;
        }

        private async Task StartAuthorization(MobileConnectStatus response)
        {
            _state = Guid.NewGuid().ToString("N");
            _nonce = Guid.NewGuid().ToString("N");
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
            submit.IsEnabled = false;

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

        private async void web_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            Debug.WriteLine("Navigating");
            Debug.WriteLine(e.Uri.AbsoluteUri);

            web.Visibility = Visibility.Collapsed;

            if (e.Uri.AbsoluteUri.StartsWith(_config.RedirectUrl))
            {
                //cancel navigation to prevent final redirect from loading, navigate to blank to prevent previous redirect reloading
                e.Cancel = true;
                web.Source = new Uri("about:blank");
                await HandleRedirect(e.Uri);
            }
        }

        private void web_Navigated(object sender, NavigationEventArgs e)
        {
            Debug.WriteLine("Navigated");
            Debug.WriteLine(e.Uri.AbsoluteUri);

            if (!string.IsNullOrEmpty(e.Uri.Host) && !e.Uri.AbsoluteUri.StartsWith(_config.RedirectUrl))
            {
                web.Visibility = Visibility.Visible;
            }
        }

        #endregion

        private IntPtr web_MessageHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            //Catch browser closing due to javascript window.close()
            // WndProc Message WM_CLOSE
            if(msg == 0x10)
            {
                handled = true;
                web.Source = new Uri("about:blank");
                HandleError(null);
            }

            return IntPtr.Zero;
        }
    }
}
