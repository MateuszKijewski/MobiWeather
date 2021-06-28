using System.Collections.Generic;

namespace MobiWeather.Models.Responses
{
    public class RegisterResponse
    {
        public string Result { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
