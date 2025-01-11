using System;
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.ViewModel
{
	public class LoginStudentUserViewModel
	{
		[Required(ErrorMessage = "Email is required")]
		[EmailAddress]
		public required string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

		[Display(Name = "RememberMe")]
		public bool RememberMe { get; set; }
	}
}

