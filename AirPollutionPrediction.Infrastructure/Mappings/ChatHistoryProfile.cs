using AirPollutionPrediction.Infrastructure.Models.Identity;
using AutoMapper;
using AirPollutionPrediction.Application.Interfaces.Chat;
using AirPollutionPrediction.Application.Models.Chat;

namespace AirPollutionPrediction.Infrastructure.Mappings
{
    public class ChatHistoryProfile : Profile
    {
        public ChatHistoryProfile()
        {
            _ = CreateMap<ChatHistory<IChatUser>, ChatHistory<ApplicationUser>>().ReverseMap();
        }
    }
}
