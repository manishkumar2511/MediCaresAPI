using MediCaresAPI.Interfaces;
using MediCaresAPI.Models.Account;
using MediCaresAPI.ResponseModel;
using Microsoft.AspNetCore.Identity;

namespace MediCaresAPI.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<MediCaresUsers> _userManager;

        public AccountService(UserManager<MediCaresUsers> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ResponseMessage> LoginAsync(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                // Generate token logic (JWT or other) could go here.
                return new ResponseMessage("Login successful.", user, true);
            }
            return new ResponseMessage("Invalid credentials.", null, false);
        }

        public async Task<ResponseMessage> ForgotPasswordAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return new ResponseMessage("User not found.", null, false);

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            // Logic to send the reset token via email goes here.

            return new ResponseMessage("Password reset token sent.", null, true);
        }

        public async Task<ResponseMessage> ResetPasswordAsync(ResetPasswordRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                return new ResponseMessage("User not found.", null, false);

            var result = await _userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);
            if (result.Succeeded)
                return new ResponseMessage("Password reset successful.", null, true);

            return new ResponseMessage("Password reset failed.", null, false);
        }
    }
}
