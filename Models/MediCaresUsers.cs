using MediCaresAPI.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

public class MediCaresUsers : IdentityUser
{
    public bool IsPharmacyAdmin { get; set; } = false; 
    public bool IsStaticAdmin { get; set; } = false; 

    [ForeignKey("Pharmacy")]
    public int? PharmacyId { get; set; }
    public Pharmacy? Pharmacy { get; set; }
}