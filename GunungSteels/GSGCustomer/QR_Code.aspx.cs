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
using BarcodeLib;
//using BarcodeLib.Barcode;


namespace GunungSteels.GSGCustomer
{
    public partial class QR_Code : System.Web.UI.Page
    {
        public SqlConnection sqlConnection;
        public SqlCommand sqlCmnd;

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
                    string deliveryOrderID = Session["DeliveryOrderID"] != null ? Session["DeliveryOrderID"].ToString() : string.Empty;
                    int currentID = Session["currentID"] != null ? Convert.ToInt32(Session["currentID"]) : 0;
                    GetCustomerOrderDeatils(deliveryOrderID, currentID);
                }
            }
            //string deliveryOrderID = Session["DeliveryOrderID"].ToString();
            //int currentID = Convert.ToInt32(Session["currentID"]);
            //GetCustomerOrderDeatils(deliveryOrderID,currentID);
        }

        private void GetCustomerOrderDeatils(string deliveryOrderID, int currentID)
        {
            try
            {
                string salesOrderId = string.Empty;

                using (sqlConnection = new DBConnection().connection)
                {
                    using (sqlCmnd = new SqlCommand())
                    {
                        if (sqlConnection.State == ConnectionState.Closed)
                        {
                            sqlConnection.Open();
                        }
                        sqlCmnd.Connection = sqlConnection;
                        sqlCmnd.CommandType = CommandType.StoredProcedure;
                        sqlCmnd.CommandText = "USP_M_TRANSPORTREGISTRATION_VE";
                        sqlCmnd.Parameters.AddWithValue("@ID_NO", currentID);
                        sqlCmnd.CommandTimeout = 20000;
                        DataSet ds = new DataSet();
                        SqlDataAdapter dap = new SqlDataAdapter(sqlCmnd);
                        dap.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            salesOrderId = ds.Tables[0].Rows[0]["SALES_ORDER_MASTER_ID"].ToString();
                            //txtDeliveryOrderId.Text = ds.Tables[0].Rows[0]["DELIVERY_ORDER_MASTER_ID"].ToString();
                            txt_SalesOrder_Id.Text = ds.Tables[0].Rows[0]["SALES_ORDER_ID"].ToString();
                            txtDeliveryOrderId.Text = ds.Tables[0].Rows[0]["DELIVERY_ID"].ToString();

                            txt_Uom.Text = ds.Tables[0].Rows[0]["UOM"].ToString();
                            txtTonnage.Text = ds.Tables[0].Rows[0]["Tonnage"].ToString();
                            txt_Transporter_Name.Text = ds.Tables[0].Rows[0]["TRANSPORTER_NAME"].ToString();
                            txt_Source.Text = ds.Tables[0].Rows[0]["SOURCE"].ToString();
                            txt_VehicleNumber.Text = ds.Tables[0].Rows[0]["VEHICLE_NUMBER"].ToString();
                            txt_VehicleDetails.Text = ds.Tables[0].Rows[0]["VEHICLE_DETAILS"].ToString();
                            txt_DriverName.Text = ds.Tables[0].Rows[0]["DRIVER_NAME"].ToString();
                            txtDriverId.Text = ds.Tables[0].Rows[0]["DRIVER_ID"].ToString();
                            txt_Driver_Contact_No.Text = ds.Tables[0].Rows[0]["DRIVER_CONTACT"].ToString();
                            txt_KTP.Text = ds.Tables[0].Rows[0]["KTP"].ToString();
                            var DateOfArrival = Convert.ToDateTime(ds.Tables[0].Rows[0]["DATE"].ToString());//.ToShortDateString();
                            txt_Date.Text = DateOfArrival.ToString("dd/M/yyyy");// ds.Tables[0].Rows[0]["DATE"].ToString();
                            txt_Time_Arrival.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["TIME_ARRIVAL"].ToString()).ToString("hh:mm:ss tt");
                            //Generate QR Code
                            string barCode = GenerateCustomeBarCode();// GenerateBarCode();
                            //Save QR Code
                            SaveQRCode(barCode, deliveryOrderID, salesOrderId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // Custom Barcode need to uncomment  this code in production
        private string GenerateCustomeBarCode()
        {
            var randomNumber = new Random();
            string barCode = randomNumber.Next().ToString();
            string strData = barCode;
            int imageHeight = 125;//150;
            int imageWidth = 275;//300;
            string Forecolor = "000000";
            string Backcolor = "FFFFFF";
            // bool bIncludeLabel =true;
            string strImageFormat = "png";// Request.QueryString["if"].ToLower().Trim();
            //string strAlignment = "c";// Request.QueryString["align"].ToLower().Trim();

            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            b.IncludeLabel = true;
            b.Alignment = BarcodeLib.AlignmentPositions.CENTER;
            System.Drawing.Image barcodeImage = b.Encode(BarcodeLib.TYPE.CODE128, barCode, System.Drawing.ColorTranslator.FromHtml("#" + Forecolor), System.Drawing.ColorTranslator.FromHtml("#" + Backcolor), imageWidth, imageHeight);
            //barcodeImage.
            System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            using (MemoryStream ms = new MemoryStream())
            {
                barcodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] byteImage = ms.ToArray();

                Convert.ToBase64String(byteImage);
                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                //ms.WriteTo(Response.OutputStream);
            }
            plBarCode.Controls.Add(imgBarCode);
            return barCode;
        }

        //private string GenerateBarCode()
        //{
        //    var randomNumber = new Random();
        //    string barCode = randomNumber.Next().ToString();

        //    Linear code39 = new Linear();

        //    // code39.Type = BarcodeType.CODE39;
        //    code39.Type = BarcodeType.CODABAR;
        //    code39.CodabarStartChar = CodabarStartStopChar.B;
        //    code39.ShowStartStopChar = false;
        //    code39.AddCheckSum = true;
        //    code39.ShowCheckSumChar = true;
        //    code39.Data = barCode;// 
        //    code39.CodabarStopChar = CodabarStartStopChar.D;
        //    code39.BarWidth = 2;
        //    code39.BarHeight = 80;
        //    code39.LeftMargin = 20;
        //    code39.RightMargin = 20;

        //    // Customize Code 39 image color

        //    code39.BarColor = Color.Black;
        //    code39.TextFontColor = Color.Black;
        //    // code39.drawBarcode("D://GSG_code39.png");
        //    Bitmap bitMap = code39.drawBarcode();
        //    //byte[] byteImagArray = File.ReadAllBytes(@"D:\GSG_code39.png");

        //    System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();

        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        //        byte[] byteImage = ms.ToArray();
        //        Convert.ToBase64String(byteImage);
        //        imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
        //    }
        //    plBarCode.Controls.Add(imgBarCode);

        //    return  barCode;
        //}

        private string SaveQRCode(string qrCode, string deliveryOrderId, string salesOrderId)
        {
            try
            {
                using (sqlConnection = new DBConnection().connection)
                {
                    using (sqlCmnd = new SqlCommand())
                    {
                        if (sqlConnection.State == ConnectionState.Closed)
                        {
                            sqlConnection.Open();
                        }
                        sqlCmnd.Connection = sqlConnection;
                        sqlCmnd.CommandTimeout = 20000;
                        sqlCmnd.CommandType = CommandType.StoredProcedure;
                        sqlCmnd.CommandText = "USP_SAVE_PRVS_QR_CODE";
                        sqlCmnd.CommandTimeout = 20000;
                        sqlCmnd.Parameters.AddWithValue("@DELIVERY_ORDER_MASTER_ID", Convert.ToInt32(deliveryOrderId));
                        sqlCmnd.Parameters.AddWithValue("@SALES_ORDER_MASTER_ID", Convert.ToInt32(salesOrderId));
                        sqlCmnd.Parameters.AddWithValue("@QR_CODE", qrCode);
                        SqlParameter par = new SqlParameter("@STATUS", SqlDbType.VarChar, 20);
                        par.Direction = ParameterDirection.Output;
                        sqlCmnd.Parameters.Add(par);
                        var output = sqlCmnd.ExecuteScalar();
                        string status = (string)sqlCmnd.Parameters["@STATUS"].Value;
                        return status;
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