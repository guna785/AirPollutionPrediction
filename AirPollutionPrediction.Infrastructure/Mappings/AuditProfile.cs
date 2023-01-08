using AirPollutionPrediction.Infrastructure.Models.Audit;
using AutoMapper;
using AirPollutionPrediction.Application.Responses.Audit;

namespace AirPollutionPrediction.Infrastructure.Mappings
{
    public class AuditProfile : Profile
    {
        public AuditProfile()
        {
            _ = CreateMap<AuditResponse, Audit>().ReverseMap();
        }
    }
}
