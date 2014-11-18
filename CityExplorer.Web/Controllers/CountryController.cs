using AutoMapper;
using CityExplorer.Data;
using CityExplorer.Models;
using CityExplorer.Web.Infrastructure.ImageHandler;
using CityExplorer.Web.InputModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CityExplorer.Web.Controllers
{
    public class CountryController : BaseController
    {
        public CountryController(ICityExplorerData data)
            : base(data)
        {
            
        }

        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insert(int id, CountryInputModel model)
        {
            if (ModelState.IsValid)
            {
                var newId = 0;
                using (MemoryStream ms = new MemoryStream())
                {
                    model.Photo.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                    var path = ImageHandler.UploadImageToImgur(array);

                    var country = Mapper.Map<Country>(model);
                    country.ContinentId = id;
                    country.Image = path;

                    this.Data.Countries.Add(country);
                    this.Data.SaveChanges();

                    newId = country.Id;
                }

                this.TempData["message"] = "Country added";

                return RedirectToAction("Cities", "Home", routeValues: new { countryId = newId });
            }
        
            return View(model);
        }
    }
}