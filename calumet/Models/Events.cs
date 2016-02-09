using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace calumet.Models
{
    public class Events
    {
        public long e_id { get; set; }
        public DateTime? e_startdate { get; set; }
        public DateTime? e_enddate { get; set; }
        public string e_name { get; set; }
        public string e_creator { get; set; }
        public string e_dateortime { get; set; }
        public string e_link { get; set; }
        public string e_comments { get; set; }
    }
}