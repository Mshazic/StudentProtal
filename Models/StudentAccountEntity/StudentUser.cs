using System;
using Microsoft.AspNetCore.Identity;

namespace StudentPortal.Models.StudentAccountEntity
{
	public class StudentUser : IdentityUser
	{
		public string FullName { get; set; }
	}
}

