using Microsoft.AspNetCore.Identity;

namespace MediCaresAPI.SeedData
{
    public static class MediCaresAdminSeed
    {
        public static MediCaresUsers GetMediCaresAdmin()
        {
            return new MediCaresUsers
            {
                UserName = "solutionmedicares@gmail.com",  
                Email = "solutionmedicares@gmail.com",    
                IsStaticAdmin = true,
                PasswordHash = new PasswordHasher<MediCaresUsers>().HashPassword(null, "MediCares@123") 
            };
        }
    }
}
