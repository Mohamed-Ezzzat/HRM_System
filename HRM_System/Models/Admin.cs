using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRM_System.Models
{
                                             //المستخدمين
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your User Name")]
        [MaxLength(30, ErrorMessage = "Maximum Length of User Name is 50 Chars")]
        [MinLength(3, ErrorMessage = "Minimum Length of User Name is 3 Chars")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress (ErrorMessage = "Please enter a valid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter a valid Password")]

        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter a valid Group")]

        public string RoleName { get; set; }


        [ForeignKey(nameof(HRUser))]
        public string UserId { get; set; }
        public HRUser HRUser { get; set; }






    }
}
