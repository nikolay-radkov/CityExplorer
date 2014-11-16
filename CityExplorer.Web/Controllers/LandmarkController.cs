namespace CityExplorer.Web.Controllers
{
    using AutoMapper;
    using CityExplorer.Data;
    using CityExplorer.Models;
    using CityExplorer.Web.Infrastructure.ImageHandler;
    using CityExplorer.Web.InputModels;
    using CityExplorer.Web.ViewModels;
    using System.IO;
    using System.Web;
    using System.Web.Mvc;

    public class LandmarkController : BaseController
    {
        public LandmarkController(ICityExplorerData data)
            : base(data)
        {

        }


        public ActionResult Index(int id)
        {
            var landmark = this.Data.Places.GetById(id);

            var landmarkViewModel = Mapper.Map<LandmarkViewModel>(landmark);

            return View(landmarkViewModel);
        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insert(int id, LandmarkInputModel model)
        {
            if (ModelState.IsValid)
            {
                var newId = 0;
                using (MemoryStream ms = new MemoryStream())
                {
                    model.Photo.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                    var path = ImageHandler.UploadImageToImgur(array);
                    var image = new Photo
                    {
                        Url = path,
                        PlaceId = id
                    };

                    var landmark = Mapper.Map<Place>(model);
                    landmark.CityId = id;
                    landmark.Photos.Add(image);

                    this.Data.Places.Add(landmark);
                    this.Data.SaveChanges();

                    newId = landmark.Id;
                }
                return RedirectToAction("Index", "Landmark", new { id = newId });

            }

            return View(model);
        }

        [HttpGet]
        public ActionResult AddPhoto(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPhoto(int id, HttpPostedFileBase file)
        {
            if (file != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                    var path = ImageHandler.UploadImageToImgur(array);
                    var image = new Photo
                    {
                        Url = path,
                        PlaceId = id
                    };

                    this.Data.Photos.Add(image);
                    this.Data.SaveChanges();
                }
            }

            return RedirectToAction("Index", "Landmark", new { id = id });
        }

    }
}