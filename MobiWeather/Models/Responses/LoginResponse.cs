using System;

namespace MobiWeather.Models.Responses
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
