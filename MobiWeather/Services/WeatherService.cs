using MobiWeather.Common;
using MobiWeather.Models.Contracts;
using MobiWeather.Models.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
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
    public class WeatherService : IWeatherService
    {
        private readonly ISettingsService _settingsService;
        private readonly JsonSerializerSettings _serializerSettings;

        public WeatherService()
        {
            _settingsService = DependencyService.Get<ISettingsService>();
            _serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };
            _serializerSettings.Converters.Add(new StringEnumConverter());
        }

        public async Task<CurrentWeatherResponse> GetCurrentWeather(CurrentWeatherContract currentWeatherContract)
        {
            var client = CreateHttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(currentWeatherContract, _serializerSettings));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var uri = string.IsNullOrEmpty(currentWeatherContract.City)
                ? $"{GlobalSettings.Instance.DefaultCurrentWeatherEndpoint}lat={currentWeatherContract.Latitude}&lon={currentWeatherContract.Longitude}&appid={GlobalSettings.Instance.WeatherApiKey}"
                : $"{GlobalSettings.Instance.DefaultCurrentWeatherEndpoint}q={currentWeatherContract.City}&appid={GlobalSettings.Instance.WeatherApiKey}";

            var response = await client.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                var jsonResponse = JObject.Parse(stringResponse);

                var weather = JArray.Parse(jsonResponse["weather"].ToString())[0];

                return new CurrentWeatherResponse
                {
                    Main = weather["main"].ToString(),
                    Description = weather["description"].ToString(),
                    IconCode = weather["icon"].ToString(),
                    Temp = double.Parse(jsonResponse["main"]["temp"].ToString())
                };
            }
            throw new Exception("Unable to collect weather data");
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
