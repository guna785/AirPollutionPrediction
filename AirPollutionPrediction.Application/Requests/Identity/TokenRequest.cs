using System.ComponentModel.DataAnnotations;

namespace AirPollutionPrediction.Application.Requests.Identity
{
    public class TokenRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
