using CRM3._0.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CRM3._0.ViewModels
{
	public class EventViewModel
	{
		public int id { get; set; }
		public int CreatorId { get; set; }
		[DisplayName("Event Name")]
		public string EventName { get; set; }
		[DisplayName("Is this an all-day event?")]
		public int AllDayEvent { get; set; }
		[DisplayName("Event Begins"), DisplayFormat(DataFormatString = "{0:MM-dd-yyyy hh:mm}")]
		public DateTime EventBegins { get; set; }
		[DisplayName("Event Ends"), DisplayFormat(DataFormatString = "{0:MM-dd-yyyy hh:mm}")]
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
		[DisplayName("The mentor you wish to meet")]
		public int MentorId { get; set; }
		[DisplayName("The mentee you wish to meet")]
		public int MenteeId { get; set; }
		public EventViewModel()
		{

		}

		public EventViewModel(CalendarEvent myEvent)
		{
			this.id = myEvent.id;
			this.EventName = myEvent.EventName;
			this.EventBegins = myEvent.EventBegins;
			this.EventEnds = myEvent.EventEnds;
			this.EventType = myEvent.EventType;
			this.EventUrl = myEvent.EventUrl;
			this.EventDetails = myEvent.EventDetails;
			this.AllDayEvent = myEvent.AllDayEvent;
			this.MenteeId = myEvent.MenteeId;
			this.MentorId = myEvent.MentorId;
		}
	}
}