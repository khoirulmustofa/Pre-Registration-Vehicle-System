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

namespace GunungSteels.GSGCustomer
{
    public partial class User_Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // Session["OrderID"] = orderId = Request.QueryString["OrderID"] != null ? Request.QueryString["OrderID"].ToString() : string.Empty;
            //Session["DeliveryID"]=deliveryId=  Request.QueryString["DeliveryID"] != null ? Request.QueryString["DeliveryID"].ToString() :string.Empty;
           // string sec_Mismatch_Id = Request.QueryString["CustomerMisMatch"]!=null?Request.QueryString["CustomerMisMatch"].ToString():string.Empty;
           // string matchDeliveryMasterId =Request.QueryString["CustomerMatch"]!=null ? Request.QueryString["CustomerMatch"].ToString():string.Empty;
        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            string[] userType = new string[2];
            string userName = txt_UserName.Text;
            string password = txt_Password.Text;
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                userType = ValidateUser(userName, password);
                if (userType[0] == Constants.userAccessAccepted)
                {
                    FormsAuthentication.SetAuthCookie(Session["LoggedInCustomerID"].ToString(), false);
                    //For Customer Transport Registration
                    string orderId = Request.QueryString["OrderID"] != null ? Request.QueryString["OrderID"].ToString() : null;
                    string deliveryId = Request.QueryString["DeliveryID"] != null ? Request.QueryString["DeliveryID"].ToString() : null;
                    //For Customer MisMatch
                    string sec_Mismatch_Id = Request.QueryString["CustomerMisMatch"] != null ? Request.QueryString["CustomerMisMatch"].ToString() : null;
                    //For Customer Match
                    string matchDeliveryMasterId = Request.QueryString["CustomerMatch"] != null ? Request.QueryString["CustomerMatch"].ToString() : null;
                    if (userType[1] == "Y" && orderId != null && deliveryId != null)
                    {
                        Session["OrderId"] = orderId;
                        Session["DeliveryId"] = deliveryId;
                        Response.Redirect("~/GSGCustomer/Change Password.aspx");
                    }
                    else if (userType[1] == "Y" && orderId == null && deliveryId == null)
                    {
                        Response.Redirect("~/GSGCustomer/Change Password.aspx");
                    }
                    else if (userType[1] == "N" && orderId != null && deliveryId != null)
                    {
                        Response.Redirect("~/GSGCustomer/TransportRegistrationOrder.aspx?OrderID=" + orderId + "&DeliveryID=" + deliveryId);
                    }
                    else if (userType[1] == "N" && matchDeliveryMasterId != null)
                    {
                        Response.Redirect("~/GSGCustomer/CustomerMatch.aspx/?CustomerMatch=" + matchDeliveryMasterId);
                    }
                    else if (userType[1] == "N" && sec_Mismatch_Id != null && deliveryId != null)
                    {
                        Response.Redirect("~/GSGCustomer/CustomerMismatchApproval.aspx/?CustomerMisMatch=" + sec_Mismatch_Id + "&DeliveryID=" + deliveryId);
                    }
                    else
                    {
                        Response.Redirect("~/GSGCustomer/CustomerDashboard.aspx");
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

        private string[] ValidateUser(string userName, string password)
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
                        sqlCommand.CommandText = "USP_Validate_User";
                        sqlCommand.Parameters.AddWithValue("@USER_NAME", userName);
                        sqlCommand.Parameters.AddWithValue("@USER_PASSWORD", password);
                        sqlCommand.Parameters.AddWithValue("@IsCustomerAccess", 'Y');
                        SqlParameter par = new SqlParameter("@OUTMSG", SqlDbType.VarChar, 50);
                        par.Direction = ParameterDirection.Output;
                        sqlCommand.Parameters.Add(par);
                        sqlCommand.CommandTimeout = 20000;
                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                        da.Fill(ds);
                        string[] result = new string[2];
                        string outputMessage = result[0] = (string)sqlCommand.Parameters["@OUTMSG"].Value;
                        //string isOneTimePasswordStatus = result[1] = (string)sqlCommand.Parameters["@IsOneTimePassword"].Value;

                        if (outputMessage == Constants.userAccessAccepted && ds.Tables[0].Rows.Count > 0)
                        {
                            Session["LoggedInCustomerID"] = ds.Tables[0].Rows[0]["CUSTOMER_MASTER_ID"].ToString();
                            Session["LoggedInUserID"] = ds.Tables[0].Rows[0]["USER_ID"].ToString();
                            Session["LoggedInUserName"] = ds.Tables[0].Rows[0]["NAME"].ToString();
                            Session["LoggedInUser_UserName"] = ds.Tables[0].Rows[0]["USER_NAME"].ToString();
                            Session["LoggedInUserEMail"] = ds.Tables[0].Rows[0]["USER_EMAIL"].ToString();
                            Session["LoggedInUserContact"] = ds.Tables[0].Rows[0]["USER_CONTACT"].ToString();
                            Session["LoggedInUserRole"] = ds.Tables[0].Rows[0]["ROLE_NAME"].ToString();
                            result[1] = ds.Tables[0].Rows[0]["IsOneTimePassword"] != DBNull.Value ? ds.Tables[0].Rows[0]["IsOneTimePassword"].ToString() : "Y";
                        }
                        return result;
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