using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CityExplorer.Web.Areas.Administration.Controllers
{
    public class HomeController : Controller
    {
        // GET: Administration/Home
        public ActionResult Navigation()
        {
            return View();
        }
    }
}