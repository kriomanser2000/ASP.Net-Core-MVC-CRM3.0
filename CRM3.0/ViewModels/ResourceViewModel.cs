using CRM3._0.Helpers;
using CRM3._0.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRM3._0.ViewModels
{
	public class ResourceViewModel
	{
		public int id { get; set; }
		[Display(Name = "Resource Name")]
		public string Name { get; set; }
		[Display(Name = "Resource Type")]
		public int Type { get; set; }
		[Display(Name = "Resource Type")]
		public string DocumentType { get; set; }
		[Display(Name = "Resource Description")]
		public string Description { get; set; }
		[Display(Name = "Resource Location")]
		public string Location { get; set; }
		[Display(Name = "Relative URL to Resource")]
		public string RelativeUrl { get; set; }
		[Display(Name = "Upload Date")]
		public DateTime UploadDate { get; set; }
		public ResourceViewModel()
		{
		}

		public ResourceViewModel(Resource myResource)
		{
			this.id = myResource.id;
			this.Name = myResource.Name;
			this.Location = myResource.Location;
			this.RelativeUrl = myResource.RelativeUrl;
			this.Type = myResource.Type;
			this.UploadDate = myResource.UploadDate;
		}
	}
}