using AirPollutionPrediction.Application.Requests;

namespace AirPollutionPrediction.Application.Interfaces.Services
{
    public interface IUploadService
    {
        string UploadAsync(UploadRequest request);
    }
}
