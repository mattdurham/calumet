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
            for (int i = 0; i < 100; i++)
            {
                var ev = new Events() { e_creator = "mattdurham@ppog.org", e_dateortime = "DATE", e_name = "TEST EVENT", e_startdate = DateTime.Now.Date, e_enddate = DateTime.Now.AddDays(i).Date, e_comments = i.ToString() };
                var eventsController = new EventsController();
                var result = eventsController.PostEvent(ev) as CreatedAtRouteNegotiatedContentResult<Events>;

                Assert.IsTrue(result.Content.e_id > 0);
                Assert.IsTrue(result.Content.e_link.Length > 0);
            }

        }
    }
}
