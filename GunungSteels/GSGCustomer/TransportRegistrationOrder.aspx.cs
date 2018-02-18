using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GunungSteels.App_Code;

namespace GunungSteels.GSGCustomer
{
    public partial class TransportRegistrationOrder : System.Web.UI.Page
    {
        public SqlConnection sqlConnection;
        public SqlDataAdapter da;
        public SqlCommand sqlCommand;
        public DataSet ds;
        public string retMsg;
        public DataTable dt;
        DBConnection con = new DBConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Session["LoggedInCustomerID"] == null || Session["LoggedInCustomerID"].ToString() == string.Empty)
                    Response.Redirect("~/GSGCustomer/User_Login.aspx", true);
                else
                {
                    lblUser_Name.Text = Session["LoggedInUser_UserName"] != null ? Session["LoggedInUser_UserName"].ToString() : string.Empty;  
                    this.txt_Time_Arrival.Text = DateTime.Now.ToString("hh:mm:ss tt");
                    txt_SalesOrder_Id.Text = Request.QueryString["OrderID"] != null ? Request.QueryString["OrderID"].ToString() : string.Empty;
                    txtDeliveryOrderId.Text = Request.QueryString["DeliveryId"] != null ? Request.QueryString["DeliveryId"].ToString() : string.Empty;
                    GetDeliveryOrderInfo(Convert.ToInt32(!string.IsNullOrEmpty(txtDeliveryOrderId.Text) ? txtDeliveryOrderId.Text : "0"));
                }
            }
            
            //txt_SalesOrder_Id.Text = Request.QueryString["OrderID"]!=null? Request.QueryString["OrderID"].ToString():string.Empty;
            //txtDeliveryOrderId.Text =Request.QueryString["DeliveryId"]!=null? Request.QueryString["DeliveryId"].ToString():string.Empty;// Session["DeliveryID"].ToString();

            //if (!this.IsPostBack && Session["OrderID"] != null)
            //{
            //    txt_SalesOrder_Id.Text = Session["OrderID"].ToString();
            //    txtDeliveryOrderId.Text = Session["DeliveryID"].ToString();
            //    GetDeliveryOrderInfo(Convert.ToInt32(!string.IsNullOrEmpty(txtDeliveryOrderId.Text) ? txtDeliveryOrderId.Text : "0"));
            //}
        }

        #region Customer Transport Registration

        private void GetDeliveryOrderInfo(int deliveryOrderId)
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
                        sqlCommand.CommandText = "USP_GET_CUSTOMER_ORDER_DETAILS";
                        sqlCommand.Parameters.AddWithValue("@DELIVERY_ORDER_MASTER_ID", Convert.ToInt32(deliveryOrderId));
                        sqlCommand.CommandTimeout = 20000;
                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            txt_SalesOrder_Id.Text = ds.Tables[0].Rows[0]["SALES_ORDER_MASTER_ID"].ToString();
                            txtDeliveryOrderId.Text = ds.Tables[0].Rows[0]["DELIVERY_ORDER_MASTER_ID"].ToString();
                            txt_Uom.Text = ds.Tables[0].Rows[0]["UOM"].ToString();
                            txtTonnageQuantity.Text = ds.Tables[0].Rows[0]["TONNAGE_QUANTITY"].ToString();
                            txtAxptaSalesOrderId.Text = ds.Tables[0].Rows[0]["SALES_ORDER_ID"].ToString();
                            txtAxptaDeliveryOrderId.Text = ds.Tables[0].Rows[0]["DELIVERY_ID"].ToString();

                            string isNewOrder = ds.Tables[0].Rows[0]["IsNewOrder"].ToString();
                            if (isNewOrder == "N")
                            {
                                txt_Transporter_Name.Text = ds.Tables[0].Rows[0]["TRANSPORTER_NAME"].ToString();
                                txt_Date.Text = ds.Tables[0].Rows[0]["DATE"].ToString();
                                txt_Time_Arrival.Text = ds.Tables[0].Rows[0]["TIME_ARRIVAL"].ToString();
                                txt_VehicleNumber.Text = ds.Tables[0].Rows[0]["VEHICLE_NUMBER"].ToString();
                                txt_Source.Text = ds.Tables[0].Rows[0]["SOURCE"].ToString();
                                txt_VehicleDetails.Text = ds.Tables[0].Rows[0]["VEHICLE_DETAILS"].ToString();
                                txt_DriverName.Text = ds.Tables[0].Rows[0]["DRIVER_NAME"].ToString();
                                txt_Driver_Contact_No.Text = ds.Tables[0].Rows[0]["DRIVER_CONTACT"].ToString();
                                txt_KTP.Text = ds.Tables[0].Rows[0]["KTP"].ToString();
                                pnlTransportReg.Enabled = false;
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

        protected void btn_Submit_Click(object sender, EventArgs e)
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
                sqlCommand.CommandText = "USP_M_TRANSPORTREGISTRATION_AUD";
                sqlCommand.CommandTimeout = 20000;
                sqlCommand.Parameters.AddWithValue("@ACTION", "I");
                sqlCommand.Parameters.AddWithValue("@DELIVERY_ID", txtDeliveryOrderId.Text);
                sqlCommand.Parameters.AddWithValue("@KTP", txt_KTP.Text);
                sqlCommand.Parameters.AddWithValue("@TRANSPORTER_NAME", txt_Transporter_Name.Text);
                sqlCommand.Parameters.AddWithValue("@DATE", DateTime.ParseExact(txt_Date.Text, "dd/MM/yyyy", null));//Convert.ToDateTime(txt_Date.Text) 
                sqlCommand.Parameters.AddWithValue("@TIME_ARRIVAL", Convert.ToDateTime(txt_Time_Arrival.Text));
                sqlCommand.Parameters.AddWithValue("@SALES_ORDER_ID", txt_SalesOrder_Id.Text);
                sqlCommand.Parameters.AddWithValue("@VEHICLE_NUMBER", txt_VehicleNumber.Text);
                sqlCommand.Parameters.AddWithValue("@SOURCE", txt_Source.Text);
                sqlCommand.Parameters.AddWithValue("@VEHICLE_DETAILS", txt_VehicleDetails.Text);
                sqlCommand.Parameters.AddWithValue("@UOM", txt_Uom.Text);
                sqlCommand.Parameters.AddWithValue("@DRIVER_NAME", txt_DriverName.Text);
                sqlCommand.Parameters.AddWithValue("@DRIVER_CONTACT", txt_Driver_Contact_No.Text);
                sqlCommand.Parameters.AddWithValue("@TONNAGE_QUANTITY", txtTonnageQuantity.Text);
                sqlCommand.Parameters.AddWithValue("@DRIVER_ID", txtDriverID.Text);
                SqlParameter par = new SqlParameter("@OUTMSG", SqlDbType.VarChar, 50);
                par.Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add(par);
                var output = sqlCommand.ExecuteScalar();
                int currentID = Convert.ToInt32(!(output is DBNull) ? output : 0);
                if (currentID > 0)
                {
                    Notify(Convert.ToInt32(txt_SalesOrder_Id.Text), Convert.ToInt32(txtDeliveryOrderId.Text));
                }

                Session["currentID"] = currentID;
                Session["SalesOrderID"] = txt_SalesOrder_Id.Text;
                Session["DeliveryOrderID"] = txtDeliveryOrderId.Text;
                //txt_Truck_Id.Text = string.Empty;
                txt_KTP.Text = string.Empty;
                txt_Transporter_Name.Text = string.Empty;
                txt_Date.Text = string.Empty;
                txt_Time_Arrival.Text = string.Empty;
                txt_SalesOrder_Id.Text = string.Empty;
                txt_VehicleNumber.Text = string.Empty;
                txt_Source.Text = string.Empty;
                txt_VehicleDetails.Text = string.Empty;
                txt_Uom.Text = string.Empty;
                txt_DriverName.Text = string.Empty;
                txt_Driver_Contact_No.Text = string.Empty;
                Response.Redirect("QR_Code.aspx", false);

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

        private void Notify(int salesOrderMasterId, int deliveryOrderMasterId)
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

                string body = string.Format("Dear Sales Pic Team,<br /><br />");
                body = body + string.Format("Please find the below details of New Order with Gunnung Steel <br/><br />");
                body = body + string.Format("<b>Company Name</b>: {0}<br/>" + Environment.NewLine, companyName);
                body = body + string.Format("<b>Customer Name</b>: {0}<br/>" + Environment.NewLine, CustomerName);
                body = body + string.Format("<b>Sales Order No</b>: {1}<br/>", System.Environment.NewLine, axptaSalesOrderId);
                body = body + string.Format("<b>Delivery Order No</b>: {1}<br/><br/><br/>", System.Environment.NewLine, axptaDeliveryOrderId);
                body = body + string.Format("<b>Thanks and Regards</b><br/>");
                body = body + string.Format("Gunung Admin Group");

                string fromMailAddress = System.Configuration.ConfigurationManager.AppSettings["TargetEmailAddress"];
                string toMailAddress = salesTeamEmailID;//Need to get it from Resgitration team details
                string ccMailAddress = string.Empty;// string.IsNullOrEmpty(salesTeamEmailID) ? CustomerEMail : CustomerEMail + ";" + salesTeamEmailID;
                string subject = "Order Rigistration";
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

        #endregion
    }
}