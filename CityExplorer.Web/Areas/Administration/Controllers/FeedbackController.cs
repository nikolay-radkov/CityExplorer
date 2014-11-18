namespace CityExplorer.Web.Areas.Administration.Controllers
{
    using AutoMapper;
    using CityExplorer.Data;
    using CityExplorer.Web.Areas.Administration.Controllers.Base;
    using CityExplorer.Web.Areas.Administration.ViewModels;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using System.Web.Mvc;

    public class FeedbackController : AdminController
    {
        public FeedbackController(ICityExplorerData data)
            : base(data)
        {

        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ReadFeedbacks([DataSourceRequest]DataSourceRequest request)
        {
            var feedbacksDataSource = this.Data.Feedbacks.All()
                .ToDataSourceResult(request, feedback => Mapper.Map<FeedbackViewModel>(feedback));

            return this.Json(feedbacksDataSource);
        }
    }
}