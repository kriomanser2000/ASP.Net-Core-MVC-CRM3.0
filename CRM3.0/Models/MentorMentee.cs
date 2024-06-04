using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRM3._0.Models
{
	[Table("MentorMentee")]
	public class MentorMentee : BaseModel
	{
		#region Members
		public int MentorPersonId { get; set; }
		public int MenteePersonId { get; set; }
		#endregion
		#region Constructors

		public MentorMentee()
		{

		}
		#endregion
	}
}