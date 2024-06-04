using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRM3._0.ViewModels;
using System.ComponentModel;

namespace CRM3._0.Models
{
	[Table("CalendarEvent")]
	public class CalendarEvent : BaseModel
	{
		#region Members
		public int CreatorId { get; set; }
		[DisplayName("Event Name")]
		public string EventName { get; set; }
		[DisplayName("Is this an all-day event?")]
		public int AllDayEvent { get; set; }
		[DisplayName("Event Begins")]
		public DateTime EventBegins { get; set; }
		[DisplayName("Event Ends")]
		public DateTime EventEnds { get; set; }
		[DisplayName("Event URL")]
		public string EventUrl { get; set; }
		[DisplayName("Event Details")]
		public string EventDetails { get; set; }
		[DisplayName("Event Signup")]
		public int SignupId { get; set; }
		[DisplayName("Event Type")]
		public int EventType { get; set; }
		[DisplayName("Event Status")]
		public int StatusId { get; set; }
		public int MentorId { get; set; }
		public int MenteeId { get; set; }
		#endregion
		#region Constructors

		public CalendarEvent()
		{

		}

		public CalendarEvent(EventViewModel viewModel)
		{
			this.Copy(viewModel);
		}

		public void Copy(EventViewModel viewModel)
		{
			this.id = viewModel.id;
			this.EventName = viewModel.EventName;
			this.EventType = viewModel.EventType;
			this.EventUrl = viewModel.EventUrl;
			this.EventDetails = viewModel.EventDetails;
			this.AllDayEvent = viewModel.AllDayEvent;
			this.EventBegins = viewModel.EventBegins;
			this.EventEnds = viewModel.EventEnds;
			this.MentorId = viewModel.MentorId;
			this.MenteeId = viewModel.MenteeId;
		}
		#endregion
	}
}