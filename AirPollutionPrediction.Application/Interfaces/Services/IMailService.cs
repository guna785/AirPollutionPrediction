using AirPollutionPrediction.Application.Requests.Mail;

namespace AirPollutionPrediction.Application.Interfaces.Services
{
    public interface IMailService
    {
        Task SendAsync(MailRequest request);
    }
}
