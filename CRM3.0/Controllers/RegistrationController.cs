using iTextSharp.text.pdf;
using CRM3._0.Helpers;
using CRM3._0.Models;
using CRM3._0.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace CRM3._0.Controllers
{
    [Authorize]
    public class RegistrationController : DefaultController
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.BlankSelectDropdownList = _db.BlankSelectDropdownList;
            ViewBag.States = _db.StateList;
            ViewBag.Cities = _db.CityList;
            ViewBag.Prefixes = _db.Prefixes;
            ViewBag.Suffixes = _db.Suffixes;
            ViewBag.Genders = _db.Genders;
            ViewBag.Races = _db.Races;
            ViewBag.YesNoList = _db.YesNoList;

            if (TempData["Model"] != null)
            {
                var model = TempData["Model"] as RegistrationViewModel;

                return View(model);
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// This is the method that shows the view
        /// </summary>
        /// <returns></returns>
		public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// This method shows all of the current mentor applications in process
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult List()
        {
            var data = from r in this._db.MentorApplications
                       select r;

            return View();
        }

        /// <summary>
        /// This method handles the create form posting
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(RegistrationViewModel viewModel)
        {
            int mentorAppId = 0;

            if (viewModel.AgreeToTerms == 1)
            {
                // =================================================================
                // Save the mentor application details
                // =================================================================
                MentorApplication application = new MentorApplication(viewModel);
                application.RegistrationDate = DateTime.Now;

                this._db.MentorApplications.Add(application);
                this._db.SaveChanges();

                // We need to save the application id for use later
                mentorAppId = application.id;

                // =================================================================
                // Create the Person Record
                // =================================================================
                Person newPerson = new Person(viewModel);
                this._db.People.Add(newPerson);
                this._db.SaveChanges();

                // =================================================================
                // Addresses (Home address is the only one right now that we care about)
                // =================================================================
                Address newAddress = new Address(viewModel);
                this._db.Addresses.Add(newAddress);
                this._db.SaveChanges();

                // Add the address cross reference
                PersonAddress addrToPerson = new PersonAddress(newPerson.id,
                                                               newAddress.id,
                                                               DomainHelper.GetIdByKeyValue(ref this._db, "AddressType", "Home"));
                this._db.PersonToAddress.Add(addrToPerson);
                this._db.SaveChanges();

                // =================================================================
                // Phone Numbers
                // =================================================================
                Phone homePhone = new Phone(viewModel.HomePhone.CountryCode,
                                            viewModel.HomePhone.AreaCode,
                                            viewModel.HomePhone.PrefixCode,
                                            viewModel.HomePhone.SuffixCode);

                // Add the phone number to the database
                this._db.PhoneNumbers.Add(homePhone);
                this._db.SaveChanges();

                // Add the phone number cross reference
                PersonPhone personPhoneHome = new PersonPhone(homePhone.id,
                                                              newPerson.id,
                                                              DomainHelper.GetIdByKeyValue(ref this._db, "PhoneType", "Home"));

                this._db.PersonToPhone.Add(personPhoneHome);
                this._db.SaveChanges();

                // =================================================================
                // Phone Numbers
                // =================================================================
                Phone workPhone = new Phone(viewModel.WorkPhone.CountryCode,
                                            viewModel.WorkPhone.AreaCode,
                                            viewModel.WorkPhone.PrefixCode,
                                            viewModel.WorkPhone.SuffixCode);

                // Add the phone number to the database
                this._db.PhoneNumbers.Add(workPhone);
                this._db.SaveChanges();

                // Add the phone number cross reference
                PersonPhone personPhoneWork = new PersonPhone(workPhone.id,
                                                              newPerson.id,
                                                              DomainHelper.GetIdByKeyValue(ref this._db, "PhoneType", "Work"));

                this._db.PersonToPhone.Add(personPhoneWork);
                this._db.SaveChanges();
            }

            return RedirectToAction("Status", new { id = mentorAppId });
        }

        /// <summary>
        /// This method redirects the user to the status page
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Continue()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Status");
            }
            else
            {
                string url = this.Url.Action("Status", "Registration", null, this.Request.Url.Scheme);

                // User is not authenticated
                return RedirectToAction("Login", "Account", new { returnUrl = url });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="registrationId"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Status()
        {
            if (User.Identity.IsAuthenticated)
            {
                RegistrationViewModel viewModel =
                    RegistrationHelper.FindRegistration(ref this._db, User.Identity.Name);

                ViewBag.Prefix = (viewModel.PrefixId != 0)
                    ? DomainHelper.GetValueById(ref this._db, viewModel.PrefixId)
                    : "";

                ViewBag.Suffix = (viewModel.SuffixId != 0)
                    ? DomainHelper.GetValueById(ref this._db, viewModel.SuffixId)
                    : "";

                return View(viewModel);
            }
            else
            {
                // User is not authenticated
                return RedirectToAction("Login", "Account", new { ReturnUrl = Url.Content("~/Registration/Status") });
            }
        }

        /// <summary>
        /// Promote a mentor application
        /// </summary>
        /// <param name="id"></param>
        /// <param name="registrationStatusId"></param>
        /// <returns></returns>
        public JsonResult Promote(int id, int statusId)
        {
            string message = "failed";

            // Find the mentor application
            MentorApplication app = RegistrationHelper.GetMentorApplicationById(ref _db, id);
            if (app != null)
            {
                // Change the application status
                app.StatusId = statusId;

                // Save the application
                _db.SaveChanges();

                // Success
                message = "success";
            }

            return Json(message);
        }

        /// <summary>
        /// Demote a mentor application
        /// </summary>
        /// <param name="id"></param>
        /// <param name="registrationStatusId"></param>
        /// <returns></returns>
        public JsonResult Demote(int id, int statusId)
        {
            return Promote(id, statusId);
        }

        #region PDF Printing

        public ActionResult Forms(RegistrationViewModel applicant)
        {
            return View(applicant);
        }

        public ActionResult PrintJREC(RegistrationViewModel applicant)
        {
            try
            {
                // populate the value of each form field in the pdf form
                Dictionary<string, string> formFields = new Dictionary<string, string>
                {
                    {   "First",        applicant.FirstName                             },
                    {   "Name",         applicant.LastName                              },
                    {   "Middle",       applicant.MiddleInitial                         },
                    {   "Maiden",       applicant.LastName                              },
                    {   "Address",      applicant.HomeAddress.Street1                   },
                    {   "City",         applicant.HomeAddress.CityId.ToString()         },
                    {   "State",        applicant.HomeAddress.StateCode                 },
                    {   "ZIP_Code",     applicant.HomeAddress.PostalCode5.ToString()    },
                    {   "Telephone_1",  applicant.HomePhone.ToString()                  },
                };

                string fileName = "FL_DoC_Volunteer_Application.pdf";

                // we don't want the user to see "MyFormLetter.pdf" 
                // when they save the file, 
                // we want them to see "YourFormLetter.pdf" when they save the PDF
                // so we alias the name simply by passing it to another action 
                // named YourFormLetter

                // pass the file stream result to the alias action
                TempData["Application_FileStreamResult"] = GetPdfFileStreamResult(fileName, formFields);

                return RedirectToAction("YourApplication");
            }
            catch (Exception ex)
            {
                return HandleErrorForPopup(ex, applicant);
            }
        }

        public ActionResult PrintDoC(RegistrationViewModel applicant)
        {
            try
            {
                // populate the value of each form field in the pdf form
                Dictionary<string, string> formFields = new Dictionary<string, string>
                {
                    {   "First",        applicant.FirstName                             },
                    {   "Name",         applicant.LastName                              },
                    {   "Middle",       applicant.MiddleInitial                         },
                    {   "Maiden",       applicant.LastName                              },
                    {   "Address",      applicant.HomeAddress.Street1                   },
                    {   "City",         applicant.HomeAddress.CityId.ToString()         },
                    {   "State",        applicant.HomeAddress.StateCode                 },
                    {   "ZIP_Code",     applicant.HomeAddress.PostalCode5.ToString()    },
                    {   "Telephone_1",  applicant.HomePhone.ToString()                  },
                };

                string fileName = "FL_DoC_Volunteer_Application.pdf";

                // we don't want the user to see "MyFormLetter.pdf" 
                // when they save the file, 
                // we want them to see "YourFormLetter.pdf" when they save the PDF
                // so we alias the name simply by passing it to another action 
                // named YourFormLetter

                // pass the file stream result to the alias action
                TempData["Application_FileStreamResult"] = GetPdfFileStreamResult(fileName, formFields);

                return RedirectToAction("YourApplication");
            }
            catch (Exception ex)
            {
                return HandleErrorForPopup(ex, applicant);
            }
        }

        #region PDF Printing Helpers

        public FileStreamResult YourApplication()
        {
            return (FileStreamResult)TempData["Application_FileStreamResult"];
        }

        private FileStreamResult GetPdfFileStreamResult(string fileName, Dictionary<string, string> formFields)
        {
            MemoryStream memoryStream = GeneratePdf(fileName, formFields);

            // create a new return stream because the 
            // MemoryStream from the file is closed
            MemoryStream returnStream = new MemoryStream();
            returnStream.Write(memoryStream.GetBuffer(), 0,
            memoryStream.GetBuffer().Length);
            returnStream.Flush();

            // rewind stream back to beginning so it can be rendered to the page
            returnStream.Seek(0, SeekOrigin.Begin);

            return new FileStreamResult(returnStream, "application/pdf");
        }

        private MemoryStream GeneratePdf(string fileName, Dictionary<string, string> formFields)
        {
            string formFile = HttpContext.Server.MapPath("~/Content/Forms/" + fileName);
            PdfReader reader = new PdfReader(formFile);
            MemoryStream memoryStream = new MemoryStream();
            PdfStamper stamper = new PdfStamper(reader, memoryStream);
            AcroFields fields = stamper.AcroFields;

            // set form fields
            foreach (KeyValuePair<string, string> formField in formFields)
            {
                fields.SetField(formField.Key, formField.Value);
            }

            stamper.FormFlattening = true;
            // release file
            stamper.Close();
            reader.Close();

            return memoryStream;
        }

        [HttpGet]
        public ActionResult HandleErrorForPopup(Exception ex, object inputData)
        {
            // close the popup browser window and display the error in the parent window
            TempData["ErrorMessage"] = ex.Message;
            return RedirectToAction("ParentError");
        }

        [HttpGet]
        public ActionResult ParentError()
        {
            return View();
        }

        #endregion

        #endregion
    }
}
