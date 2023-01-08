using AirPollutionPrediction.Application.Interfaces.Common;
using AirPollutionPrediction.Application.Requests.Identity;
using AirPollutionPrediction.Application.Responses.Identity;
using AirPollutionPrediction.Shared.Wrapper;

namespace AirPollutionPrediction.Application.Interfaces.Services.Identity
{
    public interface IRoleClaimService : IService
    {
        Task<Result<List<RoleClaimResponse>>> GetAllAsync();

        Task<int> GetCountAsync();

        Task<Result<RoleClaimResponse>> GetByIdAsync(int id);

        Task<Result<List<RoleClaimResponse>>> GetAllByRoleIdAsync(int roleId);

        Task<Result<string>> SaveAsync(RoleClaimRequest request);

        Task<Result<string>> DeleteAsync(int id);
    }
}
