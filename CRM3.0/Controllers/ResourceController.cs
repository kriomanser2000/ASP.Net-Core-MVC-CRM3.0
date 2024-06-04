using AutoMapper;
using CRM3._0.Helpers;
using CRM3._0.Models;
using CRM3._0.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting.Server;

namespace CRM3._0.Controllers
{
    //[Authorize]
    public class ResourceController : DefaultController
    {
        public ResourceController()
        {
            ViewBag.ResourceTypes = this._db.ResourceTypes;
            ViewBag.Resources = ResourceHelper.GetResources(ref this._db);

            Mapper.CreateMap<Resource, ResourceViewModel>();
            Mapper.CreateMap<ResourceViewModel, Resource>();
        }

        /*
		 * This is the default method for the controller
		 */
        public ActionResult Index()
        {
            return View();
        }

        /*
		 * This method is the default method called when a user
		 * first views the Add resource screen.
		 */
        public ActionResult Create()
        {
            return View();
        }

        /*
		 * This Add method is the one when the user posts their
		 * new resource details to the server
		 */
        [HttpPost]
        public ActionResult Create(ResourceViewModel viewModel)
        {
            string returnMessage = "Failed to upload/save the resource!";

            // Upload the resource first, if successful, 
            // then save the data to the database
            viewModel.Location = Upload(Request);

            // This is the relative download link for the file
            viewModel.RelativeUrl = "~/Uploads/" + System.IO.Path.GetFileName(viewModel.Location);

            if (viewModel.Location.Length > 0)
            {
                viewModel.UploadDate = DateTime.Now;

                // Create and map the appropriate object
                Resource myResource = Mapper.Map<ResourceViewModel, Resource>(viewModel);

                // Save the information to the database
                this._db.Resources.Add(myResource);
                this._db.SaveChanges();

                returnMessage = "Successfully uploaded the resource.";
            }

            return Json(returnMessage);
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Edit(ResourceViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Good, continue
            }

            return View(viewModel);
        }

        public ActionResult View(int id)
        {
            Resource myResource = this._db.Resources.Find(id);

            ResourceViewModel viewModel = Mapper.Map<Resource, ResourceViewModel>(myResource);

            return View(viewModel);
        }

        private string Upload(HttpRequestBase request)
        {
            string location = "";

            for (int i = 0; i < request.Files.Count; i++)
            {
                // Uploaded file
                HttpPostedFileBase file = request.Files[i];

                // Use the following properties to get file's name, size and MIMEType
                int fileSize = file.ContentLength;
                string fileName = file.FileName;
                string mimeType = file.ContentType;
                Stream fileContent = file.InputStream;
                string basePath = "~/Uploads/";

                // Define the initial file path/name
                string filePath = Server.MapPath(basePath + fileName);

                if (System.IO.File.Exists(filePath))
                {
                    // Change the name of the file to something different
                    System.IO.FileInfo fInfo = new System.IO.FileInfo(filePath);

                    filePath = Server.MapPath(basePath + fileName + "_" + DateTime.Now.ToFileTime() + fInfo.Extension);
                }

                // To save file, use SaveAs method
                file.SaveAs(filePath);

                // Make sure the file is there
                if (System.IO.File.Exists(filePath))
                {
                    // Success!
                    location = filePath;
                }
            }

            return location;
        }
    }
}