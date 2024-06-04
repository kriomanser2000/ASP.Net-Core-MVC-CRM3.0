using CRM3._0.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRM3._0.Models
{
	[Table("Phone")]
	public class Phone : BaseModel
	{
		#region Members
		public string CountryCode { get; set; }
		public string AreaCode { get; set; }
		public string PrefixCode { get; set; }
		public string SuffixCode { get; set; }
		#endregion
		#region Constructors
		public Phone()
		{

		}

		public Phone(Phone myPhone)
		{
			this.id = myPhone.id;
			this.CountryCode = myPhone.CountryCode;
			this.AreaCode = myPhone.AreaCode;
			this.PrefixCode = myPhone.PrefixCode;
			this.SuffixCode = myPhone.SuffixCode;
		}

		public Phone(string countryCode, string areaCode, string prefix, string suffix)
		{
			this.CountryCode = countryCode;
			this.AreaCode = areaCode;
			this.PrefixCode = prefix;
			this.SuffixCode = suffix;
		}
		#endregion
	}
}