using MediCaresAPI.Models;
using MediCaresAPI.ResponseModel;

namespace MediCaresAPI.Interfaces
{
    public interface IPharmacyStaffService
    {
        Task<Response> GetAllStaffAsync();
        Task<Response> GetStaffByIdAsync(int id);
        Task<ResponseMessage> CreateStaffAsync(PharmacyStaff staff);
        Task<ResponseMessage> UpdateStaffAsync(PharmacyStaff staff);
        Task<ResponseMessage> DeleteStaffAsync(int id);
    }
}
