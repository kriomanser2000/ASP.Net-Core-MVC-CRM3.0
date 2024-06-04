using CRM3._0.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRM3._0.Models
{
	[Table("Message")]
	public class Message : BaseModel
	{
		#region Members
		public bool IsFlashTraffic { get; set; }
		public int FromUserId { get; set; }
		public int ToUserId { get; set; }
		public DateTime Created { get; set; }
		public string Subject { get; set; }
		public string Body { get; set; }
		#endregion
		#region Constructors
		public Message()
		{

		}

		public Message(MessageViewModel viewModel)
		{
			this.Copy(viewModel);
		}

		public void Copy(MessageViewModel viewModel)
		{
			this.id = viewModel.MessageId;
			this.IsFlashTraffic = viewModel.IsFlashTraffic;
			this.FromUserId = viewModel.FromUserId;
			this.ToUserId = viewModel.ToUserId;
			this.Subject = viewModel.Subject;
			this.Body = viewModel.Body;
			this.Created = viewModel.Created;
		}
		#endregion
	}
}