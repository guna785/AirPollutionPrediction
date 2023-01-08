using AirPollutionPrediction.Application.Interfaces.Chat;
using AirPollutionPrediction.Application.Models.Chat;

namespace AirPollutionPrediction.Application.Responses.Identity
{
    public class ChatUserResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string ProfilePictureDataUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public bool IsOnline { get; set; }
        public virtual ICollection<ChatHistory<IChatUser>> ChatHistoryFromUsers { get; set; }
        public virtual ICollection<ChatHistory<IChatUser>> ChatHistoryToUsers { get; set; }
    }
}
