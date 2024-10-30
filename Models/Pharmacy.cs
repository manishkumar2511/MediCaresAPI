using System.ComponentModel.DataAnnotations;

namespace MediCaresAPI.Models
{
    public class Pharmacy
    {
        [Key]
        public int PharmacyId { get; set; }
        public string? PharmacyName { get; set; } 
        public string? PharmacyEmail { get; set; }
        public string? Phone { get; set; }
        public string? RegistrationNumber { get; set; } 
        public string? GSTNumber { get; set; } 
        public string? Password { get; set; } 
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public ICollection<MediCaresUsers> PharmacyStaff { get; set; } = new List<MediCaresUsers>();
    }
}
