using AirPollutionPrediction.Application.Interfaces.Chat;
using AirPollutionPrediction.Application.Models.Chat;
using AirPollutionPrediction.Application.Responses.Identity;
using AirPollutionPrediction.Shared.Wrapper;

namespace AirPollutionPrediction.Application.Interfaces.Services
{
    public interface IChatService
    {
        Task<Result<IEnumerable<ChatUserResponse>>> GetChatUsersAsync(int userId);

        Task<IResult> SaveMessageAsync(ChatHistory<IChatUser> message);

        Task<Result<IEnumerable<ChatHistoryResponse>>> GetChatHistoryAsync(int userId, int contactId);
    }
}
