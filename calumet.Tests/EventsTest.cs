using Microsoft.VisualStudio.TestTools.UnitTesting;
using calumet.Models;
using calumet.Controllers;
using System.Net.Http;
using System.Web.Http;

namespace calumet.Tests
{
    [TestClass]
    public class EventsTest
    {
        [TestMethod]
        public void CreateEvent()
        {
            var ec = new EventController();
            ec.Request = new HttpRequestMessage();
            ec.Configuration = new HttpConfiguration();
            ec.PostEvent(new Event { EventName = "Birthday party" });
            ec.PostEvent(new Event { EventName = "Luncheon" });
        }
    }
}
