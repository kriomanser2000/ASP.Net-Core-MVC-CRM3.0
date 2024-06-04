using CRM3._0.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM3._0.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRM3._0.Controllers
{
    public class HomeController : DefaultController
    {
        public HomeController()
        {

        }

        public HomeController(IConfiguration config)
        {
            this._config = config;
        }

        public ActionResult Index()
        {
            ViewBag.UserRole = Helpers.AccountHelper.GetUserRoleByUsername(ref this._db, User.Identity.Name);

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}