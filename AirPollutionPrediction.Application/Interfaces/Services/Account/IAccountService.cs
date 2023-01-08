using AirPollutionPrediction.Application.Interfaces.Common;
using AirPollutionPrediction.Application.Requests.Identity;
using AirPollutionPrediction.Shared.Wrapper;

namespace AirPollutionPrediction.Application.Interfaces.Services.Account
{
    public interface IAccountService : IService
    {
        Task<IResult> UpdateProfileAsync(UpdateProfileRequest model, int userId);

        Task<IResult> ChangePasswordAsync(ChangePasswordRequest model, int userId);

        Task<IResult<string>> GetProfilePictureAsync(int userId);

        Task<IResult<string>> UpdateProfilePictureAsync(UpdateProfilePictureRequest request, int userId);
    }
}
