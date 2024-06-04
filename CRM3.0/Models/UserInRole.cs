using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRM3._0.Models
{
	[Table("UserInRole")]
	public class UserInRole
	{
		[Key, Column(Order = 0)]
		public int UserId { get; set; }
		[Key, Column(Order = 1)]
		public int RoleId { get; set; }
		public UserProfile User { get; set; }
		public UserRole Role { get; set; }
		public DateTime? CreatedOn { get; set; }
		public DateTime? DeletedOn { get; set; }
	}
}