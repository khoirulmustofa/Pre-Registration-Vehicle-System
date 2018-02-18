using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GunungSteels.App_Code;

namespace GunungSteels.PRVSSecurity
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        public SqlConnection SQLConn;
        public DataTable DT;
        public SqlDataAdapter SQLAdapter;
        protected void Page_Load(object sender, EventArgs e)
        {
            //SQLConn = new SqlConnection(@"Data Source=DESKTOP-5IC111P;Initial Catalog=PRVS;Integrated Security=True");

            if (!IsPostBack)
            {
                if (Session["LoggedInUserID"] == null || Session["LoggedInUserID"].ToString() == string.Empty)
                    Response.Redirect("~/Home/Login.aspx", true);
                else
                    lblUser_Name.Text = Session["LoggedInUser_UserName"] != null ? Session["LoggedInUser_UserName"].ToString() : string.Empty;
            }
        }

        protected void btnchangepass_Click1(object sender, EventArgs e)
        {
            bool isCustomer = false; // Session["LoggedInUserRole"] != null && Session["LoggedInUserRole"].ToString() == "Customer" ? true : false;
            int UserID = Session["LoggedInUserID"] != null ? Convert.ToInt32(Session["LoggedInUserID"]) : 0;
            string CurrentPassword = txtCurrentPsw.Text;
            string ConfirmPassword = txtConfirmPsw.Text;
            string NewPassword = txtNewPsw.Text;

            if (!string.IsNullOrEmpty(NewPassword) && NewPassword == ConfirmPassword)
            {
                string result = ChangeUserPassword(isCustomer, UserID, CurrentPassword, NewPassword);
                if (result.Contains("successfully"))
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowPopUp();", true);
                }
                else if (result.Contains("Invalid"))
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowFailurePopUp();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowInvalidUserPopUp();", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowErrorPopUp();", true);
            }
        }

        private string ChangeUserPassword(bool isCustomer, int UserID, string CurrentPassword, string NewPassword)
        {
            try
            {
                using (SqlConnection sqlConnection = new DBConnection().connection)
                {
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        if (sqlConnection.State == ConnectionState.Closed)
                        {
                            sqlConnection.Open();
                        }
                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.CommandText = "USP_CHANGE_PASSWORD";
                        sqlCommand.Parameters.AddWithValue("@IsCustomer", isCustomer);
                        sqlCommand.Parameters.AddWithValue("@UserID", UserID);
                        sqlCommand.Parameters.AddWithValue("@CurrentPassword", CurrentPassword);
                        sqlCommand.Parameters.AddWithValue("@NewPassword", NewPassword);
                        SqlParameter par = new SqlParameter("@OUTMSG", SqlDbType.VarChar, 50);
                        par.Direction = ParameterDirection.Output;
                        sqlCommand.Parameters.Add(par);
                        sqlCommand.CommandTimeout = 20000;
                        var output = sqlCommand.ExecuteScalar();
                        string outputMessage = (string)sqlCommand.Parameters["@OUTMSG"].Value;
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