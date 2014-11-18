using AutoMapper;
using CityExplorer.Data;
using CityExplorer.Models;
using CityExplorer.Web.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CityExplorer.Web.Controllers
{
    public class EventController : BaseController
    {

        public EventController(ICityExplorerData data)
            : base(data)
        {

        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insert(int id, EventInputModel model)
        {
            if (ModelState.IsValid)
            {
                var newEvent = Mapper.Map<Event>(model);
                newEvent.CityId = id;

                this.Data.Events.Add(newEvent);
                this.Data.SaveChanges();

                this.TempData["message"] = "Event added";
                return RedirectToAction("Details", "City", new { id = id });
            }

            return View(model);
        }
    }
}