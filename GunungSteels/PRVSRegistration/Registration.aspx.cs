using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GunungSteels.App_Code;

namespace GunungSteels.PRVSRegistration
{

    public partial class Registration : System.Web.UI.Page
    {
        public SqlConnection sqlConnection;
        public SqlCommand sqlCommand;
        DBConnection con = new DBConnection();
        SqlDataAdapter da;
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //txtMatchRegistrationGateIn.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                //txtRegistrationGateIn.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                //txtCustomerDateSec.Text = DateTime.Now.ToString("dd/MM/yyyy");
                //this.txtTimeofArrivalSec.Text = DateTime.Now.ToString("hh:mm:ss tt");
                if (Session["LoggedInUserID"] == null || Session["LoggedInUserID"].ToString() == string.Empty)
                    Response.Redirect("~/Home/Login.aspx", true);
                else
                    lblUser_Name.Text = Session["LoggedInUser_UserName"] != null ? Session["LoggedInUser_UserName"].ToString() : string.Empty;
               
                WebControl.DisabledCssClass = "";
            }
        }

        private void GetDeliveryOrderInfo(string barCode)
        {
            try
            {
                if (con.connection.State == ConnectionState.Closed)
                {
                    Session["DeliveryID"] = txtDeliveryOrderIdSecurity.Text;
                    con.connection.Open();

                    sqlCommand = new SqlCommand();
                    sqlCommand.Connection = con.connection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "USP_M_TRANSPORTREGISTRATION_SEARCH";
                    sqlCommand.Parameters.AddWithValue("@ACTION", "S");
                    //cmd.Parameters.AddWithValue("@DELIVERY_ORDER_ID", Convert.ToInt32(deliveryOrderId));
                    sqlCommand.Parameters.AddWithValue("@QR_CODE", barCode);
                    sqlCommand.CommandTimeout = 20000;
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtMSalesOrderID.Text = ds.Tables[0].Rows[0]["SALES_ORDER_MASTER_ID"].ToString();
                        txtDeliveryOrderIdSecurity.Text = ds.Tables[0].Rows[0]["DELIVERY_ORDER_MASTER_ID"].ToString();
                        txtSalesOrderID.Text = ds.Tables[0].Rows[0]["SALES_ORDER_MASTER_ID"].ToString();
                        txtDeliveryOrderIdCust.Text = ds.Tables[0].Rows[0]["DELIVERY_ORDER_MASTER_ID"].ToString();
                        txt_KTP_Cust.Text = ds.Tables[0].Rows[0]["KTP"].ToString();
                        txtTransporterNameCust.Text = ds.Tables[0].Rows[0]["TRANSPORTER_NAME"].ToString();
                        txtCustomerDateCust.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DATE"].ToString()).ToString("dd/MM/yyyy");
                        txtTimeofArrivalCust.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["TIME_ARRIVAL"].ToString()).ToString("hh:mm:ss tt");
                        txtVehicleNumberCust.Text = ds.Tables[0].Rows[0]["VEHICLE_NUMBER"].ToString();
                        txtSourceCust.Text = ds.Tables[0].Rows[0]["SOURCE"].ToString();
                        txtVehicleDetailsCust.Text = ds.Tables[0].Rows[0]["VEHICLE_DETAILS"].ToString();
                        txtMUomSec.Text = txtUomCust.Text = ds.Tables[0].Rows[0]["UOM"].ToString();
                        txtDriverNameCust.Text = ds.Tables[0].Rows[0]["DRIVER_NAME"].ToString();
                        txtDriverNumberCust.Text = ds.Tables[0].Rows[0]["DRIVER_CONTACT"].ToString();
                        txtDriverID.Text = ds.Tables[0].Rows[0]["DRIVER_ID"].ToString();
                        txtMismatchTotalQuantity.Text = txtTotalQuantity.Text = ds.Tables[0].Rows[0]["TONNAGE_QUANTITY"].ToString();

                        txtAxptaSalesOrderId.Text = txtMAxptaSalesOrderId.Text = ds.Tables[0].Rows[0]["SALES_ORDER_ID"].ToString();
                        txtAxptaDeliveryOrderId.Text = txtMAxptaDeliveryOrderId.Text = ds.Tables[0].Rows[0]["DELIVERY_ID"].ToString();
                        txtMatchRegistrationGateIn.Text = ds.Tables[0].Rows[0]["REGISTRATION_GATE_IN"] != DBNull.Value ? Convert.ToDateTime(ds.Tables[0].Rows[0]["REGISTRATION_GATE_IN"]).ToString("dd/MM/yyyy hh:mm:ss tt") : DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");

                        txtCustomerDateSec.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        txtTimeofArrivalSec.Text = DateTime.Now.ToString("hh:mm:ss tt");
                        txtRegistrationGateIn.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");

                        lblTokenNo.Text = ds.Tables[0].Rows[0]["DO_TOKEN_NO"] != DBNull.Value ? ds.Tables[0].Rows[0]["DO_TOKEN_NO"].ToString() : string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.connection.Close();
            }
        }

        private void GetMismatchVehicleInfo()
        {
            try
            {
                using (sqlConnection = con.connection)
                {
                    using (sqlCommand = new SqlCommand())
                    {
                        if (sqlConnection.State == ConnectionState.Closed)
                        {
                            sqlConnection.Open();
                        }
                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.CommandText = "USP_M_TRANSPORTREGISTRATION_CUSTOMER_SHOW";//USP_M_TRANSPORTREGISTRATION_CUSTOMERMATCH_SHOW
                        sqlCommand.CommandTimeout = 20000;
                        sqlCommand.Parameters.AddWithValue("@ACTION", "V");
                        sqlCommand.Parameters.AddWithValue("@ID_NO", null);
                        sqlCommand.Parameters.AddWithValue("@DELIVERY_ORDER_MASTER_ID", Convert.ToInt32(!string.IsNullOrEmpty(txtDeliveryOrderIdCust.Text) ? txtDeliveryOrderIdCust.Text : "0"));
                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            txt_KTP_SEC.CssClass =ds.Tables[0].Rows[0]["SEC_MISMATCH_KTP_ID"]==DBNull.Value || txt_KTP_Cust.Text == ds.Tables[0].Rows[0]["SEC_MISMATCH_KTP_ID"].ToString() ? "" : "Mismatch";
                            txt_KTP_SEC.Text = txt_KTP_SEC.CssClass == "Mismatch" ? ds.Tables[0].Rows[0]["SEC_MISMATCH_KTP_ID"].ToString() : txt_KTP_Cust.Text;

                            txtTransporterNameSec.CssClass =ds.Tables[0].Rows[0]["SEC_MISMATCH_TRANSPORTER_NAME"]==DBNull.Value || txtTransporterNameCust.CssClass == ds.Tables[0].Rows[0]["SEC_MISMATCH_TRANSPORTER_NAME"].ToString() ? "" : "Mismatch";
                            txtTransporterNameSec.Text = txtTransporterNameSec.CssClass == "Mismatch" ? ds.Tables[0].Rows[0]["SEC_MISMATCH_TRANSPORTER_NAME"].ToString() : txtTransporterNameCust.Text;

                            txtVehicleNumberSec.CssClass =ds.Tables[0].Rows[0]["SEC_MISMATCH_VEHICLE_NUMBER"]==DBNull.Value || txtVehicleNumberCust.Text == ds.Tables[0].Rows[0]["SEC_MISMATCH_VEHICLE_NUMBER"].ToString() ? "" : "Mismatch";
                            txtVehicleNumberSec.Text = txtVehicleNumberSec.CssClass == "Mismatch" ? ds.Tables[0].Rows[0]["SEC_MISMATCH_VEHICLE_NUMBER"].ToString() : txtVehicleNumberCust.Text;

                            txtSourceSec.CssClass =ds.Tables[0].Rows[0]["SEC_MISMATCH_SOURCE"]==DBNull.Value || txtSourceCust.Text == ds.Tables[0].Rows[0]["SEC_MISMATCH_SOURCE"].ToString() ? "" : "Mismatch";
                            txtSourceSec.Text = txtSourceSec.CssClass == "Mismatch" ? ds.Tables[0].Rows[0]["SEC_MISMATCH_SOURCE"].ToString() : txtSourceSec.Text;

                            txtVehicleDetailsSec.CssClass =ds.Tables[0].Rows[0]["SEC_MISMATCH_VEHICLE_DETAILS"]==DBNull.Value || txtVehicleDetailsCust.Text == ds.Tables[0].Rows[0]["SEC_MISMATCH_VEHICLE_DETAILS"].ToString() ? "" : "Mismatch";
                            txtVehicleDetailsSec.Text = txtVehicleDetailsCust.Text != ds.Tables[0].Rows[0]["SEC_MISMATCH_VEHICLE_DETAILS"].ToString() ? ds.Tables[0].Rows[0]["SEC_MISMATCH_VEHICLE_DETAILS"].ToString() : txtVehicleDetailsCust.Text;

                            txtDriverNameSec.CssClass =ds.Tables[0].Rows[0]["SEC_MISMATCH_DRIVER_NAME"]==DBNull.Value || txtDriverNameCust.Text == ds.Tables[0].Rows[0]["SEC_MISMATCH_DRIVER_NAME"].ToString() ? "" : "Mismatch";
                            txtDriverNameSec.Text = txtDriverNameSec.CssClass == "Mismatch" ? ds.Tables[0].Rows[0]["SEC_MISMATCH_DRIVER_NAME"].ToString() : txtDriverNameCust.Text;

                            txtDriverNumberSec.CssClass = ds.Tables[0].Rows[0]["SEC_MISMATCH_DRIVER_CONTACT"] == DBNull.Value || txtDriverNumberCust.Text == ds.Tables[0].Rows[0]["SEC_MISMATCH_DRIVER_CONTACT"].ToString() ? "" : "Mismatch";
                            txtDriverNumberSec.Text = txtDriverNumberSec.CssClass == "Mismatch" ? ds.Tables[0].Rows[0]["SEC_MISMATCH_DRIVER_CONTACT"].ToString() : txtDriverNumberCust.Text;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btn_Match_Click(object sender, EventArgs e)
        {
            string outputMessage= SaveRegisterationDetails();
            if (!string.IsNullOrEmpty(outputMessage) && outputMessage=="SUCCESS")
            {
                bool isMismatched = Convert.ToBoolean(hdnIsMismatched.Value);
                int deliveryOrderId = Convert.ToInt32(!string.IsNullOrEmpty(txtDeliveryOrderIdSecurity.Text) ? txtDeliveryOrderIdSecurity.Text : "0");
                if (isMismatched)
                    CustomerMismatchApproval(deliveryOrderId);
                else
                    CustomerMatchApproval(deliveryOrderId);

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowPopUp();", true);
            }
            else
            {
                // Show Error Message;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowErroPopUp();", true);
            }
            
        }

        private string SaveRegisterationDetails()
        {
            try
            {
                if (con.connection.State == ConnectionState.Closed)
                {
                    con.connection.Open();
                }
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = con.connection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "USP_SAVE_REGISTRATION_DETAILS";
                sqlCommand.CommandTimeout = 20000;
                sqlCommand.Parameters.AddWithValue("@SALES_ORDER_MASTER_ID", txtMSalesOrderID.Text);
                sqlCommand.Parameters.AddWithValue("@DELIVERY_ORDER_MASTER_ID", txtDeliveryOrderIdSecurity.Text);
                sqlCommand.Parameters.AddWithValue("@KTP", !string.IsNullOrEmpty(txt_KTP_Cust.Text) ? txt_KTP_Cust.Text : null);
                sqlCommand.Parameters.AddWithValue("@TRANSPORTER_NAME", !string.IsNullOrEmpty(txtTransporterNameCust.Text) ? txtTransporterNameCust.Text : null);
                sqlCommand.Parameters.AddWithValue("@ARRIVAL_DATE", !string.IsNullOrEmpty(txtCustomerDateSec.Text) ? DateTime.ParseExact(txtCustomerDateSec.Text, "dd/MM/yyyy", null).ToString() : null);
                sqlCommand.Parameters.AddWithValue("@ARRIVAL_TIME", !string.IsNullOrEmpty(txtTimeofArrivalSec.Text) ? txtTimeofArrivalSec.Text : null);//Convert.ToDateTime(txtTimeofArrivalSec.Text)
                sqlCommand.Parameters.AddWithValue("@VEHICLE_NUMBER", !string.IsNullOrEmpty(txtVehicleNumberCust.Text) ? txtVehicleNumberCust.Text : null);
                sqlCommand.Parameters.AddWithValue("@SOURCE", !string.IsNullOrEmpty(txtSourceCust.Text) ? txtSourceCust.Text : null);
                sqlCommand.Parameters.AddWithValue("@VEHICLE_DETAILS", !string.IsNullOrEmpty(txtVehicleDetailsCust.Text) ? txtVehicleDetailsCust.Text : null);
                sqlCommand.Parameters.AddWithValue("@UOM", !string.IsNullOrEmpty(txtUomCust.Text) ? txtUomCust.Text : null);
                sqlCommand.Parameters.AddWithValue("@TONNAGE_QUANTITY", !string.IsNullOrEmpty(txtTotalQuantity.Text) ? txtTotalQuantity.Text : null);
                sqlCommand.Parameters.AddWithValue("@DRIVER_NAME", !string.IsNullOrEmpty(txtDriverNameCust.Text) ? txtDriverNameCust.Text : null);
                sqlCommand.Parameters.AddWithValue("@DRIVER_ID", !string.IsNullOrEmpty(txtDriverID.Text) ? txtDriverID.Text : null);
                sqlCommand.Parameters.AddWithValue("@DRIVER_CONTACT", !string.IsNullOrEmpty(txtDriverNumberCust.Text) ? txtDriverNumberCust.Text : null);
                var registration_Gate_In = !string.IsNullOrEmpty(txtMatchRegistrationGateIn.Text) ? DateTime.ParseExact(txtMatchRegistrationGateIn.Text, "dd/MM/yyyy hh:mm:ss tt", null) : DateTime.Now;
                sqlCommand.Parameters.AddWithValue("@REGISTRATION_GATE_IN", registration_Gate_In);
                //Logged In User Info need to puul here.
                sqlCommand.Parameters.AddWithValue("@AUTHORIZED_BY", txtAuthorizedbySec.Text);
                sqlCommand.Parameters.AddWithValue("@AUTHORIZED_CONTACT_NO", txtAuthorizationContactNoSec.Text);
                sqlCommand.Parameters.AddWithValue("@AUTHORIZED_MAIL", txtAuthorizationMailSec.Text);
                SqlParameter par = new SqlParameter("@OUTMSG", SqlDbType.VarChar, 50);
                par.Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add(par);
                int registrationID = Convert.ToInt32(sqlCommand.ExecuteScalar());
                string outputMessage = (string)sqlCommand.Parameters["@OUTMSG"].Value;
                return outputMessage;
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.connection.Close();
            }
        }

        private void CustomerMatchApproval(int deliveryOrderId)
        {
            try
            {
                if (con.connection.State == ConnectionState.Closed)
                {
                    con.connection.Open();
                }
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = con.connection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "USP_CUSTOMERINFORMATION_PASS";
                sqlCommand.CommandTimeout = 20000;
                sqlCommand.Parameters.AddWithValue("@ACTION", "P");
                sqlCommand.Parameters.AddWithValue("@DELIVERY_ID", deliveryOrderId);
                da = new SqlDataAdapter(sqlCommand);
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string OrderId = txtMSalesOrderID.Text;
                    string CustomerEMail = ds.Tables[0].Rows[0]["CUSTOMER_EMAIL"] != DBNull.Value ? ds.Tables[0].Rows[0]["CUSTOMER_EMAIL"].ToString() : string.Empty;
                    string CustomerName = ds.Tables[0].Rows[0]["CUSTOMER_NAME"] != DBNull.Value ? ds.Tables[0].Rows[0]["CUSTOMER_NAME"].ToString() : string.Empty;
                    string salesTeamEmailID = ds.Tables[0].Rows[0]["SALES_TEAM_EMP_MAIL"] != DBNull.Value ? ds.Tables[0].Rows[0]["SALES_TEAM_EMP_MAIL"].ToString() : string.Empty;
                    string axptaSalesOrderId = ds.Tables[0].Rows[0]["SALES_ORDER_ID"] != DBNull.Value ? ds.Tables[0].Rows[0]["SALES_ORDER_ID"].ToString() : string.Empty;
                    string axptaDeliveryOrderId = ds.Tables[0].Rows[0]["DELIVERY_ID"] != DBNull.Value ? ds.Tables[0].Rows[0]["DELIVERY_ID"].ToString() : string.Empty;
                    string compnayName = ds.Tables[0].Rows[0]["COMPANY_NAME"] != DBNull.Value ? ds.Tables[0].Rows[0]["COMPANY_NAME"].ToString() : string.Empty;
                    HttpRequest request = HttpContext.Current.Request;
                    string baseURL = request["HTTP_HOST"];
                    baseURL = baseURL + "/" + request.RawUrl.ToString().Split('/')[1];
                    string body = string.Format("Dear {0},<br /><br />", CustomerName);
                    body = body + string.Format("For Company-" + compnayName + "  <b>Sales Order No.-" + axptaSalesOrderId + "</b> and <b>Delevery Order No.-" + axptaDeliveryOrderId + "</b> is waiting for your Approval/Validation.<br/><br/>");
                    body = body + string.Format("Kindly Approve/Validate by clicking on below link:<br /><br />");
                    body = body + String.Format("<a href=\"https://" + baseURL + "/GSGCustomer/CustomerMatch.aspx/?CustomerMatch={0}\" +txtDeliveryOrderIdCust.Text>Click Here To Approve/Reject Your Order Details</a>", deliveryOrderId);
                    body = body + string.Format("<br/><br/><br/><b>Thanks and Regard's</b><br/>");
                    body = body + string.Format("Gunung Admin Group");
                    string fromMailAddress = System.Configuration.ConfigurationManager.AppSettings["TargetEmailAddress"];
                    string toMailAddress = CustomerEMail;
                    string subject = "APPROVE YOUR ORDER DETAILS";
                    Notification.EMail.SendMail(fromMailAddress, toMailAddress, subject, body, salesTeamEmailID);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.connection.Close();
            }

        }

        private void CustomerMismatchApproval(int deliveryOrderId)
        {
            try
            {
                if (con.connection.State == ConnectionState.Closed)
                {
                    con.connection.Open();
                }
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = con.connection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "USP_M_SECURITY_CUSTOMER_MISMATCH_DETAILS_AUD";
                sqlCommand.CommandTimeout = 20000;
                sqlCommand.Parameters.AddWithValue("@ACTION", "I");
                sqlCommand.Parameters.AddWithValue("@SEC_MISMATCH_KTP_ID", !string.IsNullOrEmpty(txt_KTP_SEC.Text) ? txt_KTP_SEC.Text : null);
                sqlCommand.Parameters.AddWithValue("@SEC_MISMATCH_TRANSPORTER_NAME", !string.IsNullOrEmpty(txtTransporterNameSec.Text) ? txtTransporterNameSec.Text : null);
                sqlCommand.Parameters.AddWithValue("@SEC_MISMATCH_DATE", !string.IsNullOrEmpty(txtCustomerDateSec.Text) ? DateTime.ParseExact(txtCustomerDateSec.Text, "dd/MM/yyyy", null).ToString() : null);
                sqlCommand.Parameters.AddWithValue("@SEC_MISMATCH_TIME_ARRIVAL", !string.IsNullOrEmpty(txtTimeofArrivalSec.Text) ? txtTimeofArrivalSec.Text : null);//Convert.ToDateTime(txtTimeofArrivalSec.Text)
                sqlCommand.Parameters.AddWithValue("@SEC_MISMATCH_VEHICLE_NUMBER", !string.IsNullOrEmpty(txtVehicleNumberSec.Text) ? txtVehicleNumberSec.Text : null);
                sqlCommand.Parameters.AddWithValue("@SEC_MISMATCH_SOURCE", !string.IsNullOrEmpty(txtSourceSec.Text) ? txtSourceSec.Text : null);
                sqlCommand.Parameters.AddWithValue("@SEC_MISMATCH_VEHICLE_DETAILS", !string.IsNullOrEmpty(txtVehicleDetailsSec.Text) ? txtVehicleDetailsSec.Text : null);
                sqlCommand.Parameters.AddWithValue("@SEC_MISMATCH_UOM", !string.IsNullOrEmpty(txtMUomSec.Text) ? txtMUomSec.Text : null);
                sqlCommand.Parameters.AddWithValue("@SEC_MISMATCH_DRIVER_NAME", !string.IsNullOrEmpty(txtDriverNameSec.Text) ? txtDriverNameSec.Text : null);
                sqlCommand.Parameters.AddWithValue("@SEC_MISMATCH_DRIVER_ID", !string.IsNullOrEmpty(txtMisMatchDriverID.Text) ? txtMisMatchDriverID.Text : null);
                sqlCommand.Parameters.AddWithValue("@SEC_MISMATCH_DRIVER_CONTACT", !string.IsNullOrEmpty(txtDriverNumberSec.Text) ? txtDriverNumberSec.Text : null);
                //cmd.Parameters.AddWithValue("@SEC_MISMATCH_DRIVER_CONTACT", !string.IsNullOrEmpty(txtDriverNumberSec.Text) ? txtDriverNumberSec.Text : null);
                sqlCommand.Parameters.AddWithValue("@SEC_SECURITY_AUTHORIZED_BY", txtAuthorizedbySec.Text);
                sqlCommand.Parameters.AddWithValue("@SEC_SECURITY_AUTHORIZED_CONTACT_NO", txtAuthorizationContactNoSec.Text);
                sqlCommand.Parameters.AddWithValue("@SEC_SECURITY_AUTHORIZED_MAIL", txtAuthorizationMailSec.Text);
                sqlCommand.Parameters.AddWithValue("@DELIVERY_ORDER_ID", deliveryOrderId);
                SqlParameter par = new SqlParameter("@OUTMSG", SqlDbType.VarChar, 50);
                par.Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add(par);
                int vehicleMismatchID = Convert.ToInt32(sqlCommand.ExecuteScalar());
                Session["VehicleMismatchID"] = vehicleMismatchID;

                sqlCommand = new SqlCommand();
                sqlCommand.Connection = con.connection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "USP_CUSTOMERINFORMATION_PASS";
                sqlCommand.CommandTimeout = 20000;
                sqlCommand.Parameters.AddWithValue("@ACTION", "P");
                sqlCommand.Parameters.AddWithValue("@DELIVERY_ID", deliveryOrderId);
                da = new SqlDataAdapter(sqlCommand);
                ds = new DataSet();
                da.Fill(ds);

                 if (ds.Tables[0].Rows.Count > 0)
                {
                    
                    string CustomerEMail = ds.Tables[0].Rows[0]["CUSTOMER_EMAIL"] != DBNull.Value ? ds.Tables[0].Rows[0]["CUSTOMER_EMAIL"].ToString() : string.Empty;
                    string CustomerName = ds.Tables[0].Rows[0]["CUSTOMER_NAME"] != DBNull.Value ? ds.Tables[0].Rows[0]["CUSTOMER_NAME"].ToString() : string.Empty;
                    string salesTeamEmailID = ds.Tables[0].Rows[0]["SALES_TEAM_EMP_MAIL"] != DBNull.Value ? ds.Tables[0].Rows[0]["SALES_TEAM_EMP_MAIL"].ToString() : string.Empty;
                    string axptaSalesOrderId = ds.Tables[0].Rows[0]["SALES_ORDER_ID"] != DBNull.Value ? ds.Tables[0].Rows[0]["SALES_ORDER_ID"].ToString() : string.Empty;
                    string axptaDeliveryOrderId = ds.Tables[0].Rows[0]["DELIVERY_ID"] != DBNull.Value ? ds.Tables[0].Rows[0]["DELIVERY_ID"].ToString() : string.Empty;
                    string compnayName = ds.Tables[0].Rows[0]["COMPANY_NAME"] != DBNull.Value ? ds.Tables[0].Rows[0]["COMPANY_NAME"].ToString() : string.Empty;
                    string OrderId = txtMSalesOrderID.Text;
                    HttpRequest request = HttpContext.Current.Request;
                    string baseURL = request["HTTP_HOST"];
                    baseURL = baseURL + "/" + request.RawUrl.ToString().Split('/')[1];
                    string body = string.Format("Dear {0},<br/><br/><br/>", CustomerName);
                    body = body + string.Format("For Company-" + compnayName + "   <b>Sales Order No.-" + axptaSalesOrderId + "</b> and <b>Delevery Order No.-" + axptaDeliveryOrderId + "</b> is waiting for your Approval/Validation.<br/><br/>");
                    body = body + string.Format("Kindly Approve/Validate by clicking on below link:<br /><br />");
                    body = body + String.Format("<a href=\"https://" + baseURL + "/GSGCustomer/CustomerMismatchApproval.aspx/?CustomerMismatch={0}&DeliveryId={1}\"> Click Here To Approve/Reject Your Order Details</a>", vehicleMismatchID, deliveryOrderId);
                    body = body + string.Format("<br/><br/><br/><b>Thanks and Regards</b><br/>");
                    body = body + string.Format("Gunung Admin Group");
                    string fromMailAddress = System.Configuration.ConfigurationManager.AppSettings["TargetEmailAddress"];
                    string toMailAddress = CustomerEMail;
                    string subject = "APPROVE YOUR ORDER DETAILS";
                    Notification.EMail.SendMail(fromMailAddress, toMailAddress, subject, body, salesTeamEmailID);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.connection.Close();
            }
        }

        protected void txtQRCode_TextChanged(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(txtQRCode.Text) && txtQRCode.Text.Length >= 9)
            //{
            //    string barCode = txtQRCode.Text;
            //    GetDeliveryOrderInfo(barCode);
            //    GetMismatchVehicleInfo();
            //}
        }

        protected void Search(object sender, EventArgs e)
        {
            string barCode = txtQRCode.Text;
            GetDeliveryOrderInfo(barCode);
            GetMismatchVehicleInfo();
        }
    }
}