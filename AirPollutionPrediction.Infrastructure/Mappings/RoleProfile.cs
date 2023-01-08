using AirPollutionPrediction.Infrastructure.Models.Identity;
using AutoMapper;
using AirPollutionPrediction.Application.Responses.Identity;

namespace AirPollutionPrediction.Infrastructure.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            _ = CreateMap<RoleResponse, ApplicationRole>().ReverseMap();
        }
    }
}
