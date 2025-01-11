using System;
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.ViewModel
{
	public class VerifyStudentUserViewModel
	{

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public required string Email { get; set; }
    }
}

