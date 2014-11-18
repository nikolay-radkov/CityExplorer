namespace CityExplorer.Web.Areas.Administration.Controllers
{
    using AutoMapper;
    using CityExplorer.Data;
    using CityExplorer.Models;
    using CityExplorer.Web.Areas.Administration.Controllers.Base;
    using CityExplorer.Web.Areas.Administration.ViewModels;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using System;
    using System.Web.Mvc;

    [Authorize(Roles="Admin")]
    public class CountryController : AdminController
    {
        public CountryController(ICityExplorerData data)
            : base(data)
        {

        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult ReadCountries([DataSourceRequest]DataSourceRequest request)
        {
            var countriesDataSource = this.Data.Feedbacks.All()
                .ToDataSourceResult(request, country => Mapper.Map<CountryViewModel>(country));

            return this.Json(countriesDataSource);
        }

        [HttpPost]
        public ActionResult CreateCountry([DataSourceRequest]DataSourceRequest request, CountryViewModel model)
        {
            if (model != null)
            {
                var country = new Country();
                Mapper.Map(model, country);

                country.CreatedOn = DateTime.Now.ToLocalTime();
                this.Data.Countries.Add(country);

                this.Data.SaveChanges();
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult UpdateCountry([DataSourceRequest]DataSourceRequest request, CountryViewModel model)
        {
            if (model != null)
            {
                var Country = this.Data.Countries.GetById(model.Id);
                Mapper.Map(model, Country);
                Country.ModifiedOn = DateTime.Now.ToLocalTime();
                this.Data.SaveChanges();
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult DestroyCountry([DataSourceRequest]DataSourceRequest request, CountryViewModel model)
        {
            if (model != null)
            {
                var Country = this.Data.Countries.GetById(model.Id);
                Mapper.Map(model, Country);
                Country.IsDeleted = true;
                Country.DeletedOn = DateTime.Now.ToLocalTime();

                this.Data.SaveChanges();
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}