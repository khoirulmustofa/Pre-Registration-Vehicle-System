<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="GunungSteels.PRVSRegistration.Registration" %>

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
         .Mismatch
        {
          background: YELLOW;
        }
    </style>   
    <script type="text/javascript">

        function ResetMatchData() {
           
            $("#lblTokenNo").empty("");
            $("#txtQRCode").val("");
            $("#txtSalesOrderID").val("");
            $("#txtMSalesOrderID").val("");
            $("#txtDeliveryOrderIdSecurity").val("");
            $("#txtDeliveryOrderIdCust").val("");
            $("#txtAxptaSalesOrderId").val("");
            $("#txtAxptaDeliveryOrderId").val("");
            $("#txtMAxptaSalesOrderId").val("");
            $("#txtMAxptaDeliveryOrderId").val("");

            $("#txt_KTP_Cust").val("");
            $("#txtTransporterNameCust").val("");
            $("#txtCustomerDateCust").val("");
            $("#txtTimeofArrivalCust").val("");
            $("#txtVehicleNumberCust").val("");


            $("#txtSourceCust").val("");
            $("#txtVehicleDetailsCust").val("");
            $("#txtUomCust").val("");
            $("#txtDriverNameCust").val("");
            $("#txtDriverNumberCust").val("");
          
            $("#txtSecurityGateOutDate").val("");
            $("#txtTotalQuantity").val("");
            $("#txtTransporterNameCust").val("");

            $("#txtMatchRegistrationGateIn").val("");
            $("#txtRegistrationGateIn").val("");
            $("#txtCustomerDateSec").val("");
            $("#txtTimeofArrivalSec").val("");

        }

        function ReseMistMatchData() {
            $("#txt_KTP_SEC").val("");
            $("#txtTransporterNameSec").val("");
            $("#txtCustomerDateSec").val("");
            $("#txtTimeofArrivalSec").val("");
            $("#txtVehicleNumberSec").val("");

            $("#txtSourceSec").val("");
            $("#txtVehicleDetailsSec").val("");

            $("#txtMUomSec").val("");
            $('#txtMismatchTotalQuantity').val("");

            $("#txtDriverNameSec").val("");
            $("#txtDriverNumberSec").val("");

            $("#txtTransporterNameSec").val("");

            $(".Mismatch").removeClass();
        }

        function ShowPopUp() {
            $("#modal_dialog").dialog({
                title: "Registration confirmation",
                buttons: {
                    Close: function () {
                        ResetMatchData();
                        ReseMistMatchData();
                        $(this).dialog('close');
                    }
                },
                modal: true
            });
            return false;
        }

        function ShowErroPopUp() {
            $("#modal_dialog_error").dialog({
                title: "Registration error",
                buttons: {
                    Close: function () {
                        $(this).dialog('close');
                    }
                },
                modal: true
            });
            return false;
        }

        function enableOrDisableFields() {
            console.log("hi...");
            //debugger;
            var chkStatus = document.getElementById("mismatchCheck");
            if (chkStatus.checked) {
                initializeFlags(false);
            } else {
                initializeFlags(true);
            }
        }

        function initializeFlags(flag) {

            document.getElementById("hdnIsMismatched").value = (!flag);
            // document.getElementById("txtUomSec").disabled = flag;
            document.getElementById("txtTransporterNameSec").disabled = flag;
            document.getElementById("txtSourceSec").disabled = flag;
            document.getElementById("txtVehicleNumberSec").disabled = flag;
            document.getElementById("txtVehicleDetailsSec").disabled = flag;
            document.getElementById("txtMisMatchDriverID").disabled = flag;
            document.getElementById("txtDriverNumberSec").disabled = flag;
            document.getElementById("txtDriverNameSec").disabled = flag;
            document.getElementById("txt_KTP_SEC").disabled = flag;
            document.getElementById("txtCustomerDateSec").disabled = flag;
            document.getElementById("txtTimeofArrivalSec").disabled = flag;

            document.getElementById("txtAuthorizedbySec").disabled = flag;
            document.getElementById("txtAuthorizationContactNoSec").disabled = flag;
            document.getElementById("txtAuthorizationMailSec").disabled = flag;
            document.getElementById("btn_Submit").disabled = flag;

        }
    </script>
     
