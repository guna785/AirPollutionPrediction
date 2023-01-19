using AirPollutionPrediction.Application.Features.AirPollution.Commands.AddEdit;
using AirPollutionPrediction.Application.Features.AirPollution.Queries.GetPaged;
using AirPollutionPrediction.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPollutionPrediction.Application.Mappers
{
    public class AirPollutionForcastProfile : Profile
    {
        public AirPollutionForcastProfile()
        {
            _ = CreateMap<AddEditAirPollutionCommand, AirPollutionForcast>().ReverseMap();
            _ = CreateMap<GetAllPaginatedAirpollutionResponse, AirPollutionForcast>().ReverseMap();
        }
    }
}
