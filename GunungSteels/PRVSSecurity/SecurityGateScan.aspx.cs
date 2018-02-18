using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GunungSteels.App_Code;
using GunungSteels.Notification;
using System.Globalization;
using GunungSteels.Common;


namespace GunungSteels.PRVSSecurity
{
    public partial class SecurityGateScan : System.Web.UI.Page
    {
        public SqlConnection sqlConnection;
        public SqlCommand sqlCommand;
        string security_Access_Gate_Status;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Hard coded data ,need to fecth from Barcode Scanned files  
            //var barCode = txtQRCode.Text = "997652151";
            if (!IsPostBack)
            {
                //txtSecurityGateInDate.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                //txtSalesOrderID.Text = "1";
                //txtDeliveryOrderId.Text = "1";
                if (Session["LoggedInUserID"] == null || Session["LoggedInUserID"].ToString() == string.Empty)
                    Response.Redirect("~/Home/Login.aspx", true);
                else
                    lblUser_Name.Text = Session["LoggedInUser_UserName"] != null ? Session["LoggedInUser_UserName"].ToString() : string.Empty;
            }
            //GetSceurityGateInOutStatus(barCode);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            security_Access_Gate_Status = hdnSecurityGateAccess.Text;
            //Save Security Gate In-Out Data in PRVS System after Scanning QR Code 
            var secGateIn = !string.IsNullOrEmpty(txtSecurityGateInDate.Text) ? DateTime.ParseExact(txtSecurityGateInDate.Text, "dd/MM/yyyy hh:mm:ss tt", null) : DateTime.Now;
            var secGateOut = !string.IsNullOrEmpty(txtSecurityGateOutDate.Text) ? DateTime.ParseExact(txtSecurityGateOutDate.Text, "dd/MM/yyyy hh:mm:ss tt", null) : DateTime.Now;
            string retMessage =security_Access_Gate_Status!= Constants.gateOut ? SaveSecurityGateInOutAccessInfo(secGateIn, secGateOut):string.Empty;
            //Redirecting to PRVS-Registration page not required
            if (!string.IsNullOrEmpty(retMessage) && retMessage == "SUCCESS")
            {
               //Send Notification Mail to Customer while Gate Out
                if (security_Access_Gate_Status == "IN")
                {
                    int salesOrderMasterId = Convert.ToInt32(txtSalesOrderID.Text);
                    int deliveryOrderMasterId = Convert.ToInt32(txtDeliveryOrderId.Text);
                    security_Access_Gate_Status = string.Empty;
                    Notify(string.Empty, salesOrderMasterId, deliveryOrderMasterId);
                }
                //Server.Transfer("Registration.aspx?DeliveryId=" + txtDeliveryOrderId.Text);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowPopUp();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowPopUp();", true);
            }
        }

        private void Notify(string bodyTag, int salesOrderMasterId, int deliveryOrderMasterId)
        {
            DataTable dt = GetCustomerDetails(salesOrderMasterId, deliveryOrderMasterId);
            if (dt.Rows.Count > 0)
            {
                string CustomerEMail = dt.Rows[0]["CUSTOMER_EMAIL"] != DBNull.Value ? dt.Rows[0]["CUSTOMER_EMAIL"].ToString() : string.Empty;
                string CustomerName = dt.Rows[0]["CUSTOMER_NAME"] != DBNull.Value ? dt.Rows[0]["CUSTOMER_NAME"].ToString() : string.Empty;
                string salesTeamEmailID = dt.Rows[0]["SALES_TEAM_EMP_MAIL"] != DBNull.Value ? dt.Rows[0]["SALES_TEAM_EMP_MAIL"].ToString() : string.Empty;
                string axptaSalesOrderId = dt.Rows[0]["SALES_ORDER_ID"] != DBNull.Value ? dt.Rows[0]["SALES_ORDER_ID"].ToString() : string.Empty;
                string axptaDeliveryOrderId = dt.Rows[0]["DELIVERY_ID"] != DBNull.Value ? dt.Rows[0]["DELIVERY_ID"].ToString() : string.Empty;
                string companyName = dt.Rows[0]["COMPANY_NAME"] != DBNull.Value ? dt.Rows[0]["COMPANY_NAME"].ToString() : string.Empty;
                string fromMailAddress = System.Configuration.ConfigurationManager.AppSettings["TargetEmailAddress"];
                string toMailAddress = CustomerEMail;
                string ccMailAddress = salesTeamEmailID;
                string subject = "DELIVERY STATUS";
                string body = string.Format("Dear {0},<br/><br/><br/>", CustomerName);
                body = body + string.Format("For Company-" + companyName + "  <b>Sales Order No.-" + axptaSalesOrderId + "</b> and <b>Delivery Order No.-" + axptaDeliveryOrderId + "</b>  has been delivered.<br/><br/><br/>");
                body = body + string.Format("<b>Thanks and Regards</b><br/>");
                body = body + string.Format("Gunung Admin Group");
                Notification.EMail.SendMail(fromMailAddress, toMailAddress, subject, body, ccMailAddress);
            }
        }

