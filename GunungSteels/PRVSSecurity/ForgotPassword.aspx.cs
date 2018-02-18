using System;
using System.Data.SqlClient;
using System.Web.UI;
using GunungSteels.App_Code;
using System.Data;

namespace GunungSteels.PRVSSecurity
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Send_Click(object sender, EventArgs e)
        {
            string emailId = txtEmail.Text.Trim();
            if (!string.IsNullOrEmpty(emailId))
            {
                string result = SendPassword(emailId);
                if (!string.IsNullOrEmpty(result) && result.Contains("Success"))
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowPopUp();", true);
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

        private string SendPassword(string emailId)
        {
            string username = string.Empty;
            string password = string.Empty;
            string name = string.Empty;
            string outputMessage = string.Empty;
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
                        sqlCommand.CommandText = "USP_FORGOT_PASSWORD";
                        sqlCommand.Parameters.AddWithValue("@IsCustomer", false);
                        sqlCommand.Parameters.AddWithValue("@Email", emailId);
                        SqlParameter par = new SqlParameter("@OUTMSG", SqlDbType.VarChar, 50);
                        par.Direction = ParameterDirection.Output;
                        sqlCommand.Parameters.Add(par);
                        sqlCommand.CommandTimeout = 20000;
                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            if (sqlDataReader.Read())
                            {
                                username = sqlDataReader["USER_NAME"].ToString();
                                password = sqlDataReader["PASSWORD"].ToString();
                                name = sqlDataReader["Name"].ToString();
                            }
                            // outputMessage = (string)sqlCommand.Parameters["@OUTMSG"].Value;
                            if (!string.IsNullOrEmpty(password))
                            {
                                SendMail(name, username, password);
                                outputMessage = "Success";
                            }
                            else
                            {
                                outputMessage = "Fail";
                                //lblMessage.ForeColor = Color.Red;
                                //lblMessage.Text = "This email address does not match our records.";
                            }
                        }
                    }
                }
                return outputMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SendMail(string name, string username, string password)
        {
            string body = string.Format("Dear {0},<br /><br />", name);
            body = string.Format("Hi {0},<br /><br />Your password is {1}.<br /><br />Thank You.", username, password);
            body = body + string.Format("<br/><br/><br/><b>Thanks and Regard's</b><br/>");
            body = body + string.Format("Gunung Admin Group");
            string fromMailAddress = System.Configuration.ConfigurationManager.AppSettings["TargetEmailAddress"];
            string toMailAddress = txtEmail.Text.Trim();
            string subject = "Forgot Password";
            Notification.EMail.SendMail(fromMailAddress, toMailAddress, subject, body);
            //lblMessage.ForeColor = Color.Green;
            //lblMessage.Text = "Password has been sent to your email address.";
        }
    }
}