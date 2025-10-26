using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WEBProjekat2025.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Full name")]
        public string FullName { get; set; }
    }
}
