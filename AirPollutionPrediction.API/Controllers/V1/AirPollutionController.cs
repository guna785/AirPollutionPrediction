using AirPollutionPrediction.Application.Features.AirPollution.Commands.AddEdit;
using AirPollutionPrediction.Application.Features.AirPollution.Queries.GetPaged;
using AirPollutionPrediction.Application.Models;
using AirPollutionPrediction_API;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirPollutionPrediction.API.Controllers.V1
{

    public class AirPollutionController : BaseApiController<AirPollutionController>
    {
        /// <summary>
        /// Get All Employees
        /// </summary
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchString"></param>
        /// <param name="orderBy"></param>
        /// <returns>Status 200 OK</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll(int pageNumber, int pageSize, string? searchString, string? orderBy)
        {
            AirPollutionPrediction.Shared.Wrapper.PaginatedResult<GetAllPaginatedAirpollutionResponse> brands = await _mediator.Send(new GetAllPaginatedAirpollutionQuery(pageNumber, pageSize, searchString!, orderBy!));
            return Ok(brands);
        }
        /// <summary>
        /// Create/Update a Employee
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Status 200 OK</returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(AddEditAirPollutionCommand command)
        {
            var result = MLModel.Predict(new MLModel.ModelInput()
            {
                Co = float.Parse(command.CO)
            }, command.Horizon);
            var No2Res = NO2.Predict(new NO2.ModelInput()
            {
                No2 = float.Parse(command.NO2)
            }, command.Horizon);
            var SO2Res = SO2.Predict(new SO2.ModelInput()
            {
                So2 = float.Parse(command.SO2)
            }, command.Horizon);
            command.SO2 = Newtonsoft.Json.JsonConvert.SerializeObject(new ChartObject() { Normal = SO2Res.So2, UperBand = SO2Res.So2_UB, LowerBand = SO2Res.So2_LB });
            command.NO2 = Newtonsoft.Json.JsonConvert.SerializeObject(new ChartObject() { Normal = No2Res.No2, UperBand = No2Res.No2_UB, LowerBand = No2Res.No2_LB });
            command.CO = Newtonsoft.Json.JsonConvert.SerializeObject(new ChartObject() { Normal = result.Co, UperBand = result.Co_UB, LowerBand = result.Co_LB });
            return Ok(await _mediator.Send(command));
        }
    }
}
