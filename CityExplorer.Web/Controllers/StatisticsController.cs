namespace CityExplorer.Web.Controllers
{
    using AutoMapper;
    using CityExplorer.Data;
    using CityExplorer.Web.Areas.Administration.Controllers.Base;
    using CityExplorer.Web.ViewModels;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using System.Web.Mvc;
    
    public class StatisticsController : AdminController
    {
        public StatisticsController(ICityExplorerData data)
            : base(data)
        {

        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ReadStatistics([DataSourceRequest]DataSourceRequest request)
        {
            var citiesDataSource = this.Data.Cities.All()
                .ToDataSourceResult(request, city => Mapper.Map<CityStatisticsViewModel>(city));

            return this.Json(citiesDataSource);
        }
    }
}