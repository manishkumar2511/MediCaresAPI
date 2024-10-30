using MediCaresAPI.Interfaces;
using MediCaresAPI.ResponseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;

namespace MediCaresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediCaresAdminController : ControllerBase
    {
        private readonly ILogger<MediCaresAdminController> _logger;
        private readonly IMediCaresAdminService _adminService;

        public MediCaresAdminController(ILogger<MediCaresAdminController> logger,IMediCaresAdminService adminService)
        {
            _logger = logger;
            _adminService = adminService;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(typeof(ErrorMessageWrapper), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAdmin()
        {
            try
            {
                var result = await _adminService.GetAdminAsync();
                return Ok(result);
            }

            catch (Exception ex)
            {
                var actionName = this.ControllerContext.RouteData.Values["action"]?.ToString() ?? "";
                var controllerName = this.ControllerContext.RouteData.Values["controller"]?.ToString() ?? "";
                _logger.LogError("There has been an error in controller {controller} method {action} reported: {error}", controllerName, actionName, ex.Message);

                return BadRequest(new ErrorMessageWrapper()
                {
                    HasUpdated = false,
                    ErrorMessage = "An error occurred while retrieving pharmacies."
                });
            }
        }
    }

}
