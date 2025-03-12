using AirPollutionPrediction.Application.Extensions;
using AirPollutionPrediction.Application.Interfaces.Repositories;
using AirPollutionPrediction.Application.Specifications.Features;
using AirPollutionPrediction.Domain.Entities;
using AirPollutionPrediction.Shared.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AirPollutionPrediction.Application.Features.AirPollution.Queries.GetPaged
{
    public class GetAllPaginatedAirpollutionQuery : IRequest<PaginatedResult<GetAllPaginatedAirpollutionResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public string[] OrderBy { get; set; } // of the form fieldname [ascending|descending],fieldname [ascending|descending]...

        public GetAllPaginatedAirpollutionQuery(int pageNumber, int pageSize, string searchString, string orderBy)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            SearchString = searchString;
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                OrderBy = orderBy.Split(',');
            }
        }
    }

    internal class GetAllPaginatedAirpollutionsCachedQueryHandler : IRequestHandler<GetAllPaginatedAirpollutionQuery, PaginatedResult<GetAllPaginatedAirpollutionResponse>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;

        public GetAllPaginatedAirpollutionsCachedQueryHandler(IUnitOfWork<int> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginatedResult<GetAllPaginatedAirpollutionResponse>> Handle(GetAllPaginatedAirpollutionQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<AirPollutionForcast, GetAllPaginatedAirpollutionResponse>> expression = e => new GetAllPaginatedAirpollutionResponse
            {
                Id = e.Id,
                CO = e.CO,
                CreatedOn = e.CreatedOn ?? DateTime.Now,
                Horizon = e.Horizon,
                NO2 = e.NO2,
                SO2 = e.SO2,
            };
            //AirPollutionForcastFilterSpecification AirPollutionForcastFilterSpec = new(request.SearchString);
            if (request.OrderBy?.Any() != true)
            {
                PaginatedResult<GetAllPaginatedAirpollutionResponse> data = await _unitOfWork.Repository<AirPollutionForcast>().Entities
                   //.Specify(AirPollutionForcastFilterSpec)
                   .Select(expression)
                   .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                return data;
            }
            else
            {
                string ordering = string.Join(",", request.OrderBy); // of the form fieldname [ascending|descending], ...
                PaginatedResult<GetAllPaginatedAirpollutionResponse> data = await _unitOfWork.Repository<AirPollutionForcast>().Entities
                   //.Specify(AirPollutionForcastFilterSpec)
                   .OrderBy(ordering) // require system.linq.dynamic.core
                   .Select(expression)
                   .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                return data;

            }
        }

    }
}
