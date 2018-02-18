<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SecurityGateScan.aspx.cs"
    Inherits="GunungSteels.PRVSSecurity.SecurityGateScan" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../admin-lte/css/AdminLTE.min.css" rel="stylesheet" />
    <link href="../admin-lte/css/skins/skin-grey.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/font-awesome.min.css" rel="stylesheet" />
    <link href="../admin-lte/css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-3.1.1.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.12.1.js" type="text/javascript"></script>
    <script src="../admin-lte/js/adminlte.min.js" type="text/javascript"></script>
    <script src="../Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        function Reset() {
            $("#txtQRCode").val("");
            $("#txtSalesOrderID").val("");
            $("#txtDeliveryOrderId").val("");
            $("#txtAxptaSalesOrderId").val("");
            $("#txtAxptaDeliveryOrderId").val("");
            $("#txtUomCust").val("");
            $("#txtTotalQuantity").val("");
            $("#txtSecurityGateInDate").val("");
            $("#txtSecurityGateOutDate").val("");
            $("#txtCustomerApprovalStatus").val("");
            $("#txtTokenNo").val("");
        }

        function ShowPopUp() {
            $("#modal_dialog").dialog({
                title: "Security check-in/out confirmation",
                buttons: {
                    Close: function () {
                        Reset();
                        $(this).dialog('close');
                    }
                },
                modal: true
            });
            return false;
        }

        function ShowErroPopUp() {
            $("#modal_dialog_error").dialog({
                title: "Security check-in/out error",
                buttons: {
                    Close: function () {
                        $(this).dialog('close');
                    }
                },
                modal: true
            });
            return false;
        }

    </script>
    <style type="text/css">
        .ui-dialog-titlebar-close
        {
            visibility: hidden;
        }
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
    <div id="modal_dialog" style="display: none">
        Submitted successfully.
    </div>
    <div id="modal_dialog_error" style="display: none">
        Error while saving.
    </div>
    <div>
        <div class="col-md-3" style="padding-top: 6px; background: #DCDBD9; height: 70px;
            padding-top: 10px">
            <div class="col-md-12" style="background: #C0BDBD">
                <img src="../images/Slogan-Logo-GSG-Nov2017[2]_New.png" style="float: left;" />
            </div>
        </div>
        <div class="col-md-9" style="background: #C0BDBD">
            <div class="col-md-3">
                <header class="main-header">

                    <div>
                      <%--  <a href="../Home/Dashboard.aspx"><span class="glyphicon glyphicon-home" style="padding: 25px 20%"></span></a>--%>
                        <%--<a href="CustomerDashBoard.aspx"><span class="glyphicon glyphicon-home" style="padding: 25px 20%"></span></a>--%>

                    </div>

                </header>
            </div>
            <div class="col-md-6" style="height: 70px;">
                <label style="padding: 25px 20%; float: left;">
                    <b>PRE REGISTRATION VEHICLE SYSYTEM</b></label>
            </div>
            <div class="col-md-3">
                <header class="main-header">



                    <!-- Header Navbar -->
                    <nav class="navbar navbar-static-top" role="navigation">
                        <!-- Sidebar toggle button-->

                        <!-- Navbar Right Menu -->
                        <div class="navbar-custom-menu">
                            <ul class="nav navbar-nav">
                                <!-- Messages: style can be found in dropdown.less-->

                                <!-- User Account Menu -->
                                <li class="dropdown user user-menu">
                                    <!-- Menu Toggle Button -->
                                    <a href="#" class="dropdown-toggle" data-toggle="dropdown" style="padding: 25px 20%">
                                        <!-- The user image in the navbar-->
                                        <img src="../images/User_new.png" class="user-image" alt="User Image" />



                                        <!-- hidden-xs hides the username on small devices so only the image appears. -->
                                        <span class="hidden-xs"></span>
                                    </a>
                                    <ul class="dropdown-menu">
                                        <!-- The user image in the menu -->
                                        <li class="user-header">
                                            <img src="../images/User_new.png" class="img-circle" alt="User Image" />

                                           <p style="color:black">
                                             <%-- User Name
                                              <small>Designation</small>--%>
                                               <asp:Label ID="lblUser_Name" runat="server" Text="Label"></asp:Label>
                                            </p>
                                        </li>
                                        <!-- Menu Body -->
                                        <li class="user-body">
                                            <div class="row">
                                                <%--<div class="col-xs-4 text-center">
                    <a href="#">Followers</a>
                  </div>--%>
                                                <div class="col-xs-4 text-center">
                                                    <a href="ChangePassword.aspx">Change Password </a>

                                                </div>
                                                <%--<div class="col-xs-4 text-center">
                    <a href="#">Change Password</a>
                  </div>--%>
                                            </div>
                                            <!-- /.row -->
                                        </li>
                                        <!-- Menu Footer-->
                                        <li class="user-footer">
                                            <%--<div class="pull-left">
                  <a href="#" class="btn btn-default btn-flat">Profile</a>
                </div>--%>
                                            <div class="pull-right">
                                                <a href="../Home/LogOut.aspx"><b>
                                                    <img src="../images/Logout_new.png" /></b> <span style="color: red">Sign Out</span></a>


                                            </div>
                                        </li>
                                    </ul>
                                </li>
                                <!-- Control Sidebar Toggle Button -->
                                <li></li>
                            </ul>
                        </div>
                    </nav>
                </header>
            </div>
        </div>
    </div>
    <form id="form2" class="form-horizontal" runat="server" defaultfocus="txtQRCode">
    <div class="row">
        <div class="col-md-12 container content">
            <asp:ToolkitScriptManager ID="toolscriptcal" runat="server">
            </asp:ToolkitScriptManager>
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
                                    SECURITY GATE SCANNING
                                </label>
                            </div>
                            <div class="col-md-3">
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-4">
                                <label>
                                    QR Code</label>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtQRCode" runat="server" AutoPostBac="True" OnTextChanged="txtQRCode_TextChanged"></asp:TextBox>
                                <asp:RequiredFieldValidator Display="Dynamic" runat="server" ErrorMessage="Driver Name Should Not be blank"
                                    ControlToValidate="txtQRCode"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-3 pull-right">
                                <asp:Button ID="btnQRCodeSearch" runat="server" Text="Search" CssClass="btn btn-success"
                                    OnClick="Search" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-4">
                                <label>
                                    Sales Order
                                </label>
                            </div>
                            <%--  <input id="Hidden1" type="hidden" />--%>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtSalesOrderID" ReadOnly="true" runat="server" Visible="false"></asp:TextBox>
                                <asp:TextBox ID="txtAxptaSalesOrderId" runat="server" Enabled="False"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-4">
                                <label>
                                    Delivery Order</label>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtDeliveryOrderId" runat="server" Visible="false"></asp:TextBox>
                                <asp:TextBox ID="txtAxptaDeliveryOrderId" runat="server" Enabled="False"></asp:TextBox>
                                <%--  <asp:Button ID="btn_Search" runat="server" CssClass="btn btn-danger" Text="Search" OnClick="btn_Search_Click1" />--%>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-4">
                                <label>
                                    Customer Approval Status</label>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtCustomerApprovalStatus" runat="server" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-4">
                                <label>
                                    Security Check In</label>
                            </div>
                            <%-- <asp:TextBox ID="TextBox3" ReadOnly="true" runat ="server" Enabled="false"></asp:TextBox>--%>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtSecurityGateInDate" runat="server" ReadOnly="true" Enabled="false"></asp:TextBox>
                            </div>
                            <asp:CalendarExtender ID="Calender1" TargetControlID="txtSecurityGateInDate" runat="server"
                                Format="dd/MM/yyyy HH:mm:ss tt">
                            </asp:CalendarExtender>
                        </div>
                        <div class="form-group">
                            <div class="col-md-4">
                                <label>
                                    Security Gate Out</label>
                            </div>
                            <%-- <asp:TextBox ID="TextBox3" ReadOnly="true" runat ="server" Enabled="false"></asp:TextBox>--%>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtSecurityGateOutDate" runat="server" ReadOnly="true" Enabled="false"></asp:TextBox>
                            </div>
                            <asp:CalendarExtender ID="CalendarExtender2" TargetControlID="txtSecurityGateOutDate"
                                runat="server" Format="dd/MM/yyyy HH:mm:ss tt">
                            </asp:CalendarExtender>
                        </div>
                        <div class="form-group">
                            <div class="col-md-4">
                                <label>
                                    Token No</label>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtTokenNo" runat="server" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-3">
                            </div>
                            <div class="col-md-5">
                                <div class="col-md-4">
                                </div>
                                <asp:Button ID="Button2" runat="server" Text="Submit" CssClass="btn btn-success"
                                    OnClick="Button2_Click" />
                                <%-- <asp:Button ID="btn_Match" runat="server" Text="Submit" CssClass="btn btn-success"  OnClick="btn_Match_Click" />--%>
                            </div>
                            <div class="col-md-4">
                                <div class="col-md-3" style="display: none;">
                                    <asp:TextBox ID="hdnSecurityGateAccess" runat="server"></asp:TextBox>
                                </div>
                                <%--<asp:Button ID="btn_Submit" runat="server" CssClass="btn btn-danger" Text="Submit" Enabled="false" OnClick="btn_Submit_Click1"  />--%>
                            </div>
                        </div>
                        <button type="button" id="modalButton" class="btn btn-default" data-toggle="modal"
                            data-target="#modal-default" style="display: none">
                            Launch Default Modal
                        </button>
                        <div class="modal fade" id="modal-default">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <span aria-hidden="true">×</span></button>
                                        <h4 class="modal-title">
                                            For Your Information</h4>
                                    </div>
                                    <div class="modal-body">
                                        <p>
                                            Mail Notification has Sent to Customer</p>
                                    </div>
                                    <div class="modal-footer">
                                    </div>
                                </div>
                                <!-- /.modal-content -->
                            </div>
                            <!-- /.modal-dialog -->
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
