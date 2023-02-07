//using Microsoft.Extensions.Options;
//using _211787P_Practical_Assn.Model;
//using Newtonsoft.Json;
//using _211787P_Practical_Assn.ViewModels;
//using Microsoft.EntityFrameworkCore;

//namespace _211787P_Practical_Assn.Services
//{
//    public class RegistrationService : IRegistration
//    {
//        private readonly IConfiguration config;

//        public RegistrationService(IConfiguration _config)
//        {
//            config = _config;
//        }

//        public async Task<RegistrationResponse> Registration(Registration request)
//        {
//            try
//            {
//                string RecaptchaSecretKey = config.GetValue<string>("RecaptchaSettings:RecaptchaSecretKey"); // to get the secret key form appsetttings.json file

//                var dictionary = new Dictionary<string, string>
//                    {
//                        { "secret", RecaptchaSecretKey },
//                        { "response", request.ReCaptchaToken }
//                    };

//                var postContent = new FormUrlEncodedContent(dictionary);

//                HttpResponseMessage httpRecaptchaResponse = null;

//                string stringContent = "";

//                // Calling  the recaptcha api and validating the token

//                using (var http = new HttpClient())
//                {
//                    httpRecaptchaResponse = await http.PostAsync("https://www.google.com/recaptcha/api/siteverify", postContent);
//                    stringContent = await httpRecaptchaResponse.Content.ReadAsStringAsync();
//                }

//                if (!httpRecaptchaResponse.IsSuccessStatusCode)
//                {
//                    return new RegistrationResponse() { Success = false, Error = "Unable to verify google recaptcha token" };
//                }
                
//                if (string.IsNullOrEmpty(stringContent))
//                {
//                    return new RegistrationResponse() { Success = false, Error = "Invalid google reCAPTCHA verification response" };
//                }

//                var reCaptchaResponse = JsonConvert.DeserializeObject<ReCaptchaResponse>(stringContent);

//                if (!reCaptchaResponse.Success)
//                {
//                    var errors = string.Join(",", reCaptchaResponse.ErrorCodes);
                    
//                    return new RegistrationResponse() { Success = false, Error = errors };
//                }

//                // Captcha was successful,now verify the score

//                if (reCaptchaResponse.Score < 0.5)
//                {
//                    return new RegistrationResponse() { Success = false, Error = "It might be a boat. registration request rejected" };
//                }

//                return new RegistrationResponse() { Success = true };
//            }

//            catch (Exception ex)
//            {
//                return new RegistrationResponse() { Success = false, Error = "Unable to verify google recaptcha token" };
//            }
//        }
//    }
//}
