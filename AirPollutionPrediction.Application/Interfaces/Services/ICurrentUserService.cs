

using AirPollutionPrediction.Application.Interfaces.Common;

namespace AirPollutionPrediction.Application.Interfaces.Services
{
    public interface ICurrentUserService : IService
    {
        int UserId { get; }
        string UserName { get; }
        string IpAddress { get; }
    }
}
