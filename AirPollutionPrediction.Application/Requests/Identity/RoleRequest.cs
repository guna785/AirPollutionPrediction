using System.ComponentModel.DataAnnotations;

namespace AirPollutionPrediction.Application.Requests.Identity
{
    public class RoleRequest
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
