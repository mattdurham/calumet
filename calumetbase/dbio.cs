using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data.SqlClient;
using calumetbase.Models;

namespace calumetbase
{
    /// <summary>
    /// SQLite is the initial support followed by SQL Server. Why am I using SQLITE? Simply because its quicker
    /// and for the small workload. In a truley real environment I would probably switch to SQL Server.
    /// </summary>
    public class dbio
    {
        public static Calumet db
        {
            get
            {
                var sb = new SqlConnectionStringBuilder();
                sb.IntegratedSecurity = true;
                sb.InitialCatalog = "calumet";
                sb.DataSource = "localhost";
                return new Calumet(sb.ToString());
            }
        }
    }
}