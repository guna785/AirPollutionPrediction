using AirPollutionPrediction.Application.Enums;

namespace AirPollutionPrediction.Application.Requests
{
    public class UploadRequest
    {
        public string? FileName { get; set; } = null;
        public string Extension { get; set; }
        public UploadType UploadType { get; set; }
        public byte[] Data { get; set; }
    }
}
