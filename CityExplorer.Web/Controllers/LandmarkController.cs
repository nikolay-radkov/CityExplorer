namespace CityExplorer.Web.Controllers
{
    using AutoMapper;
    using CityExplorer.Data;
    using CityExplorer.Web.ViewModels;
    using System.Web.Mvc;

    public class LandmarkController : BaseController
    {
        public LandmarkController(ICityExplorerData data)
            : base(data)
        {

        }

        public ActionResult Index(int id)
        {
            var landmark = this.Data.Places.GetById(id);

            var landmarkViewModel = Mapper.Map<LandmarkViewModel>(landmark);

            return View(landmarkViewModel);
        }
        
        public ActionResult Insert()
        {
           
            return View();
        }
    }
}