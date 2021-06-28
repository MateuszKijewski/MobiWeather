namespace MobiWeather.Common
{
    public interface ISettingsService
    {
        string UserName { get; set; }

        string AccessToken { get; set; }
    }
}
