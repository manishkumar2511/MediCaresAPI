using MediCaresAPI.Models.Account;
using MediCaresAPI.ResponseModel;

namespace MediCaresAPI.Interfaces
{
    public interface IAccountService
    {
        Task<ResponseMessage> LoginAsync(LoginRequest request);
        Task<ResponseMessage> ForgotPasswordAsync(string email);
        Task<ResponseMessage> ResetPasswordAsync(ResetPasswordRequest request);

    }
}
