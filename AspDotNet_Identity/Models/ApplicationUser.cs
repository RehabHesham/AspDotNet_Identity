using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspDotNet_Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }

        [ForeignKey("instructor")]
        public int? InsId { get; set; }

        public Instructor? instructor { get; set; }
    }
}
