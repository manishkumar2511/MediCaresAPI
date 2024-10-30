using MediCaresAPI.Data;
using MediCaresAPI.Interfaces;
using MediCaresAPI.Models;
using MediCaresAPI.ResponseModel;
using Microsoft.EntityFrameworkCore;

namespace MediCaresAPI.Services
{
    public class PharmacyStaffService : IPharmacyStaffService
    {
        private readonly MediCaresDbContext _context;

        public PharmacyStaffService(MediCaresDbContext context)
        {
            _context = context;
        }

        public async Task<Response> GetAllStaffAsync()
        {
            try
            {
                var staff = await _context.PharmacyStaff.ToListAsync();
                return new Response(staff, staff.Count, true);
            }
            catch (Exception ex)
            {
                return new Response(null, null, false);
            }
        }

        public async Task<Response> GetStaffByIdAsync(int id)
        {
            try
            {
                var staff = await _context.PharmacyStaff.FindAsync(id);
                return new Response(staff, null, staff != null);
            }
            catch (Exception ex)
            {
                return new Response(null, null, false);
            }
        }

        public async Task<ResponseMessage> CreateStaffAsync(PharmacyStaff staff)
        {
            try
            {
                _context.PharmacyStaff.Add(staff);
                await _context.SaveChangesAsync();
                return new ResponseMessage("Staff created successfully.", staff, true);
            }
            catch (Exception ex)
            {
                return new ResponseMessage("Error creating staff.", null, false);
            }
        }

        public async Task<ResponseMessage> UpdateStaffAsync(PharmacyStaff staff)
        {
            try
            {
                _context.Entry(staff).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return new ResponseMessage("Staff updated successfully.", staff, true);
            }
            catch (Exception ex)
            {
                return new ResponseMessage("Error updating staff.", null, false);
            }
        }

        public async Task<ResponseMessage> DeleteStaffAsync(int id)
        {
            try
            {
                var staff = await _context.PharmacyStaff.FindAsync(id);
                if (staff == null)
                {
                    return new ResponseMessage("Staff not found.", null, false);
                }

                _context.PharmacyStaff.Remove(staff);
                await _context.SaveChangesAsync();
                return new ResponseMessage("Staff deleted successfully.", null, true);
            }
            catch (Exception ex)
            {
                return new ResponseMessage("Error deleting staff.", null, false);
            }
        }
    }

}
