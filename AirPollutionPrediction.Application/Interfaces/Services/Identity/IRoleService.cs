using AirPollutionPrediction.Application.Interfaces.Common;
using AirPollutionPrediction.Application.Requests.Identity;
using AirPollutionPrediction.Application.Responses.Identity;
using AirPollutionPrediction.Shared.Wrapper;

namespace AirPollutionPrediction.Application.Interfaces.Services.Identity
{
    public interface IRoleService : IService
    {
        Task<Result<List<RoleResponse>>> GetAllAsync();

        Task<int> GetCountAsync();

        Task<Result<RoleResponse>> GetByIdAsync(int id);

        Task<Result<string>> SaveAsync(RoleRequest request);

        Task<Result<string>> DeleteAsync(int id);

        Task<Result<PermissionResponse>> GetAllPermissionsAsync(int roleId);

        Task<Result<string>> UpdatePermissionsAsync(PermissionRequest request);
    }
}
