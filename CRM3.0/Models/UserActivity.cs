using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRM3._0.Models
{
	public enum SystemActivityType
	{
		LogContact,
		ScheduleEvent,
		SendMessage,
		UploadResource,
		ViewResource,
		UpdateProfile,
		CreateApplication,
		UpdateApplication
	};
	[Table("UserActivity")]
	public class UserActivity : BaseModel
	{
		#region Members
		public int UserId { get; set; }
		public DateTime Created { get; set; }
		public SystemActivityType ActivityType { get; set; }
		#endregion
		#region Constructors

		public UserActivity()
		{

		}
		#endregion
	}
}