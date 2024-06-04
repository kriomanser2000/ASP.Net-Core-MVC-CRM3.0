using System.Linq;
using System.Web.Mvc;
using CRM3._0.Models;
using CRM3._0.ViewModels;
using CRM3._0.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CRM3._0.Controllers
{
    [Authorize]
    public class MentorController : DefaultController
    {
        public MentorController()
        {
            ViewBag.UserId = base._userId;
            ViewBag.Logs = ContactLogHelper.GetContactLogsByMentorId(ref this._db, _userId).Take(3);
            ViewBag.Messages = MessagingHelper.GetMessagesToUserId(ref this._db, _userId).Take(3);
            ViewBag.Events = CalendarHelper.GetEventsByUserId(ref this._db, _userId).Take(3);
            ViewBag.Resources = ResourceHelper.GetResources(ref this._db).Take(3);
            ViewBag.Mentees = MentorHelper.GetMenteesDropdownList(ref this._db);
            ViewBag.Ministries = MinistryHelper.GetMinistriesDropdownList(ref this._db);
            ViewBag.ContactTypes = this._db.ContactTypes;
            ViewBag.Ministries = _db.MinistriesList;
            ViewBag.States = _db.StateList;
            ViewBag.Cities = _db.CityList;
            ViewBag.Prefixes = _db.Prefixes;
            ViewBag.Suffixes = _db.Suffixes;
            ViewBag.Genders = _db.Genders;
            ViewBag.Races = _db.Races;
            ViewBag.YesNoList = _db.YesNoList;

            Mapper.CreateMap<ContactLog, ContactLogViewModel>();
            Mapper.CreateMap<ContactLogViewModel, ContactLog>();
        }

        public ActionResult Index()
        {
            return this.View();
        }

        // This is a staff-only method
        public ActionResult List()
        {
            var data = MentorHelper.GetMentors(ref _db);

            ViewBag.Mentors = data.ToList();

            return View();
        }

        #region Create

        // This method returns the Create View
        public ActionResult Create()
        {
            return View();
        }

        // This method actually populates the database with the new Mentor
        [HttpPost]
        public ActionResult Create(MentorViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Go forward    
                Person mentor = new Person(viewModel.Person);
                Address homeAddr = new Address(viewModel.HomeAddress);
                Address workAddr = new Address(viewModel.WorkAddress);

                // Update some codes
                mentor.PersonTypeId = DomainHelper.GetIdByKeyValue(ref _db, "PersonType", "Mentor");
                mentor.StatusId = DomainHelper.GetIdByKeyValue(ref _db, "StatusCode", "Active");

                // Add the objects to the database
                this._db.People.Add(mentor);
                this._db.Addresses.Add(homeAddr);
                this._db.Addresses.Add(workAddr);

                // Save the data
                this._db.SaveChanges();

                return RedirectToAction("Create");
            }
            else
            {
                var errors = ModelState.Where(v => v.Value.Errors.Any());
            }

            return View(viewModel);
        }

        #endregion

        #region Editing

        // This method returns the Edit View
        public ActionResult Edit(int id)
        {
            MentorViewModel viewModel = MentorHelper.GetMentorById(ref _db, id);

            return View(viewModel);
        }

        // This method actually updates the database with the changes to the mentor
        [HttpPost]
        public ActionResult Edit(MentorViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Go forward
            }

            return View(viewModel);
        }

        #endregion

        #region Other

        public ActionResult Schedule()
        {
            return View();
        }

        public ActionResult Message()
        {
            return View();
        }

        public ActionResult Feedback()
        {
            return View();
        }

        public ActionResult FrequentlyAskedQuestions()
        {
            return View();
        }

        public ActionResult UpdateProfile()
        {
            return View();
        }

        #endregion

        #region Contact Logging

        public ActionResult Log(int? id)
        {
            if (id != null)
            {
                var viewModel = new ContactLogViewModel(_db.ContactLogs.Find(id));
                return View(viewModel);
            }
            return this.View();
        }

        [HttpPost]
        public ActionResult Log(ContactLogViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(viewModel);
            }
            else
            {
                if (viewModel.ContactLogId > 0)
                {
                    ContactLog foundLog = _db.ContactLogs.Find(viewModel.ContactLogId);
                    foundLog.Copy(viewModel);
                }
                else
                {
                    var newLog = new ContactLog(viewModel);
                    this._db.ContactLogs.Add(newLog);
                }

                this._db.SaveChanges();

                Response.Redirect("~/Mentor");
            }

            return this.View();
        }

        [HttpGet]
        public ActionResult Logs()
        {
            if (Request.ContentType == "application/json")
            {
                var logs = from r in _db.ContactLogs
                           select r;

                return Json(logs, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ViewBag.Logs = ContactLogHelper.GetContactLogs(ref _db);

                return View();
            }
        }

        [HttpDelete]
        public JsonResult DeleteLog(int id)
        {
            var bSuccess = false;
            var message = "failed";

            // Find the event
            var myLog = this._db.ContactLogs.Find(id);
            if (myLog != null)
            {
                // Delete the event
                var deleted = this._db.ContactLogs.Remove(myLog);
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

        #endregion
    }
}
