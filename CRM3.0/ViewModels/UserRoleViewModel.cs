using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRM3._0.ViewModels
{
	public class UserRoleViewModel
	{
		public int RoleID { get; set; }
		[Required]
		public string RoleName { get; set; }
		[Required]
		public int RoleStatus { get; set; }
	}
}