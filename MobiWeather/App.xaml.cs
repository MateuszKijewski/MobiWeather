using MobiWeather.Common;
using MobiWeather.Services;
using MobiWeather.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobiWeather
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.RegisterSingleton<ISettingsService>(new SettingsService());
            DependencyService.Register<IAuthService, AuthService>();
            DependencyService.Register<IWeatherService, WeatherService>();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
