using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Models.StudentAccountEntity
{
	public class LogInViewModel
    {

        [Required(ErrorMessage = "UserName or Email is required")]
        [MaxLength(50, ErrorMessage = "Max 50 characters allowed")]
        [DisplayName("Username or Email")]
        public string UserNameOrEmail { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(10, MinimumLength = 08, ErrorMessage = "Max 10 characters allowed")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

