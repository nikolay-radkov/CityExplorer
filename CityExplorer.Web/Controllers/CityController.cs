using CityExplorer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using CityExplorer.Web.ViewModels;
using CityExplorer.Models;
using CityExplorer.Web.InputModels;

namespace CityExplorer.Web.Controllers
{
    public class CityController : BaseController
    {
        public CityController(ICityExplorerData data)
            : base(data)
        {

        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var city = this.Data.Cities.GetById(id);
            var cityViewModel = Mapper.Map<CityViewModel>(city);

            return View(cityViewModel);
        }

        public ActionResult Information(int id)
        {
            var city = this.Data.Cities.GetById(id);
            var cityViewModel = Mapper.Map<CityInformationViewModel>(city);

            return PartialView("_Information", cityViewModel);
        }

        public ActionResult Landmarks(int id)
        {
            var city = this.Data.Cities.GetById(id);
            var landmarks = city.Places.ToList();
            var landmarksViewModel = Mapper.Map<ICollection<LandmarkViewModel>>(landmarks);

            return PartialView("_Landmarks", landmarksViewModel);
        }

        public ActionResult People(int id)
        {
            var city = this.Data.Cities.GetById(id);

            var vips = city.VIPs.ToList();
            var vipsViewModel = Mapper.Map<ICollection<VipViewModel>>(vips);

            return PartialView("_People", vipsViewModel);
        }

        public ActionResult Gallery(int id)
        {
            var city = this.Data.Cities.GetById(id);
            var gallery = Mapper.Map<IEnumerable<PhotoViewModel>>(city.Places.SelectMany(p => p.Photos));

            return PartialView("_Gallery", gallery);
        }

        public ActionResult Events(int id)
        {
            var city = this.Data.Cities.GetById(id);

            var events = Mapper.Map<ICollection<EventViewModel>>(city.Events);

            return PartialView("_Events", events);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Comment(CommentInputModel model)
        {
            if (ModelState.IsValid)
            {
                var comment = Mapper.Map<Comment>(model);
                comment.DateCreated = DateTime.Now;

                var user = this.Data.Users
                                        .All()
                                        .FirstOrDefault(u => u.UserName == this.User.Identity.Name);

                comment.UserId = user.Id;

                this.Data.Comments.Add(comment);

                this.Data.SaveChanges();
            }

            return this.CommentsListPartial((int)model.CityId);
        }

        public ActionResult CommentsListPartial(int cityId)
        {
            var city = this.Data.Cities.GetById(cityId);

            var comments = Mapper.Map<ICollection<CommentViewModel>>(city.Comments);

            return PartialView("_CommentsListPartial", comments);
        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insert(int id, CityInputModel model)
        {
            if (ModelState.IsValid)
            {
                var city = Mapper.Map<City>(model);
                city.CountryId = id;

                this.Data.Cities.Add(city);
                this.Data.SaveChanges();

                this.TempData["message"] = "City added";

                return RedirectToAction("Details", "City", new { id = city.Id });
            }

            return View(model);
        }
    }
}