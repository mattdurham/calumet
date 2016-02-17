using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace calumet.Models
{
    public class Calumet : DbContext
    {
        public Calumet(string connectionstring) : base(connectionstring)
        {

        }
        public DbSet<Event> Events { get; set; }
    }
}