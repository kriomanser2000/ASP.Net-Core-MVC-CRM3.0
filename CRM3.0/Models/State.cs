using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM3._0.Models
{
	[Table("State")]
	public class State : BaseModel
	{
		#region Members
		public string StateCode { get; set; }
		public string Name { get; set; }
		#endregion
		#region Constructors

		public State()
		{

		}
		#endregion
	}
}