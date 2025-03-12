using AirPollutionPrediction.Application.Features.AirPollution.Queries.GetPaged;
using AirPollutionPrediction.Application.Requests.Features;
using AirPollutionPrediction.Shared.Wrapper;
using AirPollutionPrediction.UI.Infrastructure.Extensions;
using AirPollutionPrediction.UI.Infrastructure.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPollutionPrediction.Client.Managers.Dashboard
{
    public class AirPollutionManager : IAirPollutionManager
    {
        private readonly HttpClient _httpClient;

        public AirPollutionManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<PaginatedResult<GetAllPaginatedAirpollutionResponse>> GetDataAsync(GetAirPollutionPagedRequest request)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(AirPollutionEndpoints.GetAllPaged(request.PageNumber, request.PageSize, request.SearchString, request.Orderby));
            return await response.ToPaginatedResult<GetAllPaginatedAirpollutionResponse>();
        }
    }
}
