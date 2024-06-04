using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRM3._0.ViewModels
{
	public class ChangePasswordViewModel
	{
		public string Username { get; set; }
		[Display(Name = "New password")]
		public string NewPassword { get; set; }
		[Display(Name = "Confirm new password")]
		public string ConfirmPassword { get; set; }
		[Display(Name = "Security Question")]
		public string SecurityQuestion { get; set; }
		[Display(Name = "Answer to your security question (not case sensitive)")]
		public string SecurityAnswer { get; set; }
	}
}