</head>
<body>
    <div id="modal_dialog" style="display: none">
            Submitted successfully.
        </div>
        <div id="modal_dialog_error" style="display: none">
            Error while saving order ragistration details.
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
 
      <div  >
         
                <%--<a href="CustomerDashBoard.aspx" > <span class="glyphicon glyphicon-home"  style="padding:25px 20%"></span></a>--%>
          
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
            <a href="#" class="dropdown-toggle" data-toggle="dropdown" style="padding:25px 20%">
              <!-- The user image in the navbar-->
                <img src="../images/User_new.png" class="user-image" alt="User Image"/>
               
                
                
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
                    <a href="../PRVSSecurity/ChangePassword.aspx">Change Password </a>
                      
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
                  <a href="../Home/LogOut.aspx"><b> <img src="../images/Logout_new.png" /></b> <span style="color:red">Sign Out</span></a>
                    
                    
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
                                    <%-- SECURITY MATCH/MISMATCH ORDER VERIFICATION --%>
                                     MATCH/MISMATCH ORDER REGISTRATION
                                     </label>
                            </div>
                            <div class="col-md-3">
                            </div>
                        </div>
                        <div class="form-group">
                        <div class="col-md-3">
                                <label>
                                    Token No</label>
                            </div>
                            <div class="col-md-3">
                                 <asp:Label runat="server" Id="lblTokenNo" class="token"></asp:Label>
                            </div>
                            
                            <label>
                                Actual</label>
                            <div class="col-md-3">
                                <label>
                                    System</label>
                            </div>
                            <div class="col-md-3">
                                Report Mismatch &nbsp;
                                <input type="checkbox" id="mismatchCheck" onclick="enableOrDisableFields()" />
                                <asp:HiddenField ID="hdnIsMismatched" runat="server" Value="false" />
                            </div>
                        </div>
                        <div class="form-group">
                                <div class="col-md-4">
                                    <label>QR Code</label>  
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtQRCode" runat="server" 
                                        ontextchanged="txtQRCode_TextChanged" AutoPostBac="True"></asp:TextBox>
                                  <%--  <asp:Button ID="btnQRCodeSearch"  runat="server" Text="Search" 
                                        CssClass="btn btn-success" onclick="Search" />--%>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server" ErrorMessage="Please enter QR Code to search" ControlToValidate="txtQRCode"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-3 pull-right">
                                    <asp:Button ID="Button1"  runat="server" Text="Search" 
                                        CssClass="btn btn-success" onclick="Search" />
                                </div>
                            </div>

                        <div class="form-group">
                            <div class="col-md-4">
                                <label>
                                    Sales Order
                                </label>
                            </div>
                            <asp:TextBox ID="txtSalesOrderID" Visible="false" runat="server" ></asp:TextBox>
                              <asp:TextBox ID="txtAxptaSalesOrderId" runat="server" Enabled="false"></asp:TextBox>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtMSalesOrderID" Visible="false" runat="server"></asp:TextBox>
                                  <asp:TextBox ID="txtMAxptaSalesOrderId" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-md-4">
                                <label>
                                    Delivery Order</label>
                            </div>
                            <asp:TextBox ID="txtDeliveryOrderIdCust" Visible="false" runat="server"></asp:TextBox>
                            <asp:TextBox ID="txtAxptaDeliveryOrderId" runat="server" Enabled="false"></asp:TextBox>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtDeliveryOrderIdSecurity" Visible="false" runat="server"></asp:TextBox>
                                  <asp:TextBox ID="txtMAxptaDeliveryOrderId" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-4">
                                <label>
                                    UOM</label>
                            </div>
                            <asp:TextBox ID="txtMUomSec" runat="server" Enabled="false"></asp:TextBox>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtUomCust" ReadOnly="true" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-4">
                                <label>
                                    Total Quantity (Tonnage/No. Of Pieces)</label>
                            </div>
                            <asp:TextBox ID="txtMismatchTotalQuantity" runat="server" Enabled="false"></asp:TextBox>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtTotalQuantity" ReadOnly="true" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-4">
                                <label>
                                    Transporter Name</label>
                            </div>
                            <asp:TextBox ID="txtTransporterNameSec" runat="server" Enabled="false"></asp:TextBox>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtTransporterNameCust" ReadOnly="true" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-4">
                                <label>
                                    Source</label>
                            </div>
                            <asp:TextBox ID="txtSourceSec" runat="server" Enabled="false"></asp:TextBox>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtSourceCust" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-4">
                                <label>
                                    Vehicle No</label>
                            </div>
                            <asp:TextBox ID="txtVehicleNumberSec" runat="server" Enabled="false"></asp:TextBox>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtVehicleNumberCust" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-4">
                                <label>
                                    Vehicle Details</label>
                            </div>
                            <asp:TextBox ID="txtVehicleDetailsSec" runat="server" Enabled="false"></asp:TextBox>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtVehicleDetailsCust" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-4">
                                <label>
                                    Driver Name</label>
                            </div>
                            <asp:TextBox ID="txtDriverNameSec" runat="server" Enabled="false"></asp:TextBox>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtDriverNameCust" ReadOnly="true" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group" style="display:none;">
                            <div class="col-md-4">
                                <label>
                                    Driver ID</label>
                            </div>
                            <asp:TextBox ID="txtMisMatchDriverID" runat="server" Enabled="false"></asp:TextBox>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtDriverID" ReadOnly="true" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-4">
                                <label>
                                    Driver Phone No</label>
                            </div>
                            <asp:TextBox ID="txtDriverNumberSec" runat="server" Enabled="false"></asp:TextBox>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtDriverNumberCust" ReadOnly="true" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-4">
                                <label>
                                    KTP/SIM</label>
                            </div>
                            <asp:TextBox ID="txt_KTP_SEC" runat="server" Enabled="false"></asp:TextBox>
                            <div class="col-md-4">
                                <asp:TextBox ID="txt_KTP_Cust" ReadOnly="true" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-4">
                                <label>
                                    Date of Arrival</label>
                            </div>
                            <asp:TextBox ID="txtCustomerDateSec" runat="server" Enabled="false"></asp:TextBox>
                            <asp:CalendarExtender ID="txtCustomerDateSec_CalendarExtender" runat="server" Enabled="True"
                                Format="dd/MM/yyyy" TargetControlID="txtCustomerDateSec">
                            </asp:CalendarExtender>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtCustomerDateCust" ReadOnly="true" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-4">
                                <label>
                                    Time of Arrival</label>
                            </div>
                            <asp:TextBox ID="txtTimeofArrivalSec" runat="server" Enabled="false"></asp:TextBox>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtTimeofArrivalCust" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-4">
                                <label>
                                    Registration Gate In</label>
                            </div>
                            <asp:TextBox ID="txtRegistrationGateIn" ReadOnly="true" runat="server" Enabled="false"></asp:TextBox>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtMatchRegistrationGateIn" ReadOnly="true" runat="server"></asp:TextBox>
                                 <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtMatchRegistrationGateIn" runat="server" Format="dd/MM/yyyy HH:mm:ss tt"></asp:CalendarExtender>
                            </div>
                             <asp:CalendarExtender ID="Calender1" TargetControlID="txtRegistrationGateIn" runat="server" Format="dd/MM/yyyy HH:mm:ss tt"></asp:CalendarExtender>
                        </div>
                        
                        <div class="form-group" style="display:none;">
                            <div class="col-md-4">
                                <label>
                                    Authorized by</label>
                            </div>
                            <div class="col-md-4">
                            </div>
                            <asp:TextBox ID="txtAuthorizedbySec" runat="server" Enabled="false"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator10" Display="Dynamic" runat="server" ErrorMessage="Authorized by is required" ControlToValidate="txtAuthorizedbySec"></asp:RequiredFieldValidator>--%>
                        </div>
                        <div class="form-group" style="display:none;">
                            <div class="col-md-4">
                                <label>
                                    Authorized Contact Number</label>
                            </div>
                            <div class="col-md-4">
                            </div>
                            <asp:TextBox ID="txtAuthorizationContactNoSec" runat="server" Enabled="false"></asp:TextBox>
                              <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server" ErrorMessage="Authorized Contact Number is required" ControlToValidate="txtAuthorizationContactNoSec"></asp:RequiredFieldValidator>--%>
                        </div>
                        <div class="form-group" style="display:none;">
                            <div class="col-md-4">
                                <label>
                                    Authorization Mail</label>
                            </div>
                            <div class="col-md-4">
                            </div>
                            <asp:TextBox ID="txtAuthorizationMailSec" runat="server" Enabled="false"></asp:TextBox>
                              <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" runat="server" ErrorMessage="Authorization Mail is required" ControlToValidate="txtAuthorizationMailSec"></asp:RequiredFieldValidator>--%>
                        </div>
                        <div class="form-group" >
                            <div class="col-md-3">
                            </div>
                            <div class="col-md-5">
                                <div class="col-md-4">
                                </div>
                                <asp:Button ID="btn_Match" runat="server" Text="Submit" CssClass="btn btn-success"
                                    OnClick="btn_Match_Click" OnClientClick="openModal()" />
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
    </form>
</body>
</html>
