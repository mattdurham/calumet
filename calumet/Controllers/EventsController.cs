using calumet;
using calumet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace calumet.Controllers
{
    public class EventsController : BaseController
    {
        public IEnumerable<Events> GetAllEvents()
        {
            var events = dbio.db.GetAllEvents();
            return events;
        }

        public IHttpActionResult PostEvent(Events ev)
        {
            if(ev == null)
            {
                throw new ArgumentNullException();
            }
            var newID = dbio.db.AddEvent(ev);
            ev.e_id = newID;
            ev.e_link = this.BaseLink + "/events.html?id=" + ev.e_id;
            return CreatedAtRoute<Events>("DefaultApi", new { id = ev.e_id }, ev);
        }
        
    }
}