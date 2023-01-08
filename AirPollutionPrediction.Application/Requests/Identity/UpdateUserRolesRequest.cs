using AirPollutionPrediction.Application.Responses.Identity;

namespace AirPollutionPrediction.Application.Requests.Identity
{
    public class UpdateUserRolesRequest
    {
        public string UserId { get; set; }
        public IList<UserRoleModel> UserRoles { get; set; }
    }
}
