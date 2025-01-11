using System;
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.ViewModel
{
	public class RegisterStudentUserViewModel
	{

        [Required(ErrorMessage = "Name is required")]
        public required string Name { get; set; }


        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public required string Email { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [StringLength(40, MinimumLength = 8 , ErrorMessage ="The {0} must be at and at max {1} charactes")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword",ErrorMessage = "Password does not match.")]
        public required string Password { get; set; }


        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public required string ConfirmPassword { get; set; }
	}
}

