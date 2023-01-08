using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AirPollutionPrediction.Application.Interfaces.Services.Identity;
using AirPollutionPrediction.Application.Requests.Identity;
using AirPollutionPrediction.Shared.Constants.Permission;

namespace AirPollutionPrediction.API.Controllers.Identity
{
    [Route("api/identity/role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        /// <summary>
        /// Get All Roles (basic, admin etc.)
        /// </summary>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.Roles.View)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            AirPollutionPrediction.Shared.Wrapper.Result<List<AirPollutionPrediction.Application.Responses.Identity.RoleResponse>> roles = await _roleService.GetAllAsync();
            return Ok(roles);
        }

        /// <summary>
        /// Add a Role
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.Roles.Create)]
        [HttpPost]
        public async Task<IActionResult> Post(RoleRequest request)
        {
            AirPollutionPrediction.Shared.Wrapper.Result<string> response = await _roleService.SaveAsync(request);
            return Ok(response);
        }

        /// <summary>
        /// Delete a Role
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.Roles.Delete)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            AirPollutionPrediction.Shared.Wrapper.Result<string> response = await _roleService.DeleteAsync(id);
            return Ok(response);
        }

        /// <summary>
        /// Get Permissions By Role Id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns>Status 200 Ok</returns>
        [Authorize(Policy = Permissions.RoleClaims.View)]
        [HttpGet("permissions/{roleId}")]
        public async Task<IActionResult> GetPermissionsByRoleId([FromRoute] int roleId)
        {
            AirPollutionPrediction.Shared.Wrapper.Result<AirPollutionPrediction.Application.Responses.Identity.PermissionResponse> response = await _roleService.GetAllPermissionsAsync(roleId);
            return Ok(response);
        }

        /// <summary>
        /// Edit a Role Claim
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize(Policy = Permissions.RoleClaims.Edit)]
        [HttpPut("permissions/update")]
        public async Task<IActionResult> Update(PermissionRequest model)
        {
            AirPollutionPrediction.Shared.Wrapper.Result<string> response = await _roleService.UpdatePermissionsAsync(model);
            return Ok(response);
        }
    }
}
