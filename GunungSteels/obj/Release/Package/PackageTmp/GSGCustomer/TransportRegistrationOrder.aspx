<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransportRegistrationOrder.aspx.cs"
    Inherits="GunungSteels.GSGCustomer.TransportRegistrationOrder" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../admin-lte/css/AdminLTE.min.css" rel="stylesheet" />
    <link href="../admin-lte/css/skins/skin-grey.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/font-awesome.min.css" rel="stylesheet" />
    <link href="../admin-lte/css/jquery-ui.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.1.1.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.12.1.js" type="text/javascript"></script>
    <script src="../admin-lte/js/adminlte.min.js" type="text/javascript"></script>
    <script src="../Scripts/bootstrap.min.js" type="text/javascript"></script>
    <%--<script src="../Scripts/jquery-1.12.4.js"></script>--%>
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
    <script type="text/javascript">
        $(function () {
            var availableTags = [
                "Ahmedabad",
                "Mumbai",
                "Delhi",
                "Bangalore",
                "Hyderabad",
                "Chennai",
                "Kolkata",
                "Pune",
                "Jaipur",
                "Lucknow",
                "Nagpur",
                "Raipur",
                "Marathahalli",
                "Jayanagar",
                "Vijayawada",

                "Navi Mumbai",
                "Scheme"
            ];
            $("#txt_Source").autocomplete({
                source: availableTags
            });
        });
    </script>
    <script>
        function openModal() {
            document.getElementById("").click();
        }


    </script>
</head>
<body>
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
                        <a href="CustomerDashboard.aspx"><span class="glyphicon glyphicon-home" style="padding: 25px 20%"></span></a>
                    </div>

                </header>
            </div>
            <div class="col-md-6" style="height: 70px;">
                <label style="padding: 25px 20%; float: left;">
                    <b>CUSTOMER ORDER REGISTRATION </b>
                </label>
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
                                                <div class="col-xs-4 text-center">
                                                    <a href="Change%20Password.aspx">Change Password </a>

                                                </div>

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
    <form id="form1" class="form-horizontal" runat="server">
    <div class="col-md-12 container content">
        <asp:ToolkitScriptManager ID="toolscriptcal" runat="server">
        </asp:ToolkitScriptManager>
        <div class="col-md-3">
        </div>
        <div class="col-md-6">
           <asp:Panel ID="pnlTransportReg" runat="server">
            <div class="box box-info">
                <div class="box-body">
                    <div class="form-group">
                        <div class="col-md-3">
                        </div>
                        <div class="col-md-6">
                            <label>
                                CUSTOMER VEHICLE REGISTRATION
                            </label>
                        </div>
                        <div class="col-md-3">
                            <div style="display: none;">
                                <asp:TextBox ID="txt_SalesOrder_Id" Visible="false" runat="server" Enabled="False"></asp:TextBox>
                                <asp:TextBox ID="txtDeliveryOrderId" Visible="false" runat="server" Enabled="False"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-6">
                            <label>
                                Sales Order</label>
                        </div>
                        <div class="col-md-6">
                            <%--<asp:TextBox ID="txt_SalesOrder_Id" runat="server" Enabled="False"></asp:TextBox>--%>
                            <asp:TextBox ID="txtAxptaSalesOrderId" runat="server" Enabled="False"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-6">
                            <label>
                                Delivery Order
                            </label>
                        </div>
                        <div class="col-md-6">
                            <%--<asp:TextBox ID="txtDeliveryOrderId" runat="server" Enabled="False"></asp:TextBox>--%>
                            <asp:TextBox ID="txtAxptaDeliveryOrderId" runat="server" Enabled="False"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-6">
                            <label>
                                UOM</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txt_Uom" runat="server" Enabled="False"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server"
                                ErrorMessage="UOM Should Not be blank" ControlToValidate="txt_Uom"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-6">
                            <label>
                                Total Quantity (Tonnage/No. Of Pieces)</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtTonnageQuantity" runat="server" Enabled="False"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" runat="server"
                                ErrorMessage="Total Quantity Should Not be blank" ControlToValidate="txtTonnageQuantity"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-6">
                            <label>
                                Transporter Name</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txt_Transporter_Name" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" runat="server"
                                ErrorMessage="Transporter Name Should not be blank" ControlToValidate="txt_Transporter_Name"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-6">
                            <div class="ui-widget">
                                <label>
                                    Source</label>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txt_Source" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"
                                ErrorMessage="Source Should Not be blank" ControlToValidate="txt_Source"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-6">
                            <label>
                                Vehicle No</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txt_VehicleNumber" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic"
                                ErrorMessage="Vehicle Number Should Not be blank" ControlToValidate="txt_VehicleNumber"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-6">
                            <label>
                                Vehicle Details</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txt_VehicleDetails" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic"
                                ErrorMessage="Vehicle Details Should Not be blank" ControlToValidate="txt_VehicleDetails"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-6">
                            <label>
                                Driver Name</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txt_DriverName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Display="Dynamic" runat="server"
                                ErrorMessage="Driver Name Should Not be blank" ControlToValidate="txt_DriverName"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group" style="display: none;">
                        <div class="col-md-6">
                            <label>
                                Driver ID</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtDriverID" runat="server"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8" Display="Dynamic" runat="server" ErrorMessage="Driver ID Should Not be blank" ControlToValidate="txtDriverID"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-6">
                            <label>
                                Driver Phone No</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txt_Driver_Contact_No" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" Display="Dynamic" runat="server"
                                ErrorMessage="Driver Contact Number Should Not be Blank" ControlToValidate="txt_Driver_Contact_No"></asp:RequiredFieldValidator>
                            <%--<asp:RegularExpressionValidator ID="txt_Driver_Contact_No1" runat="server" ControlToValidate="txt_Driver_Contact_No" ErrorMessage="Contact Number Should be max 10 Nmbrs" ValidationExpression="[0-9]{10}">
                                 </asp:RegularExpressionValidator>--%>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-6">
                            <label>
                                KTP/SIM</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txt_KTP" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" Display="Dynamic" runat="server"
                                ErrorMessage="KTP/SIM Should Not be Blank" ControlToValidate="txt_KTP"></asp:RequiredFieldValidator>
                            <%-- <asp:CompareValidator ID="CompareValidator2" runat="server" Operator="DataTypeCheck"
                                Type="Integer" ControlToValidate="txt_KTP" ErrorMessage="KTP/SIM must be numeric" />--%>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-6">
                            <label>
                                Date of Arrival</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txt_Date" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" Display="Dynamic"
                                ErrorMessage="Date Should not be Blank" ControlToValidate="txt_Date"></asp:RequiredFieldValidator>
                        </div>
                        <asp:CalendarExtender ID="Calender1" TargetControlID="txt_Date" runat="server" Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                    </div>
                    <div class="form-group">
                        <div class="col-md-6">
                            <label>
                                Time of Arrival</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txt_Time_Arrival" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" Display="Dynamic"
                                ErrorMessage="Time Should Not be blank" ControlToValidate="txt_Time_Arrival"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group ">
                        <div class="col-md-6">
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btn_Submit" CssClass="btn btn-block btn-danger" Text="Submit" runat="server"
                                OnClick="btn_Submit_Click" OnClientClick="openModal()" />
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
                                            Thanks for Your Time</h4>
                                    </div>
                                    <div class="modal-body">
                                        <p>
                                            Successfully Updated Vehichle Details</p>
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
            </asp:Panel>
        </div>
    </form>
</body>
</html>
