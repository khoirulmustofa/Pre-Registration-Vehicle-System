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
using GunungSteels.Common;

namespace GunungSteels.PRVSSecurity
{
    public partial class WarehouseVehicleScan : System.Web.UI.Page
    {
        public SqlConnection sqlConnection;
        public SqlCommand sqlCommand;
        string ware_House_Access_Gate_Status;

        protected void Page_Load(object sender, EventArgs e)
        {
            //string barCode = txtQRCode.Text = "997652151";
            if (!IsPostBack)
            {
                //txtWHGateInDate.Text = DateTime.Now.ToString();
                //Get QR Code details Info
                //txtSalesOrderID.Text = "1";
                //txtDeliveryOrderId.Text = "1";
                //txtUomCust.Text = "100";
                //txtTotalQuantity.Text = "200";
                //txtActualLoadedQuantity.Text = "150";
                //Get Order Details Info Using BarCode 

                if (Session["LoggedInUserID"] == null || Session["LoggedInUserID"].ToString() == string.Empty)
                    Response.Redirect("~/Home/Login.aspx", true);
                else
                    lblUser_Name.Text = Session["LoggedInUser_UserName"] != null ? Session["LoggedInUser_UserName"].ToString() : string.Empty;
            }
            //GetWareHouseGateInOutStatus(barCode);
        }

        protected void Submit(object sender, EventArgs e)
        {
            ware_House_Access_Gate_Status = hdnSecurityGateAccess.Text;
            var whGateIn = !string.IsNullOrEmpty(txtWHGateInDate.Text) ? DateTime.ParseExact(txtWHGateInDate.Text, "dd/MM/yyyy hh:mm:ss tt", null) : DateTime.Now;
            var whGateOut = !string.IsNullOrEmpty(txtWHGateOutDate.Text) ? DateTime.ParseExact(txtWHGateOutDate.Text, "dd/MM/yyyy hh:mm:ss tt", null) : DateTime.Now;
            string retMessage =ware_House_Access_Gate_Status!=Constants.gateOut ? SaveWareHouseGateInOutAccessInfo(whGateIn, whGateOut):string.Empty;
            
            if (!string.IsNullOrEmpty(retMessage) && retMessage.Contains("SUCCESS"))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowPopUp();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowErroPopUp();", true);
            }
        }

        private string SaveWareHouseGateInOutAccessInfo(DateTime whGateIn, DateTime whGateOut)
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
                        sqlCommand.CommandText = "USP_SAVE_WAREHOUSE_GATE_IN_OUT_ACCESS_INFO";
                        sqlCommand.CommandTimeout = 20000;
                        sqlCommand.Parameters.AddWithValue("@QR_CODE", !string.IsNullOrEmpty(txtQRCode.Text) ? txtQRCode.Text : null);
                        sqlCommand.Parameters.AddWithValue("@SALES_ORDER_MASTER_ID", !string.IsNullOrEmpty(txtSalesOrderID.Text) ? txtSalesOrderID.Text : null);
                        sqlCommand.Parameters.AddWithValue("@DELIVERY_ORDER_MASTER_ID", !string.IsNullOrEmpty(txtDeliveryOrderId.Text) ? txtDeliveryOrderId.Text : null);
                        sqlCommand.Parameters.AddWithValue("@UOM", !string.IsNullOrEmpty(txtUomCust.Text) ? txtUomCust.Text : null);
                        sqlCommand.Parameters.AddWithValue("@TOTAL_TONNAGE", !string.IsNullOrEmpty(txtTotalQuantity.Text) ? txtTotalQuantity.Text : null);
                        sqlCommand.Parameters.AddWithValue("@ACTUAL_LOADED_QUANTITY", !string.IsNullOrEmpty(txtActualLoadedQuantity.Text) ? txtActualLoadedQuantity.Text : null);
                        sqlCommand.Parameters.AddWithValue("@WAREHOUSE_NAME", !string.IsNullOrEmpty(txtWareHouseName.Text) ? txtWareHouseName.Text : null);
                        sqlCommand.Parameters.AddWithValue("@WAREHOUSE_GATE_IN", whGateIn);
                        sqlCommand.Parameters.AddWithValue("@WAREHOUSE_GATE_OUT", whGateOut);
                        SqlParameter par = new SqlParameter("@OUTMSG", SqlDbType.VarChar, 50);
                        par.Direction = ParameterDirection.Output;
                        sqlCommand.Parameters.Add(par);
                        int wareHouse_Entry_Id = Convert.ToInt32(sqlCommand.ExecuteScalar());
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

