using GSMA.MobileConnect.Authentication;
using GSMA.MobileConnect.Discovery;
using GSMA.MobileConnect.Utils;
using GSMA.MobileConnect.Web;
using NUnit.Framework;
using System.Collections.Generic;

namespace GSMA.MobileConnect.Test.Web
{
    [TestFixture]
    public class ResponseConverterTests
    {
        private const string OPERATOR_SELECTION_URL = "http://discovery.sandbox2.mobileconnect.io/v2/discovery/users/operator-selection?session_id=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJyZWRpcmVjdFVybCI6Imh0dHA6Ly9sb2NhbGhvc3Q6ODAwMS8iLCJhcHBsaWNhdGlvbiI6eyJleHRlcm5hbF9pZCI6IjExMzgiLCJuYW1lIjoiY3NoYXJwLXNkayIsImtleXMiOnsic2FuZGJveCI6eyJrZXkiOiI2Njc0MmE4NS0yMjgyLTQ3NDctODgxZC1lZDViN2JkNzRkMmQiLCJzZWNyZXQiOiJmMTUxOTlmNC1iNjU4LTRlNTgtOGJiMy1lNDA5OTg4NzMzOTIifX0sInJlZGlyZWN0X3VyaSI6Imh0dHBzOi8vbG9jYWxob3N0OjgwMDEvIiwiZGV2ZWxvcGVyIjp7InBvcnRhbF91c2VyX2lkIjoiMTEzOCIsIm5hbWUiOiJOaWNob2xhcyBEb25vaG9lIiwiZW1haWwiOiJuaWNob2xhcy5kb25vaG9lQGJqc3MuY29tIiwicHJvZmlsZSI6Imh0dHBzOi8vZGV2ZWxvcGVyLm1vYmlsZWNvbm5lY3QuaW8vYXBpL3YxL3VzZXI_ZW1haWw9bmljaG9sYXMuZG9ub2hvZSU0MGJqc3MuY29tIiwidXBkYXRlZCI6IjIwMTYtMDQtMjBUMDk6MzQ6MThaIiwibXNpc2RucyI6WyI5NDE0ZTI1MmMzYjE1ZWUzMGIyN2NmYmQxNjkzN2UwNWJlMGQ1NWYwZGZjZGQ0MjM2OTg3NTU1MjQ3ZjU0YzUyIiwiZjYwZjFkZDU1YzUxMjE3ZTAwMTc4YWE3ZGIxM2Q5Njc4OGUxZmM0MzRkMGU2ZGZiZmI2NjVlYjU5NzU3MGIwZiJdLCJtc2lzZG5TaG9ydCI6WyI3NTc1IiwiMzMzMyJdLCJzbXNBdXRoIjp0cnVlLCJtY2MiOiI5MDEiLCJtbmMiOiIwMSIsImNvbnNlbnQiOmZhbHNlfX0sInVzZXIiOnsibmFtZSI6IjY2NzQyYTg1LTIyODItNDc0Ny04ODFkLWVkNWI3YmQ3NGQyZCIsInBhc3MiOiJmMTUxOTlmNC1iNjU4LTRlNTgtOGJiMy1lNDA5OTg4NzMzOTIifSwiaWF0IjoxNDYxMTY5MzA5fQ.2Lp0Xt9JXVZxNbnNq_RH-5KJPQ06qw6ttR4ZK3fwcQU";
        private const string AUTHORIZE_URL = "http://localhost:8080/authorize";
        private Dictionary<string, RestResponse> _responses = new Dictionary<string, RestResponse>()
        {
            { "operator-selection", new RestResponse(System.Net.HttpStatusCode.Accepted, "{\"links\":[{\"rel\":\"operatorSelection\",\"href\":\"http://discovery.sandbox2.mobileconnect.io/v2/discovery/users/operator-selection?session_id=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJyZWRpcmVjdFVybCI6Imh0dHA6Ly9sb2NhbGhvc3Q6ODAwMS8iLCJhcHBsaWNhdGlvbiI6eyJleHRlcm5hbF9pZCI6IjExMzgiLCJuYW1lIjoiY3NoYXJwLXNkayIsImtleXMiOnsic2FuZGJveCI6eyJrZXkiOiI2Njc0MmE4NS0yMjgyLTQ3NDctODgxZC1lZDViN2JkNzRkMmQiLCJzZWNyZXQiOiJmMTUxOTlmNC1iNjU4LTRlNTgtOGJiMy1lNDA5OTg4NzMzOTIifX0sInJlZGlyZWN0X3VyaSI6Imh0dHBzOi8vbG9jYWxob3N0OjgwMDEvIiwiZGV2ZWxvcGVyIjp7InBvcnRhbF91c2VyX2lkIjoiMTEzOCIsIm5hbWUiOiJOaWNob2xhcyBEb25vaG9lIiwiZW1haWwiOiJuaWNob2xhcy5kb25vaG9lQGJqc3MuY29tIiwicHJvZmlsZSI6Imh0dHBzOi8vZGV2ZWxvcGVyLm1vYmlsZWNvbm5lY3QuaW8vYXBpL3YxL3VzZXI_ZW1haWw9bmljaG9sYXMuZG9ub2hvZSU0MGJqc3MuY29tIiwidXBkYXRlZCI6IjIwMTYtMDQtMjBUMDk6MzQ6MThaIiwibXNpc2RucyI6WyI5NDE0ZTI1MmMzYjE1ZWUzMGIyN2NmYmQxNjkzN2UwNWJlMGQ1NWYwZGZjZGQ0MjM2OTg3NTU1MjQ3ZjU0YzUyIiwiZjYwZjFkZDU1YzUxMjE3ZTAwMTc4YWE3ZGIxM2Q5Njc4OGUxZmM0MzRkMGU2ZGZiZmI2NjVlYjU5NzU3MGIwZiJdLCJtc2lzZG5TaG9ydCI6WyI3NTc1IiwiMzMzMyJdLCJzbXNBdXRoIjp0cnVlLCJtY2MiOiI5MDEiLCJtbmMiOiIwMSIsImNvbnNlbnQiOmZhbHNlfX0sInVzZXIiOnsibmFtZSI6IjY2NzQyYTg1LTIyODItNDc0Ny04ODFkLWVkNWI3YmQ3NGQyZCIsInBhc3MiOiJmMTUxOTlmNC1iNjU4LTRlNTgtOGJiMy1lNDA5OTg4NzMzOTIifSwiaWF0IjoxNDYxMTY5MzA5fQ.2Lp0Xt9JXVZxNbnNq_RH-5KJPQ06qw6ttR4ZK3fwcQU\"}]}") },
            { "authentication", new RestResponse(System.Net.HttpStatusCode.OK, "{\"ttl\":1461169322705,\"subscriber_id\":\"e06a09de399ae6c6798c2126e531775ddf3cfe00367af1842534be709fef25e199157c49cc44adf661d286a29afa09c017747fb4383db22b2eaf33db5f878b3ea261c8f342b234e998757e83de23f4a637ce2390453d5d578c76cd65aae99332ee7fbdbd4a140c99babc4e700eae6aa44d3e17ac050771c1fd784fef0214bf770cd0854ea6f4cff87b3ea1e4b25dccd1d340f00eb66c0f041f90596f5236c1017b2541606fff5165320fc4b3381ebfe1fdb848ab04fbedc550bc575ca385b44695a0a9917a368552ee9f8e2178553318a17c32284197631f74f293f30fe6c04f7a77115ec0d2e8ab2a522db88c60263ec1b690ca22540b916e8a9d2c3d820ec1\",\"response\":{\"serving_operator\":\"Example Operator A\",\"country\":\"US\",\"currency\":\"USD\",\"apis\":{\"operatorid\":{\"link\":[{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/authorize\",\"rel\":\"authorization\"},{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/accesstoken\",\"rel\":\"token\"},{\"href\":\"http://operator_a.sandbox2.mobileconnect.io/oidc/userinfo\",\"rel\":\"userinfo\"},{\"href\":\"openid profile email\",\"rel\":\"scope\"}]}},\"client_id\":\"66742a85-2282-4747-881d-ed5b7bd74d2d\",\"client_secret\":\"f15199f4-b658-4e58-8bb3-e40998873392\",\"subscriber_id\":\"e06a09de399ae6c6798c2126e531775ddf3cfe00367af1842534be709fef25e199157c49cc44adf661d286a29afa09c017747fb4383db22b2eaf33db5f878b3ea261c8f342b234e998757e83de23f4a637ce2390453d5d578c76cd65aae99332ee7fbdbd4a140c99babc4e700eae6aa44d3e17ac050771c1fd784fef0214bf770cd0854ea6f4cff87b3ea1e4b25dccd1d340f00eb66c0f041f90596f5236c1017b2541606fff5165320fc4b3381ebfe1fdb848ab04fbedc550bc575ca385b44695a0a9917a368552ee9f8e2178553318a17c32284197631f74f293f30fe6c04f7a77115ec0d2e8ab2a522db88c60263ec1b690ca22540b916e8a9d2c3d820ec1\"}}") },
            { "error", new RestResponse(System.Net.HttpStatusCode.OK, "{\"error\":\"Not_Found_Entity\",\"description\":\"Operator Not Found\"}") },
            { "token", new RestResponse(System.Net.HttpStatusCode.OK, "{\"access_token\":\"966ad150-16c5-11e6-944f-43079d13e2f3\",\"token_type\":\"Bearer\",\"expires_in\":3600,\"id_token\":\"eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJub25jZSI6Ijc3YzE2M2VmZDkzYzQ4ZDFhNWY2NzdmNGNmNTUzOGE4Iiwic3ViIjoiY2M3OGEwMmNjM2ViNjBjOWVjNTJiYjljZDNhMTg5MTAiLCJhbXIiOlsiU0lNX1BJTiJdLCJhdXRoX3RpbWUiOjE0NjI4OTQ4NTcsImFjciI6IjIiLCJhenAiOiI2Njc0MmE4NS0yMjgyLTQ3NDctODgxZC1lZDViN2JkNzRkMmQiLCJpYXQiOjE0NjI4OTQ4NTYsImV4cCI6MTQ2Mjg5ODQ1NiwiYXVkIjpbIjY2NzQyYTg1LTIyODItNDc0Ny04ODFkLWVkNWI3YmQ3NGQyZCJdLCJpc3MiOiJodHRwOi8vb3BlcmF0b3JfYS5zYW5kYm94Mi5tb2JpbGVjb25uZWN0LmlvL29pZGMvYWNjZXNzdG9rZW4ifQ.lwXhpEp2WUTi0brKBosM8Uygnrdq6FnLqkZ0Bm53gXA\"}") },
            { "invalid-code", new RestResponse(System.Net.HttpStatusCode.BadRequest, "{\"error\":\"invalid_grant\",\"error_description\":\"Authorization code doesn't exist or is invalid for the client\"}") },
        };

