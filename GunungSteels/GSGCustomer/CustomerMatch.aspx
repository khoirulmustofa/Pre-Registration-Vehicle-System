<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerMatch.aspx.cs"
    Inherits="GunungSteels.GSGCustomer.CustomerMatch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../admin-lte/css/AdminLTE.min.css" rel="stylesheet" />
    <link href="../admin-lte/css/skins/skin-grey.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/font-awesome.min.css" rel="stylesheet" />
    <link href="../admin-lte/css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-3.1.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-ui-1.12.1.js" type="text/javascript"></script>
    <script src="../../admin-lte/js/adminlte.min.js" type="text/javascript"></script>
    <script src="../../Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript">

              function ShowPopUp() {
            $("#modal_dialog").dialog({
                title: "Order Approval",
                buttons: {
                    Close: function () {
                        $(this).dialog('close');
                    }
                },
                modal: true
            });
            return false;
        }

        function ShowRejectPopUp() {
            $("#modal_dialog").dialog({
                title: "Order Rejection",
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
            This Information is Sent To GSG Team.
        </div>
    <div>
        <div class="col-md-3" style="padding-top: 6px; background: #DCDBD9; height: 70px;
            padding-top: 10px">
            <div class="col-md-12" style="background: #C0BDBD">
                <img src="../../images/Slogan-Logo-GSG-Nov2017[2]_New.png" style="float: left;" />
            </div>
        </div>
        <div class="col-md-9" style="background: #C0BDBD">
            <div class="col-md-3">
                <header class="main-header">
 
      <div >
                <a href="../CustomerDashboard.aspx"><span class="glyphicon glyphicon-home" style="padding: 25px 20%"></span></a>
                <%--<a href="CustomerDashBoard.aspx" > <span class="glyphicon glyphicon-home"  style="padding:25px 20%"></span></a>--%>
      </div>
    
  </header>
            </div>
            <div class="col-md-6" style="height: 70px;">
                <label style="padding: 25px 20%; float: left;">
                    <b>CUSTOMER ORDER REGISTRATION</b></label>
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
            <a href="#" class="dropdown-toggle" data-toggle="dropdown" style="padding:25px 20%">
              <!-- The user image in the navbar-->
                <img src="../../images/User_new.png" class="user-image" alt="User Image"/>
                
                
              <!-- hidden-xs hides the username on small devices so only the image appears. -->
              <span class="hidden-xs"></span>
            </a>
            <ul class="dropdown-menu">
              <!-- The user image in the menu -->
              <li class="user-header">
                  <img src="../../images/User_new.png" class="img-circle" alt="User Image" />
                 
                <p style="color:black">
                  <%--User Name
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
                    <a href="../Change%20Password.aspx">Change Password </a>
                      
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
                  <a href="../../Home/LogOut.aspx"><b> <img src="../../images/Logout_new.png" /></b> <span style="color:red">Sign Out</span></a>
                </div>
              </li>
            </ul>
          </li>
          <!-- Control Sidebar Toggle Button -->
          <li>
        
          </li>
        </ul>
      </div>
    </nav>
  </header>
            </div>
        </div>
    </div>
    <form id="form1" class="form-horizontal" runat="server">
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
                                Customer Match Approval</label>
                        </div>
                        <div class="col-md-3">
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-6">
                            <label>
                                Sales Order</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txt_SalesOrder_Id" runat="server" Visible="false"></asp:TextBox>
                             <asp:TextBox ID="txtAxptaSalesOrderId" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-6">
                            <label>
                                Delivery Order
                            </label>
                        </div>
                        <div class="col-md-6">
                           <asp:TextBox ID="txtDeliveryOrderId" runat="server" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="txtAxptaDeliveryOrderId" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-6">
                            <label>
                                UOM</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txt_Uom" runat="server" ReadOnly="true"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server"
                                ErrorMessage="UOM Should Not be blank" ControlToValidate="txt_Uom"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-6">
                            <label>
                                Total Quantity (Tonnage/No. Of Pieces)</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtTotalQuantity" runat="server" ReadOnly="true"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" runat="server"
                                ErrorMessage="Quantity Should Not be blank" ControlToValidate="txtTotalQuantity"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-6">
                            <label>
                                Transporter Name</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txt_Transporter_Name" runat="server"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" runat="server"
                                ErrorMessage="Transporter Name Should not be blank" ControlToValidate="txt_Transporter_Name"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-6">
                            <label>
                                Source</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txt_Source" runat="server" ReadOnly="true"></asp:TextBox>
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
                            <asp:TextBox ID="txt_VehicleNumber" runat="server" ReadOnly="true"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic"
                                ErrorMessage="Vehicle Number Should Not be blank" ControlToValidate="txt_VehicleNumber"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-6">
                            <label>
                                Vehicle Details</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txt_VehicleDetails" runat="server"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic"
                                ErrorMessage="Vehicle Details Should Not be blank" ControlToValidate="txt_VehicleDetails"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-6">
                            <label>
                                Driver Name</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txt_DriverName" runat="server" ReadOnly="true"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" Display="Dynamic" runat="server"
                                ErrorMessage="Driver Name Should Not be blank" ControlToValidate="txt_DriverName"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <div class="form-group" style="display:none;">
                        <div class="col-md-6">
                            <label>
                                Driver ID</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtDriverID" runat="server" ReadOnly="true"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8" Display="Dynamic" runat="server"
                                ErrorMessage="Driver ID Should Not be Blank" ControlToValidate="txtDriverID"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-6">
                            <label>
                                Driver Phone No</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txt_Driver_Contact_No" runat="server" ReadOnly="true"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" Display="Dynamic" runat="server"
                                ErrorMessage="Driver Contact Number Should Not be Blank" ControlToValidate="txt_Driver_Contact_No"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-6">
                            <label>
                                KTP/SIM</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txt_KTP" runat="server" ReadOnly="true"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator10" Display="Dynamic" runat="server"
                                ErrorMessage="KTP/SIM Should Not be Blank" ControlToValidate="txt_KTP"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <%--  <div class="form-group">
                            <div class="col-md-6">
                                <label>Gate In</label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" Display="Dynamic" runat="server" ErrorMessage="Driver Name Should Not be blank" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                         <div class="form-group">
                            <div class="col-md-6">
                                <label>Gate Out</label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" Display="Dynamic" runat="server" ErrorMessage="Driver Name Should Not be blank" ControlToValidate="TextBox4"></asp:RequiredFieldValidator>
                            </div>
                        </div>--%>
                    <div class="form-group col-md-3">
                    </div>
                    <div class="form-group">
                        <div class="col-md-12">
                            <label>
                                Decription :
                            </label>
                        </div>
                        <textarea class="form-control" maxlength="150" placeholder="Type here....."></textarea>
                    </div>
                    <div class="col-md-12">
                        <div class="col-md-5">
                        </div>
                        <asp:Button ID="btnApprove" runat="server" Text="Approve" CssClass="btn btn-success"
                            OnClick="Approve" />
                        <asp:Button ID="btnReject" runat="server" Text="Reject" CssClass="btn btn-danger" OnClick="Reject" />
                    </div>
                </div>
            </div>
        </div>
        <%-- <asp:Button ID="" runat="server" Text="Approve" CssClass="btn btn-success"  OnClick="btn_Match_Click" OnClientClick="openModal()"/>--%>
        <div class="col-md-1">
        </div>
    </div>
    </form>
</body>
</html>
