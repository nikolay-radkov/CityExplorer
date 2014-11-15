namespace CityExplorer.Web.Controllers
{
    using System.Web.Mvc;

    using CityExplorer.Web.ViewModels;
    using System.Data.Entity;
    using CityExplorer.Data;
    using CityExplorer.Models;

    public abstract class BaseController : Controller
    {
        public BaseController(ICityExplorerData data)
        {
            this.Data = data;
        }

        protected ICityExplorerData Data { get; set; }

        protected User CurrentUser { get; set; }
    }
}