using CRM3._0.Helpers;
using CRM3._0.Models;
using CRM3._0.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CRM3._0.Controllers
{
    [Authorize]
    public class MenteeController : DefaultController
    {
        public MenteeController()
        {
            ViewBag.MenteesDropDownList = MentorHelper.GetMenteesDropdownList(ref this._db);
            ViewBag.MentorsDropDownList = MentorHelper.GetMentorsDropdownList(ref this._db);
            ViewBag.Mentees = MentorHelper.GetMentees(ref this._db);
            ViewBag.Mentors = MentorHelper.GetMentors(ref this._db);

            ViewBag.States = _db.StateList;
            ViewBag.Cities = _db.CityList;
            ViewBag.Prefixes = _db.Prefixes;
            ViewBag.Suffixes = _db.Suffixes;
            ViewBag.Genders = _db.Genders;
            ViewBag.Races = _db.Races;
            ViewBag.YesNoList = _db.YesNoList;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(MenteeViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Where(v => v.Value.Errors.Any());
                return View(viewModel);
            }

            // New person that represents the mentee
            Person mentee = new Person(viewModel.Mentee);

            // Make sure we set the user as Mentee
            mentee.PersonTypeId = DomainHelper.GetIdByKeyValue(ref this._db, "PersonType", "Mentee");
            mentee.StatusId = DomainHelper.GetIdByKeyValue(ref _db, "StatusCode", "Active");
            this._db.People.Add(mentee);

            // Home Address
            Address homeAddr = new Address(viewModel.HomeAddress);
            PersonAddress p2a = new PersonAddress(mentee.id, homeAddr.id, DomainHelper.GetIdByKeyValue(ref _db, "AddressType", "Home"));
            this._db.Addresses.Add(homeAddr);
            this._db.PersonToAddress.Add(p2a);

            // Save changes
            this._db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Person mentee = PersonHelper.GetPersonById(ref this._db, id);
            Address homeAddress = AddressHelper.GetAddressByPersonAndType(ref this._db, mentee.id, "Home");

            MenteeViewModel viewModel = new MenteeViewModel
            {
                Mentee = mentee,
                HomeAddress = homeAddress
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(MenteeViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Where(v => v.Value.Errors.Any());
                return View(viewModel);
            }

            // Find the existing Person object
            Person mentee = this._db.People.Find(viewModel.Mentee.id);
            if (mentee != null)
            {
                // Update the Person object with the new details
                mentee.Copy(viewModel.Mentee);
                mentee.PersonTypeId = DomainHelper.GetIdByKeyValue(ref this._db, "PersonType", "Mentee");
            }
            else
            {
                // New address record
                this._db.People.Add(new Person(viewModel.Mentee));
            }

            // Find the home address
            Address homeAddr = this._db.Addresses.Find(viewModel.HomeAddress.id);
            if (homeAddr != null)
            {
                homeAddr.Copy(homeAddr);
            }
            else
            {
                homeAddr = this._db.Addresses.Add(new Address(viewModel.HomeAddress));

                this._db.PersonToAddress.Add(
                    new PersonAddress(mentee.id,
                        homeAddr.id,
                        DomainHelper.GetIdByKeyValue(ref this._db, "AddressType", "Home")));
            }

            // Update the database
            this._db.SaveChanges();

            // Done, go back to the list of mentors
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int menteeId)
        {
            return View();
        }

        public ActionResult Assign()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Assign(Object viewModel)
        {
            return RedirectToAction("Index");
        }
    }
}
