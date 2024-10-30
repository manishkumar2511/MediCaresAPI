using MediCaresAPI.Data;
using MediCaresAPI.Interfaces;
using MediCaresAPI.ResponseModel;
using Microsoft.EntityFrameworkCore;

namespace MediCaresAPI.Services
{
    public class MediCaresAdminService : IMediCaresAdminService
    {
        private readonly MediCaresDbContext _context;

        public MediCaresAdminService(MediCaresDbContext context)
        {
            _context = context;
        }

        public async Task<Response> GetAdminAsync()
        {
            try
            {
                var admin = await _context.Users
                    .FirstOrDefaultAsync(u => u.IsStaticAdmin);

                return new Response(admin, null, admin != null);
            }
            catch (Exception ex)
            {
                return new Response(null, null, false);
            }
        }

    }

}
