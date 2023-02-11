using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPollutionPrediction.Application.Models
{
    public class ChartObject
    {
        public float[] Normal { get; set; }
        public float[] UperBand { get; set; }
        public float[] LowerBand { get; set; }
    }
}
