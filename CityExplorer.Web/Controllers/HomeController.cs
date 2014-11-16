using CityExplorer.Data;
using CityExplorer.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;

namespace CityExplorer.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ICityExplorerData data)
            : base(data)
        {

        }

       // [OutputCache(Duration = 20 * 60)]
        public ActionResult Index()
        {
            var continents = this.Data.Continents.All()
              .AsQueryable()
              .Project()
              .To<ContinentViewModel>()
              .ToList();

            return View(continents);
        }

        [OutputCache(Duration = 10 * 60)]
        public ActionResult Countries(int continentid)
        {
            var counties = this.Data.Countries
                                        .All()
                                        .Where(c => c.ContinentId == continentid)
                                        .AsQueryable()
                                        .Project()
                                        .To<CountryViewModel>();
            return View(counties);
        }

        [OutputCache(Duration = 5 * 60)]
        public ActionResult Cities(int countryId)
        {
            var city = this.Data.Cities
                                    .All()
                                  .Where(c => c.CountryId == countryId)
                                    .AsQueryable()
                                    .Project()
                                    .To<CityViewModel>();

            return View(city);
        }

    }
}