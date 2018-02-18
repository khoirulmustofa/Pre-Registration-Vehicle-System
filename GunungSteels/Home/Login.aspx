<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GunungSteels.Home.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../admin-lte/css/AdminLTE.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../admin-lte/css/skins/skin-grey.min.css" rel="stylesheet" />
    <link href="../Content/font-awesome.min.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.1.1.min.js" type="text/javascript"></script>
    <script src="../Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../admin-lte/js/adminlte.min.js" type="text/javascript"></script>
    <style type="text/css">
        .auto-style1
        {
            text-align: center;
        }
        
        .top
        {
            width: 100%;
            height: 55px;
            background: #C0BDBD;
        }
        .btn
        {
            padding: 2px 12px;
        }
    </style>
    <title></title>
    <style type="text/css">
        .auto-style1
        {
            text-align: center;
        }
        .auto-style2
        {
            height: 26px;
        }
        .auto-style3
        {
            width: 405px;
        }
    </style>
</head>
<body>
    <div>
        <div class="col-md-3" style="padding-top: 6px; background: #DCDBD9; height: 70px;
            padding-top: 10px">
            <div class="col-md-12" style="background: #C0BDBD">
                <img src="https://prvms.gunungsteel.com/Gunnung/Images/Slogan-Logo-GSG-Nov2017[2]_New.png"
                    style="float: left;" />
                    <%--<asp:Image ID="Image1" runat="server" style="float: left;" />--%>
            </div>
        </div>
        <div class="col-md-9" style="background: #C0BDBD">
            <div class="col-md-3">
            </div>
            <div class="col-md-6" style="height: 70px;">
                <label style="padding: 10px 20%; float: left; padding-top: 25px;">
                    <b>PRE REGISTRATION VEHICLE SYSTEM</b></label>
            </div>
            <div class="col-md-3">
            </div>
        </div>
    </div>
    <form id="form2" class="form-horizontal" runat="server">
    <div class="col-md-12 container content">
        <div class="col-md-3">
        </div>
        <div class="col-md-6">
            <div class="box box-info">
                <div class="box-body">
                    <div class="form-group">
                        <div class="col-md-3">
                        </div>
                        <div class="col-md-6">
                            <label>
                                User Login</label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-6">
                            <label>
                                UserName</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txt_UserName" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-6">
                            <label>
                                Password</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txt_Password" TextMode="Password" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-6">
                        </div>
                        <div class="col-md-6">
                            <asp:Button ID="txtLogin" runat="server" CssClass="btn btn-danger" Text="Submit"
                                OnClick="Submit" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-6">
                        </div>
                        <div class="col-md-9 pull-right">
                            <%--<a href="../PRVSSecurity/ForgotPassword.aspx" Font-Underline="true">Forgot Password </a>--%>
                            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="active" NavigateUrl="../PRVSSecurity/ForgotPassword.aspx"
                                Font-Underline="true">Forgot Password 
                            </asp:HyperLink>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
