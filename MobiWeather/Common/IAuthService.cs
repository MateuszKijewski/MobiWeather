using MobiWeather.Models.Contracts;
using MobiWeather.Models.Responses;
using System.Threading.Tasks;

namespace MobiWeather.Common
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginContract loginContract);

        Task<string> Register(RegisterContract registerContract);
    }
}
