using System;
using System.Data.SqlClient;
using GunungSteels.App_Code;
using System.Data;

namespace GunungSteels.Home
{
    public partial class RegistrationAdminDashboard : System.Web.UI.Page
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


        protected void btn_Search_Click1(object sender, EventArgs e)
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
                        string QR_CODE = txtQRCode.Text;
                        //string deliveryID = txtDeliveryOrderNo.Text;
                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.CommandText = "USP_GET_TOKEN_STATUS_DETAILS";
                        sqlCommand.Parameters.AddWithValue("@QR_CODE", QR_CODE);
                        sqlCommand.CommandTimeout = 20000;
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                        else
                        {
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