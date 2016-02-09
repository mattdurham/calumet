using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using calumet.Models;
using calumet.Controllers;
using System.Web.Http.Results;

namespace calumet.Tests
{
    [TestClass]
    public class EventsTest
    {
        [TestMethod]
        public void CreateEvent()
        {
            var ev = new Events() { e_creator = "mattdurham@ppog.org", e_dateortime = "DATE", e_name = "TEST EVENT", e_startdate = DateTime.Now.Date, e_enddate = DateTime.Now.AddDays(7).Date };
            var eventsController = new EventsController();
            var result = eventsController.PostEvent(ev) as CreatedAtRouteNegotiatedContentResult<Events>;

            Assert.IsTrue(result.Content.e_id > 0);
            Assert.IsTrue(result.Content.e_link.Length > 0);

        }
    }
}
