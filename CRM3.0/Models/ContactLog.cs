using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using CRM3._0.ViewModels;

namespace CRM3._0.Models
{
	[Table("ContactLog")]
	public class ContactLog : BaseModel
	{
		#region Members
		public int MentorId { get; set; }
		public int MenteeId { get; set; }
		public int ActivityTypeId { get; set; }
		public int ContactTypeId { get; set; }
		public DateTime ContactDate { get; set; }
		public string Details { get; set; }
		public string Feedback { get; set; }
		#endregion
		#region Constructors
		public ContactLog()
		{

		}

		public void Copy(ContactLogViewModel log)
		{
			this.id = log.ContactLogId;
			this.ContactDate = DateTime.Parse(log.ContactDate);
			this.ContactTypeId = log.ContactTypeId;
			this.MentorId = log.MentorId;
			this.MenteeId = log.MenteeId;
			this.Details = log.Details;
			this.ActivityTypeId = log.ActivityTypeId;
		}

		public ContactLog(ContactLogViewModel viewModel)
		{
			this.id = viewModel.ContactLogId;
			this.ContactDate = DateTime.Parse(viewModel.ContactDate);
			this.ContactTypeId = viewModel.ContactTypeId;
			this.MentorId = viewModel.MentorId;
			this.MenteeId = viewModel.MenteeId;
			this.Details = viewModel.Details;
			this.ActivityTypeId = viewModel.ActivityTypeId;
		}
		#endregion
	}
}