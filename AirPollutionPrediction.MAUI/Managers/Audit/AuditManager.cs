using AirPollutionPrediction.Application.Responses.Audit;
using AirPollutionPrediction.Shared.Wrapper;
using AirPollutionPrediction.UI.Infrastructure.Extensions;
using AirPollutionPrediction.UI.Infrastructure.Routes;

namespace AirPollutionPrediction.MAUI.Managers.Audit
{
    public class AuditManager : IAuditManager
    {
        private readonly HttpClient _httpClient;

        public AuditManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IResult<IEnumerable<AuditResponse>>> GetCurrentUserTrailsAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(AuditEndpoints.GetCurrentUserTrails);
            IResult<IEnumerable<AuditResponse>> data = await response.ToResult<IEnumerable<AuditResponse>>();
            return data;
        }

        public async Task<IResult<string>> DownloadFileAsync(string searchString = "", bool searchInOldValues = false, bool searchInNewValues = false)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.IsNullOrWhiteSpace(searchString)
                ? AuditEndpoints.DownloadFile
                : AuditEndpoints.DownloadFileFiltered(searchString, searchInOldValues, searchInNewValues));
            return await response.ToResult<string>();
        }
    }
}
