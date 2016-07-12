using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Web
{
    /// <summary>
    /// Helper class to convert from a heavyweight MobileConnectStatus instance to a Lightweight serializable MobileConnectWebResponse instance
    /// </summary>
    /// <seealso cref="MobileConnectStatus"/>
    /// <seealso cref="MobileConnectWebInterface"/>
    public static class ResponseConverter
    {
        private const string STATUS_SUCCESS = "success";
        private const string STATUS_FAILURE = "failure";

        private static Dictionary<MobileConnectResponseType, string> _statusDict = new Dictionary<MobileConnectResponseType, string>()
        {
            { MobileConnectResponseType.Authorization, STATUS_SUCCESS },
            { MobileConnectResponseType.Complete, STATUS_SUCCESS },
            { MobileConnectResponseType.Error, STATUS_FAILURE },
            { MobileConnectResponseType.OperatorSelection, STATUS_SUCCESS },
            { MobileConnectResponseType.StartAuthorization, STATUS_SUCCESS },
            { MobileConnectResponseType.StartDiscovery, STATUS_SUCCESS },
            { MobileConnectResponseType.UserInfo, STATUS_SUCCESS },
        };

        private static Dictionary<MobileConnectResponseType, string> _actionDict = new Dictionary<MobileConnectResponseType, string>()
        {
            { MobileConnectResponseType.Authorization, "authorization" },
            { MobileConnectResponseType.Complete, "complete" },
            { MobileConnectResponseType.Error, "error" },
            { MobileConnectResponseType.OperatorSelection, "operator_selection" },
            { MobileConnectResponseType.StartAuthorization, "start_authorization" },
            { MobileConnectResponseType.StartDiscovery, "discovery" },
            { MobileConnectResponseType.UserInfo, "user_info" },
        };

        /// <summary>
        /// Convert to lightweight serializable MobileConnectWebResponse
        /// </summary>
        /// <param name="status">Input status instance</param>
        /// <returns>Serializable response instance</returns>
        /// <example>
        /// <code language="C#" title="WebApi Controller Example">
        /// <![CDATA[
        /// [HttpGet]
        /// [Route("start_discovery")]
        /// public async Task<object> StartDiscovery(string msisdn = "", string mcc = "", string mnc = "")
        /// {
        ///     var response = await _mobileConnect.AttemptDiscovery(Request, msisdn, mcc, mnc, true, new MobileConnectRequestOptions());
        ///     return ResponseConverter.Convert(response);
        /// }
        /// ]]>
        /// </code>
        /// </example>
        public static MobileConnectWebResponse Convert(MobileConnectStatus status)
        {
            var response = new MobileConnectWebResponse
            {
                Status = _statusDict[status.ResponseType],
                Action = _actionDict[status.ResponseType],
                ApplicationShortName = status.DiscoveryResponse?.ApplicationShortName,
                Nonce = status.Nonce,
                State = status.State,
                Url = status.Url,
                SdkSession = status.SDKSession,
                SubscriberId = status.DiscoveryResponse?.ResponseData?.subscriber_id,
                Token = status.TokenResponse?.ResponseData,
                UserInfo = status.UserInfoResponse?.ResponseJson != null ? new Newtonsoft.Json.Linq.JRaw(status.UserInfoResponse.ResponseJson) : null,
            };

            if(status.ResponseType == MobileConnectResponseType.Error)
            {
                response.Error = status.ErrorCode;
                response.Description = status.ErrorMessage;
            }

            return response;
        }
    }
}
