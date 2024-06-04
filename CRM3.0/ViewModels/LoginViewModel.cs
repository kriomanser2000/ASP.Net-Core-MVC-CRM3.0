using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRM3._0.ViewModels
{
	public class LoginViewModel
	{
		[Required]
		[Display(Name = "Username")]
		public string Username { get; set; }
		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }
		[Display(Name = "Remember me?")]
		public bool RememberMe { get; set; }
	}
}