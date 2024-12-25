using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace HRM_System.Models
{
    public class HRUser : IdentityUser
    {
        [Required(ErrorMessage = "Please enter your Name")]
        [MaxLength(50 , ErrorMessage ="Maximum Length of Full Name is 50 Chars")]
        [MinLength(5 , ErrorMessage ="Minimum Length of Full Name is 5 Chars")]
        public string FullName { get; set; }

        public virtual Admin Admin { get; set; }

    }
}
