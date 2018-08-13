using GSMA.MobileConnect.Authentication;
using GSMA.MobileConnect.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace GSMA.MobileConnect.Test.Authentication
{
    [TestFixture]
    public class JWKeyTests
    {
        private Dictionary<string, string> _jwks = new Dictionary<string, string>
        {
            ["RS256"] = "{\"alg\":\"RS256\",\"e\":\"AQAB\",\"n\":\"hzr2li5ABVbbQ4BvdDskl6hejaVw0tIDYO-C0GBr5lRA-AXtmCO7bh0CEC9-R6mqctkzUhVnU22Vrj-B1J0JtJoaya9VTC3DdhzI_-7kxtIc5vrHq-ss5wo8-tK7UqtKLSRf9DcyZA0H9FEABbO5Qfvh-cfK4EI_ytA5UBZgO322RVYgQ9Do0D_-jf90dcuUgoxz_JTAOpVNc0u_m9LxGnGL3GhMbxLaX3eUublD40aK0nS2k37dOYOpQHxuAS8BZxLvS6900qqaZ6z0kwZ2WFq-hhk3Imd6fweS724fzqVslY7rHpM5n7z5m7s1ArurU1dBC1Dxw1Hzn6ZeJkEaZQ\",\"kty\":\"RSA\",\"use\":\"sig\"}",
            ["RS384"] = "{\"alg\":\"RS384\",\"e\":\"AQAB\",\"n\":\"iJd5RMMkgCp3gYwvA4b91xgmpgJT69mzPSyHUqr4Lbmjb4V31kgH9k1GRY3MyfQ6NahWg1g5NZ1XPC2rrmyfnceKPtcfgKE9ty_2HAvxG2m_n-kI_cVAuDsVDwEtYUa4ST1Hke9lcq9jaO_BuvofUv_fhuMbFLWg_xqzYA6C2xM-fiB9By-Op2BWLjNtwwsll0WD-Hfl3cysV3P2QT0S7ReV9im_H5fozm8XYVadoWWJfK_wlzxBH_NehUCivtYE2Jk5qwY50saN86VHU0xZDZkQnuVg7N8rwDpXggPvn6h0kSmSA51OvEwvLlILnem8RWoAohzHP1G5Lq8Fyudf1w\",\"kty\":\"RSA\",\"use\":\"sig\"}",
            ["RS512"] = "{\"alg\":\"RS512\",\"e\":\"AQAB\",\"n\":\"0tf1hCqBuMP0modKMscg52Iy4HpvCFwjHAdWcpOCZxNrjYiI6G3B_dex-unH9EF8u0ysBXEONbnzG4WzTaRTkHWmL_V4OzasU-hyK-Ad6v4MpzVBYBXKt2qhq7-ePsA6LLtAKXlntcNdxbaTDttMN0RaoEzm7Qy9wX1Wzm_6kUl4HCox5UosfHAm7FfFvzXmuQYb2K5C6-t7pQ0XYLZn9bFjBY_ka86VQHkGyXGf8AtU-XNI-b-dmghZK4k6Muw84pI1WCZC1tGWFdwwoL68TsEBknJ1lqZD4xW7_COQ2Qw_HIh8aau8GfENJurzY2cb9ek62PmcfOyqFcMWzngk_Q\",\"kty\":\"RSA\",\"use\":\"sig\"}",
            ["HS256"] = "{\"alg\":\"HS256\",\"kty\":\"oct\",\"use\":\"sig\",\"k\":\"E5JqlByqY5vGQmeczEigRRr43fr-m7KdJMkN3eSDHOiv3UYYhRTr6OIirFHaYDdUgA4iq3WQ3lkHd3r-KV_iWlDzpha0dmaGaHvzYMThO5WKUBlsekGHT17V7tnnYq7aameaAUmVOZocKQ5svXrPNQJcFhDs-XO6Kcsin2zaYL6eCdLZF8w_YUYtGfxYD0SqB5mdmmE5jIam3f1dnodkoLmfGxUeSSAgCCJXHQtM-SwPpyZfGbYrhTAkcahPmrJOiQwZ7WPtFlMYR-T8U12STNaTDv63hjPW57cwLfjeTW8NEYO00KCWZD7HZo-8Tg4j93FG6b78VE7QUB-vjopQlw\"}",
            ["HS384"] = "{\"alg\":\"HS384\",\"kty\":\"oct\",\"use\":\"sig\",\"k\":\"aCKgpCh56_p2OALRuqYoDrZAz-bF0A8iKyMUXwPRGYvUL7SkWBM7pJgdk1BQTUtG8fxb1CCz-Z71ed760jXz13orRdL-9gMF-MKRoNAsZvR2QPMg3AQVbrdrHxx-7TLaSOVEIkTuB5pAIlIx17LJYkX4vscCpKAa7i-B-KDwn41dG8o8LrmoBR9DW0jwsjZDjJm2A2yjR9z7UKrGF2dNd4kT1uDGRi8PnKDJpFY-ndZLLbeoFuscr1ksBG92_sXoprOctl_7rQca7qX77Mv8wxpVcnEMf0VhyjLR1x5NymAoKqBz4Kzhg3hfuWcOEm6SzZObiILSGJYJBaEifOG23A\"}",
            ["HS512"] = "{\"alg\":\"HS512\",\"kty\":\"oct\",\"use\":\"sig\",\"k\":\"Ff_UQMcORR6Cr6WxG9NcBTppR2KTU4wtQwCWz-DSDI4kQx-1Et3e-heLKNgmoqUIyqg85guq1JokpwvJVvKkcTQ5ag2V-0rMfeoi6vwKQ-7ZhhaAokLt9Bmyl7KPXfhxdJWQWIaDFgRs_2JWXVXhkFkETAGPZ-4jR1QHhTddS_0sf_6YS0c3wnBSVzhzMG6hu89oxvAGFZCdzwCPASwLlPaxv-reMfBuOmvXqMYM7t_LsRNSWsh6t6YBvPs0SMCpc-zS0E-sN0b4P7mvpRQYdVvG1EOWQeeqNURHND0sUw1kvYPmC5mpHZcRhHyvZLFpulDRNVM-nVouvftm5CfLaw\"}",
        };

        private Dictionary<string, string> _tokens = new Dictionary<string, string>
        {
            ["RS256"] = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJhenAiOiJNekZsWmpreFpHSXRPV1UyTlMwMFpURm1MVGt3TXpjdE5UUXpOamRrTURCa016Y3pPbTl3WlhKaGRHOXlMV0U9IiwiYXV0aF90aW1lIjoxNDcwMzI2ODIwLCJhdWQiOlsiTXpGbFpqa3haR0l0T1dVMk5TMDBaVEZtTFRrd016Y3ROVFF6Tmpka01EQmtNemN6T205d1pYSmhkRzl5TFdFPSJdLCJhbXIiOlsiU0lNX1BJTiJdLCJub25jZSI6ImFkNjVmOGUwNzA3MTRlYTU5Yzc2NDRlZjE1OGM1MjM3IiwiaWF0IjoxNDcwMzI2ODIwLCJpc3MiOiJpbnRlZ3JhdGlvbjIuc2FuZGJveC5tb2JpbGVjb25uZWN0LmlvIiwiYWNyIjoiMiIsImV4cCI6MTQ3MDMzMDQyMCwic3ViIjoiYzIzMjQ2N2MtNDliMi0xMWU2LTlhYTgtMDI0MmFjMTEwMDAzIn0.QOdjTBG5xzX9ROIYmEyJ5ozamcd1O8R6Zna0GpO14n2lFu2oG2FP7HWws3VvgDqMkgwhyt-l7wFs-SDxYWsXj6a3wCGOHQSkOwdFWx5QZwHf4abOCVbcD0HMcFRWAAhBU8K0k9gBlNOdblArEusXWUtNOb3zA9kE5X8aX8v3anh_utrxaKYSvndjHIe7d50XybsOip4QOsqMEUbeBdos4hqSc_KW9qQvZcqBoZs3J7n-n8nPX5TcXu7OZd62pT48GvpL1Y1O6xvBA-gvLEpba3KffucBkgSXtLYsfw8n109A335z9TWIM_9D6OrRkWQrYBLm3B6GfcGOUDJIISegTA",
            ["RS384"] = "eyJhbGciOiJSUzM4NCIsInR5cCI6IkpXVCJ9.eyJhenAiOiJNekZsWmpreFpHSXRPV1UyTlMwMFpURm1MVGt3TXpjdE5UUXpOamRrTURCa016Y3pPbTl3WlhKaGRHOXlMV0U9IiwiYXV0aF90aW1lIjoxNDcwMzI2ODIwLCJhdWQiOlsiTXpGbFpqa3haR0l0T1dVMk5TMDBaVEZtTFRrd016Y3ROVFF6Tmpka01EQmtNemN6T205d1pYSmhkRzl5TFdFPSJdLCJhbXIiOlsiU0lNX1BJTiJdLCJub25jZSI6ImFkNjVmOGUwNzA3MTRlYTU5Yzc2NDRlZjE1OGM1MjM3IiwiaWF0IjoxNDcwMzI2ODIwLCJpc3MiOiJpbnRlZ3JhdGlvbjIuc2FuZGJveC5tb2JpbGVjb25uZWN0LmlvIiwiYWNyIjoiMiIsImV4cCI6MTQ3MDMzMDQyMCwic3ViIjoiYzIzMjQ2N2MtNDliMi0xMWU2LTlhYTgtMDI0MmFjMTEwMDAzIn0.E7Y7YiMO_LtQqu0nQmAs-fiIY-eaQ3HaX1PpD8mKBunTUKK3bDxAB8MB5Ku7jHmCQuamb5i0R9lyUJyX_IDx2FZFJJQluG1SN06DLK_H1Bzs7I-Ud5GwGwvHDQXCflx2Z1cEaP-9sBzuecbE8wLWRIITgCEP2qTJwuF9mic6mwNOBmavdSQb1g_pnbhH4Omnyzg5YCbJBhfmGNzybJS3CQtxP4oBYjTCG9RwrfnoKWwHyj3vf6f2pKR5G7urNBcfm2xNLJnV2nA9tKEdjeNNhQd9iZ7WsgP3k7f1Je4KO4Va-NQ5r5ml6xhw4cRech_cQciOP-iveBaZaRQk_YO8pA",
            ["RS512"] = "eyJhbGciOiJSUzUxMiIsInR5cCI6IkpXVCJ9.eyJhenAiOiJNekZsWmpreFpHSXRPV1UyTlMwMFpURm1MVGt3TXpjdE5UUXpOamRrTURCa016Y3pPbTl3WlhKaGRHOXlMV0U9IiwiYXV0aF90aW1lIjoxNDcwMzI2ODIwLCJhdWQiOlsiTXpGbFpqa3haR0l0T1dVMk5TMDBaVEZtTFRrd016Y3ROVFF6Tmpka01EQmtNemN6T205d1pYSmhkRzl5TFdFPSJdLCJhbXIiOlsiU0lNX1BJTiJdLCJub25jZSI6ImFkNjVmOGUwNzA3MTRlYTU5Yzc2NDRlZjE1OGM1MjM3IiwiaWF0IjoxNDcwMzI2ODIwLCJpc3MiOiJpbnRlZ3JhdGlvbjIuc2FuZGJveC5tb2JpbGVjb25uZWN0LmlvIiwiYWNyIjoiMiIsImV4cCI6MTQ3MDMzMDQyMCwic3ViIjoiYzIzMjQ2N2MtNDliMi0xMWU2LTlhYTgtMDI0MmFjMTEwMDAzIn0.R6j5oXrBZ1zEENEuGno6SBQ9lq8Tp3xB4g3XcdKVPgzQG0nW-UQe9cll2mfOAACifPM8VM_Y0K9_eYmeNOWqLCxDcFoQfD7wic-Npa77-XiDFjrviXYWNSC3yTwbPuIf2wvmAIG31HOL4nnPmMnpX4iqlS8_B40IVzPtrYAiDtivPVc9ULsCimpDiNXmjdERZ6Jc6JqT-bjTCvb53zF7jVPTad2-rrYbns7XrdupVMnf41xrRv2NDkkXVmHX9kuNA4yHpgAuyPRHstLEkmafbGh0BCrDLH-WV2VteiXx8TVHHC0D3gtX5RkfQObBEKecy-4kMBKQ6oaEIyQeJ9W70A",
            ["HS256"] = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJhenAiOiJNekZsWmpreFpHSXRPV1UyTlMwMFpURm1MVGt3TXpjdE5UUXpOamRrTURCa016Y3pPbTl3WlhKaGRHOXlMV0U9IiwiYXV0aF90aW1lIjoxNDcwMzI2ODIwLCJhdWQiOlsiTXpGbFpqa3haR0l0T1dVMk5TMDBaVEZtTFRrd016Y3ROVFF6Tmpka01EQmtNemN6T205d1pYSmhkRzl5TFdFPSJdLCJhbXIiOlsiU0lNX1BJTiJdLCJub25jZSI6ImFkNjVmOGUwNzA3MTRlYTU5Yzc2NDRlZjE1OGM1MjM3IiwiaWF0IjoxNDcwMzI2ODIwLCJpc3MiOiJpbnRlZ3JhdGlvbjIuc2FuZGJveC5tb2JpbGVjb25uZWN0LmlvIiwiYWNyIjoiMiIsImV4cCI6MTQ3MDMzMDQyMCwic3ViIjoiYzIzMjQ2N2MtNDliMi0xMWU2LTlhYTgtMDI0MmFjMTEwMDAzIn0.iTLUvv-HCYBkDzeVX0tRc5k3URY8kbjqvY1EgyXUE2s",
            ["HS384"] = "eyJhbGciOiJIUzM4NCIsInR5cCI6IkpXVCJ9.eyJhenAiOiJNekZsWmpreFpHSXRPV1UyTlMwMFpURm1MVGt3TXpjdE5UUXpOamRrTURCa016Y3pPbTl3WlhKaGRHOXlMV0U9IiwiYXV0aF90aW1lIjoxNDcwMzI2ODIwLCJhdWQiOlsiTXpGbFpqa3haR0l0T1dVMk5TMDBaVEZtTFRrd016Y3ROVFF6Tmpka01EQmtNemN6T205d1pYSmhkRzl5TFdFPSJdLCJhbXIiOlsiU0lNX1BJTiJdLCJub25jZSI6ImFkNjVmOGUwNzA3MTRlYTU5Yzc2NDRlZjE1OGM1MjM3IiwiaWF0IjoxNDcwMzI2ODIwLCJpc3MiOiJpbnRlZ3JhdGlvbjIuc2FuZGJveC5tb2JpbGVjb25uZWN0LmlvIiwiYWNyIjoiMiIsImV4cCI6MTQ3MDMzMDQyMCwic3ViIjoiYzIzMjQ2N2MtNDliMi0xMWU2LTlhYTgtMDI0MmFjMTEwMDAzIn0.SigQhR9M3ugzjQMu8ZxJJnVCU_FSV5TWIAPN50SHO0Xz4Sf4GFV2zJ8c1bV_2Ene",
            ["HS512"] = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJhenAiOiJNekZsWmpreFpHSXRPV1UyTlMwMFpURm1MVGt3TXpjdE5UUXpOamRrTURCa016Y3pPbTl3WlhKaGRHOXlMV0U9IiwiYXV0aF90aW1lIjoxNDcwMzI2ODIwLCJhdWQiOlsiTXpGbFpqa3haR0l0T1dVMk5TMDBaVEZtTFRrd016Y3ROVFF6Tmpka01EQmtNemN6T205d1pYSmhkRzl5TFdFPSJdLCJhbXIiOlsiU0lNX1BJTiJdLCJub25jZSI6ImFkNjVmOGUwNzA3MTRlYTU5Yzc2NDRlZjE1OGM1MjM3IiwiaWF0IjoxNDcwMzI2ODIwLCJpc3MiOiJpbnRlZ3JhdGlvbjIuc2FuZGJveC5tb2JpbGVjb25uZWN0LmlvIiwiYWNyIjoiMiIsImV4cCI6MTQ3MDMzMDQyMCwic3ViIjoiYzIzMjQ2N2MtNDliMi0xMWU2LTlhYTgtMDI0MmFjMTEwMDAzIn0.cH1AEuw-eVYzlcuXBh5_DnpdyzKQzs2vcLc8j4f-0n222wX6Q84hZjMTpHuIg5YPvnliNzqTdLTebIFZ_3Bz9A",
        };

        [TestCase("RS256")]
        [TestCase("RS384")]
        [TestCase("RS512")]
        [TestCase("HS256")]
        [TestCase("HS384")]
        [TestCase("HS512")]
        public void VerifyShouldVerifyUsing(string alg)
        {
            var key = GetKey(alg);
            var toSign = GetDataToSign(alg);
            var expected = GetSignature(alg);

            Assert.IsTrue(key.Verify(toSign, expected, alg));
        }

        [TestCase("RS256")]
        [TestCase("RS384")]
        [TestCase("RS512")]
        [TestCase("HS256")]
        [TestCase("HS384")]
        [TestCase("HS512")]
        public void VerifyShouldReturnFalseIfHeaderModified(string alg)
        {
            var key = GetKey(alg);
            var toSign = GetDataToSign(alg, true, false);
            var expected = GetSignature(alg);

            Assert.IsFalse(key.Verify(toSign, expected, alg));
        }

        [TestCase("RS256")]
        [TestCase("RS384")]
        [TestCase("RS512")]
        [TestCase("HS256")]
        [TestCase("HS384")]
        [TestCase("HS512")]
        public void VerifyShouldReturnFalseIfPayloadModified(string alg)
        {
            var key = GetKey(alg);
            var toSign = GetDataToSign(alg, false, true);
            var expected = GetSignature(alg);

            Assert.IsFalse(key.Verify(toSign, expected, alg));
        }

        [TestCase("RS256")]
        [TestCase("RS384")]
        [TestCase("RS512")]
        [TestCase("HS256")]
        [TestCase("HS384")]
        [TestCase("HS512")]
        public void VerifyShouldReturnFalseIfHeaderAndPayloadModified(string alg)
        {
            var key = GetKey(alg);
            var toSign = GetDataToSign(alg, true, true);
            var expected = GetSignature(alg);

            Assert.IsFalse(key.Verify(toSign, expected, alg));
        }

        private JWKey GetKey(string alg)
        {
            return JsonConvert.DeserializeObject<JWKey>(_jwks[alg]);
        }

        private string GetDataToSign(string alg, bool modifyHeader = false, bool modifyPayload = false)
        {
            var token = _tokens[alg];
            var index = token.LastIndexOf('.');

            if (!modifyPayload && !modifyHeader)
            {
                return token.Substring(0, index);
            }

            var header = JObject.Parse(JsonWebToken.DecodePart(token, JWTPart.Header));
            if(modifyHeader)
            {
                header["alg"] = "ES256";
            }

            var payload = JObject.Parse(JsonWebToken.DecodePart(token, JWTPart.Claims));
            if (modifyPayload)
            {
                payload["nonce"] = "test-nonce";
            }

            return $"{StringUtils.EncodeAsBase64Url(header.ToString())}.{StringUtils.EncodeAsBase64Url(payload.ToString())}";
        }

        private string GetSignature(string alg)
        {
            var token = _tokens[alg];
            var index = token.LastIndexOf('.');
            return token.Substring(index + 1);
        }
    }
}
