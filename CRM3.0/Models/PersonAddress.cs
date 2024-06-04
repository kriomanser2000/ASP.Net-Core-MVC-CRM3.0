﻿using CRM3._0.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRM3._0.Models
{
	[Table("PersonAddress")]
	public class PersonAddress : BaseModel
	{
		[DisplayName("Person")]
		public int PersonId { get; set; }
		[DisplayName("Address")]
		public int AddressId { get; set; }
		[DisplayName("Address Type")]
		public int AddressType { get; set; }
		public PersonAddress()
		{

		}
		public PersonAddress(int personId, int addressId, int addressType)
		{
			this.PersonId = personId;
			this.AddressId = addressId;
			this.AddressType = addressType;
		}
	}
}