        private DataTable GetCustomerDetails(int salesOrderMasterId, int deliveryOrderMasterId)
        {
            DataTable dt = null;
            using (sqlConnection = new DBConnection().connection)
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    if (sqlConnection.State == ConnectionState.Closed)
                        sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "USP_GET_NOTIFY_CUSTOMER_DETAILS";
                    sqlCommand.Parameters.AddWithValue("@SALES_ORDER_MASTER_ID", salesOrderMasterId);
                    sqlCommand.Parameters.AddWithValue("@DELIVERY_ORDER_MASTER_ID", deliveryOrderMasterId);
                    sqlCommand.CommandTimeout = 2000;
                    using (SqlDataAdapter sda = new SqlDataAdapter(sqlCommand))
                    {
                        dt = new DataTable();
                        sda.Fill(dt);
                    }
                }
            }
            return dt;
        }

        private string SaveSecurityGateInOutAccessInfo(DateTime secGateIn, DateTime secGateOut)
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
                        sqlCommand.CommandText = "USP_SAVE_SECURITY_GATE_IN_OUT_ACCESS_INFO";
                        sqlCommand.CommandTimeout = 20000;
                        sqlCommand.Parameters.AddWithValue("@QR_CODE", !string.IsNullOrEmpty(txtQRCode.Text) ? txtQRCode.Text : null);
                        sqlCommand.Parameters.AddWithValue("@SALES_ORDER_MASTER_ID", !string.IsNullOrEmpty(txtSalesOrderID.Text) ? txtSalesOrderID.Text : null);
                        sqlCommand.Parameters.AddWithValue("@DELIVERY_ORDER_MASTER_ID", !string.IsNullOrEmpty(txtDeliveryOrderId.Text) ? txtDeliveryOrderId.Text : null);//DateTime.ParseExact(txtDeliveryOrderId.Text, "dd/MM/yyyy", null).ToString()
                        sqlCommand.Parameters.AddWithValue("@SECURITY_GATE_IN", secGateIn);
                        sqlCommand.Parameters.AddWithValue("@SECURITY_GATE_OUT", secGateOut);
                        SqlParameter par = new SqlParameter("@OUTMSG", SqlDbType.VarChar, 50);
                        par.Direction = ParameterDirection.Output;
                        sqlCommand.Parameters.Add(par);
                        int security_Entry_Id = Convert.ToInt32(sqlCommand.ExecuteScalar());
                        
                        if (security_Entry_Id > 0)
                            txtTokenNo.Text = security_Entry_Id.ToString();

                        string message = (string)sqlCommand.Parameters["@OUTMSG"].Value;
                        return message;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void txtQRCode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQRCode.Text) && txtQRCode.Text.Length >= 9)
            {
                string barcode = txtQRCode.Text;//694026538
                //Get Security Gate In Details using sacanned Bar Cod
               GetSceurityGateInOutStatus(barcode);
            }
        }

        private void GetSceurityGateInOutStatus(string barCode)
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
                        sqlCommand.CommandText = "USP_GET_QR_CODE_ACCESS_IN_OUT_INFO";
                        sqlCommand.Parameters.AddWithValue("@SecGateOrWHGate_AccessType", "SCG");
                        sqlCommand.Parameters.AddWithValue("@QR_CODE", barCode);
                        sqlCommand.CommandTimeout = 20000;
                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                        da.Fill(ds);
                        security_Access_Gate_Status = string.Empty;
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            hdnSecurityGateAccess.Text = security_Access_Gate_Status = ds.Tables[0].Rows[0]["SECURITY_ACCESS_GATE_STATUS"] != DBNull.Value ? ds.Tables[0].Rows[0]["SECURITY_ACCESS_GATE_STATUS"].ToString() : string.Empty;

                            if (!security_Access_Gate_Status.Equals(Constants.invalidAccess))
                            {
                                txtSalesOrderID.Text = ds.Tables[0].Rows[0]["SALES_ORDER_MASTER_ID"].ToString();
                                txtDeliveryOrderId.Text = ds.Tables[0].Rows[0]["DELIVERY_ORDER_MASTER_ID"].ToString();
                                txtAxptaSalesOrderId.Text = ds.Tables[0].Rows[0]["SALES_ORDER_ID"].ToString();
                                txtAxptaDeliveryOrderId.Text = ds.Tables[0].Rows[0]["DELIVERY_ID"].ToString();
                                txtCustomerApprovalStatus.Text = ds.Tables[0].Rows[0]["CUSTOMER_APPROVAL_STATUS"].ToString();
                                txtTokenNo.Text = ds.Tables[0].Rows[0]["DO_TOKEN_NO"].ToString();
                                if (security_Access_Gate_Status !=Constants.gateNotIN)
                                {
                                    txtSecurityGateInDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["SECURITY_GATE_IN"].ToString()).ToString("dd/MM/yyyy hh:mm:ss tt");// secInDate + " " + secInTime;
                                }
                                else
                                {
                                    txtSecurityGateInDate.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                                }
                                if (security_Access_Gate_Status ==Constants.gateIn)
                                {
                                    txtSecurityGateOutDate.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                                }
                                else if (security_Access_Gate_Status ==Constants.gateOut)
                                {
                                    txtSecurityGateOutDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["SECURITY_GATE_OUT"].ToString()).ToString("dd/MM/yyyy hh:mm:ss tt");// secOutDate + " " + secOutTime;
                                }
                            }
                            else
                            {
                                //Redirect to Error Page Or Show Massage 
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        protected void Search(object sender, EventArgs e)
        {
            var barCode = txtQRCode.Text;
            GetSceurityGateInOutStatus(barCode);
        }
    }
}