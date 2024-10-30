using MediCaresAPI.Data;
using MediCaresAPI.Interfaces;
using MediCaresAPI.Models;
using MediCaresAPI.ResponseModel;
using Microsoft.EntityFrameworkCore;

namespace MediCaresAPI.Services
{
    public class PharmacyService : IPharmacyService
    {
        private readonly MediCaresDbContext _context;

        public PharmacyService(MediCaresDbContext context)
        {
            _context = context;
        }

        public async Task<Response> GetAllPharmaciesAsync()
        {
            try
            {
                var Pharmacy = await _context.Pharmacy.ToListAsync();
                return new Response(Pharmacy, Pharmacy.Count, true);
            }
            catch (Exception ex)
            {
                return new Response(null, null, false);
            }
        }

        public async Task<Response> GetPharmacyByIdAsync(int id)
        {
            try
            {
                var pharmacy = await _context.Pharmacy.FindAsync(id);
                return new Response(pharmacy, null, pharmacy != null);
            }
            catch (Exception ex)
            {
                return new Response(null, null, false);
            }
        }

        public async Task<ResponseMessage> CreatePharmacyAsync(Pharmacy pharmacy)
        {
            try
            {
                _context.Pharmacy.Add(pharmacy);
                await _context.SaveChangesAsync();
                return new ResponseMessage("Pharmacy created successfully.", pharmacy, true);
            }
            catch (Exception ex)
            {
                return new ResponseMessage("Error creating pharmacy.", null, false);
            }
        }

        public async Task<ResponseMessage> UpdatePharmacyAsync(Pharmacy pharmacy)
        {
            try
            {
                _context.Entry(pharmacy).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return new ResponseMessage("Pharmacy updated successfully.", pharmacy, true);
            }
            catch (Exception ex)
            {
                return new ResponseMessage("Error updating pharmacy.", null, false);
            }
        }

        public async Task<ResponseMessage> DeletePharmacyAsync(int id)
        {
            try
            {
                var pharmacy = await _context.Pharmacy.FindAsync(id);
                if (pharmacy == null)
                {
                    return new ResponseMessage("Pharmacy not found.", null, false);
                }

                _context.Pharmacy.Remove(pharmacy);
                await _context.SaveChangesAsync();
                return new ResponseMessage("Pharmacy deleted successfully.", null, true);
            }
            catch (Exception ex)
            {
                return new ResponseMessage("Error deleting pharmacy.", null, false);
            }
        }
    }

}
