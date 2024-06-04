using System;
using System.Linq;
using System.Web.Mvc;
using CRM3._0.Models;
using CRM3._0.ViewModels;
using CRM3._0.Helpers;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CRM3._0.Controllers
{
    [Authorize]
    public class CalendarController : DefaultController
    {
        public CalendarController()
        {
            this.ViewBag.ContactType = this._db.ContactTypes;
            this.ViewBag.EventType = this._db.EventTypes;
            this.ViewBag.Events = this._db.Events;

            Mapper.CreateMap<EventViewModel, CalendarEvent>();
            Mapper.CreateMap<CalendarEvent, EventViewModel>();
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet, AllowAnonymous]
        public JsonResult List()
        {
            var events = from r in _db.Events
                         select r;

            var url = (User.Identity.IsAuthenticated)
                          ? Url.Content("~/Calendar/Edit/")
                          : Url.Content("~/Calendar/View/");

            var eventList = (from e in events
                             select e).AsEnumerable()
                            .Select(e => new EventListViewModel
                            {
                                id = e.id,
                                title = e.EventName,
                                start = e.EventBegins.ToString("s"),
                                end = e.EventEnds.ToString("s"),
                                allDay = (e.AllDayEvent == 1) ? "true" : "false",
                                url = url + e.id
                            }).ToList();

            //var rows = eventList.ToArray();

            return Json(eventList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet, AllowAnonymous]
        public JsonResult ListBetweenDates(double start, double end)
        {
            var fromDate = Helpers.CommonUtils.ConvertFromUnixTimestamp(start);
            var toDate = Helpers.CommonUtils.ConvertFromUnixTimestamp(end);

            var events = (from r in _db.Events
                          where r.EventBegins >= fromDate
                          where r.EventEnds <= toDate
                          select r).ToList();

            var url = (User.Identity.IsAuthenticated)
                          ? Url.Content("~/Calendar/Edit/")
                          : Url.Content("~/Calendar/View/");

            var eventList = from e in events
                            select new EventListViewModel
                            {
                                id = e.id,
                                title = e.EventName,
                                start = e.EventBegins.ToString("s"),
                                end = e.EventEnds.ToString("s"),
                                allDay = (e.AllDayEvent == 1) ? "true" : "false",
                                url = url + e.id
                            };

            var rows = eventList.ToArray();

            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult Manage()
        {
            var calendarEvents = this._db.Events;
            if (calendarEvents != null)
            {
                var events = from r in calendarEvents
                             select r;

                this.ViewBag.Events = events;
            }

            return this.View();
        }

        [AllowAnonymous]
        public ActionResult View(int id)
        {
            var myEvent = _db.Events.Find(id);
            if (myEvent != null)
            {
                var viewModel = Mapper.Map<CalendarEvent, EventViewModel>(myEvent);
                return this.View(viewModel);
            }

            return this.View("Edit");
        }

        // This is a get - comes here first
        [Authorize]
        public ActionResult Create()
        {
            return this.View();
        }

        // This accepts the http post
        [HttpPost, Authorize]
        public ActionResult Create(EventViewModel viewModel)
        {
            IEnumerable<KeyValuePair<string, ModelState>> errors;

            if (!ModelState.IsValid)
            {
                errors = ModelState.Where(v => v.Value.Errors.Any());

                return this.View(viewModel);
            }


            CalendarEvent newEvent = Mapper.Map<EventViewModel, CalendarEvent>(viewModel);

            this._db.Events.Add(newEvent);
            this._db.SaveChanges();

            return RedirectToAction("Manage");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var myEvent = _db.Events.Find(id);
            if (myEvent != null)
            {
                EventViewModel viewModel = new EventViewModel(myEvent);

                return this.View(viewModel);
            }

            return this.View();
        }

        [HttpPost, Authorize]
        public ActionResult Edit(EventViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // The model is good, so lets update the appropriate object
                var myEvent = this._db.Events.Find(viewModel.id);
                if (myEvent != null)
                {
                    //myEvent = Mapper.Map<EventViewModel, CalendarEvent>(viewModel);
                    myEvent.Copy(viewModel);

                    // Update the db
                    this._db.SaveChanges();

                    this.Response.Redirect("~/Calendar");
                }
                else
                {
                    return this.View("Edit", viewModel);
                }
            }

            return this.View("Edit", viewModel);
        }

        [HttpPost, Authorize]
        public ActionResult Delete(int id)
        {
            var bSuccess = false;
            var message = "failed";

            // Find the event
            var myEvent = this._db.Events.Find(id);
            if (myEvent != null)
            {
                // Delete the event
                var deleted = this._db.Events.Remove(myEvent);
                if (deleted != null)
                {
                    this._db.SaveChanges();

                    bSuccess = true;
                    message = "success";
                }
            }

            return Json(new
            {
                Success = bSuccess,
                Message = message
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Specific(int id)
        {
            switch (id)
            {
                case 25: // Public
                    ViewBag.Events = CalendarHelper.GetPublicEvents(ref _db);
                    break;
                case 26: // Training
                    ViewBag.Events = CalendarHelper.GetTrainingEvents(ref _db);
                    break;
                case 27: // Mentee Meeting Request
                    ViewBag.Events = CalendarHelper.GetMenteeMeetingRequests(ref this._db, 1);
                    break;
                case 28: // Mentor Meeting Request
                    ViewBag.Events = CalendarHelper.GetEventsForMentor(ref this._db, 1);
                    break;
            }

            return View();
        }
    }
}