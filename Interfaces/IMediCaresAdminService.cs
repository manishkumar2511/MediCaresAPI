using MediCaresAPI.ResponseModel;

namespace MediCaresAPI.Interfaces
{
    public interface IMediCaresAdminService
    {
        Task<Response> GetAdminAsync();
    }
}
