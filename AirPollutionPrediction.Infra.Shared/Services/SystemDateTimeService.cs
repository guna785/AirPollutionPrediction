using AirPollutionPrediction.Application.Interfaces.Services;

namespace AirPollutionPrediction.Infra.Shared.Services
{
    public class SystemDateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
