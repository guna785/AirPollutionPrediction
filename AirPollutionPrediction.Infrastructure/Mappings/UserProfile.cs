using AirPollutionPrediction.Infrastructure.Models.Identity;
using AutoMapper;
using AirPollutionPrediction.Application.Responses.Identity;

namespace AirPollutionPrediction.Infrastructure.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            _ = CreateMap<UserResponse, ApplicationUser>().ReverseMap();
            _ = CreateMap<ChatUserResponse, ApplicationUser>().ReverseMap()
                .ForMember(dest => dest.EmailAddress, source => source.MapFrom(source => source.Email)); //Specific Mapping
        }
    }
}
