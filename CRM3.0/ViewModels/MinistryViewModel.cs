using CRM3._0.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM3._0.ViewModels
{
	[Bind(Exclude = "MinistryId, LeadMentorId")]
	public class MinistryViewModel
	{
		public int MinistryId { get; set; }
		[DisplayName("Ministry Name")]
		public string Name { get; set; }
		[DisplayName("Description of Ministry")]
		public string Description { get; set; }
		[DisplayName("Address of Ministry")]
		public Address Address { get; set; }
		public int AddressId { get; set; }
		[DisplayName("Lead Mentor")]
		public int LeadMentorId { get; set; }
		[DisplayName("Main Phone")]
		public Phone PhoneNumber { get; set; }
		public int PhoneId { get; set; }
	}
}