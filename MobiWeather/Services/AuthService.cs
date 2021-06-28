using MobiWeather.Common;
using MobiWeather.Models.Contracts;
using MobiWeather.Models.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobiWeather.Services
{
    public class AuthService : IAuthService
    {
        private readonly ISettingsService _settingsService;
        private readonly JsonSerializerSettings _serializerSettings;

        public AuthService()
        {
            _settingsService = DependencyService.Get<ISettingsService>();
            _serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };
            _serializerSettings.Converters.Add(new StringEnumConverter());
        }

        public async Task Login(LoginContract loginContract)
        {
            var client = CreateHttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(loginContract, _serializerSettings));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync($"{GlobalSettings.Instance.DefaultAuthEndpoint}/login", content);

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync(); 
                var convertedResponse = JsonConvert.DeserializeObject<LoginResponse>(stringResponse);

                _settingsService.AccessToken = convertedResponse.Token;
                _settingsService.UserName = loginContract.Username;
            }
            throw new Exception("Login failed");
        }

        public async Task<string> Register(RegisterContract registerContract)
        {
            var client = CreateHttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(registerContract, _serializerSettings));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync($"{GlobalSettings.Instance.DefaultAuthEndpoint}/register", content);

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                var convertedResponse = JsonConvert.DeserializeObject<RegisterResponse>(stringResponse);

                return convertedResponse.Result;
            }
            throw new Exception("Registration failed");
        }

        private HttpClient CreateHttpClient()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            var httpClient = new HttpClient(clientHandler);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }
    }
}
