using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRM3._0.Models
{
	[Table("UserRole")]
	public class UserRole : BaseModel
	{
		#region Members
    	public string Name { get; set; }
		public int StatusId { get; set; }
		#endregion
		#region Constructors
		public UserRole()
		{

		}

		public UserRole(UserRole role)
		{
			id = role.id;
			Name = role.Name;
			StatusId = role.StatusId;
		}
		#endregion
	}
}