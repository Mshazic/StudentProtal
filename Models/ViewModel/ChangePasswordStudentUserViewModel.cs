using System;
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.ViewModel
{
	public class ChangePasswordStudentUserViewModel
	{
        [Required(ErrorMessage = "Name is required")]
        [EmailAddress]
        public required string Email { get; set; }


        [Required(ErrorMessage = "Name is required")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "The {0} must be at and at max {1} charactes")]
        [DataType(DataType.Password)]
        [Display(Name = "NewPassword")]
        [Compare("ConfirmNewPassword", ErrorMessage = "Password does not match.")]
        public required string NewPassword { get; set; }


        [Required(ErrorMessage = "Name is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm New Password")]
        public required string ConfirmNewPassword { get; set; }
    }
}

