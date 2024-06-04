using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM3._0.Controllers
{
    [Authorize]
    public class FacilityController : Controller
    {
        public FacilityController()
        {

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

        public ActionResult Edit(Object viewModel)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Object viewModel)
        {
            if (ModelState.IsValid)
            {

            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Delete(int facilityId)
        {
            return View();
        }
    }
}