        private void GetWareHouseGateInOutStatus(string barCode)
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
                        sqlCommand.Parameters.AddWithValue("@SecGateOrWHGate_AccessType", "WHG");
                        sqlCommand.Parameters.AddWithValue("@QR_CODE", barCode);
                        sqlCommand.CommandTimeout = 20000;
                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                             ware_House_Access_Gate_Status = ds.Tables[0].Rows[0]["WARE_HOUSE_GATE_ACCESS_STATUS"] != DBNull.Value ?ds.Tables[0].Rows[0]["WARE_HOUSE_GATE_ACCESS_STATUS"].ToString():string.Empty;

                            if (!ware_House_Access_Gate_Status.Equals(Constants.invalidAccess))
                            {
                                txtSalesOrderID.Text = ds.Tables[0].Rows[0]["SALES_ORDER_MASTER_ID"].ToString();
                                txtDeliveryOrderId.Text = ds.Tables[0].Rows[0]["DELIVERY_ORDER_MASTER_ID"].ToString();
                                txtUomCust.Text = ds.Tables[0].Rows[0]["UOM"] != DBNull.Value ? ds.Tables[0].Rows[0]["UOM"].ToString() : string.Empty;
                                txtTotalQuantity.Text = ds.Tables[0].Rows[0]["TOTAL_TONNAGE"] != DBNull.Value ? ds.Tables[0].Rows[0]["TOTAL_TONNAGE"].ToString() : string.Empty;
                                txtAxptaSalesOrderId.Text = ds.Tables[0].Rows[0]["SALES_ORDER_ID"] != DBNull.Value ? ds.Tables[0].Rows[0]["SALES_ORDER_ID"].ToString() : string.Empty;
                                txtAxptaDeliveryOrderId.Text = ds.Tables[0].Rows[0]["DELIVERY_ID"] != DBNull.Value ? ds.Tables[0].Rows[0]["DELIVERY_ID"].ToString() : string.Empty;
                                
                                if (ware_House_Access_Gate_Status!=Constants.gateNotIN)
                                {
                                    txtUser.Text= txtWareHouseName.Text = ds.Tables[0].Rows[0]["WAREHOUSE_NAME"] != DBNull.Value ? ds.Tables[0].Rows[0]["WAREHOUSE_NAME"].ToString() : string.Empty;
                                    txtWHGateInDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["WAREHOUSE_GATE_IN"].ToString()).ToString("dd/MM/yyyy hh:mm:ss tt");// secInDate + " " + secInTime;
                                    txtActualLoadedQuantity.Text = ds.Tables[0].Rows[0]["Actual_Loaded_Quantity"] != DBNull.Value ? ds.Tables[0].Rows[0]["Actual_Loaded_Quantity"].ToString() : string.Empty;
                                }
                                else
                                {
                                    txtWHGateInDate.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                                }
                                if (ware_House_Access_Gate_Status ==Constants.gateIn)
                                {
                                    txtWHGateOutDate.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                                }
                                else if (ware_House_Access_Gate_Status ==Constants.gateOut)
                                {
                                    txtWHGateOutDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["WAREHOUSE_GATE_OUT"].ToString()).ToString("dd/MM/yyyy hh:mm:ss tt");// secOutDate + " " + secOutTime;
                                }
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
            string barCode = txtQRCode.Text;
            GetWareHouseGateInOutStatus(barCode);
        }

        //Need to use while Barcode Scanning
        protected void txtQRCode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQRCode.Text) && txtQRCode.Text.Length >= 9)
            {
                string barCode = txtQRCode.Text;
                GetWareHouseGateInOutStatus(barCode);
            }
        }
    }
}