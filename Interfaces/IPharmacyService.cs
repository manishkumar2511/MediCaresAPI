using MediCaresAPI.Models;
using MediCaresAPI.ResponseModel;

namespace MediCaresAPI.Interfaces
{
    public interface IPharmacyService
    {
        Task<Response> GetAllPharmaciesAsync();
        Task<Response> GetPharmacyByIdAsync(int id);
        Task<ResponseMessage> CreatePharmacyAsync(Pharmacy pharmacy);
        Task<ResponseMessage> UpdatePharmacyAsync(Pharmacy pharmacy);
        Task<ResponseMessage> DeletePharmacyAsync(int id);
    }
}
