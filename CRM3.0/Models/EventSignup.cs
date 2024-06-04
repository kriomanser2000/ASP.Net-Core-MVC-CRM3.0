using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRM3._0.Models
{
	[Table("EventSignup")]
	public class EventSignup : BaseModel
	{
		#region Members
		[DisplayName("Event ID")]
		public int EventId { get; set; }
		[DisplayName("Minimum Signees")]
		public int Minimum { get; set; }
		[DisplayName("Maximum Signees")]
		public int Maximum { get; set; }
		[DisplayName("Signup Opens")]
		public DateTime Opens { get; set; }
		[DisplayName("Signup Closes")]
		public DateTime Closes { get; set; }
		[DisplayName("Is the event open to the public?")]
		public bool OpenToPublic { get; set; }
		[DisplayName("Signup Status")]
		public bool SignupIsOpen { get; set; }
		#endregion
		#region Constructors
		public EventSignup()
		{

		}
		#endregion
	}
}
