using CRM3._0.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRM3._0.Models
{
	public enum UserActivityType
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
	public class Activity : BaseModel
	{
		public int UserId { get; set; }
		public DateTime Created { get; set; }
		public UserActivityType ActivityType { get; set; }
	}
}
