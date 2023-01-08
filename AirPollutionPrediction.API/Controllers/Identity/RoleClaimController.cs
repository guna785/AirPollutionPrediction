using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AirPollutionPrediction.Application.Interfaces.Services.Identity;
using AirPollutionPrediction.Application.Requests.Identity;
using AirPollutionPrediction.Shared.Constants.Permission;

namespace AirPollutionPrediction.API.Controllers.Identity
{
    [Route("api/identity/roleClaim")]
    [ApiController]
    public class RoleClaimController : ControllerBase
    {
        private readonly IRoleClaimService _roleClaimService;

        public RoleClaimController(IRoleClaimService roleClaimService)
        {
            _roleClaimService = roleClaimService;
        }

        /// <summary>
        /// Get All Role Claims(e.g. Product Create Permission)
        /// </summary>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.RoleClaims.View)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            AirPollutionPrediction.Shared.Wrapper.Result<List<AirPollutionPrediction.Application.Responses.Identity.RoleClaimResponse>> roleClaims = await _roleClaimService.GetAllAsync();
            return Ok(roleClaims);
        }

        /// <summary>
        /// Get All Role Claims By Id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.RoleClaims.View)]
        [HttpGet("{roleId}")]
        public async Task<IActionResult> GetAllByRoleId([FromRoute] int roleId)
        {
            AirPollutionPrediction.Shared.Wrapper.Result<List<AirPollutionPrediction.Application.Responses.Identity.RoleClaimResponse>> response = await _roleClaimService.GetAllByRoleIdAsync(roleId);
            return Ok(response);
        }

        /// <summary>
        /// Add a Role Claim
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Status 200 OK </returns>
        [Authorize(Policy = Permissions.RoleClaims.Create)]
        [HttpPost]
        public async Task<IActionResult> Post(RoleClaimRequest request)
        {
            AirPollutionPrediction.Shared.Wrapper.Result<string> response = await _roleClaimService.SaveAsync(request);
            return Ok(response);
        }

        /// <summary>
        /// Delete a Role Claim
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.RoleClaims.Delete)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            AirPollutionPrediction.Shared.Wrapper.Result<string> response = await _roleClaimService.DeleteAsync(id);
            return Ok(response);
        }
    }
}
