using MobiWeather.Common;
using MobiWeather.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MobiWeather.ViewModels
{
    public class CurrentWeatherViewModel : BindableObject
    {
        private readonly IWeatherService _weatherService;

        public CurrentWeatherViewModel()
        {
            _weatherService = DependencyService.Get<IWeatherService>();
            GetCurrentWeatherByCityCommand = new Command(GetCurrentWeatherByCity);
            GetCurrentWeatherByGeoCommand = new Command(GetCurrentWeatherByGeo);
        }

        private async void GetCurrentWeatherByGeo(object obj)
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
            var currentWeather = await _weatherService.GetCurrentWeather(new CurrentWeatherContract
            {
                Longitude = location.Longitude.ToString(),
                Latitude = location.Latitude.ToString()
            });

            Main = currentWeather.Main;
            Description = currentWeather.Description;
            Icon = currentWeather.IconCode;
            TempCelsius = currentWeather.Temp;
        }

        private async void GetCurrentWeatherByCity(object obj)
        {
            var currentWeather = await _weatherService.GetCurrentWeather(new CurrentWeatherContract
            {
                City = City
            });

            Main = currentWeather.Main;
            Description = currentWeather.Description;
            Icon = currentWeather.IconCode;
            TempCelsius = currentWeather.Temp;
        }

        private string _city;
        public string City
        {
            get { return _city; }
            set
            {
                if (_city != value)
                {
                    _city = value;
                }
                OnPropertyChanged();
            }
        }

        private string _main;
        public string Main
        {
            get { return _main; }
            set
            {
                if (_main != value)
                {
                    _main = value;
                }
                OnPropertyChanged();
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                }
                OnPropertyChanged();
            }
        }

        private string _icon;
        public string Icon
        {
            get
            {
                return $"http://openweathermap.org/img/w/{_icon}.png";
            }
            set
            {
                if (_icon != value)
                {
                    _icon = value;
                }
                OnPropertyChanged();
            }
        }

        private double _tempCelsius;
        public double TempCelsius
        {
            get { return _tempCelsius; }
            set
            {
                if (_tempCelsius != value)
                {
                    _tempCelsius = value - 273.15;
                }
                OnPropertyChanged();
            }
        }

        public ICommand GetCurrentWeatherByCityCommand { get; }
        public ICommand GetCurrentWeatherByGeoCommand { get; }
    }
}
