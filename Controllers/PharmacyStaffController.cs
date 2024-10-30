using MediCaresAPI.Interfaces;
using MediCaresAPI.ResponseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MediCaresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyStaffController : ControllerBase
    {
        private readonly ILogger<PharmacyStaffController> _logger;

        private readonly IPharmacyStaffService _staffService;

        public PharmacyStaffController(ILogger<PharmacyStaffController> logger, IPharmacyStaffService staffService)
        {
            _logger = logger;
            _staffService = staffService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(typeof(ErrorMessageWrapper), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetPharmacyStaff()
        {
            try
            {
                var result = await _staffService.GetAllStaffAsync();
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
