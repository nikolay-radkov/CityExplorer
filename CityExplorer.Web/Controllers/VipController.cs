using AutoMapper;
using CityExplorer.Data;
using CityExplorer.Models;
using CityExplorer.Web.Infrastructure.ImageHandler;
using CityExplorer.Web.InputModels;
using CityExplorer.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CityExplorer.Web.Controllers
{
    public class VipController : BaseController
    {
        public VipController(ICityExplorerData data)
            : base(data)
        {

        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insert(int id, VipInputModel model)
        {
            if (ModelState.IsValid)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    model.Photo.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                    var path = ImageHandler.UploadImageToImgur(array);
                    
                    var vip = Mapper.Map<VIP>(model);
                    vip.CityId = id;
                    vip.Photo = path;

                    this.Data.VIPs.Add(vip);
                    this.Data.SaveChanges();
                }

                this.TempData["message"] = "VIP added";

                return RedirectToAction("Details", "City", new { id = id });
            }

            return View(model);
        }
    }
}