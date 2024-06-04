using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRM3._0.ViewModels
{
	public class NewUserViewModel
	{
		[Required]
		public string Username { get; set; }
		[Required, DataType(DataType.Password)]
		public string Password { get; set; }
		[Required, DisplayName("Confirm Password")]
		public string ConfirmPassword { get; set; }
	}
}