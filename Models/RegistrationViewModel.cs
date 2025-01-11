using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace StudentPortal.Models.StudentAccountEntity
{
	public class RegistrationViewModel
	{
        [Required(ErrorMessage = "FristName required")]
        [MaxLength(50, ErrorMessage = "Max 50 characters allowed")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName required")]
        [MaxLength(50, ErrorMessage = "Max 50 characters allowed")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        //[MaxLength(50, ErrorMessage = "Max 100 characters allowed")]
        [RegularExpression((@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z"), ErrorMessage = "Max 100 characters allowed")]
        public string Email { get; set; }

        [Required(ErrorMessage = "UserName is required")]
        [MaxLength(50, ErrorMessage = "Max 50 characters allowed")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(10, MinimumLength =08, ErrorMessage = "Max 10 characters allowed")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage="Please Confrim your Password")]
        [DataType(DataType.Password)]
        public string ConfrimPassword { get; set; }
    }
}

