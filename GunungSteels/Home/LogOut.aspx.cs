using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace GunungSteels.Home
{
    public partial class LogOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool isCustomer = Session["LoggedInUserRole"] != null && Session["LoggedInUserRole"].ToString() == "Customer" ? true : false;
            Session.Abandon();
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            if (isCustomer)
            {
                HttpRequest request = HttpContext.Current.Request;
                string baseURL = request["HTTP_HOST"];
                baseURL = baseURL + "/" + request.RawUrl.ToString().Split('/')[1];
                Response.Redirect("~/GSGCustomer/User_Login.aspx", true);
            }
            else
                Response.Redirect("~/Home/Login.aspx", true);
        }
    }
}