using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using CRM3._0.Helpers;
using CRM3._0.Models;
using CRM3._0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

using Microsoft.AspNetCore.Mvc;
using Azure.Core;
using Azure;
using Microsoft.AspNetCore.Authorization;

namespace CRM3._0.Controllers
{
    [Authorize]
    public class AccountController : DefaultController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpGet, AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost, AllowAnonymous]
        public ActionResult Register(NewUserViewModel viewModel)
        {
            // Log any logged-in user out
            this.ClearSession();

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            // Create the new user profile
            UserProfile profile = new UserProfile();

            profile.Username = viewModel.Username;
            profile.Salt = CryptHelper.CreateSalt(256);
            profile.Password = CryptHelper.CreatePasswordHash(viewModel.Password, profile.Salt);
            profile.RoleId = DomainHelper.GetIdByKeyValue(ref this._db, "PersonType", "Mentor");
            profile.CanBeDeleted = true;

            // Add the profile to the dataset
            this._db.UserProfiles.Add(profile);

            // Save the changes
            this._db.SaveChanges();

            // Let the user in
            FormsAuthentication.SetAuthCookie(profile.Username, true);

            // Send the user on to the registration page
            return RedirectToAction("Index", "Registration");
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            // This method is called when the user is prompted to enter
            // their username and password.  Once the user enters their credentials
            // the overloaded version of this method is called with the viewmodel
            ViewBag.ReturnUrl = Request.UrlReferrer;

            return View();
        }

        [HttpGet, AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (returnUrl != null)
                ViewBag.ReturnUrl = returnUrl;
            else
                ViewBag.ReturnUrl = Request.UrlReferrer;

            return View();
        }

        // This is the overloaded version of the Login function
        // and is called only when the user has submitted their security credentials on
        // the login form; otherwise, the other version of this method is called
        // to present them with a blank version of the security credentials form
        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel viewModel, string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            // This method is called when the user has submitted their security credentials
            if (ModelState.IsValid)
            {
                // Here is where we need to check security credentials

                // 1. Find the user in the database
                var user = (from r in this._db.UserProfiles
                            where r.Username == viewModel.Username
                            select r).First();

                if (user != null)
                {
                    // 2. Validate the user's password: to do this we have to calculate the user's 
                    // supplied password has with the user's saved salt
                    string hash = CryptHelper.CreatePasswordHash(viewModel.Password, user.Salt);

                    // 3. Now, we have to compare the new hash with the stored hash
                    if (user.Password.Equals(hash))
                    {
                        // 4.  Success!  This is the right user
                        // 5.  Now, we need to create a session state cookie.
                        FormsAuthentication.SetAuthCookie(viewModel.Username, true);

                        // 6.  Send the user on their way!
                        return RedirectToLocal(returnUrl);
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");

            // Send them back to the login form
            return View(viewModel);
        }

        [HttpGet, AllowAnonymous]
        public JsonResult Find(string id)
        {
            var data = from r in _db.UserProfiles
                       where r.Username == id
                       select r;

            var result = (data.Count() == 0) ? "available" : "unavailable";

            var message = new
            {
                message = result
            };

            return Json(message, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult Reset()
        {
            return View();
        }

        public ActionResult Manage()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Logout()
        {
            // Here is where we need to log the user out and delete any cookies
            this.ClearSession();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            // Here is where we need to log the user out and delete any cookies
            this.ClearSession();

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult ClearSession()
        {
            // clear authentication cookie
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie1);

            // clear session cookie (not necessary for your current problem but i would recommend you do it anyway)
            HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie2);

            // Signout!
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            System.Uri uri = new Uri(returnUrl);

            if (Url.IsLocalUrl(uri.PathAndQuery))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
