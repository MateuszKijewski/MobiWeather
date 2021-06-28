namespace MobiWeather.Models.Responses
{
    public class CurrentWeatherResponse
    {
        public string Main { get; set; }
        public string Description { get; set; }
        public string IconCode { get; set; }
        public double Temp { get; set; }
    }
}
