using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM3._0.Models
{
	[Table("City")]
	public class City : BaseModel
	{
		#region Members
		public string Name { get; set; }
		public string StateCode { get; set; }
		#endregion
		#region Constructors
		public City()
		{

		}
		#endregion
	}

	[Table("CityExtended")]
	public class CityExtended : BaseModel
	{
		#region Members
		public string StateCode { get; set; }
		public string Name { get; set; }
		public int ZipCode { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public string County { get; set; }
		#endregion
		#region Constructors
		public CityExtended()
		{

		}
		#endregion
	}
}