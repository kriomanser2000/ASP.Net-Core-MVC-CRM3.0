using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRM3._0.Models
{
	[Table("Facility")]
	public class Facility : BaseModel
	{
		#region Members
		public string FacilityName { get; set; }
		public int AddressId { get; set; }
		public int PhoneId { get; set; }
		public int ChaplainId { get; set; }
		#endregion
		#region Constructors
		public Facility()
		{

		}
		#endregion
	}
}