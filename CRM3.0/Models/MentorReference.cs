using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRM3._0.Models
{
	[Table("MentorReference")]
	public class MentorReference : BaseModel
	{
		#region Members
		public int MentorId { get; set; }
		public int ReferrerId { get; set; }
		public string Body { get; set; }
		#endregion
		#region Constructors
		public MentorReference()
		{

		}
		#endregion
	}
}