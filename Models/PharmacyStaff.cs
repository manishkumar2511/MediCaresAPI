using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MediCaresAPI.Models
{
    public class PharmacyStaff
    {
        [Key]
        public int StaffId { get; set; }
        public string? StaffName { get; set; } 
        public string? Email { get; set; } 
        public string? Mobile { get; set; } 
        public string? Address { get; set; } 
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public int PharmacyId { get; set; }
        public Pharmacy? Pharmacy { get; set; }
        public string? UserId { get; set; } 
        public MediCaresUsers? MedicaresUser { get; set; }
    }
}