        [Test]
        public void ResponseConverterShouldHandleOperatorSelectionStatus()
        {
            var status = MobileConnectStatus.OperatorSelection(OPERATOR_SELECTION_URL);

            var actual = ResponseConverter.Convert(status);

            Assert.IsNotNull(actual);
            Assert.AreEqual("success", actual.Status);
            Assert.AreEqual("operator_selection", actual.Action);
            Assert.AreEqual(OPERATOR_SELECTION_URL, actual.Url);
        }

        [Test]
        public void ResponseConverterShouldHandleStartAuthenticationStatus()
        {
            var session = "session";
            var response = new DiscoveryResponse(_responses["authentication"]);
            var status = MobileConnectStatus.StartAuthorization(response);
            status.SDKSession = session;

            var actual = ResponseConverter.Convert(status);

            Assert.IsNotNull(actual);
            Assert.AreEqual("success", actual.Status);
            Assert.AreEqual("start_authentication", actual.Action);
            Assert.IsNotNull(actual.SdkSession);
            Assert.IsNotNull(actual.SubscriberId);
        }

        [Test]
        public void ResponseConverterShouldHandleAuthenticationStatus()
        {
            var state = "qpwoeirurytalsksjdhdgf";
            var nonce = "qpwowieuryrttalksjsggdfj";
            var status = MobileConnectStatus.Authorization(AUTHORIZE_URL, state, nonce);

            var actual = ResponseConverter.Convert(status);

            Assert.IsNotNull(actual);
            Assert.AreEqual("success", actual.Status);
            Assert.AreEqual("authentication", actual.Action);
            Assert.AreEqual(AUTHORIZE_URL, actual.Url);
            Assert.AreEqual(state, actual.State);
            Assert.AreEqual(nonce, actual.Nonce);
        }

