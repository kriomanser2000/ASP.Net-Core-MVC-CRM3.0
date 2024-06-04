using CRM3._0.Helpers;
using CRM3._0.Models;
using CRM3._0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CRM3._0.Controllers
{
    [Authorize]
    public class MessagingController : DefaultController
    {
        public MessagingController()
        {
            ViewBag.UserId = AccountHelper.GetUserIdByUsername(ref this._db, WebSecurity.CurrentUserName);
            ViewBag.Users = AccountHelper.GetUserDropdownList(ref this._db);
            ViewBag.Inbox = MessagingHelper.GetMessagesToUserId(ref this._db, ViewBag.UserId);
            ViewBag.Outbox = MessagingHelper.GetMessagesFromUserId(ref this._db, ViewBag.UserId);
            ViewBag.YesNo = _db.YesNoList;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Inbox()
        {
            return View("Index");
        }

        public ActionResult Outbox()
        {
            return View();
        }

        // This method just returns the compose/create view
        public ActionResult Create()
        {
            return View();
        }

        // This method actually takes the form input and saves it to the database
        [HttpPost]
        public ActionResult Create(MessageViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var newMessage = new MMS.Models.Message(viewModel);
            newMessage.Created = DateTime.Now;

            this._db.Messages.Add(newMessage);

            this._db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult View(int id)
        {
            Message msg = (from r in this._db.Messages
                           where r.id == id
                           select r).FirstOrDefault();

            MessageViewModel viewModel = new MessageViewModel(ref this._db, msg);

            return View(viewModel);
        }

        #region REST Services

        [HttpGet]
        public JsonResult GetMessagesByUserId(int id)
        {
            var msg = from r in this._db.Messages
                      join p in this._db.UserProfiles on r.FromUserId equals p.id
                      where r.ToUserId == WebSecurity.CurrentUserId
                      select new MessageViewModel
                      {
                          MessageId = r.id,
                          FromUserId = r.FromUserId,
                          FromUser = p.Username,
                          ToUserId = r.ToUserId,
                          Created = r.Created,
                          IsFlashTraffic = r.IsFlashTraffic,
                          Subject = r.Subject,
                          Body = r.Body
                      };

            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
