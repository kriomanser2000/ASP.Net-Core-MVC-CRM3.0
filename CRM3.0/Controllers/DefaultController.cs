using CRM3._0.DAO;
using CRM3._0.Helpers;
using CRM3._0.Models;
using CRM3._0.ViewModels;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CRM3._0.Controllers
{
    public class DefaultController : Controller
    {
        protected ApplicationContext _db = new ApplicationContext();
        protected IConfiguration _config;
        protected int _userId;
        protected string _userName;

        public DefaultController()
        {
            ViewBag.YesNo = this._db.YesNoList;
            ViewBag.BlankDropdown = this._db.BlankSelectDropdownList;
            ViewBag.Mentors = Helpers.MentorHelper.GetMentorsDropdownList(ref this._db);
            ViewBag.Mentees = Helpers.MentorHelper.GetMenteesDropdownList(ref this._db);
        }

        public bool UserIsAuthorized(string username, string rolename)
        {
            bool bReturn = false;

            string roleFromDb = Helpers.AccountHelper.GetUserRoleByUsername(ref this._db, username);

            if (rolename == roleFromDb)
                bReturn = true;

            return bReturn;
        }

        [HttpGet, AllowAnonymous]
        public JsonResult Cities(CitiesViewModel viewModel)
        {
            var cities = (from r in this._db.Cities
                          where r.StateCode == viewModel._value
                          select r).ToDictionary(x => x.id.ToString(), x => x.Name);

            cities.Add("0", "Please select ...");

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string html = "[" + serializer.Serialize(cities) + "]";

            return Json(html, JsonRequestBehavior.AllowGet);
        }

        protected override void OnActionExecuted(ActionExecutedContext ctx)
        {
            base.OnActionExecuted(ctx);

            if (HttpContext.User.Identity.Name != "")
            {
                _userId = AccountHelper.GetUserIdByUsername(ref _db, HttpContext.User.Identity.Name);
                _userName = HttpContext.User.Identity.Name;

                ViewData["IsAuthenticated"] = HttpContext.Request.IsAuthenticated;
            }
        }
    }
}