        [Test]
        public void ResponseConverterShouldHandleCompleteStatus()
        {
            var response = new RequestTokenResponse(_responses["token"]);
            var status = MobileConnectStatus.Complete(response);

            var actual = ResponseConverter.Convert(status);

            Assert.IsNotNull(actual);
            Assert.AreEqual("success", actual.Status);
            Assert.AreEqual("complete", actual.Action);
            Assert.AreEqual(status.TokenResponse.ResponseData, actual.Token);
        }

        [Test]
        public void ResponseConverterShouldHandleStartDiscoveryStatus()
        {
            var status = MobileConnectStatus.StartDiscovery();

            var actual = ResponseConverter.Convert(status);

            Assert.IsNotNull(actual);
            Assert.AreEqual("success", actual.Status);
            Assert.AreEqual("discovery", actual.Action);
        }

        [Test]
        public void ResponseConverterShouldHandleErrorStatus()
        {
            var error = "this is the error";
            var description = "this is the description";
            var status = MobileConnectStatus.Error(error, description, null);

            var actual = ResponseConverter.Convert(status);

            Assert.IsNotNull(actual);
            Assert.AreEqual("failure", actual.Status);
            Assert.AreEqual("error", actual.Action);
            Assert.AreEqual(error, actual.Error);
            Assert.AreEqual(description, actual.Description);
        }
    }
}
