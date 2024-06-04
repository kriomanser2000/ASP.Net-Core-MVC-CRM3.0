using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using CRM3._0.Helpers;

namespace CRM3._0.Models
{
	public enum Daypart
	{
		Morning,
		Afternoon,
		Evening
	};
	public enum Weekday
	{
		Monday,
		Tuesday,
		Wednesday,
		Thursday,
		Friday,
		Saturday,
		Sunday
	};

	[Table("MentorAvailability")]
	public class MentorAvailability : BaseModel
	{
		#region Members
		public int MentorId { get; set; }
		public Weekday Day { get; set; }
		public Daypart Time { get; set; }
		#endregion
		#region Constructors

		public MentorAvailability()
		{

		}
		#endregion
	}
}