using System;
using GunungSteels.Common;
using System.Data.SqlClient;
using GunungSteels.App_Code;
using System.Data;

namespace GunungSteels.Home
{
    public partial class Dashboard : System.Web.UI.Page
    {
        public SqlConnection sqlConnection;
        public SqlCommand sqlCommand;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["LoggedInUserID"] == null || Session["LoggedInUserID"].ToString() == string.Empty)
                {
                    Response.Redirect("~/Home/Login.aspx", true);
                }
                else
                {
                    lblUser_Name.Text = Session["LoggedInUser_UserName"] != null ? Session["LoggedInUser_UserName"].ToString() : string.Empty;
                    BindSalesOrderData();
                }
            }
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            BindSalesOrderData();
        }

        protected void GridView1_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            BindSalesOrderData();
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();

        }

        public void BindSalesOrderData()
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
                        string orderID = txt_SalesOrderAxptaNo.Text;
                        string deliveryID = txtDeliveryOrderNo.Text;
                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.CommandText = "USP_GET_SALES_ORDER_DETAILS";
                        sqlCommand.Parameters.AddWithValue("@SALES_ORDER_ID", orderID);// !string.IsNullOrEmpty(txt_SalesOrder.Text) ? Convert.ToInt32(txt_SalesOrder.Text) : default(Int32));
                        sqlCommand.Parameters.AddWithValue("@DELIVERY_ID", deliveryID);// !string.IsNullOrEmpty(txtDeliveryOrderNo.Text) ? Convert.ToInt32(txtDeliveryOrderNo.Text) : default(Int32));

                        sqlCommand.CommandTimeout = 20000;
                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            GridView1.DataSource = ds;
                            GridView1.DataBind();
                        }
                        else
                        {
                            //Empty DataTable to execute the “else-condition”  
                            DataTable emptydt = new DataTable();
                            GridView1.DataSource = emptydt;
                            GridView1.DataBind();
                        }
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