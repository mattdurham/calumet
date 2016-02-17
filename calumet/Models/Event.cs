using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace calumet.Models
{
    public class Event
    {
        public long EventID { get; set; }
        public DateTime? EventStartDate { get; set; }
        public DateTime? EventEndDate { get; set; }
        public string EventName { get; set; }
        public string EventCreator { get; set; }
        public string EventDateOrTime { get; set; }
        public string EventLink { get; set; }
        public string EventComments { get; set; }
    }
}