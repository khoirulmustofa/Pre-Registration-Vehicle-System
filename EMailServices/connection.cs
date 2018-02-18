using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMailServices
{
  public  class connection
    {
        private SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
        public SqlConnection Connection
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
