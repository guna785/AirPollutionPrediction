using AirPollutionPrediction.Application.Interfaces.Repositories;
using AirPollutionPrediction.Application.Interfaces.Services;
using AirPollutionPrediction.Application.Requests;
using AirPollutionPrediction.Domain.Entities;
using AirPollutionPrediction.Shared.Wrapper;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPollutionPrediction.Application.Features.AirPollution.Commands.AddEdit
{
    public class AddEditAirPollutionCommand : IRequest<Result<int>>
    {
        public int Id { get; set; } = 0;
        public string CO { get; set; }
        public string NO2 { get; set; }
        public string SO2 { get; set; }
        public int Horizon { get; set; }
    }
    internal class AddEditAirPollutionCommandHandler : IRequestHandler<AddEditAirPollutionCommand, Result<int>>
    {
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<AddEditAirPollutionCommandHandler> _localizer;
        private readonly IUnitOfWork<int> _unitOfWork;

        public AddEditAirPollutionCommandHandler(IUnitOfWork<int> unitOfWork, IMapper mapper, IStringLocalizer<AddEditAirPollutionCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localizer = localizer;
        }

        public async Task<Result<int>> Handle(AddEditAirPollutionCommand command, CancellationToken cancellationToken)
        {
            if (command.Id == 0)
            {
                AirPollutionForcast org = _mapper.Map<AirPollutionForcast>(command);
                _ = await _unitOfWork.Repository<AirPollutionForcast>().AddAsync(org);
                await _unitOfWork.Commit(cancellationToken);
                return await Result<int>.SuccessAsync(org.Id, _localizer["AirPollutionForcast Saved"]);
            }
            else
            {
                return await Result<int>.FailAsync(_localizer["AirPollutionForcast Not Found!"]);
            }
        }
    }
}
