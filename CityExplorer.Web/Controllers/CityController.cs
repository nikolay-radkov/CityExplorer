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
            return GetPartialView(id, "_People");
        }

        public ActionResult Gallery(int id)
        {
            return GetPartialView(id, "_Gallery");
        }

        public ActionResult Events(int id)
        {
            return GetPartialView(id, "_Events");
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

        [NonAction]
        public ActionResult GetPartialView(int id, string partialView)
        {
            var city = this.Data.Cities.GetById(id);
            var cityViewModel = Mapper.Map<CityViewModel>(city);

            if (Request.IsAjaxRequest())
            {
                return PartialView(partialView, cityViewModel);
            }
            else
            {
                return View();
            }
        }
    }
}