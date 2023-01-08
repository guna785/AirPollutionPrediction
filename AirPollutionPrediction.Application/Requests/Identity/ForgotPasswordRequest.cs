using System.ComponentModel.DataAnnotations;

namespace AirPollutionPrediction.Application.Requests.Identity
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
