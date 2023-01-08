using AirPollutionPrediction.Domain.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPollutionPrediction.Domain.Entities
{
    public class AirPollutionForcast:AuditableEntity<int>
    {
        public string CO { get; set; }
        public string NO2 { get; set; }
        public string SO2 { get; set; }
        public int Horizon { get; set; }
    }
}
