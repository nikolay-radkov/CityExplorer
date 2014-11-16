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
    using System.Runtime;
    using System.Web.Mvc;

    public class ContinentController : AdminController
    {
        public ContinentController(ICityExplorerData data)
            : base(data)
        {
   
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult ReadContinents([DataSourceRequest]DataSourceRequest request)
        {
            var continentsDataSource = this.Data.Continents.All()
                .ToDataSourceResult(request, continent => Mapper.Map<ContinentViewModel>(continent));

            return this.Json(continentsDataSource);
        }


        [HttpPost]
        public ActionResult CreateContinent([DataSourceRequest]DataSourceRequest request, ContinentViewModel model)
        {
            if (model != null)
            {
                    var continent = new Continent();
                    Mapper.Map(model, continent);

                    continent.CreatedOn = DateTime.Now.ToLocalTime();
                    this.Data.Continents.Add(continent);

                    this.Data.SaveChanges();
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult UpdateContinent([DataSourceRequest]DataSourceRequest request, ContinentViewModel model)
        {
            if (model != null)
            {
                var continent = this.Data.Continents.GetById(model.Id);
                Mapper.Map(model, continent);
                continent.ModifiedOn = DateTime.Now.ToLocalTime();
                this.Data.SaveChanges();
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult DestroyContinent([DataSourceRequest]DataSourceRequest request, ContinentViewModel model)
        {
            if (model != null)
            {
                var continent = this.Data.Continents.GetById(model.Id);
                Mapper.Map(model, continent);
                continent.IsDeleted = true;
                continent.DeletedOn = DateTime.Now.ToLocalTime();

                this.Data.SaveChanges();
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}