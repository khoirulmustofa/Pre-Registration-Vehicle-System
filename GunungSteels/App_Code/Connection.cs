using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace GunungSteels.App_Code
{
    public class DBConnection
    {
        private SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
        public DBConnection()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
        }
      
        public SqlConnection connection
        {
            get
            {
                return con;
            }
            set
            {
                con = value;
            }
        }
    }

}