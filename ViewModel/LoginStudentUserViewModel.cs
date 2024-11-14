﻿using System;
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.ViewModel
{
	public class LoginStudentUserViewModel
	{
		[Required(ErrorMessage = "Email is required")]
		[EmailAddress]
		public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

		[Display(Name = "RememberMe")]
		public bool RememberMe { get; set; }
	}
}

