using calumetbase;
using calumetbase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace calumetmvc.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult Index()
        {
            Calumet db = dbio.db;
            List<Event> events = db.Events.ToList();
            return View(events);
        }

        public ActionResult AddEvent()
        {
            return View(new Event());
        }

        [HttpPost]
        public ActionResult AddEvent(Event ev)
        {
            if (ModelState.IsValid)
            {
                Calumet db = dbio.db;
                db.Events.Add(ev);
                db.SaveChanges();
                //Return back to the main page
                return RedirectToAction("Index");
            }
            return View(ev);
        }

        public string Welcome()
        {
            return "Welcome";
        }
    }
}