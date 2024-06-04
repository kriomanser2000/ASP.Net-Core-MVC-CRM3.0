using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM3._0.ViewModels
{
	public class EventListViewModel
	{
		public int id { get; set; }
		public string title { get; set; }
		public string start { get; set; }
		public string end { get; set; }
		public string allDay { get; set; }
		public string url { get; set; }
	}
}