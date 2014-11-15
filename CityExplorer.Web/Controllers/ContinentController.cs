using CityExplorer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using CityExplorer.Web.ViewModels;

namespace CityExplorer.Web.Controllers
{
    public class ContinentController : Controller
    {
        private ICityExplorerData data = new CityExplorerData(new CityExplorerDbContext());

        // GET: Continent
        public ActionResult Index()
        {
            var contints = this.data.Continents.All()
                .AsQueryable()
                .Project()
                .To<ContinentViewModel>()
                .ToList();

            return View(contints);
        }
    }
}