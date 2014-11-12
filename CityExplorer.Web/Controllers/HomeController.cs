using CityExplorer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CityExplorer.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CityExplorerDbContext context = new CityExplorerDbContext();

            context.Countries.Where(x => 1 == 1);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}