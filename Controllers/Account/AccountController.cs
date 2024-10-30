using MediCaresAPI.Interfaces;
using MediCaresAPI.Models.Account;
using MediCaresAPI.ResponseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MediCaresAPI.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService _accountService;

        public AccountController(ILogger<AccountController> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(typeof(ErrorMessageWrapper), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var result = await _accountService.LoginAsync(request);
                if (result.IsSuccessfull)
                    return Ok(result);
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in {controller}/{action}: {message}", nameof(AccountController), nameof(Login), ex.Message);
                return BadRequest(new ErrorMessageWrapper { ErrorMessage = "Login failed." });
            }
        }

        [HttpPost("forgot-password")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage))]
        [ProducesResponseType(typeof(ErrorMessageWrapper), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            try
            {
                var result = await _accountService.ForgotPasswordAsync(request.Email);
                if (result.IsSuccessfull)
                    return Ok(result);
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in {controller}/{action}: {message}", nameof(AccountController), nameof(ForgotPassword), ex.Message);
                return BadRequest(new ErrorMessageWrapper { ErrorMessage = "Password reset request failed." });
            }
        }

        [HttpPost("reset-password")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage))]
        [ProducesResponseType(typeof(ErrorMessageWrapper), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            try
            {
                var result = await _accountService.ResetPasswordAsync(request);
                if (result.IsSuccessfull)
                    return Ok(result);
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in {controller}/{action}: {message}", nameof(AccountController), nameof(ResetPassword), ex.Message);
                return BadRequest(new ErrorMessageWrapper { ErrorMessage = "Password reset failed." });
            }
        }
    }

}
