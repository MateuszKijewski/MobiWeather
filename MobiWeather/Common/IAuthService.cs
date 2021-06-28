using MobiWeather.Models.Contracts;
using System.Threading.Tasks;

namespace MobiWeather.Common
{
    public interface IAuthService
    {
        Task Login(LoginContract loginContract);

        Task<string> Register(RegisterContract registerContract);
    }
}
