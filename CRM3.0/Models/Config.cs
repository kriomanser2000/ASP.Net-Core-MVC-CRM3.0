using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRM3._0.Models
{
	[Table("Config")]
	public class Config
	{
		[Key, Column(Order = 0)]
		public string Key { get; set; }
		[Key, Column(Order = 1)]
		public string Value { get; set; }
	}
}