using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediCaresAPI.Models
{
    public class MediCaresUsers: IdentityUser
    {
        
        public bool IsPharmacyAdmin { get; set; } = true;

        [ForeignKey("Pharmacy")]
        public int? PharmacyId { get; set; }
        public MediCaresUsers? Pharmacy { get; set; }
    }
}
