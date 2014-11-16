namespace CityExplorer.Web.Areas.Administration.Controllers.Base
{
    using CityExplorer.Data;
    using CityExplorer.Web.Controllers;
    using System.Web.Mvc;

    // [Authorize(Roles = "Admin")]
    public abstract class AdminController : BaseController
    {
        public AdminController(ICityExplorerData data)
            : base(data)
        {

        }
    }
}