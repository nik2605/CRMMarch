using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRM.Data
{
    public class DataObject
    {
        public DataObject()
        {
            connStr = ConfigurationManager.ConnectionStrings["CRM"].ConnectionString;
        }

        private string connStr { get; set; }

        public SqlTransaction Trans { get; set; }

        public string ConnStr
        {
            get { return connStr; }
        }
    }
}