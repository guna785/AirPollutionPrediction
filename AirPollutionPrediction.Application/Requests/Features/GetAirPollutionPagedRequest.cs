using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPollutionPrediction.Application.Requests.Features
{
    public class GetAirPollutionPagedRequest : PagedRequest
    {
        public string SearchString { get; set; }
    }
}
