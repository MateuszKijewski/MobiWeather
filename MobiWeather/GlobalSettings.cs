namespace MobiWeather
{
    public class GlobalSettings
    {

        private readonly string _defaultAuthEndpoint = @"https://192.168.8.122:44373/api/user";
        public readonly string _defaultWeatherEndpoint = "";
        
        public static GlobalSettings Instance { get; } = new GlobalSettings();

        public string DefaultAuthEndpoint { get { return _defaultAuthEndpoint; } }
        public string DefaultWeatherEndpoint { get { return _defaultWeatherEndpoint; } }
    }
}
