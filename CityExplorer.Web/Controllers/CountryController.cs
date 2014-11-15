using CityExplorer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CityExplorer.Web.Controllers
{
    public class CountryController : BaseController
    {
        public CountryController(ICityExplorerData data)
            : base(data)
        {
            
        }

        public ActionResult Index()
        {
 
            return View();
        }
    }
}