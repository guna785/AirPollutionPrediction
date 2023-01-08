using AirPollutionPrediction.Application.Responses.Audit;
using AirPollutionPrediction.Shared.Wrapper;

namespace AirPollutionPrediction.Application.Interfaces.Services
{
    public interface IAuditService
    {
        Task<IResult<IEnumerable<AuditResponse>>> GetCurrentUserTrailsAsync(string userId);

        Task<IResult<string>> ExportToExcelAsync(string userId, string searchString = "", bool searchInOldValues = false, bool searchInNewValues = false);
    }
}
