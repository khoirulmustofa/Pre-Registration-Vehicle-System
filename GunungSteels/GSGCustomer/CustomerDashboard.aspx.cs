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
    public partial class CustomerDashboard : System.Web.UI.Page
    {
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
                    BindSalesOrderData();
                }
            }
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            BindSalesOrderData();
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
                        sqlCommand.CommandText = "USP_GET_CUSTOMER_ORDER_HISTORY_DETAILS";
                        sqlCommand.Parameters.AddWithValue("@CUSTOMER_USER_ID", Session["LoggedInUserID"] != null ? Session["LoggedInUserID"].ToString() : string.Empty);
                        sqlCommand.Parameters.AddWithValue("@SALES_ORDER_ID", !string.IsNullOrEmpty(orderID) ? orderID : null);
                        sqlCommand.Parameters.AddWithValue("@DELIVERY_ID", !string.IsNullOrEmpty(deliveryID) ? deliveryID : null);

                        sqlCommand.CommandTimeout = 20000;
                        DataTable dt = new DataTable();
                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            GridView1.DataSource = dt;
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

        protected void GridView1_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            BindSalesOrderData();
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }
    }
}