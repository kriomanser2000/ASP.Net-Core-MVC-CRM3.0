using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRM3._0.ViewModels
{
	public class ContactLogViewModel
	{
		public int ContactLogId { get; set; }
		[Display(Name = "Mentor")]
    	public string MentorName { get; set; }
		[Display(Name = "Mentor")]
		public int MentorId { get; set; }
		[Display(Name = "Mentee")]
		public string MenteeName { get; set; }
		[Display(Name = "Mentee")]
		public int MenteeId { get; set; }
		[Display(Name = "Type of Contact")]
		public int ContactTypeId { get; set; }
		[Display(Name = "Activity")]
		public int ActivityTypeId { get; set; }
		[Display(Name = "Date of Contact")]
		public string ContactDate { get; set; }
		[Display(Name = "Contact Details")]
		public string Details { get; set; }
		[Display(Name = "Ministry")]
		public int MinistryId { get; set; }
		[Display(Name = "Feedback")]
		public string Feedback { get; set; }

		public ContactLogViewModel()
		{

		}

		public ContactLogViewModel(ContactLogViewModel viewModel)
		{
			this.ContactLogId = viewModel.ContactLogId;
			this.ContactDate = viewModel.ContactDate;
			this.ContactTypeId = viewModel.ContactTypeId;
			this.MentorId = viewModel.MentorId;
			this.Details = viewModel.Details;
			this.ActivityTypeId = viewModel.ActivityTypeId;
			this.MinistryId = viewModel.MinistryId;
		}

		public ContactLogViewModel(Models.ContactLog contactLog)
		{
			this.ContactLogId = contactLog.id;
			this.ContactDate = contactLog.ContactDate.ToString("s");
			this.ContactTypeId = contactLog.ContactTypeId;
			this.MentorId = contactLog.MentorId;
			this.Details = contactLog.Details;
			this.ActivityTypeId = contactLog.ActivityTypeId;
		}
	}
}