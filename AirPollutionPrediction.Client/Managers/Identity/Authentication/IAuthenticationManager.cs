using AirPollutionPrediction.Application.Requests.Identity;
using AirPollutionPrediction.Shared.Wrapper;
using System.Security.Claims;

namespace AirPollutionPrediction.Client.Managers.Identity.Authentication
{
    public interface IAuthenticationManager : IManager
    {
        Task<IResult> Login(TokenRequest model);

        Task<IResult> Logout();

        Task<string> RefreshToken();

        Task<string> TryRefreshToken();

        Task<string> TryForceRefreshToken();

        Task<ClaimsPrincipal> CurrentUser();
    }
}
