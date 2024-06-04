using CRM3._0.Helpers;
using CRM3._0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CRM3._0.Controllers
{
    [Authorize]
    public class ChaplainController : DefaultController
    {
        public ChaplainController()
        {
            ViewBag.Logs = ContactLogHelper.GetContactLogsByMentorId(ref this._db, _userId).Take(3);
            ViewBag.Messages = MessagingHelper.GetMessagesToUserId(ref this._db, _userId).Take(3);
            ViewBag.Events = CalendarHelper.GetEventsByUserId(ref this._db, _userId).Take(3);
            ViewBag.Resources = ResourceHelper.GetResources(ref this._db).Take(3);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ChaplainViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Good, continue
            }

            return View(viewModel);
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(ChaplainViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Good, continue
            }

            return View(viewModel);
        }

        public ActionResult Requests()
        {
            return View();
        }

        public ActionResult Approve()
        {
            return View();
        }

        public ActionResult Deny()
        {
            return View();
        }

        public ActionResult Reschedule()
        {
            return View();
        }

        public ActionResult Mentees()
        {
            return View();
        }
    }
}