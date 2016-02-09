using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data.SQLite;
using calumet.Models;
using System.IO;

namespace calumet
{
    /// <summary>
    /// SQLite is the initial support followed by SQL Server. Why am I using SQLITE? Simply because its quicker
    /// and for the small workload. In a truley real environment I would probably switch to SQL Server.
    /// </summary>
    public class dbio
    {
        static dbio _db;
        static object _lock = new object();

        private SQLiteConnection _sqlite;
        //This is so no one can ever construct this object
        private dbio()
        {
            //Need to see if a SQLite Database even exists
            var fileInfo = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "\\calumet.db");
            _sqlite = new SQLiteConnection(string.Format("Data Source={0};Version=3;",fileInfo.FullName));
            _sqlite.Open();
            var results = _sqlite.Query("SELECT name FROM sqlite_master WHERE type = 'table'");
            if(results.Count() == 0)
            {
                _sqlite.Execute(CREATE_EVENTS_TABLE_SQLITE);
                _sqlite.Execute(CREATE_EVENT_RECIPIENTS_TABLE_SQLITE);
                _sqlite.Execute(CREATE_EVENT_RECIPIENT_DATES_TABLE_SQLITE);
            }
        }

        /// <summary>
        /// Access the dbio object that all the api helpers user
        /// </summary>
        public static dbio db
        {
            get
            {
                if (_db == null)
                {
                    lock (_lock)
                    {
                        _db = new dbio();
                    }
                }
                return _db;
            }
        }

        public IEnumerable<T> Query<T>(string sql, object parameters)
        {
            return _sqlite.Query<T>(sql, parameters);
        }

        public IEnumerable<Events> GetAllEvents()
        {
            return _sqlite.Query<Events>("SELECT * FROM EVENTS");
        }

        public long AddEvent(Events ev)
        {
            var result = _sqlite.QueryFirst("INSERT INTO EVENTS (E_STARTDATE, E_ENDDATE, E_NAME, E_CREATOREMAIL, E_DATEORTIME, E_LINK, E_COMMENTS) VALUES (@start, @end,@name, @creator, @dateortime, @link, @comments); SELECT last_insert_rowid() as 'rowid';", new { start = ev.e_startdate, end = ev.e_enddate, creator = ev.e_creator, dateortime = ev.e_dateortime,link = ev.e_link, name = ev.e_name, comments = ev.e_comments });
            return result.rowid;
        }

        #region SQLITE Creation

        const string CREATE_EVENTS_TABLE_SQLITE =
            @"
                CREATE TABLE EVENTS
                (
                    E_ID INTEGER PRIMARY KEY,
                    E_STARTDATE DATETIME,
                    E_ENDDATE DATETIME,
                    E_NAME VARCHAR(200),
                    E_CREATOREMAIL VARCHAR(200),
                    E_DATEORTIME VARCHAR(10),
                    E_LINK VARCHAR(200),
                    E_COMMENTS TEXT
                );
            ";

        const string CREATE_EVENT_RECIPIENTS_TABLE_SQLITE =
            @"
                CREATE TABLE EVENT_RECIPIENTS
                (
                    ER_ID INTEGER PRIMARY KEY,
                    ER_EMAIL VARCHAR(200),
	                ER_RESPONDED BOOLEAN,
	                ER_EID INTEGER,
	                ER_LINK VARCHAR(200),
                    FOREIGN KEY(ER_EID) REFERENCES EVENTS(E_ID)
                );
            ";


        const string CREATE_EVENT_RECIPIENT_DATES_TABLE_SQLITE =
            @"
                CREATE TABLE EVENT_RECIPIENT_DATES
                (
                    ERD_ID INTEGER PRIMARY KEY,
                    ERD_ERID INTEGER,
                    ERD_STARTDATE DATETIME,
                    ERD_ENDDATE DATETIME,
                    FOREIGN KEY(ERD_ERID) REFERENCES EVENT_RECIPIENTS(ERD_ERID)
                );
            ";
        #endregion

    }
}