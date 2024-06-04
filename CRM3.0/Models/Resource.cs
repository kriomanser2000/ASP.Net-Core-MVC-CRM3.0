using CRM3._0.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace CRM3._0.Models
{
	[Table("Resource")]
	public class Resource : BaseModel
	{
		#region Members
		public string Name { get; set; }
		public int Type { get; set; }
		public string Description { get; set; }
		public string Location { get; set; }
		public string RelativeUrl { get; set; }
		public DateTime UploadDate { get; set; }
		#endregion
		#region Constructors

		public Resource()
		{

		}
		#endregion
	}
}