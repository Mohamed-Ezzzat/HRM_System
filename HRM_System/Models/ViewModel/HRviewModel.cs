using System.ComponentModel.DataAnnotations;

namespace HRM_System.Models.ViewModel
{
	public class HRviewModel
	{
        [Required(ErrorMessage = "Please enter your Name")]
        [MaxLength(50, ErrorMessage = "Maximum Length of Full Name is 50 Chars")]
        [MinLength(5, ErrorMessage = "Minimum Length of Full Name is 5 Chars")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Please enter your User Name")]
        [MaxLength(30, ErrorMessage = "Maximum Length of User Name is 50 Chars")]
        [MinLength(3, ErrorMessage = "Minimum Length of User Name is 3 Chars")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter a valid Email")]
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }

        public string RoleName { get; set; }
    }
}
