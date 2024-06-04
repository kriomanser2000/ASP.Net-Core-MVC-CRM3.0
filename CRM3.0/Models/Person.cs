using CRM3._0.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace CRM3._0.Models
{
	[Table("Person")]
	public class Person : BaseModel
	{
		#region Members
		[DisplayName("First Name")]
		public string FirstName { get; set; }
		[DisplayName("Last Name")]
		public string LastName { get; set; }
		[DisplayName("Maiden Name")]
		public string MaidenName { get; set; }
		[DisplayName("Middle Initial")]
		public string MiddleInitial { get; set; }
		[DisplayName("Name Prefix")]
		public int PrefixId { get; set; }
		[DisplayName("Name Suffix")]
		public int SuffixId { get; set; }
		[DisplayName("Date of Birth")]
		public DateTime DOB { get; set; }
		[DisplayName("Gender")]
		public int GenderId { get; set; }
		[DisplayName("Social Security Number/Tax ID")]
		public string SSN { get; set; }
		[DisplayName("Race")]
		public int RaceId { get; set; }
		[DisplayName("State ID/Driver's License Number")]
		public string StateDl { get; set; }
		[DisplayName("State Where ID Was Issued")]
		public string StateWhereDlWasIssued { get; set; }
		[DisplayName("Primary Email Address")]
		public string EmailAddress { get; set; }
		[DisplayName("Arrested on Felony Charge?")]
		public int FelonyArrested { get; set; }
		[DisplayName("Convicted of Felony?")]
		public int FelonyConvicted { get; set; }
		[DisplayName("Description of Felony?")]
		public string FelonyDescription { get; set; }
		[DisplayName("Arrested on Misdemeanor?")]
		public int MisdemeanorArrested { get; set; }
		[DisplayName("Convicted of Misdemeanor?")]
		public int MisdemeanorConvicted { get; set; }
		[DisplayName("Description of Misdemeanor?")]
		public string MisdemeanorDescription { get; set; }
		[DisplayName("Emergency Contact's Name")]
		public string EmergencyContactName { get; set; }
		[DisplayName("Emergency contact's number")]
		public Phone EmergencyContactPhone { get; set; }
		[DisplayName("Status?")]
		public int StatusId { get; set; }
		[DisplayName("Person Type")]
		public int PersonTypeId { get; set; }
		#endregion
		#region Constructors
		public Person()
		{

		}

		public Person(Person myPerson)
		{
			this.FirstName = myPerson.FirstName;
			this.MiddleInitial = myPerson.MiddleInitial;
			this.LastName = myPerson.LastName;
			this.PrefixId = myPerson.PrefixId;
			this.SuffixId = myPerson.SuffixId;
			this.DOB = myPerson.DOB;
			this.GenderId = myPerson.GenderId;
			this.SSN = myPerson.SSN;
			this.RaceId = myPerson.RaceId;
			this.StateDl = myPerson.StateDl;
			this.StateWhereDlWasIssued = myPerson.StateWhereDlWasIssued;
			this.FelonyArrested = myPerson.FelonyArrested;
			this.FelonyConvicted = myPerson.FelonyConvicted;
			this.FelonyDescription = myPerson.FelonyDescription;
			this.MisdemeanorArrested = myPerson.MisdemeanorArrested;
			this.MisdemeanorConvicted = myPerson.MisdemeanorConvicted;
			this.MisdemeanorDescription = myPerson.MisdemeanorDescription;
			this.StatusId = myPerson.StatusId;
		}

		public Person(RegistrationViewModel viewModel)
		{
			this.FirstName = viewModel.FirstName;
			this.MiddleInitial = viewModel.MiddleInitial;
			this.LastName = viewModel.LastName;
			this.PrefixId = viewModel.PrefixId;
			this.SuffixId = viewModel.SuffixId;
			this.DOB = viewModel.DateOfBirth;
			this.GenderId = viewModel.GenderId;
			this.SSN = viewModel.SocialSecurityNumber;
			this.RaceId = viewModel.RaceId;
			this.StateDl = viewModel.StateDl;
			this.StateWhereDlWasIssued = viewModel.StateWhereDlIssued;
			this.FelonyArrested = viewModel.FelonyArrested;
			this.FelonyConvicted = viewModel.FelonyConvicted;
			this.FelonyDescription = viewModel.FelonyDescription;
			this.MisdemeanorArrested = viewModel.MisdemeanorArrested;
			this.MisdemeanorConvicted = viewModel.MisdemeanorConvicted;
			this.MisdemeanorDescription = viewModel.MisdemeanorDescription;
		}

		public void Copy(Person myPerson)
		{
			this.id = myPerson.id;
			this.FirstName = myPerson.FirstName;
			this.MiddleInitial = myPerson.MiddleInitial;
			this.LastName = myPerson.LastName;
			this.PrefixId = myPerson.PrefixId;
			this.SuffixId = myPerson.SuffixId;
			this.DOB = myPerson.DOB;
			this.GenderId = myPerson.GenderId;
			this.SSN = myPerson.SSN;
			this.RaceId = myPerson.RaceId;
			this.StateDl = myPerson.StateDl;
			this.StateWhereDlWasIssued = myPerson.StateWhereDlWasIssued;
			this.FelonyArrested = myPerson.FelonyArrested;
			this.FelonyConvicted = myPerson.FelonyConvicted;
			this.FelonyDescription = myPerson.FelonyDescription;
			this.MisdemeanorArrested = myPerson.MisdemeanorArrested;
			this.MisdemeanorConvicted = myPerson.MisdemeanorConvicted;
			this.MisdemeanorDescription = myPerson.MisdemeanorDescription;
			this.StatusId = myPerson.StatusId;
		}
		#endregion
	}
}