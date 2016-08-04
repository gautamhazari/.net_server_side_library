using GSMA.MobileConnect.Authentication;
using GSMA.MobileConnect.Cache;
using GSMA.MobileConnect.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMA.MobileConnect.Test.Authentication
{
    [TestFixture]
    public class JWKeysetServiceTests
    {
        private Dictionary<string, RestResponse> _responses = new Dictionary<string, RestResponse>()
        {
            { "single", new RestResponse(System.Net.HttpStatusCode.OK, "{keys:[{kty:\"RSA\",use:\"sig\",n:\"ALyIC8vj1tqEIvAvpDMQfgosw13LpBS9Z2lsMmuaLDNJjN_FKIb-HVR2qtMj7AYC0-wYJhGxJpTXJTVRRDz-zLN7uredNxuhVj76vmU1tfvEN0Xq2INYoWeJ3d9fZtkBgKl7Enfkgz858DLAfZuJzDycOzuZXR5r29zXMDstT5F5\",e:\"AQAB\",kid:\"PHPOP-00\"}]}") },
            { "multi", new RestResponse(System.Net.HttpStatusCode.OK, "{keys:[{kty:\"RSA\",alg:\"RS256\",use:\"sig\",kid:\"e27d33093814b052594840219c8f4b0070ee5a3a\",n:\"vNSQ2tMH7T20JgWCUMhQb2ofkE5oG0TFqXb-eOa3ap-BdujTeKUgS-ZZj7Apw_X3Bvf-yTkY_cFuH3paqUkKHy0BNQCo_Y4qPVa8u_57n2bFntHAz0Qi4YeXGxVTwgFa7X0gLFbhWjZBPmlj44vWUsFujqfARiWJRN-dUhKPaxcc7hUBnzRIs2Ll3tYZ2nYw9DT_l1qC9-b2zikWyZ_5bqv7l5Njq2Naf5GZug2m2OgH5lrnaxNU5eQhvMyajeld36GGAzn5a76Rr1fB3F-NaurzUDuw7mgmRjZU6aCjx-OqUwHsgnS3IY5a0EEuI6Hzc6T-GCmUBqUy85kko8595Q\",e:\"AQAB\"},{kty:\"RSA\",alg:\"RS256\",use:\"sig\",kid:\"136510045208f4b17448036e7da1bce8cd8ef856\",n:\"sbi3CNplTFmPN5HslnSKGW80piY0tZW9FQf1T_l4f2-JEKLJWfqzROQ-oSR7LMK-atIZ4dbl3xRH09F4ceAGJ5n6wWBUIDUuWqzgz9GH2vpy609oYT_kyQ9rmjk4n4nCA-NQ7-pk-sN9vx5xhuSOTuU-RBwexTHYKMTMsHNAOmUxfupv5EnnEL99mNybbZlbIUORZ6J1ue7_apoqhcW-4LcF_rq-oDEANc_t3MzbmBoBXxtCSzcOKftH3YwY6F86gh3mlyar5wSQdIAfTUl7v2MaYJaDQnlbpADvqYSPULvnxv-JfsKupkMcl6_5nd7WS6rw3TYN4G6DfU1iB8e6GQ\",e:\"AQAB\"},{kty:\"RSA\",alg:\"RS256\",use:\"sig\",kid:\"6192a6b061685321732c4ba10c010969ae2f55bc\",n:\"sTlBZpLI8NxRVHsDMRNMuiUONPpthV-wQ6iPH5GgjICtZZL9qha4JVy1e7gILOWLRp4madr8qKbi5ii0rEaNSC1KGY8xQjcsqoO_WNpT_quWdSZ6Qk4HLS05uO0fD00QVNj_ZOrYdfOPciMcnWP5lZVihKq_itFe6Rz79v9ibxljaPLe74eLaker55sUwXrbSVqWkM_QM2dzdPVvnSE4-iH5j69tMUaf6NeRwCAFUmy8GyuO-1fJDpzMELVB3MonJ_3Ny6FSMYykPMEEHWKBV6Wdb86nSefTWhQfAMNtm4nvkn-F77HPKJHKNHCUjYpotR0C4by5Sjy8vbDDW5Wo6w\",e:\"AQAB\"},{kty:\"RSA\",alg:\"RS256\",use:\"sig\",kid:\"d0ec514a32b6f88c0abd12a2840699bdd3deba9d\",n:\"yecH_BNaZW3vuU2jepfqUVeXrGzRKQo6CvAI4lqOFdfYjXtj7VAg64Q7-VtCO-VDovnXsQ2f_ytts3B3UI9j8v8nNDlrNSL7vwekgu-FNfsCDV8ktmNivES9ounsL1xbg5u6Amvyp4p8fQ_QJmp0GHaUy4m2BsU9dp-kpoO7ByKqbpbjHHiSvxyST5JZk1_PV9lzsmpm5pyXw28w-l6lVrdG9in82Kao4LciOspOMserCBguag0abrSE19vE5n_36ZStqUqR-IdOsGTq3BehJP7OmX21BcqSpRep4uo5Y61qZvFBcOXLyk0YGZ4x7ksvzFHzjpl6pi_Awv3-VWfC-w\",e:\"AQAB\"}]}") },
        };

        private MockRestClient _restClient;
        private IJWKeysetService _jwksService;

        [SetUp]
        public void Setup()
        {
            _restClient = new MockRestClient();
            _jwksService = new JWKeysetService(_restClient, new ConcurrentCache());
        }

        [Test]
        public async Task RetrieveJWKSAsyncReturnsJWKS()
        {
            _restClient.NextExpectedResponse = _responses["single"];

            var actual = await _jwksService.RetrieveJWKSAsync("http://jwks.com/jwks");

            Assert.AreEqual(1, actual.Keys.Count);
            var key = actual.Keys.First();
            Assert.AreEqual("RSA", key.KeyType);
            Assert.AreEqual("sig", key.Use);
            Assert.AreEqual("ALyIC8vj1tqEIvAvpDMQfgosw13LpBS9Z2lsMmuaLDNJjN_FKIb-HVR2qtMj7AYC0-wYJhGxJpTXJTVRRDz-zLN7uredNxuhVj76vmU1tfvEN0Xq2INYoWeJ3d9fZtkBgKl7Enfkgz858DLAfZuJzDycOzuZXR5r29zXMDstT5F5", key.RSAN);
            Assert.AreEqual("AQAB", key.RSAE);
            Assert.AreEqual("PHPOP-00", key.KeyID);
        }

        [Test]
        public async Task RetrieveJWKSAsyncUsesCache()
        {
            var jwksUrl = "http://jwks.com/jwks";
            _restClient.NextExpectedResponse = _responses["single"];

            var initial = await _jwksService.RetrieveJWKSAsync(jwksUrl);
            var cached = await _jwksService.RetrieveJWKSAsync(jwksUrl);

            Assert.IsTrue(cached.Cached);
            Assert.AreEqual(1, cached.Keys.Count);
            var key = cached.Keys.First();
            Assert.AreEqual("RSA", key.KeyType);
            Assert.AreEqual("sig", key.Use);
            Assert.AreEqual("ALyIC8vj1tqEIvAvpDMQfgosw13LpBS9Z2lsMmuaLDNJjN_FKIb-HVR2qtMj7AYC0-wYJhGxJpTXJTVRRDz-zLN7uredNxuhVj76vmU1tfvEN0Xq2INYoWeJ3d9fZtkBgKl7Enfkgz858DLAfZuJzDycOzuZXR5r29zXMDstT5F5", key.RSAN);
            Assert.AreEqual("AQAB", key.RSAE);
            Assert.AreEqual("PHPOP-00", key.KeyID);
        }
    }
}
