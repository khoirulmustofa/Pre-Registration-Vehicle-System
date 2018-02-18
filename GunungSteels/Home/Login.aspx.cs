using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GunungSteels.App_Code;
using GunungSteels.Common;
using System.Web.Security;

namespace GunungSteels.Home
{
    public partial class Login : System.Web.UI.Page
    {
        public SqlConnection sqlConnection;
        public SqlCommand sqlCommand;

        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void Submit(object sender, EventArgs e)
        {
            string userType = string.Empty;
            string userName = txt_UserName.Text;
            string password = txt_Password.Text;

            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                userType = ValidateUser(userName, password);
                if (userType == Constants.userAccessAccepted)
                {
                    FormsAuthentication.SetAuthCookie(Session["LoggedInUserID"].ToString(), false);
                    string loggedInUserRole = Session["LoggedInUserRole"] != null ? Session["LoggedInUserRole"].ToString() : string.Empty;
                    if (loggedInUserRole == Constants.adminRole)
                        Response.Redirect("~/Home/Dashboard.aspx");
                    else if (loggedInUserRole == Constants.adminRegistrationRole)
                    {
                        Response.Redirect("~/Home/RegistrationAdminDashboard.aspx");
                    }
                    else if (loggedInUserRole == Constants.adminSecurityRole)
                    {
                        Response.Redirect("~/PRVSSecurity/SecurityGateScan.aspx");
                    }
                    else if (loggedInUserRole == Constants.adminWareHouseRole)
                    {
                        Response.Redirect("~/PRVSSecurity/WarehouseVehicleScan.aspx");
                    }
                }
                else
                {
                    Response.Write("Invalid User");
                }
            }
            else
            {
                Response.Write("Please Enter User Name and Password");
            }
        }

        private string ValidateUser(string userName, string password)
        {
            try
            {
                using (sqlConnection = new DBConnection().connection)
                {
                    using (sqlCommand = new SqlCommand())
                    {
                        if (sqlConnection.State == ConnectionState.Closed)
                        {
                            sqlConnection.Open();
                        }
                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.CommandText = "USP_Validate_User";
                        sqlCommand.Parameters.AddWithValue("@USER_NAME", userName);
                        sqlCommand.Parameters.AddWithValue("@USER_PASSWORD", password);
                        SqlParameter par = new SqlParameter("@OUTMSG", SqlDbType.VarChar, 50);
                        par.Direction = ParameterDirection.Output;
                        sqlCommand.Parameters.Add(par);
                        sqlCommand.CommandTimeout = 20000;
                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                        da.Fill(ds);
                        string outputMessage = (string)sqlCommand.Parameters["@OUTMSG"].Value;
                        if (outputMessage == Constants.userAccessAccepted && ds.Tables[0].Rows.Count > 0)
                        {
                            Session["LoggedInUserID"] = ds.Tables[0].Rows[0]["USER_ID"].ToString();
                            Session["LoggedInUserName"] = ds.Tables[0].Rows[0]["NAME"].ToString();
                            Session["LoggedInUser_UserName"] = ds.Tables[0].Rows[0]["USER_NAME"].ToString();
                            Session["LoggedInUserEMail"] = ds.Tables[0].Rows[0]["USER_EMAIL"].ToString();
                            Session["LoggedInUserContact"] = ds.Tables[0].Rows[0]["USER_CONTACT"].ToString();
                            Session["LoggedInUserRole"] = ds.Tables[0].Rows[0]["ROLE_NAME"].ToString();
                        }
                        return outputMessage;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}