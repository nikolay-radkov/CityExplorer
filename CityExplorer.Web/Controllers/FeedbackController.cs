namespace CityExplorer.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using CityExplorer.Models;
    using CityExplorer.Web.Infrastructure;
    using CityExplorer.Web.ViewModels;

    using Microsoft.AspNet.Identity;
    using CityExplorer.Data.Contracts;
    using CityExplorer.Data;
    using CityExplorer.Web.InputModels;
    using AutoMapper;

    public class FeedbackController  : BaseController
    {
        public FeedbackController(ICityExplorerData data)
            : base(data)
        {

        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new CreateFeedbackInputModel();
            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateFeedbackInputModel input)
        {
            if (ModelState.IsValid)
            {
                var feedback = Mapper.Map<Feedback>(input);

                if (this.User.Identity.IsAuthenticated)
                {
                     var userId = this.User.Identity.GetUserId();

                     feedback.AuthorId = userId;
                }
                else
                {
                    feedback.Author = null;
                }

                this.Data.Feedbacks.Add(feedback);
                this.Data.SaveChanges();
                this.TempData["message"] = "Feedback sent";

                return this.RedirectToAction("Index", "Home");
            }

            return this.View(input);
        }
    }
}