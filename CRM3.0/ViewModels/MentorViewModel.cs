using CRM3._0.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CRM3._0.ViewModels
{
	[Bind(Exclude = "PersonId, MinistryId, WorkAddress")]
	public class MentorViewModel
	{
		[DisplayName("Person ID")]
		public int PersonId { get; set; }
		[DisplayName("Person")]
		public Person Person { get; set; }
		[DisplayName("Last Name")]
		public string LastName { get; set; }
		[DisplayName("First Name")]
		public string FirstName { get; set; }
		[DisplayName("Registration Date")]
		public DateTime RegistrationDate { get; set; }
		[DisplayName("Associated Ministry")]
		public int MinistryId { get; set; }
		[DisplayName("Associated Ministry")]
		public string MinistryName { get; set; }
    	[DisplayName("Home Address")]
		public Address HomeAddress { get; set; }
		[DisplayName("Work Address")]
		public Address WorkAddress { get; set; }
		[DisplayName("User Profile ID")]
		public int ProfileId { get; set; }
		[DisplayName("Username")]
		public string Username { get; set; }
		[DisplayName("Role ID")]
		public int RoleId { get; set; }
		[DisplayName("User Role")]
		public string RoleName { get; set; }
		[DisplayName("User Profile")]
		public UserProfile UserProfile { get; set; }
	}
}