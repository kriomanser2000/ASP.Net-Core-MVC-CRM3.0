using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRM3._0.ViewModels
{
	public class AssignMentorViewModel
	{
		[Required, DisplayName("Select a Mentor...")]
		public int MentorId { get; set; }
		[Required, DisplayName("Select a Mentee...")]
		public int MenteeId { get; set; }
	}
}