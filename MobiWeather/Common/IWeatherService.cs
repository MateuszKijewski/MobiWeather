using MobiWeather.Models.Contracts;
using MobiWeather.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobiWeather.Common
{
    public interface IWeatherService
    {
        Task<CurrentWeatherResponse> GetCurrentWeather(CurrentWeatherContract currentWeatherContract);
    }
}
