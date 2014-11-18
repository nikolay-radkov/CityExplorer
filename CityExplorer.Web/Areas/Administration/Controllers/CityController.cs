namespace CityExplorer.Web.Areas.Administration.Controllers
{
    using AutoMapper;
    using CityExplorer.Data;
    using CityExplorer.Web.Areas.Administration.Controllers.Base;
    using CityExplorer.Web.Areas.Administration.ViewModels;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using System;
    using System.Web.Mvc;

    [Authorize(Roles = "Admin")]
    public class CityController : AdminController
    {
        public CityController(ICityExplorerData data)
            : base(data)
        {

        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult ReadCities([DataSourceRequest]DataSourceRequest request)
        {
            var citiesDataSource = this.Data.Cities.All()
                .ToDataSourceResult(request, cities => Mapper.Map<CityViewModel>(cities));

            return this.Json(citiesDataSource);
        }

        [HttpPost]
        public ActionResult DestroyCity([DataSourceRequest]DataSourceRequest request, CityViewModel model)
        {
            if (model != null)
            {
                var city = this.Data.Cities.GetById(model.Id);
                Mapper.Map(model, city);
                city.IsDeleted = true;
                city.DeletedOn = DateTime.Now.ToLocalTime();

                this.Data.SaveChanges();
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}