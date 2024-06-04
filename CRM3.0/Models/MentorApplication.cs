using CRM3._0.Helpers;
using CRM3._0.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace CRM3._0.Models
{
	[Table("MentorApplication")]
	public class MentorApplication : BaseModel
	{
		#region Members
		public int PersonId { get; set; }
		public int StatusId { get; set; }
		public int AgreeToTerms { get; set; }
		public int MinistryId { get; set; }
		public string Availability { get; set; }
		public string MinistryExperience { get; set; }
		public string LeadershipSkills { get; set; }
		public string SpecialHobbies { get; set; }
		public string SpecialRequests { get; set; }
		public int HasRelationIncarcerated { get; set; }
		public string RelationIncarceratedName { get; set; }
		public string RelationIncarceratedNumber { get; set; }
		public string RelationIncarceratedType { get; set; }
		public int WorkedForDoC { get; set; }
		public DateTime? RegistrationDate { get; set; }
		public DateTime? WhenWorkedStarted { get; set; }
		public DateTime? WhenWorkedEnded { get; set; }
		public string WhereDidYouWork { get; set; }
		public int RelativesWorkingForDoC { get; set; }
		public string RelativeWorkingForDoCName { get; set; }
		public string RelativeWorkingForDoCRelationType { get; set; }
		public string RelativeWorkingForDoCWorkLocation { get; set; }
		#endregion
		#region Constructors
		public MentorApplication()
		{

		}

		public MentorApplication(RegistrationViewModel viewModel)
		{
			this.PersonId = viewModel.PersonId;
			this.StatusId = viewModel.StatusId;
			this.AgreeToTerms = viewModel.AgreeToTerms;
			this.Availability = viewModel.Availability;
			this.HasRelationIncarcerated = viewModel.HasRelationIncarcerated;
			this.LeadershipSkills = viewModel.LeadershipSkills;
			this.MinistryExperience = viewModel.MinistryExperience;
			this.MinistryId = viewModel.MinistryId;
			this.RelationIncarceratedName = viewModel.RelationIncarceratedName;
			this.RelationIncarceratedNumber = viewModel.RelationIncarceratedNumber;
			this.RelationIncarceratedType = viewModel.RelationIncarceratedType;
			this.RelativesWorkingForDoC = viewModel.RelativesWorkingForDoC;
			this.RelativeWorkingForDoCName = viewModel.RelativeWorkingForDoCName;
			this.RelativeWorkingForDoCRelationType = viewModel.RelativeWorkingForDoCRelationType;
			this.RelativeWorkingForDoCWorkLocation = viewModel.RelativeWorkingForDoCWorkLocation;
			this.SpecialHobbies = viewModel.SpecialHobbies;
			this.SpecialRequests = viewModel.SpecialRequests;
			if (viewModel.WhenWorkedEnded < SqlDateTime.MinValue.Value)
			{
				this.WhenWorkedEnded = SqlDateTime.MinValue.Value;
			}
			else
			{
				this.WhenWorkedEnded = viewModel.WhenWorkedEnded;
			}

			if (viewModel.WhenWorkedEnded < SqlDateTime.MinValue.Value)
			{
				this.WhenWorkedStarted = SqlDateTime.MinValue.Value;
			}
			else
			{
				this.WhenWorkedStarted = viewModel.WhenWorkedStarted;
			}
			this.WhereDidYouWork = viewModel.WhereDidYouWork;
			this.WorkedForDoC = viewModel.WorkedForDoC;
		}
		#endregion
	}
}