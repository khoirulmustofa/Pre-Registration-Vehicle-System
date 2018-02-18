using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GunungSteels.App_Code;

namespace GunungSteels.GSGCustomer
{
    public partial class CustomerMismatchApproval : System.Web.UI.Page
    {
        public SqlConnection sqlConnection;
        public SqlCommand sqlCommand;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sec_Mismatch_Id = Request.QueryString["CustomerMisMatch"] != null ? Request.QueryString["CustomerMisMatch"].ToString() : "0";
                string deliveryMasterId = Request.QueryString["DeliveryId"] != null ? Request.QueryString["DeliveryId"].ToString() : "0";
                if (Session["LoggedInCustomerID"] == null || Session["LoggedInCustomerID"].ToString() == string.Empty)
                {
                    Response.Redirect("~/GSGCustomer/User_Login.aspx?CustomerMismatch=" + deliveryMasterId + "&DeliveryId=" + deliveryMasterId, true);
                }
                else
                {
                    lblUser_Name.Text = Session["LoggedInUser_UserName"] != null ? Session["LoggedInUser_UserName"].ToString() : string.Empty;  
                    GetDeliveryOrderInfo(Convert.ToInt32(deliveryMasterId));
                    GetMismatchVehicleInfo(Convert.ToInt32(sec_Mismatch_Id));
                }
            }
        }

        private void GetMismatchVehicleInfo(int sec_Mismatch_Id)
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
                        sqlCommand.CommandText = "USP_M_TRANSPORTREGISTRATION_CUSTOMER_SHOW";//USP_M_TRANSPORTREGISTRATION_CUSTOMERMATCH_SHOW
                        sqlCommand.CommandTimeout = 20000;
                        sqlCommand.Parameters.AddWithValue("@ACTION", "V");
                        sqlCommand.Parameters.AddWithValue("@ID_NO", sec_Mismatch_Id);
                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            //txt_KTP.CssClass = ds.Tables[0].Rows[0]["SEC_MISMATCH_KTP_ID"].ToString() == "0" ? "" : "Mismatch";
                            //txt_KTP.Text = txt_KTP.CssClass == "Mismatch" ? ds.Tables[0].Rows[0]["SEC_MISMATCH_KTP_ID"].ToString() : txt_KTP.Text;

                            txt_KTP.CssClass = ds.Tables[0].Rows[0]["SEC_MISMATCH_KTP_ID"] == DBNull.Value || txt_KTP.Text == ds.Tables[0].Rows[0]["SEC_MISMATCH_KTP_ID"].ToString() ? "" : "Mismatch";
                            txt_KTP.Text = txt_KTP.CssClass == "Mismatch" ? ds.Tables[0].Rows[0]["SEC_MISMATCH_KTP_ID"].ToString() : txt_KTP.Text;

                            //txt_Transporter_Name.CssClass = ds.Tables[0].Rows[0]["SEC_MISMATCH_TRANSPORTER_NAME"].ToString() == "Matched" ? "" : "Mismatch";
                            //txt_Transporter_Name.Text = txt_Transporter_Name.CssClass == "Mismatch" ? ds.Tables[0].Rows[0]["SEC_MISMATCH_TRANSPORTER_NAME"].ToString() : txt_Transporter_Name.Text;

                            txt_Transporter_Name.CssClass =ds.Tables[0].Rows[0]["SEC_MISMATCH_TRANSPORTER_NAME"] == DBNull.Value ||  txt_Transporter_Name.CssClass == ds.Tables[0].Rows[0]["SEC_MISMATCH_TRANSPORTER_NAME"].ToString() ? "" : "Mismatch";
                            txt_Transporter_Name.Text = txt_Transporter_Name.CssClass == "Mismatch" ? ds.Tables[0].Rows[0]["SEC_MISMATCH_TRANSPORTER_NAME"].ToString() : txt_Transporter_Name.Text;


                            //txt_VehicleNumber.CssClass = ds.Tables[0].Rows[0]["SEC_MISMATCH_VEHICLE_NUMBER"].ToString() == "Matched" ? "" : "Mismatch";
                            //txt_VehicleNumber.Text = txt_VehicleNumber.CssClass == "Mismatch" ? ds.Tables[0].Rows[0]["SEC_MISMATCH_VEHICLE_NUMBER"].ToString() : txt_VehicleNumber.Text;

                            txt_VehicleNumber.CssClass =ds.Tables[0].Rows[0]["SEC_MISMATCH_VEHICLE_NUMBER"] == DBNull.Value ||  txt_VehicleNumber.Text == ds.Tables[0].Rows[0]["SEC_MISMATCH_VEHICLE_NUMBER"].ToString() ? "" : "Mismatch";
                            txt_VehicleNumber.Text = txt_VehicleNumber.CssClass == "Mismatch" ? ds.Tables[0].Rows[0]["SEC_MISMATCH_VEHICLE_NUMBER"].ToString() : txt_VehicleNumber.Text;


                            //txt_Source.CssClass = ds.Tables[0].Rows[0]["SEC_MISMATCH_SOURCE"].ToString() == "Matched" ? "" : "Mismatch";
                            //txt_Source.Text = txt_Source.CssClass == "Mismatch" ? ds.Tables[0].Rows[0]["SEC_MISMATCH_SOURCE"].ToString() : txt_Source.Text;

                            txt_Source.CssClass =ds.Tables[0].Rows[0]["SEC_MISMATCH_SOURCE"] == DBNull.Value ||  txt_Source.Text == ds.Tables[0].Rows[0]["SEC_MISMATCH_SOURCE"].ToString() ? "" : "Mismatch";
                            txt_Source.Text = txt_Source.CssClass == "Mismatch" ? ds.Tables[0].Rows[0]["SEC_MISMATCH_SOURCE"].ToString() : txt_Source.Text;

                            //txt_VehicleDetails.CssClass = ds.Tables[0].Rows[0]["SEC_MISMATCH_VEHICLE_DETAILS"].ToString() == "Matched" ? "" : "Mismatch";
                            //txt_VehicleDetails.Text = txt_VehicleDetails.CssClass == "Mismatch" ? ds.Tables[0].Rows[0]["SEC_MISMATCH_VEHICLE_DETAILS"].ToString() : txt_VehicleDetails.Text;

                            txt_VehicleDetails.CssClass =ds.Tables[0].Rows[0]["SEC_MISMATCH_VEHICLE_DETAILS"] == DBNull.Value ||  txt_VehicleDetails.Text == ds.Tables[0].Rows[0]["SEC_MISMATCH_VEHICLE_DETAILS"].ToString() ? "" : "Mismatch";
                            txt_VehicleDetails.Text = txt_VehicleDetails.Text != ds.Tables[0].Rows[0]["SEC_MISMATCH_VEHICLE_DETAILS"].ToString() ? ds.Tables[0].Rows[0]["SEC_MISMATCH_VEHICLE_DETAILS"].ToString() : txt_VehicleDetails.Text;

                            //txt_Uom.CssClass = ds.Tables[0].Rows[0]["SEC_MISMATCH_UOM"].ToString() == "Matched" ? "" : "Mismatch";
                            //txt_Uom.Text = txt_Uom.CssClass == "Mismatch" ? ds.Tables[0].Rows[0]["SEC_MISMATCH_UOM"].ToString() : txt_Uom.Text;

                            //txt_DriverName.CssClass = ds.Tables[0].Rows[0]["SEC_MISMATCH_DRIVER_NAME"].ToString() == "Matched" ? "" : "Mismatch";
                            //txt_DriverName.Text = txt_DriverName.CssClass == "Mismatch" ? ds.Tables[0].Rows[0]["SEC_MISMATCH_DRIVER_NAME"].ToString() : txt_DriverName.Text;

                            txt_DriverName.CssClass =ds.Tables[0].Rows[0]["SEC_MISMATCH_DRIVER_NAME"] == DBNull.Value ||  txt_DriverName.Text == ds.Tables[0].Rows[0]["SEC_MISMATCH_DRIVER_NAME"].ToString() ? "" : "Mismatch";
                            txt_DriverName.Text = txt_DriverName.CssClass == "Mismatch" ? ds.Tables[0].Rows[0]["SEC_MISMATCH_DRIVER_NAME"].ToString() : txt_DriverName.Text;

                            txt_Driver_Contact_No.CssClass = ds.Tables[0].Rows[0]["SEC_MISMATCH_DRIVER_CONTACT"] == DBNull.Value || txt_Driver_Contact_No.Text == ds.Tables[0].Rows[0]["SEC_MISMATCH_DRIVER_CONTACT"].ToString() ? "" : "Mismatch";
                            txt_Driver_Contact_No.Text = txt_Driver_Contact_No.CssClass == "Mismatch" ? ds.Tables[0].Rows[0]["SEC_MISMATCH_DRIVER_CONTACT"].ToString() : txt_Driver_Contact_No.Text;

                            //txtDriverID.CssClass = ds.Tables[0].Rows[0]["DRIVER_ID"].ToString() == "Matched" ? "" : "Mismatch";
                            //txtDriverID.Text = txtDriverID.CssClass == "Mismatch" ? ds.Tables[0].Rows[0]["DRIVER_ID"].ToString() : txtDriverID.Text;
                            
                            //txt_Authorized_By.Text = ds.Tables[0].Rows[0]["SEC_MISMATCH_AUTHORIZED_BY"].ToString();
                            //txt_Authorization_Contact_No.Text = ds.Tables[0].Rows[0]["SEC_MISMATCH_AUTHORIZATION_CONTACT"].ToString();
                            //txt_Authorization_Mail.Text = ds.Tables[0].Rows[0]["SEC_MISMATCH_AUTHORIZATION_MAIL"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetDeliveryOrderInfo(int deliveryOrderId)
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
                        Session["DeliveryID"] = deliveryOrderId;
                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.CommandText = "USP_M_TRANSPORTREGISTRATION_SEARCH";
                        sqlCommand.Parameters.AddWithValue("@ACTION", "S");
                        sqlCommand.Parameters.AddWithValue("@DELIVERY_ORDER_ID", Convert.ToInt32(deliveryOrderId));
                        sqlCommand.CommandTimeout = 20000;
                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            txt_MatchSalesOrder_Id.Text = txt_SalesOrder_Id.Text = ds.Tables[0].Rows[0]["SALES_ORDER_MASTER_ID"].ToString();
                            txtMatchDeliveryOrderId.Text = txtDeliveryOrderId.Text = ds.Tables[0].Rows[0]["DELIVERY_ORDER_MASTER_ID"].ToString();
                            txt_MatchKTP.Text = txt_KTP.Text = ds.Tables[0].Rows[0]["KTP"].ToString();
                            txt_MatchTransporter_Name.Text = txt_Transporter_Name.Text = ds.Tables[0].Rows[0]["TRANSPORTER_NAME"].ToString();
                            txt_MatchVehicleNumber.Text = txt_VehicleNumber.Text = ds.Tables[0].Rows[0]["VEHICLE_NUMBER"].ToString();
                            txt_MatchSource.Text = txt_Source.Text = ds.Tables[0].Rows[0]["SOURCE"].ToString();
                            txt_MatchVehicleDetails.Text = txt_VehicleDetails.Text = ds.Tables[0].Rows[0]["VEHICLE_DETAILS"].ToString();
                            txt_MatchUom.Text = txt_Uom.Text = ds.Tables[0].Rows[0]["UOM"].ToString();
                            txt_MatchDriverName.Text = txt_DriverName.Text = ds.Tables[0].Rows[0]["DRIVER_NAME"].ToString();
                            txt_MatchDriver_Contact_No.Text = txt_Driver_Contact_No.Text = ds.Tables[0].Rows[0]["DRIVER_CONTACT"].ToString();
                            txtMatchDriverID.Text = txtDriverID.Text = ds.Tables[0].Rows[0]["DRIVER_ID"].ToString();
                            txtMatchTotalQuantity.Text = txtTotalQuantity.Text = ds.Tables[0].Rows[0]["TONNAGE_QUANTITY"].ToString();

                            txtAxptaSalesOrderId.Text=txtMAxptaSalesOrderId.Text = ds.Tables[0].Rows[0]["SALES_ORDER_ID"].ToString();
                            txtAxptaDeliveryOrderId.Text= txtMAxptaDeliveryOrderId.Text = ds.Tables[0].Rows[0]["DELIVERY_ID"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private int UpdateCustomerOrderApproval(string approvalStatus)
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
                        sqlCommand.CommandText = "USP_M_TRANSPORTREGISTRATION_AUD";
                        sqlCommand.CommandTimeout = 20000;
                        sqlCommand.Parameters.AddWithValue("@@ACTION", "I");
                        sqlCommand.Parameters.AddWithValue("@SALES_ORDER_MASTER_ID", !string.IsNullOrEmpty(txt_SalesOrder_Id.Text) ? txt_SalesOrder_Id.Text : null);
                        sqlCommand.Parameters.AddWithValue("@DELIVERY_ORDER_MASTER_ID", !string.IsNullOrEmpty(txtDeliveryOrderId.Text) ? txtDeliveryOrderId.Text : null);//DateTime.ParseExact(txtDeliveryOrderId.Text, "dd/MM/yyyy", null).ToString()
                        sqlCommand.Parameters.AddWithValue("@CUSTOMER_REVIEW_STATUS", approvalStatus);
                        SqlParameter par = new SqlParameter("@OUTMSG", SqlDbType.VarChar, 50);
                        par.Direction = ParameterDirection.Output;
                        sqlCommand.Parameters.Add(par);

                        int Id_NO = Convert.ToInt32(sqlCommand.ExecuteScalar());
                        string message = (string)sqlCommand.Parameters["@OUTMSG"].Value;
                        return Id_NO;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Approve(object sender, EventArgs e)
        {
            int result = UpdateCustomerOrderApproval("Approved");
            //Sending Email FROM Customer To PRVS (Security Registration Team)
            int salesOrderMasterId = Convert.ToInt32(txt_SalesOrder_Id.Text);
            int deliveryOrderMasterId = Convert.ToInt32(txtDeliveryOrderId.Text);
            string body = string.Format("Dear Registration Team,<br/><br/><br/>");
            //body = body + string.Format("For <b> Sales Order-" + salesOrderMasterId + "</b> and <b>Delivery Order-" + deliveryOrderMasterId + "</b> has been approved by the Customer.<br/> Please proceed with this delivery order.<br/><br/><br/>");
            body = body + string.Format("From Comapany-axptaCompany for <b> Sales Order No.-axptaSalesOrderId</b> and <b>Delivery Order No.-axptaDeliveryOrderId</b> has been approved by the Customer.<br/> Please proceed with this delivery order.<br/><br/><br/>");
            body = body + string.Format("<b>Thanks and Regards</b><br/>");
            body = body + string.Format("Gunung Admin Group");
            Notify(body, salesOrderMasterId, deliveryOrderMasterId);

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowApprovalPopUp();", true);
        }

        protected void Reject(object sender, EventArgs e)
        {
            int result = UpdateCustomerOrderApproval("Rejected");
            //Sending Email FROM Customer To PRVS (Security Registration Team)
            int salesOrderMasterId = Convert.ToInt32(txt_SalesOrder_Id.Text);
            int deliveryOrderMasterId = Convert.ToInt32(txtDeliveryOrderId.Text);
            string body = string.Format("Dear Registration Team,<br/><br/><br/>");
            //body = body + string.Format("For <b>Sales Order No.-" + salesOrderMasterId + "</b> and <b>Delivery Order No.-" + deliveryOrderMasterId + "</b>  has been rejected by the Customer.</b><br/> Please do'nt proceed with this delivery order.<br/><br/><br/>");
            body = body + string.Format("From Comapany-axptaCompany for <b>Sales Order No.-axptaSalesOrderId</b> and <b>Delivery Order No.-axptaDeliveryOrderId</b>  has been rejected by the Customer.</b><br/> Please do'nt proceed with this delivery order.<br/><br/><br/>");
            body = body + string.Format("<b>Thanks and Regards</b><br/>");
            body = body + string.Format("Gunung Admin Group");
            Notify(body, salesOrderMasterId, deliveryOrderMasterId);

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowRejectionPopUp();", true);
        }

        private void Notify(string body, int salesOrderMasterId, int deliveryOrderMasterId)
        {
            //string CustomerEMail = string.Empty;
            //string CustomerName = string.Empty;
            DataTable dt = GetCustomerDetails(salesOrderMasterId, deliveryOrderMasterId);
            if (dt.Rows.Count > 0)
            {
                string CustomerEMail = dt.Rows[0]["CUSTOMER_EMAIL"] != DBNull.Value ? dt.Rows[0]["CUSTOMER_EMAIL"].ToString() : string.Empty;
                string CustomerName = dt.Rows[0]["CUSTOMER_NAME"] != DBNull.Value ? dt.Rows[0]["CUSTOMER_NAME"].ToString() : string.Empty;
                string salesTeamEmailID = dt.Rows[0]["SALES_TEAM_EMP_MAIL"] != DBNull.Value ? dt.Rows[0]["SALES_TEAM_EMP_MAIL"].ToString() : string.Empty;
                string axptaSalesOrderId = dt.Rows[0]["SALES_ORDER_ID"] != DBNull.Value ? dt.Rows[0]["SALES_ORDER_ID"].ToString() : string.Empty;
                string axptaDeliveryOrderId = dt.Rows[0]["DELIVERY_ID"] != DBNull.Value ? dt.Rows[0]["DELIVERY_ID"].ToString() : string.Empty;

                string companyName = dt.Rows[0]["COMPANY_NAME"] != DBNull.Value ? dt.Rows[0]["COMPANY_NAME"].ToString() : string.Empty;
                body = body.Replace("axptaSalesOrderId", axptaSalesOrderId).Replace("axptaDeliveryOrderId", axptaDeliveryOrderId).Replace("axptaCompany", companyName);

                string fromMailAddress = System.Configuration.ConfigurationManager.AppSettings["TargetEmailAddress"];
                string toMailAddress = fromMailAddress;//Need to get it from Resgitration team details
                string ccMailAddress = string.IsNullOrEmpty(salesTeamEmailID) ? CustomerEMail : CustomerEMail + ";" + salesTeamEmailID;
                string subject = "APPROVAL/REJECTION DELIVERY STATUS";
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
                    sqlCommand.CommandTimeout = 0;
                    using (SqlDataAdapter sda = new SqlDataAdapter(sqlCommand))
                    {
                        dt = new DataTable();
                        sda.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
}