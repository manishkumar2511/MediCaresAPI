using MediCaresAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MediCaresAPI.SeedData;

namespace MediCaresAPI.Data
{
    public class MediCaresDbContext : IdentityDbContext<MediCaresUsers>
    {
        public MediCaresDbContext(DbContextOptions<MediCaresDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pharmacy> Pharmacy { get; set; }
        public DbSet<PharmacyStaff> PharmacyStaff { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var mediCaresAdmin = MediCaresAdminSeed.GetMediCaresAdmin();
            modelBuilder.Entity<MediCaresUsers>().HasData(mediCaresAdmin);

            // Define relationships without cascade delete
            modelBuilder.Entity<Pharmacy>()
                .HasMany(p => p.PharmacyStaff)
                .WithOne(s => s.Pharmacy)
                .HasForeignKey(s => s.PharmacyId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<PharmacyStaff>()
                .HasOne(s => s.MedicaresUser)
                .WithMany()
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete
        }
    }
}
