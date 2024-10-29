using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MediCaresAPI.Models
{
    public class PharmacyStaff
    {
        [Key]
        public int StaffId { get; set; }
        public string StaffName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [ForeignKey("Pharmacy")]
        public int PharmacyId { get; set; }
        public MediCaresUsers ? Pharmacy { get; set; }
    }
}
