using System;
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.ViewModel
{
	public class VerifyStudentUserViewModel
	{

        [Required(ErrorMessage = "Name is required")]
        [EmailAddress]
        public string Email { get; set; }
    }
}

