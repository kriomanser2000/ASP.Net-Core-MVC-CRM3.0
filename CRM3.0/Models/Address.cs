using CRM3._0.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRM3._0.Models
{
	[Table("Address")]
	public class Address : BaseModel
	{
		#region Members
		[DisplayName("Street Address 1")]
		public string Street1 { get; set; }
		[DisplayName("Street Address 2")]
		public string Street2 { get; set; }
		[DisplayName("City")]
		public int CityId { get; set; }
		public int StateId { get; set; }
		[DisplayName("State")]
		public string StateCode { get; set; }
    	[DisplayName("Postal Code")]
		public int PostalCode5 { get; set; }
		#endregion
		#region Constructors

		public Address()
		{

		}

		public Address(Address address)
		{
			this.id = address.id;
			this.Street1 = address.Street1;
			this.Street2 = address.Street2;
			this.CityId = address.CityId;
			this.StateId = address.StateId;
			this.PostalCode5 = address.PostalCode5;
		}

		public Address(RegistrationViewModel viewModel)
		{
			this.Street1 = viewModel.HomeAddress.Street1;
			this.Street2 = viewModel.HomeAddress.Street2;
			this.CityId = viewModel.HomeAddress.CityId;
			this.StateId = viewModel.HomeAddress.StateId;
			this.PostalCode5 = viewModel.HomeAddress.PostalCode5;
		}

		public void Copy(Address address)
		{
			this.id = address.id;
			this.Street1 = address.Street1;
			this.Street2 = address.Street2;
			this.CityId = address.CityId;
			this.StateId = address.StateId;
			this.PostalCode5 = address.PostalCode5;
		}
		#endregion
	}
}