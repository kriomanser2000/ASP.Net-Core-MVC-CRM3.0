using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations.Schema;

namespace CRM3._0.Models
{
	[Table("Domain")]
	public class Domain : BaseModel
	{
		#region Members
		public string Key { get; set; }
		public string Value { get; set; }
		#endregion
		#region Constructors
		public Domain()
		{

		}
		#endregion
	}

	[Table("MiscData")]
	public class MiscData : BaseModel
	{
		#region Members
		public string Key1 { get; set; }
		public string Key2 { get; set; }
		public string Key3 { get; set; }
		public string Data { get; set; }
		#endregion
		#region Constructors
		public MiscData()
		{

		}
		#endregion
	}
}
