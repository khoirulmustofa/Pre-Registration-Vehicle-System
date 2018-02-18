using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;
using GunungSteels.App_Code;

namespace GunungSteels.GSGCustomer
{
    public partial class Change_Password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["LoggedInCustomerID"] == null || Session["LoggedInCustomerID"].ToString() == string.Empty)
                {
                    Response.Redirect("~/GSGCustomer/User_Login.aspx", true);
                }
                else
                {
                    lblUser_Name.Text = Session["LoggedInUser_UserName"] != null ? Session["LoggedInUser_UserName"].ToString() : string.Empty;
                }
            }
        }

        protected void btnchangepass_Click(object sender, EventArgs e)
        {
            bool isCustomer = Session["LoggedInUserRole"] != null && Session["LoggedInUserRole"].ToString() == "Customer" ? true : false;
            int UserID = Session["LoggedInCustomerID"] != null ? Convert.ToInt32(Session["LoggedInCustomerID"]) : 0;
            string CurrentPassword = txtCurrentPsw.Text;
            string ConfirmPassword = txtConfirmPsw.Text;
            string NewPassword = txtNewPsw.Text;

            if (!string.IsNullOrEmpty(NewPassword) && NewPassword == ConfirmPassword)
            {
                string result = ChangeUserPassword(isCustomer, UserID, CurrentPassword, NewPassword);
                if (result.Contains("successfully"))
                {
                    if (Session["OrderID"] != null && Session["DeliveryID"] != null)
                    {
                        string orderId = Session["OrderID"].ToString();
                        string deliveryId = Session["DeliveryID"].ToString();
                        Response.Redirect("~/GSGCustomer/TransportRegistrationOrder.aspx?OrderID=" + orderId + "&&DeliveryID=" + deliveryId);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowPopUp();", true);
                    }
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