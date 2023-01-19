using AirPollutionPrediction.Application.Features.AirPollution.Queries.GetPaged;
using AirPollutionPrediction.Application.Requests.Features;
using AirPollutionPrediction.Shared.Wrapper;

namespace AirPollutionPrediction.MAUI.Managers.Dashboard
{
    public interface IAirPollutionManager : IManager
    {
        Task<PaginatedResult<GetAllPaginatedAirpollutionResponse>> GetDataAsync(GetAirPollutionPagedRequest request);
    }
}
