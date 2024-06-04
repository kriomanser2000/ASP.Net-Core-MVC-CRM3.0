using CRM3._0.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRM3._0.ViewModels
{
	public class MessageViewModel
	{
		[Display(Name = "Message ID")]
		public int MessageId { get; set; }
		[Display(Name = "Message is Flash Traffic")]
		public bool IsFlashTraffic { get; set; }
		[Required, Display(Name = "From User")]
		public int FromUserId { get; set; }
		[Display(Name = "From User")]
		public string FromUser { get; set; }
		[Required, Display(Name = "To User")]
		public int ToUserId { get; set; }
		[Display(Name = "To User")]
		public string ToUser { get; set; }
		[Display(Name = "Created")]
		public DateTime Created { get; set; }
		[Display(Name = "Created")]
		public string CreatedString
		{
			get
			{
				return this.Created.ToString("MM/dd/yy H:mm:ss");
			}
		}
		[Required, Display(Name = "Message Subject")]
		public string Subject { get; set; }
		[Required, Display(Name = "Message Body")]
		public string Body { get; set; }
		public MessageViewModel()
		{

		}

		public MessageViewModel(ref DAO.ApplicationContext context, Message msg)
		{
			this.MessageId = msg.id;
			this.ToUserId = msg.ToUserId;
			this.ToUser = Helpers.AccountHelper.GetUsernameByUserId(ref context, msg.ToUserId).Username;
			this.FromUserId = msg.FromUserId;
			this.FromUser = Helpers.AccountHelper.GetUsernameByUserId(ref context, msg.FromUserId).Username;
			this.Created = msg.Created;
			this.Subject = msg.Subject;
			this.Body = msg.Body;
		}
	}
}