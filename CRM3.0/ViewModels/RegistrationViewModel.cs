using CRM3._0.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRM3._0.ViewModels
{
	public class RegistrationViewModel
	{
		public int PersonId { get; set; }
		[Required, DisplayName("Registration Status")]
		public int StatusId { get; set; }
		[Required, DisplayName("First Name")]
		public string FirstName { get; set; }
		[Required, DisplayName("Last Name")]
		public string LastName { get; set; }
		[DisplayName("Maiden Name")]
		public string MaidenName { get; set; }
		[DisplayName("Middle Initial")]
		public string MiddleInitial { get; set; }
		[Required, DisplayName("Name Prefix")]
		public int PrefixId { get; set; }
		[Required, DisplayName("Name Suffix")]
		public int SuffixId { get; set; }
		[Required, DisplayName("Are you currently married?")]
		public int MaritalStatus { get; set; }
		[Required, DisplayName("Date of Birth")]
		public DateTime DateOfBirth { get; set; }
		[Required, DisplayName("Gender")]
		public int GenderId { get; set; }
		[Required, DisplayName("SSN or Tax ID")]
		public string SocialSecurityNumber { get; set; }
		[Required, DisplayName("Race")]
		public int RaceId { get; set; }
		[Required, DisplayName("Driver's License Number")]
		public string StateDl { get; set; }
		[Required, DisplayName("State Where Driver's License Was Issued")]
		public string StateWhereDlIssued { get; set; }
		[DisplayName("Home Address")]
		public Address HomeAddress { get; set; }
		[DisplayName("Work Address")]
		public Address WorkAddress { get; set; }
		[DisplayName("Mobile/Cell Phone Number")]
		public Phone CellPhone { get; set; }
		[DisplayName("Home Phone")]
		public Phone HomePhone { get; set; }
		[DisplayName("Work Phone")]
		public Phone WorkPhone { get; set; }
		[Required, DisplayName("Do you agree to the terms listed above?")]
		public int AgreeToTerms { get; set; }
		[Required, DisplayName("Have you ever been arrested on a felony charge?")]
		public int FelonyArrested { get; set; }
		[DisplayName("Were you convicted of the felony?")]
		public int FelonyConvicted { get; set; }
		[DisplayName("Please describe the felony...")]
		public string FelonyDescription { get; set; }
		[Required, DisplayName("Have you ever been arrested on a misdemeanor charge?")]
		public int MisdemeanorArrested { get; set; }
		[DisplayName("Were you convicted of the misdemeanor?")]
		public int MisdemeanorConvicted { get; set; }
		[DisplayName("Please describe the misdemeanor...")]
		public string MisdemeanorDescription { get; set; }
		[DisplayName("What days and times are you available to mentor?")]
		public string Availability { get; set; }
		[DisplayName("Please choose a ministry")]
		public int MinistryId { get; set; }
		[DisplayName("Ministry Name")]
		public string MinistryName { get; set; }
		[DisplayName("Ministry Experience")]
		public string MinistryExperience { get; set; }
		[DisplayName("Leadership Skills")]
		public string LeadershipSkills { get; set; }
		[DisplayName("Special Hobbies and Skills")]
		public string SpecialHobbies { get; set; }
		[DisplayName("Special Requests")]
		public string SpecialRequests { get; set; }
		[DisplayName("Are you currently on the visitation list of anyone incarcerated?")]
		public int HasRelationIncarcerated { get; set; }
		[DisplayName("Name of relation incarcerated")]
		public string RelationIncarceratedName { get; set; }
		[DisplayName("Department of Corrections Number")]
		public string RelationIncarceratedNumber { get; set; }
		[DisplayName("Type of Relationship")]
		public string RelationIncarceratedType { get; set; }
		[DisplayName("Have you ever worked for FL DoC?")]
		public int WorkedForDoC { get; set; }
		[DisplayName("When did you start work for FL DoC?")]
		public DateTime WhenWorkedStarted { get; set; }
		[DisplayName("When did you stop work for FL DoC?")]
		public DateTime WhenWorkedEnded { get; set; }
		[DisplayName("Where did you work for FL DoC?")]
		public string WhereDidYouWork { get; set; }
		[DisplayName("Do you have a relative working for FL DoC?")]
		public int RelativesWorkingForDoC { get; set; }
		[DisplayName("What is their name?")]
		public string RelativeWorkingForDoCName { get; set; }
		[DisplayName("Relation Type")]
		public string RelativeWorkingForDoCRelationType { get; set; }
		[DisplayName("Where do they work?")]
		public string RelativeWorkingForDoCWorkLocation { get; set; }
		[Required]
		public string Username { get; set; }
		[Required]
		public string Password { get; set; }
		[DisplayName("Re-type your password")]
		public string PasswordConfirm { get; set; }
	}
}