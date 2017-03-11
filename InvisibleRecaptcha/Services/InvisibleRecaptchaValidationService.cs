using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Net;

namespace InvisibleRecaptcha.Services
{
    public class InvisibleRecaptchaValidationService : ICaptchaValidationService
    {
        private const string API_URL = "https://www.google.com/recaptcha/api/siteverify";
        private readonly string _secretKey;

        public InvisibleRecaptchaValidationService(string secretKey)
        {
            _secretKey = secretKey;
        }

        public bool Validate(string response)
        {
            if (!string.IsNullOrWhiteSpace(response))
            {
                using (var client = new WebClient())
                {
                    var result = client.DownloadString($"{API_URL}?secret={_secretKey}&response={response}");
                    return ParseValidationResult(result);
                }
            }

            return false;
        }

        private bool ParseValidationResult(string validationResult) => (bool)JObject.Parse(validationResult).SelectToken("success");
    }
}