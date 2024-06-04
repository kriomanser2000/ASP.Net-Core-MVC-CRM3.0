using CRM3._0.ViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM3._0.Models
{
	[Table("Ministry")]
	public class Ministry : BaseModel
	{
		#region Members
		[DisplayName("Ministry Name")]
		public string MinistryName { get; set; }
		[DisplayName("Address")]
		public int AddressId { get; set; }
		[DisplayName("Lead Mentor")]
		public int LeadMentorId { get; set; }
		[DisplayName("Description")]
		public string Description { get; set; }
		[DisplayName("Main Phone")]
		public int MainPhoneId { get; set; }
		#endregion
		#region Constructors

		public Ministry()
		{

		}

		public Ministry(Ministry ministry)
		{
			id = ministry.id;
			MinistryName = ministry.MinistryName;
			AddressId = ministry.AddressId;
			LeadMentorId = ministry.LeadMentorId;
			Description = ministry.Description;
			MainPhoneId = ministry.MainPhoneId;
		}

		public Ministry(MinistryViewModel viewModel)
		{
			id = viewModel.MinistryId;
			MinistryName = viewModel.Name;
			AddressId = viewModel.AddressId;
			LeadMentorId = viewModel.LeadMentorId;
			Description = viewModel.Description;
			MainPhoneId = viewModel.PhoneId;
		}
		#endregion
	}
}