using AirPollutionPrediction.Application.Responses.Audit;
using AirPollutionPrediction.Shared.Wrapper;

namespace AirPollutionPrediction.Client.Managers.Audit
{
    public interface IAuditManager : IManager
    {
        Task<IResult<IEnumerable<AuditResponse>>> GetCurrentUserTrailsAsync();

        Task<IResult<string>> DownloadFileAsync(string searchString = "", bool searchInOldValues = false, bool searchInNewValues = false);
    }
}
