using AutoMapper;
using AirPollutionPrediction.Application.Requests.Identity;
using AirPollutionPrediction.Application.Responses.Identity;

namespace AirPollutionPrediction.UI.Infrastructure.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            _ = CreateMap<PermissionResponse, PermissionRequest>().ReverseMap();
            _ = CreateMap<RoleClaimResponse, RoleClaimRequest>().ReverseMap();
        }
    }
}
