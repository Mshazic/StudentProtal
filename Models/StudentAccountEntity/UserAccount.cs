using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace StudentPortal.Models.StudentAccountEntity
{
	[Index(nameof(Email),IsUnique = true)]
    [Index(nameof(UserName), IsUnique = true)]

    public class UserAccount
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage ="FristName required")]
		[MaxLength(50,ErrorMessage ="Max 50 characters allowed")]
		public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName required")]
        [MaxLength(50, ErrorMessage = "Max 50 characters allowed")]
		public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [MaxLength(50, ErrorMessage = "Max 100 characters allowed")]
		public string Email { get; set; }

        [Required(ErrorMessage = "UserName is required")]
        [MaxLength(50, ErrorMessage = "Max 50 characters allowed")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MaxLength(50, ErrorMessage = "Max 20 characters allowed")]
        public string Password { get; set; }

    }
}

