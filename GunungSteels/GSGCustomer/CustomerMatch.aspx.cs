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
    public partial class CustomerMatch : System.Web.UI.Page
    {
        public SqlConnection sqlConnection;
        public SqlCommand sqlCommand;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string deliveryMasterId =Request.QueryString["CustomerMatch"]!=null? Request.QueryString["CustomerMatch"].ToString():"0";
                if (Session["LoggedInCustomerID"] == null || Session["LoggedInCustomerID"].ToString() == string.Empty)
                    Response.Redirect("~/GSGCustomer/User_Login.aspx?CustomerMatch=" + deliveryMasterId, true);
                else
                {
                    lblUser_Name.Text = Session["LoggedInUser_UserName"] != null ? Session["LoggedInUser_UserName"].ToString() : string.Empty;  
                    GetDeliveryOrderInfo(Convert.ToInt32(deliveryMasterId));
                }
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
                        //Session["DeliveryID"] = deliveryOrderId;
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
                            txt_SalesOrder_Id.Text = ds.Tables[0].Rows[0]["SALES_ORDER_MASTER_ID"].ToString();
                            txtDeliveryOrderId.Text = ds.Tables[0].Rows[0]["DELIVERY_ORDER_MASTER_ID"].ToString();
                            txt_KTP.Text = ds.Tables[0].Rows[0]["KTP"].ToString();
                            txt_Transporter_Name.Text = ds.Tables[0].Rows[0]["TRANSPORTER_NAME"].ToString();
                            txt_VehicleNumber.Text = ds.Tables[0].Rows[0]["VEHICLE_NUMBER"].ToString();
                            txt_Source.Text = ds.Tables[0].Rows[0]["SOURCE"].ToString();
                            txt_VehicleDetails.Text = ds.Tables[0].Rows[0]["VEHICLE_DETAILS"].ToString();
                            txt_Uom.Text = ds.Tables[0].Rows[0]["UOM"].ToString();
                            txt_DriverName.Text = ds.Tables[0].Rows[0]["DRIVER_NAME"].ToString();
                            txt_Driver_Contact_No.Text = ds.Tables[0].Rows[0]["DRIVER_CONTACT"].ToString();
                            txtDriverID.Text = ds.Tables[0].Rows[0]["DRIVER_ID"].ToString();
                            txtTotalQuantity.Text = ds.Tables[0].Rows[0]["TONNAGE_QUANTITY"].ToString();
                            txtAxptaSalesOrderId.Text = ds.Tables[0].Rows[0]["SALES_ORDER_ID"].ToString();
                            txtAxptaDeliveryOrderId.Text = ds.Tables[0].Rows[0]["DELIVERY_ID"].ToString();
                        }
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
            //Send Email FROM Customer To PRVS (Security  Registration Team)
            int salesOrderMasterId = Convert.ToInt32(txt_SalesOrder_Id.Text);
            int deliveryOrderMasterId = Convert.ToInt32(txtDeliveryOrderId.Text);
            string body = string.Format("Dear Registration Team,<br/><br/><br/>");
            //body = body + string.Format("For <b> Sales Order No.-" + salesOrderMasterId + "</b> and <b>Delivery Order No.-" + deliveryOrderMasterId + "</b> has been approved by the Customer.<br/> Please proceed with this delivery order.<br/><br/><br/>");
            body = body + string.Format("From Comapany-axptaCompany for <b> Sales Order No.-axptaSalesOrderId</b> and <b>Delivery Order No.-axptaDeliveryOrderId</b> has been approved by the Customer.<br/> Please proceed with this delivery order.<br/><br/><br/>");
            body = body + string.Format("<b>Thanks and Regards</b><br/>");
            body = body + string.Format("Gunung Admin Group");
            Notify(body, salesOrderMasterId, deliveryOrderMasterId);

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowPopUp();", true);
        }

        protected void Reject(object sender, EventArgs e)
        {
            int result = UpdateCustomerOrderApproval("Rejected");
            //Send Email FROM Customer To PRVS (Security  Registration Team)
            int salesOrderMasterId = Convert.ToInt32(txt_SalesOrder_Id.Text);
            int deliveryOrderMasterId = Convert.ToInt32(txtDeliveryOrderId.Text);
            string body = string.Format("Dear Registration Team,<br/><br/><br/>");
            body = body + string.Format("From Comapany-axptaCompany for <b>Sales Order No.-axptaSalesOrderId</b> and <b>Delivery Order No.-axptaDeliveryOrderId</b>  has been rejected by the Customer.</b><br/> Please do'nt proceed with this delivery order.<br/><br/><br/>");
            body = body + string.Format("<b>Thanks and Regards</b><br/>");
            body = body + string.Format("Gunung Admin Group");
            Notify(body, salesOrderMasterId, deliveryOrderMasterId);

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowRejectPopUp();", true);
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

        private void Notify(string body, int salesOrderMasterId, int deliveryOrderMasterId)
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
                body = body.Replace("axptaSalesOrderId", axptaSalesOrderId).Replace("axptaDeliveryOrderId", axptaDeliveryOrderId).Replace("axptaCompany", companyName);
                string fromMailAddress = System.Configuration.ConfigurationManager.AppSettings["TargetEmailAddress"];
                string toMailAddress = System.Configuration.ConfigurationManager.AppSettings["EmailTo"];//Need to get it from Resgitration team details
                string ccMailAddress = salesTeamEmailID == CustomerEMail ||  string.IsNullOrEmpty(salesTeamEmailID) ? CustomerEMail : CustomerEMail + ";" + salesTeamEmailID;
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
    }
}