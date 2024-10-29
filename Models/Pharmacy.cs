using System.ComponentModel.DataAnnotations;

namespace MediCaresAPI.Models
{
    public class Pharmacy
    {
        [Key]
        public int PharmacyId { get; set; }
        public string PharmacyName { get; set; } = string.Empty;
        public string PharmacyEmail { get; set; } = string.Empty;
        public string RegistrationNumber { get; set; } = string.Empty;
        public string GSTNumber { get; set; } = string.Empty;
        public string password {  get; set; } =string.Empty;
       
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public ICollection<PharmacyStaff> StaffMembers { get; set; } = new List<PharmacyStaff>();
    }
}
