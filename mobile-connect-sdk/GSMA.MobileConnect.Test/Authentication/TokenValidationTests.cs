using GSMA.MobileConnect.Authentication;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GSMA.MobileConnect.Test.Authentication
{
    public class TokenValidationTests
    {
        private string nonce = "1234567890";
        private string clientId = "x-clientid-x";
        private string issuer = "http://mobileconnect.io";
        private int? maxAge = 36000;

        [Test]
        public void ValidateIdTokenShouldValidateWhenAllValid()
        {
            var jwksJson = "{\"keys\":[{\"alg\":\"RS256\",\"e\":\"AQAB\",\"n\":\"hzr2li5ABVbbQ4BvdDskl6hejaVw0tIDYO-C0GBr5lRA-AXtmCO7bh0CEC9-R6mqctkzUhVnU22Vrj-B1J0JtJoaya9VTC3DdhzI_-7kxtIc5vrHq-ss5wo8-tK7UqtKLSRf9DcyZA0H9FEABbO5Qfvh-cfK4EI_ytA5UBZgO322RVYgQ9Do0D_-jf90dcuUgoxz_JTAOpVNc0u_m9LxGnGL3GhMbxLaX3eUublD40aK0nS2k37dOYOpQHxuAS8BZxLvS6900qqaZ6z0kwZ2WFq-hhk3Imd6fweS724fzqVslY7rHpM5n7z5m7s1ArurU1dBC1Dxw1Hzn6ZeJkEaZQ\",\"kty\":\"RSA\",\"use\":\"sig\"}]}";
            var idToken = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJub25jZSI6IjEyMzQ1Njc4OTAiLCJhdWQiOiJ4LWNsaWVudGlkLXgiLCJhenAiOiJ4LWNsaWVudGlkLXgiLCJpc3MiOiJodHRwOi8vbW9iaWxlY29ubmVjdC5pbyIsImV4cCI6MjE0NzQ4MzY0NywiYXV0aF90aW1lIjoyMTQ3NDgzNjQ3LCJpYXQiOjE0NzEwMDczMjd9.U9c5iuybG4GIvrbQH5BT9AgllRbPL6SuIzL4Y3MW7VlCVIQOc_HFfkiLa0LNvqZiP-kFlADmnkzuuQxPq7IyaOILVYct20mrcOb_U_zMli4jg-t9P3BxHaq3ds9JlLBjz0oewd01ZQtWHgRnrGymfKAIojzHlde-aePuL1M26Eld5zoKQvCLcKAynZsjKsWF_6YdLk-uhlC5ofMOaOoPirPSPAxYvbj91z3o9XIgSHoU-umN7AJ6UQ4H-ulfftlRGK8hz0Yzpf2MHOy9OHg1u3ayfCaaf8g5zKGngcz0LgK9VAw2B31xJw-RHkPPh0Hz82FgBc4588oEFC1c22GGTw";
            var jwks = JsonConvert.DeserializeObject<JWKeyset>(jwksJson);

            TokenValidationResult actual = TokenValidation.ValidateIdToken(idToken, clientId, issuer, nonce, maxAge, jwks);

            Assert.AreEqual(TokenValidationResult.Valid, actual);
        }

        [Test]
        public void ValidateIdTokenShouldNotValidateWhenNoIdToken()
        {
            var jwksJson = "{\"keys\":[{\"alg\":\"RS256\",\"e\":\"AQAB\",\"n\":\"hzr2li5ABVbbQ4BvdDskl6hejaVw0tIDYO-C0GBr5lRA-AXtmCO7bh0CEC9-R6mqctkzUhVnU22Vrj-B1J0JtJoaya9VTC3DdhzI_-7kxtIc5vrHq-ss5wo8-tK7UqtKLSRf9DcyZA0H9FEABbO5Qfvh-cfK4EI_ytA5UBZgO322RVYgQ9Do0D_-jf90dcuUgoxz_JTAOpVNc0u_m9LxGnGL3GhMbxLaX3eUublD40aK0nS2k37dOYOpQHxuAS8BZxLvS6900qqaZ6z0kwZ2WFq-hhk3Imd6fweS724fzqVslY7rHpM5n7z5m7s1ArurU1dBC1Dxw1Hzn6ZeJkEaZQ\",\"kty\":\"RSA\",\"use\":\"sig\"}]}";
            var idToken = "";
            var jwks = JsonConvert.DeserializeObject<JWKeyset>(jwksJson);

            TokenValidationResult actual = TokenValidation.ValidateIdToken(idToken, clientId, issuer, nonce, maxAge, jwks);

            Assert.AreEqual(TokenValidationResult.IdTokenMissing, actual);
        }

        [Test]
        public void ValidateIdTokenShouldNotValidateWhenClaimInvalid()
        {
            var jwksJson = "{\"keys\":[{\"alg\":\"RS256\",\"e\":\"AQAB\",\"n\":\"hzr2li5ABVbbQ4BvdDskl6hejaVw0tIDYO-C0GBr5lRA-AXtmCO7bh0CEC9-R6mqctkzUhVnU22Vrj-B1J0JtJoaya9VTC3DdhzI_-7kxtIc5vrHq-ss5wo8-tK7UqtKLSRf9DcyZA0H9FEABbO5Qfvh-cfK4EI_ytA5UBZgO322RVYgQ9Do0D_-jf90dcuUgoxz_JTAOpVNc0u_m9LxGnGL3GhMbxLaX3eUublD40aK0nS2k37dOYOpQHxuAS8BZxLvS6900qqaZ6z0kwZ2WFq-hhk3Imd6fweS724fzqVslY7rHpM5n7z5m7s1ArurU1dBC1Dxw1Hzn6ZeJkEaZQ\",\"kty\":\"RSA\",\"use\":\"sig\"}]}";
            var idToken = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJub25jZSI6IjEyMzQ1Njc4OTAiLCJhdWQiOiJ4LWNsaWVudGlkLXkiLCJhenAiOiJ4LWNsaWVudGlkLXkiLCJpc3MiOiJodHRwOi8vbW9iaWxlY29ubmVjdC5pbyIsImV4cCI6MjE0NzQ4MzY0NywiYXV0aF90aW1lIjoyMTQ3NDgzNjQ3LCJpYXQiOjE0NzEwMDc2NzR9.byu8aDef11sJPpPD9WM_j5uv92CsQEJLJ23SVCwrmf-btdyViTe5q1Q0X1hjVzv6FcCQLlrdJj1ib4sky6It1kVEEDk_E7w8KHH1CmmApghWh2lozJRlg8LQTQXgvfnUPeSLsoGBDYWI502aUhyy9V_zm9M0F3Vi0GWmDVZeXIvUlqdGd1YdzO0cmEfc9nyQSchimVmc-0etCGJn8qehvCZa_x96_u-qJeUiOb_7NypECoVDv8UzAZ48P5Dq-iDCYP6jCmOjdZ36b4JO6co1OnYp4cGONqZTQadVDewAfskKtGkspm6XUdil0WDct1DMuPnDuH1eweQtYopxtHRsjw";
            var jwks = JsonConvert.DeserializeObject<JWKeyset>(jwksJson);

            TokenValidationResult actual = TokenValidation.ValidateIdToken(idToken, clientId, issuer, nonce, maxAge, jwks);

            Assert.AreEqual(TokenValidationResult.InvalidAudAndAzp, actual);
        }

        [Test]
        public void ValidateIdTokenSignatureShouldValidateUsingMatchingAlgKey()
        {
            var jwksJson = "{\"keys\":[{\"alg\":\"RS256\",\"e\":\"AQAB\",\"n\":\"hzr2li5ABVbbQ4BvdDskl6hejaVw0tIDYO-C0GBr5lRA-AXtmCO7bh0CEC9-R6mqctkzUhVnU22Vrj-B1J0JtJoaya9VTC3DdhzI_-7kxtIc5vrHq-ss5wo8-tK7UqtKLSRf9DcyZA0H9FEABbO5Qfvh-cfK4EI_ytA5UBZgO322RVYgQ9Do0D_-jf90dcuUgoxz_JTAOpVNc0u_m9LxGnGL3GhMbxLaX3eUublD40aK0nS2k37dOYOpQHxuAS8BZxLvS6900qqaZ6z0kwZ2WFq-hhk3Imd6fweS724fzqVslY7rHpM5n7z5m7s1ArurU1dBC1Dxw1Hzn6ZeJkEaZQ\",\"kty\":\"RSA\",\"use\":\"sig\"}]}";
            var token = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJhenAiOiJNekZsWmpreFpHSXRPV1UyTlMwMFpURm1MVGt3TXpjdE5UUXpOamRrTURCa016Y3pPbTl3WlhKaGRHOXlMV0U9IiwiYXV0aF90aW1lIjoxNDcwMzI2ODIwLCJhdWQiOlsiTXpGbFpqa3haR0l0T1dVMk5TMDBaVEZtTFRrd016Y3ROVFF6Tmpka01EQmtNemN6T205d1pYSmhkRzl5TFdFPSJdLCJhbXIiOlsiU0lNX1BJTiJdLCJub25jZSI6ImFkNjVmOGUwNzA3MTRlYTU5Yzc2NDRlZjE1OGM1MjM3IiwiaWF0IjoxNDcwMzI2ODIwLCJpc3MiOiJpbnRlZ3JhdGlvbjIuc2FuZGJveC5tb2JpbGVjb25uZWN0LmlvIiwiYWNyIjoiMiIsImV4cCI6MTQ3MDMzMDQyMCwic3ViIjoiYzIzMjQ2N2MtNDliMi0xMWU2LTlhYTgtMDI0MmFjMTEwMDAzIn0.QOdjTBG5xzX9ROIYmEyJ5ozamcd1O8R6Zna0GpO14n2lFu2oG2FP7HWws3VvgDqMkgwhyt-l7wFs-SDxYWsXj6a3wCGOHQSkOwdFWx5QZwHf4abOCVbcD0HMcFRWAAhBU8K0k9gBlNOdblArEusXWUtNOb3zA9kE5X8aX8v3anh_utrxaKYSvndjHIe7d50XybsOip4QOsqMEUbeBdos4hqSc_KW9qQvZcqBoZs3J7n-n8nPX5TcXu7OZd62pT48GvpL1Y1O6xvBA-gvLEpba3KffucBkgSXtLYsfw8n109A335z9TWIM_9D6OrRkWQrYBLm3B6GfcGOUDJIISegTA";
            var jwks = JsonConvert.DeserializeObject<JWKeyset>(jwksJson);

            TokenValidationResult actual = TokenValidation.ValidateIdTokenSignature(token, jwks);

            Assert.AreEqual(TokenValidationResult.Valid, actual);
        }

        [Test]
        public void ValidateIdTokenSignatureShouldValidateUsingMatchingKeyIdKey()
        {
            var jwksJson = "{\"keys\":[{\"alg\":\"RS256\",\"e\":\"AQAB\",\"n\":\"hzr2li5ABVbbQ4BvdDskl6hejaVw0tIDYO-C0GBr5lRA-AXtmCO7bh0CEC9-R6mqctkzUhVnU22Vrj-B1J0JtJoaya9VTC3DdhzI_-7kxtIc5vrHq-ss5wo8-tK7UqtKLSRf9DcyZA0H9FEABbO5Qfvh-cfK4EI_ytA5UBZgO322RVYgQ9Do0D_-jf90dcuUgoxz_JTAOpVNc0u_m9LxGnGL3GhMbxLaX3eUublD40aK0nS2k37dOYOpQHxuAS8BZxLvS6900qqaZ6z0kwZ2WFq-hhk3Imd6fweS724fzqVslY7rHpM5n7z5m7s1ArurU1dBC1Dxw1Hzn6ZeJkEaZQ\",\"kty\":\"RSA\",\"use\":\"sig\",\"kid\":\"test\",},{\"e\":\"AQAB\",\"n\":\"sj_E_-OM6We6kM3Zl8LFQCbp4J1GA_RArvFo8Y0jLXR1xK20nJ0UIhCR1u4a3WD9dSwDRmcDa-3nT_1g5mzMOjBBO1I0VFDG61LyTkrbHhaz-VtRKjMcZMaVPHGC-nRogg92984s-ahO-Q4hkE05tiO96u3xj4S8_A3bsMIQCLQRYKS9_ovl_HxEJne3NFRkSZiiTym5g0H_nOrl2RlBYfV7GPst8Vzq45Mn1uDtCHocSeM3zunLG8TNOz0t6U_s0hAd0gKukoxgaGc1JDSsRWNs8r9SPniRMclKkcMWpdZQbLdT9ARsEB7i6w4x4C1p9i75PloXhwE-EOZ9kCeOtw\",\"kty\":\"RSA\",\"kid\":\"nottest\"}]}";
            var token = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6InRlc3QifQ.eyJhenAiOiJNekZsWmpreFpHSXRPV1UyTlMwMFpURm1MVGt3TXpjdE5UUXpOamRrTURCa016Y3pPbTl3WlhKaGRHOXlMV0U9IiwiYXV0aF90aW1lIjoxNDcwMzI2ODIwLCJhdWQiOlsiTXpGbFpqa3haR0l0T1dVMk5TMDBaVEZtTFRrd016Y3ROVFF6Tmpka01EQmtNemN6T205d1pYSmhkRzl5TFdFPSJdLCJhbXIiOlsiU0lNX1BJTiJdLCJub25jZSI6ImFkNjVmOGUwNzA3MTRlYTU5Yzc2NDRlZjE1OGM1MjM3IiwiaWF0IjoxNDcwMzI2ODIwLCJpc3MiOiJpbnRlZ3JhdGlvbjIuc2FuZGJveC5tb2JpbGVjb25uZWN0LmlvIiwiYWNyIjoiMiIsImV4cCI6MTQ3MDMzMDQyMCwic3ViIjoiYzIzMjQ2N2MtNDliMi0xMWU2LTlhYTgtMDI0MmFjMTEwMDAzIn0.PKN_cBANpXLegnmu6My4yhqcdbZaRVRLlseQJ4y1gMyFzLfRfYFHhbQC4xrIaN6ryxIsgJvFZ-047WfMwyptIhcP87exuYt6253k9gddndmjJtLuT9d5DB9bjiKkK49IdVsu91xyT1bXBHiWnZ-alFgnC4NfsCN3ec9TAynlivhzlBwghfdc6T8V27ewHWKg1ds0ZZbLQYZ0PtuLd0PW_SEOAnajVICBN7xm0rgxf9CTgOs5mBnKVCgPu1sJ-6bdcfA2VpLGLleuDHb9J9t6kbMytEMUjs4eDjdgxlogIUBOvY4MWfuu4l85GPZPMJ29aGmvAbns9e5Pufm8nO9DEA";
            var jwks = JsonConvert.DeserializeObject<JWKeyset>(jwksJson);

            TokenValidationResult actual = TokenValidation.ValidateIdTokenSignature(token, jwks);

            Assert.AreEqual(TokenValidationResult.Valid, actual);
        }

        [Test]
        public void ValidateIdTokenSignatureShouldNotValidateWhenKeysetNull()
        {
            var token = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6InRlc3QifQ.eyJhenAiOiJNekZsWmpreFpHSXRPV1UyTlMwMFpURm1MVGt3TXpjdE5UUXpOamRrTURCa016Y3pPbTl3WlhKaGRHOXlMV0U9IiwiYXV0aF90aW1lIjoxNDcwMzI2ODIwLCJhdWQiOlsiTXpGbFpqa3haR0l0T1dVMk5TMDBaVEZtTFRrd016Y3ROVFF6Tmpka01EQmtNemN6T205d1pYSmhkRzl5TFdFPSJdLCJhbXIiOlsiU0lNX1BJTiJdLCJub25jZSI6ImFkNjVmOGUwNzA3MTRlYTU5Yzc2NDRlZjE1OGM1MjM3IiwiaWF0IjoxNDcwMzI2ODIwLCJpc3MiOiJpbnRlZ3JhdGlvbjIuc2FuZGJveC5tb2JpbGVjb25uZWN0LmlvIiwiYWNyIjoiMiIsImV4cCI6MTQ3MDMzMDQyMCwic3ViIjoiYzIzMjQ2N2MtNDliMi0xMWU2LTlhYTgtMDI0MmFjMTEwMDAzIn0.PKN_cBANpXLegnmu6My4yhqcdbZaRVRLlseQJ4y1gMyFzLfRfYFHhbQC4xrIaN6ryxIsgJvFZ-047WfMwyptIhcP87exuYt6253k9gddndmjJtLuT9d5DB9bjiKkK49IdVsu91xyT1bXBHiWnZ-alFgnC4NfsCN3ec9TAynlivhzlBwghfdc6T8V27ewHWKg1ds0ZZbLQYZ0PtuLd0PW_SEOAnajVICBN7xm0rgxf9CTgOs5mBnKVCgPu1sJ-6bdcfA2VpLGLleuDHb9J9t6kbMytEMUjs4eDjdgxlogIUBOvY4MWfuu4l85GPZPMJ29aGmvAbns9e5Pufm8nO9DEA";

            TokenValidationResult actual = TokenValidation.ValidateIdTokenSignature(token, null);

            Assert.AreEqual(TokenValidationResult.JWKSError, actual);
        }

        //[Test]
        //public void ValidateIdTokenSignatureShouldNotValidateWhenAlgNotRS256()
        //{
        //    var jwksJson = "{\"keys\":[{\"alg\":\"HS256\",\"kty\":\"oct\",\"use\":\"sig\",\"secret\":\"E5JqlByqY5vGQmeczEigRRr43fr-m7KdJMkN3eSDHOiv3UYYhRTr6OIirFHaYDdUgA4iq3WQ3lkHd3r-KV_iWlDzpha0dmaGaHvzYMThO5WKUBlsekGHT17V7tnnYq7aameaAUmVOZocKQ5svXrPNQJcFhDs-XO6Kcsin2zaYL6eCdLZF8w_YUYtGfxYD0SqB5mdmmE5jIam3f1dnodkoLmfGxUeSSAgCCJXHQtM-SwPpyZfGbYrhTAkcahPmrJOiQwZ7WPtFlMYR-T8U12STNaTDv63hjPW57cwLfjeTW8NEYO00KCWZD7HZo-8Tg4j93FG6b78VE7QUB-vjopQlw\"}]}";
        //    var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJhenAiOiJNekZsWmpreFpHSXRPV1UyTlMwMFpURm1MVGt3TXpjdE5UUXpOamRrTURCa016Y3pPbTl3WlhKaGRHOXlMV0U9IiwiYXV0aF90aW1lIjoxNDcwMzI2ODIwLCJhdWQiOlsiTXpGbFpqa3haR0l0T1dVMk5TMDBaVEZtTFRrd016Y3ROVFF6Tmpka01EQmtNemN6T205d1pYSmhkRzl5TFdFPSJdLCJhbXIiOlsiU0lNX1BJTiJdLCJub25jZSI6ImFkNjVmOGUwNzA3MTRlYTU5Yzc2NDRlZjE1OGM1MjM3IiwiaWF0IjoxNDcwMzI2ODIwLCJpc3MiOiJpbnRlZ3JhdGlvbjIuc2FuZGJveC5tb2JpbGVjb25uZWN0LmlvIiwiYWNyIjoiMiIsImV4cCI6MTQ3MDMzMDQyMCwic3ViIjoiYzIzMjQ2N2MtNDliMi0xMWU2LTlhYTgtMDI0MmFjMTEwMDAzIn0.iTLUvv-HCYBkDzeVX0tRc5k3URY8kbjqvY1EgyXUE2s";
        //    var jwks = JsonConvert.DeserializeObject<JWKeyset>(jwksJson);

        //    TokenValidationResult actual = TokenValidation.ValidateIdTokenSignature(token, jwks);

        //    Assert.AreEqual(TokenValidationResult.IncorrectAlgorithm, actual);
        //}

        [Test]
        public void ValidateIdTokenSignatureShouldNotValidateWhenNoMatchingKey()
        {
            var jwksJson = "{\"keys\":[{\"alg\":\"RS256\",\"e\":\"AQAB\",\"n\":\"hzr2li5ABVbbQ4BvdDskl6hejaVw0tIDYO-C0GBr5lRA-AXtmCO7bh0CEC9-R6mqctkzUhVnU22Vrj-B1J0JtJoaya9VTC3DdhzI_-7kxtIc5vrHq-ss5wo8-tK7UqtKLSRf9DcyZA0H9FEABbO5Qfvh-cfK4EI_ytA5UBZgO322RVYgQ9Do0D_-jf90dcuUgoxz_JTAOpVNc0u_m9LxGnGL3GhMbxLaX3eUublD40aK0nS2k37dOYOpQHxuAS8BZxLvS6900qqaZ6z0kwZ2WFq-hhk3Imd6fweS724fzqVslY7rHpM5n7z5m7s1ArurU1dBC1Dxw1Hzn6ZeJkEaZQ\",\"kty\":\"RSA\",\"use\":\"sig\",\"kid\":\"test1\",},{\"e\":\"AQAB\",\"n\":\"sj_E_-OM6We6kM3Zl8LFQCbp4J1GA_RArvFo8Y0jLXR1xK20nJ0UIhCR1u4a3WD9dSwDRmcDa-3nT_1g5mzMOjBBO1I0VFDG61LyTkrbHhaz-VtRKjMcZMaVPHGC-nRogg92984s-ahO-Q4hkE05tiO96u3xj4S8_A3bsMIQCLQRYKS9_ovl_HxEJne3NFRkSZiiTym5g0H_nOrl2RlBYfV7GPst8Vzq45Mn1uDtCHocSeM3zunLG8TNOz0t6U_s0hAd0gKukoxgaGc1JDSsRWNs8r9SPniRMclKkcMWpdZQbLdT9ARsEB7i6w4x4C1p9i75PloXhwE-EOZ9kCeOtw\",\"kty\":\"RSA\",\"kid\":\"nottest\"}]}";
            var token = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6InRlc3QifQ.eyJhenAiOiJNekZsWmpreFpHSXRPV1UyTlMwMFpURm1MVGt3TXpjdE5UUXpOamRrTURCa016Y3pPbTl3WlhKaGRHOXlMV0U9IiwiYXV0aF90aW1lIjoxNDcwMzI2ODIwLCJhdWQiOlsiTXpGbFpqa3haR0l0T1dVMk5TMDBaVEZtTFRrd016Y3ROVFF6Tmpka01EQmtNemN6T205d1pYSmhkRzl5TFdFPSJdLCJhbXIiOlsiU0lNX1BJTiJdLCJub25jZSI6ImFkNjVmOGUwNzA3MTRlYTU5Yzc2NDRlZjE1OGM1MjM3IiwiaWF0IjoxNDcwMzI2ODIwLCJpc3MiOiJpbnRlZ3JhdGlvbjIuc2FuZGJveC5tb2JpbGVjb25uZWN0LmlvIiwiYWNyIjoiMiIsImV4cCI6MTQ3MDMzMDQyMCwic3ViIjoiYzIzMjQ2N2MtNDliMi0xMWU2LTlhYTgtMDI0MmFjMTEwMDAzIn0.PKN_cBANpXLegnmu6My4yhqcdbZaRVRLlseQJ4y1gMyFzLfRfYFHhbQC4xrIaN6ryxIsgJvFZ-047WfMwyptIhcP87exuYt6253k9gddndmjJtLuT9d5DB9bjiKkK49IdVsu91xyT1bXBHiWnZ-alFgnC4NfsCN3ec9TAynlivhzlBwghfdc6T8V27ewHWKg1ds0ZZbLQYZ0PtuLd0PW_SEOAnajVICBN7xm0rgxf9CTgOs5mBnKVCgPu1sJ-6bdcfA2VpLGLleuDHb9J9t6kbMytEMUjs4eDjdgxlogIUBOvY4MWfuu4l85GPZPMJ29aGmvAbns9e5Pufm8nO9DEA";
            var jwks = JsonConvert.DeserializeObject<JWKeyset>(jwksJson);

            TokenValidationResult actual = TokenValidation.ValidateIdTokenSignature(token, jwks);

            Assert.AreEqual(TokenValidationResult.NoMatchingKey, actual);
        }

        [Test]
        public void ValidateIdTokenSignatureShouldNotValidateWhenSignatureMissing()
        {
            var jwksJson = "{\"keys\":[{\"alg\":\"RS256\",\"e\":\"AQAB\",\"n\":\"hzr2li5ABVbbQ4BvdDskl6hejaVw0tIDYO-C0GBr5lRA-AXtmCO7bh0CEC9-R6mqctkzUhVnU22Vrj-B1J0JtJoaya9VTC3DdhzI_-7kxtIc5vrHq-ss5wo8-tK7UqtKLSRf9DcyZA0H9FEABbO5Qfvh-cfK4EI_ytA5UBZgO322RVYgQ9Do0D_-jf90dcuUgoxz_JTAOpVNc0u_m9LxGnGL3GhMbxLaX3eUublD40aK0nS2k37dOYOpQHxuAS8BZxLvS6900qqaZ6z0kwZ2WFq-hhk3Imd6fweS724fzqVslY7rHpM5n7z5m7s1ArurU1dBC1Dxw1Hzn6ZeJkEaZQ\",\"kty\":\"RSA\",\"use\":\"sig\"}]}";
            var token = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJhenAiOiJNekZsWmpreFpHSXRPV1UyTlMwMFpURm1MVGt3TXpjdE5UUXpOamRrTURCa016Y3pPbTl3WlhKaGRHOXlMV0U9IiwiYXV0aF90aW1lIjoxNDcwMzI2ODIwLCJhdWQiOlsiTXpGbFpqa3haR0l0T1dVMk5TMDBaVEZtTFRrd016Y3ROVFF6Tmpka01EQmtNemN6T205d1pYSmhkRzl5TFdFPSJdLCJhbXIiOlsiU0lNX1BJTiJdLCJub25jZSI6ImFkNjVmOGUwNzA3MTRlYTU5Yzc2NDRlZjE1OGM1MjM3IiwiaWF0IjoxNDcwMzI2ODIwLCJpc3MiOiJpbnRlZ3JhdGlvbjIuc2FuZGJveC5tb2JpbGVjb25uZWN0LmlvIiwiYWNyIjoiMiIsImV4cCI6MTQ3MDMzMDQyMCwic3ViIjoiYzIzMjQ2N2MtNDliMi0xMWU2LTlhYTgtMDI0MmFjMTEwMDAzIn0.";
            var jwks = JsonConvert.DeserializeObject<JWKeyset>(jwksJson);

            TokenValidationResult actual = TokenValidation.ValidateIdTokenSignature(token, jwks);

            Assert.AreEqual(TokenValidationResult.InvalidSignature, actual);
        }

        [Test]
        public void ValidateIdTokenSignatureNotValidateWhenMisformedRSKey()
        {
            var jwksJson = "{\"keys\":[{\"alg\":\"RS256\",\"e\":\"AQAB\",\"mod\":\"hzr2li5ABVbbQ4BvdDskl6hejaVw0tIDYO-C0GBr5lRA-AXtmCO7bh0CEC9-R6mqctkzUhVnU22Vrj-B1J0JtJoaya9VTC3DdhzI_-7kxtIc5vrHq-ss5wo8-tK7UqtKLSRf9DcyZA0H9FEABbO5Qfvh-cfK4EI_ytA5UBZgO322RVYgQ9Do0D_-jf90dcuUgoxz_JTAOpVNc0u_m9LxGnGL3GhMbxLaX3eUublD40aK0nS2k37dOYOpQHxuAS8BZxLvS6900qqaZ6z0kwZ2WFq-hhk3Imd6fweS724fzqVslY7rHpM5n7z5m7s1ArurU1dBC1Dxw1Hzn6ZeJkEaZQ\",\"kty\":\"RSA\",\"use\":\"sig\"}]}";
            var token = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJhenAiOiJNekZsWmpreFpHSXRPV1UyTlMwMFpURm1MVGt3TXpjdE5UUXpOamRrTURCa016Y3pPbTl3WlhKaGRHOXlMV0U9IiwiYXV0aF90aW1lIjoxNDcwMzI2ODIwLCJhdWQiOlsiTXpGbFpqa3haR0l0T1dVMk5TMDBaVEZtTFRrd016Y3ROVFF6Tmpka01EQmtNemN6T205d1pYSmhkRzl5TFdFPSJdLCJhbXIiOlsiU0lNX1BJTiJdLCJub25jZSI6ImFkNjVmOGUwNzA3MTRlYTU5Yzc2NDRlZjE1OGM1MjM3IiwiaWF0IjoxNDcwMzI2ODIwLCJpc3MiOiJpbnRlZ3JhdGlvbjIuc2FuZGJveC5tb2JpbGVjb25uZWN0LmlvIiwiYWNyIjoiMiIsImV4cCI6MTQ3MDMzMDQyMCwic3ViIjoiYzIzMjQ2N2MtNDliMi0xMWU2LTlhYTgtMDI0MmFjMTEwMDAzIn0.QOdjTBG5xzX9ROIYmEyJ5ozamcd1O8R6Zna0GpO14n2lFu2oG2FP7HWws3VvgDqMkgwhyt-l7wFs-SDxYWsXj6a3wCGOHQSkOwdFWx5QZwHf4abOCVbcD0HMcFRWAAhBU8K0k9gBlNOdblArEusXWUtNOb3zA9kE5X8aX8v3anh_utrxaKYSvndjHIe7d50XybsOip4QOsqMEUbeBdos4hqSc_KW9qQvZcqBoZs3J7n-n8nPX5TcXu7OZd62pT48GvpL1Y1O6xvBA-gvLEpba3KffucBkgSXtLYsfw8n109A335z9TWIM_9D6OrRkWQrYBLm3B6GfcGOUDJIISegTA";
            var jwks = JsonConvert.DeserializeObject<JWKeyset>(jwksJson);

            TokenValidationResult actual = TokenValidation.ValidateIdTokenSignature(token, jwks);

            Assert.AreEqual(TokenValidationResult.KeyMisformed, actual);
        }

        [Test]
        public void ValidateIdTokenClaimsShouldReturnValidWhenAllClaimsValidWithAudArray()
        {
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJub25jZSI6IjEyMzQ1Njc4OTAiLCJhdWQiOlsieC1jbGllbnRpZC14Il0sImF6cCI6IngtY2xpZW50aWQteCIsImlzcyI6Imh0dHA6Ly9tb2JpbGVjb25uZWN0LmlvIiwiZXhwIjoyMTQ3NDgzNjQ3LCJhdXRoX3RpbWUiOjIxNDc0ODM2NDd9.sPMj1GIchXKcVTXXRDb5tJeUFds7JkuREYYIuoBvpCM";

            var result = TokenValidation.ValidateIdTokenClaims(token, clientId, issuer, nonce, maxAge);

            Assert.AreEqual(TokenValidationResult.Valid, result);
        }

        [Test]
        public void ValidateIdTokenClaimsShouldReturnValidWhenAllClaimsValidWithAudString()
        {
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJub25jZSI6IjEyMzQ1Njc4OTAiLCJhdWQiOiJ4LWNsaWVudGlkLXgiLCJhenAiOiJ4LWNsaWVudGlkLXgiLCJpc3MiOiJodHRwOi8vbW9iaWxlY29ubmVjdC5pbyIsImV4cCI6MjE0NzQ4MzY0NywiYXV0aF90aW1lIjoyMTQ3NDgzNjQ3fQ.8M6GM8GlMxSH_T8mYiQXZyEx0h6h4OYm0QN0H07ixwI";

            var result = TokenValidation.ValidateIdTokenClaims(token, clientId, issuer, nonce, maxAge);

            Assert.AreEqual(TokenValidationResult.Valid, result);
        }

        [Test]
        public void ValidateIdTokenClaimsShouldReturnInvalidNonceWhenNonceNotMatching()
        {
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJub25jZSI6IjEyMzQ1Njc4OTAiLCJhdWQiOiJ4LWNsaWVudGlkLXgiLCJhenAiOiJ4LWNsaWVudGlkLXgiLCJpc3MiOiJodHRwOi8vbW9iaWxlY29ubmVjdC5pbyIsImV4cCI6MjE0NzQ4MzY0NywiYXV0aF90aW1lIjoyMTQ3NDgzNjQ3fQ.8M6GM8GlMxSH_T8mYiQXZyEx0h6h4OYm0QN0H07ixwI";

            var result = TokenValidation.ValidateIdTokenClaims(token, clientId, issuer, "notnonce", maxAge);

            Assert.AreEqual(TokenValidationResult.InvalidNonce, result);
        }

        [Test]
        public void ValidateIdTokenClaimsShouldReturnInvalidAudWhenClientIdNotMatching()
        {
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJub25jZSI6IjEyMzQ1Njc4OTAiLCJhdWQiOiJ4LWNsaWVudGlkLXgiLCJhenAiOiJ4LWNsaWVudGlkLXgiLCJpc3MiOiJodHRwOi8vbW9iaWxlY29ubmVjdC5pbyIsImV4cCI6MjE0NzQ4MzY0NywiYXV0aF90aW1lIjoyMTQ3NDgzNjQ3fQ.8M6GM8GlMxSH_T8mYiQXZyEx0h6h4OYm0QN0H07ixwI";

            var result = TokenValidation.ValidateIdTokenClaims(token, "notclientid", issuer, nonce, maxAge);

            Assert.AreEqual(TokenValidationResult.InvalidAudAndAzp, result);
        }

        [Test]
        public void ValidateIdTokenClaimsShouldReturnInvalidAudWhenClientIdNotInAudArray()
        {
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJub25jZSI6IjEyMzQ1Njc4OTAiLCJhdWQiOlsibm90Y2xpZW50aWQiXSwiYXpwIjoieC1jbGllbnRpZC14IiwiaXNzIjoiaHR0cDovL21vYmlsZWNvbm5lY3QuaW8iLCJleHAiOjIxNDc0ODM2NDcsImF1dGhfdGltZSI6MjE0NzQ4MzY0N30.Is8A9klSQZYEs0MAScdyq_EqcpCy6r_56yzizktclNQ";

            var result = TokenValidation.ValidateIdTokenClaims(token, clientId, issuer, nonce, maxAge);

            Assert.AreEqual(TokenValidationResult.InvalidAudAndAzp, result);
        }

        [Test]
        public void ValidateIdTokenClaimsShouldReturnInvalidIssuerWhenIssuerNotMatching()
        {
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJub25jZSI6IjEyMzQ1Njc4OTAiLCJhdWQiOiJ4LWNsaWVudGlkLXgiLCJhenAiOiJ4LWNsaWVudGlkLXgiLCJpc3MiOiJodHRwOi8vbW9iaWxlY29ubmVjdC5pbyIsImV4cCI6MjE0NzQ4MzY0NywiYXV0aF90aW1lIjoyMTQ3NDgzNjQ3fQ.8M6GM8GlMxSH_T8mYiQXZyEx0h6h4OYm0QN0H07ixwI";

            var result = TokenValidation.ValidateIdTokenClaims(token, clientId, "notissuer", nonce, maxAge);

            Assert.AreEqual(TokenValidationResult.InvalidIssuer, result);
        }

        [Test]
        public void ValidateIdTokenClaimsShouldReturnIdTokenExpiredWhenExpValueHasPassed()
        {
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJub25jZSI6IjEyMzQ1Njc4OTAiLCJhdWQiOiJ4LWNsaWVudGlkLXgiLCJhenAiOiJ4LWNsaWVudGlkLXgiLCJpc3MiOiJodHRwOi8vbW9iaWxlY29ubmVjdC5pbyIsImV4cCI6MTQ1MTY1MTY2MiwiYXV0aF90aW1lIjoyMTQ3NDgzNjQ3fQ.4MhPMtGMKBbzGrpT3TC4DUzR__sBsz2J6UqXdPksJLw";

            var result = TokenValidation.ValidateIdTokenClaims(token, clientId, issuer, nonce, maxAge);

            Assert.AreEqual(TokenValidationResult.IdTokenExpired, result);
        }

        [Test]
        public void ValidateIdTokenClaimsShouldReturnMaxAgePassedWhenMaxAgePassed()
        {
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJub25jZSI6IjEyMzQ1Njc4OTAiLCJhdWQiOiJ4LWNsaWVudGlkLXgiLCJhenAiOiJ4LWNsaWVudGlkLXgiLCJpc3MiOiJodHRwOi8vbW9iaWxlY29ubmVjdC5pbyIsImV4cCI6MjE0NzQ4MzY0NywiYXV0aF90aW1lIjoxNDUxNjUxNjYyfQ.novjze9SAX5QF-EKhdelob4UAhB_ZNEC-VzrcDRqXCk";

            var result = TokenValidation.ValidateIdTokenClaims(token, clientId, issuer, nonce, 2600);

            Assert.AreEqual(TokenValidationResult.MaxAgePassed, result);
        }

        [Test]
        public void ValidateAccessTokenShouldReturnValidIfExistsAndNotExpired()
        {
            var json = "{\"access_token\":\"zmxncbvlaksjdhfgeteywteuiroqp\",\"expires_in\":36000}";
            var tokenResponse = JsonConvert.DeserializeObject<RequestTokenResponseData>(json);

            var result = TokenValidation.ValidateAccessToken(tokenResponse);

            Assert.AreEqual(TokenValidationResult.Valid, result);
        }

        [Test]
        public void ValidateAccessTokenShouldReturnExpiredIfExistsAndExpired()
        {
            var json = "{\"access_token\":\"zmxncbvlaksjdhfgeteywteuiroqp\",\"time_received\":\"2016-01-01T12:34:22\",\"expires_in\":3600}";
            var tokenResponse = JsonConvert.DeserializeObject<RequestTokenResponseData>(json);

            var result = TokenValidation.ValidateAccessToken(tokenResponse);

            Assert.AreEqual(TokenValidationResult.AccessTokenExpired, result);
        }

        [Test]
        public void ValidateAccessTokenShouldReturnMissingIfNotExists()
        {
            // This test will stop working at 01/19/2038 @ 3:14am (UTC) (but so will all unix timestamps)
            var json = "{\"access_token\":\"\",\"expires_in\":2147483647}";
            var tokenResponse = JsonConvert.DeserializeObject<RequestTokenResponseData>(json);

            var result = TokenValidation.ValidateAccessToken(tokenResponse);

            Assert.AreEqual(TokenValidationResult.AccessTokenMissing, result);
        }
    }
}
