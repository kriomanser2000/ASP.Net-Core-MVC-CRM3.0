using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRM3._0.Models
{
	[Table("UserProfile")]
	public class UserProfile : BaseModel
	{
		#region Members
		public string Username { get; set; }
		public string Password { get; set; }
		public string Salt { get; set; }
		public int PersonId { get; set; }
		public int RoleId { get; set; }
		public bool CanBeDeleted { get; set; }
		public int StatusId { get; set; }
		public string SecurityQuestion { get; set; }
		public string SecurityAnswer { get; set; }
		#endregion
		#region Constructors
		public UserProfile()
		{

		}

		public UserProfile(UserProfile profile)
		{
			id = profile.id;
			Username = profile.Username;
			Password = profile.Password;
			Salt = profile.Salt;
			PersonId = profile.PersonId;
			RoleId = profile.RoleId;
			CanBeDeleted = profile.CanBeDeleted;
			StatusId = profile.StatusId;
		}
		#endregion
	}
}