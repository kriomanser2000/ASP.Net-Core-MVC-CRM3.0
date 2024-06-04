using CRM3._0.Models;
using CRM3._0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM3._0.Models;
using CRM3._0.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CRM3._0.Controllers
{
    public class MinistryController : DefaultController
    {
        public MinistryController()
        {
            ViewBag.Mentors = Helpers.MentorHelper.GetMentorsDropdownList(ref this._db);
            ViewBag.States = _db.StateList;
            ViewBag.Cities = _db.CityList;
            ViewBag.Ministries = _db.Ministries;
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
        public ActionResult Create(MinistryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Create a new ministry object
                Ministry myMinistry = new Ministry(viewModel);

                // Create or update a new address record
                Address myAddress = _db.Addresses.Add(viewModel.Address);

                // Update the AddressFK in the ministry object
                myMinistry.AddressId = myAddress.id;

                // Add the ministry to the dataset
                this._db.Ministries.Add(myMinistry);

                // Update the database
                this._db.SaveChanges();

                // We are done, lets get outahere
                Response.Redirect("~/Ministry");
            }
            else
            {
                var errors = ModelState.Where(v => v.Value.Errors.Any());
            }

            return View(viewModel);
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(MinistryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Ministry myMinistry = this._db.Ministries.Find(viewModel.MinistryId);
                if (myMinistry != null)
                {
                    myMinistry.MinistryName = viewModel.Name;
                    myMinistry.MainPhoneId = viewModel.PhoneId;
                    myMinistry.LeadMentorId = viewModel.LeadMentorId;
                    myMinistry.Description = viewModel.Description;
                    myMinistry.AddressId = viewModel.AddressId;

                    _db.SaveChanges();

                    Response.Redirect("~/Staff");
                }
            }

            return View(viewModel);
        }
    }
}
