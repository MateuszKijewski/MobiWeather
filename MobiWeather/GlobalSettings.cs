namespace MobiWeather
{
    public class GlobalSettings
    {

        private readonly string _defaultAuthEndpoint = @"https://mobiweatherauthwebapi20210630160112.azurewebsites.net/api/user";
        public readonly string _defaultCurrentWeatherEndpoint = @"http://api.openweathermap.org/data/2.5/weather?";
        public readonly string _weatherApiKey = "d10c47ade1f08cf26c9899675c46c1c2";


        public static GlobalSettings Instance { get; } = new GlobalSettings();

        public string DefaultAuthEndpoint { get { return _defaultAuthEndpoint; } }
        public string DefaultCurrentWeatherEndpoint { get { return _defaultCurrentWeatherEndpoint; } }
        public string WeatherApiKey { get { return _weatherApiKey; } }
    }
}
