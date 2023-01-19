using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPollutionPrediction.Application.Features.AirPollution.Queries.GetPaged
{
    public class GetAllPaginatedAirpollutionResponse
    {
        public int Id { get; set; } = 0;
        public string CO { get; set; }
        public string NO2 { get; set; }
        public string SO2 { get; set; }
        public int Horizon { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
