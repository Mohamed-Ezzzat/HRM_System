using System.ComponentModel.DataAnnotations;

namespace HRM_System.Models.ViewModel
{
	public class LoginViewModel
	{
        [Required(ErrorMessage = "Please enter a valid Email")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }

    }
}
