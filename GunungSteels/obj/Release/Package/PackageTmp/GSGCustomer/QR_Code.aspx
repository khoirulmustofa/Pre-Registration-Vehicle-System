<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QR_Code.aspx.cs" Inherits="GunungSteels.GSGCustomer.QR_Code" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../admin-lte/css/AdminLTE.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../admin-lte/css/skins/skin-grey.min.css" rel="stylesheet" />
    <link href="../Content/font-awesome.min.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.1.1.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../admin-lte/js/adminlte.min.js"></script>
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
                <img src="../images/Slogan-Logo-GSG-Nov2017[2]_New.png" style="float: left;" />
            </div>
        </div>
        <div class="col-md-9" style="background: #C0BDBD">
            <div class="col-md-3">
                <header class="main-header">
 
      <div  >
         
                <a href="CustomerDashboard.aspx"> <span class="glyphicon glyphicon-home"  style="padding:25px 20%"></span></a>
          
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
    <div class="container">
        <form id="form1" runat="server" class="form-horizontal">
        <div>
         <asp:ToolkitScriptManager ID="toolscriptcal" runat="server"></asp:ToolkitScriptManager>
            <div class="col-md-12 container content">
                <p style="padding: 11px 5px 0px 1px;">
                    <b>Bar Code is generated successfully for the Delivery Order: </b>
                </p>
                <div class="main">
                    <asp:PlaceHolder ID="plBarCode" runat="server" />
                </div>
                <div class="main" style="float: right; padding-right: 20px;">
                   <a href="#"><span class="glyphicon glyphicon-save" style="color: #00001f" onclick="Download()"></span></a>&nbsp;&nbsp;
                   <a  href="#"><span class="glyphicon glyphicon-print" onclick="myFunction()" style="color: #00001f">
                    </span></a>
                      <%--<button onclick="myFunction()">Print this page</button>--%>

                                <script type="text/javascript">
                                function myFunction() {
                                    window.print();
                                }

                                function Download() {
                                    window.print();
                                   // window.location.href = "/location/file";
                                    //document.getElementById('download').click();
                                }

                                </script>  
                </div>
                <div class="col-md-1">
                </div>
                <div class="col-md-12">
                    <div class="box box-info">
                        <div class="box-body">
                          <div class="form-group">
                            <div class="col-md-3">
                            </div>
                           <%-- <div class="col-md-6">
                                <label>CUSTOMER VEHICLE REGISTRATION </label>
                            </div>--%>

                            <div class="col-md-3">
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-6">
                                <label>Sales Order</label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txt_SalesOrder_Id" runat="server" ReadOnly="true"></asp:TextBox>

                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-6">
                                <label>Delivery Order </label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtDeliveryOrderId" runat="server" ReadOnly="true"></asp:TextBox>

                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-6">
                                <label>UOM KG/No Of Pices</label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txt_Uom" runat="server" ReadOnly="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server" ErrorMessage="UOM Should Not be blank" ControlToValidate="txt_Uom"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-6">
                                <label>Total Quantity Tonnage/No Of pices</label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtTonnage" runat="server" ReadOnly="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" runat="server" ErrorMessage="Total Quantity Should Not be blank" ControlToValidate="txtTonnage"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-6">
                                <label>Transporter Name</label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txt_Transporter_Name" runat="server" ReadOnly="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" runat="server" ErrorMessage="Transporter Name Should not be blank" ControlToValidate="txt_Transporter_Name"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                         
                        <div class="form-group">
                            <div class="col-md-6">
                                 <div class="ui-widget">
                                <label>Source</label> 
                            </div></div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txt_Source" runat="server" ReadOnly="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" ErrorMessage="Source Should Not be blank" ControlToValidate="txt_Source"></asp:RequiredFieldValidator>
                            
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-6">
                                <label>Vehicle No</label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txt_VehicleNumber" runat="server" ReadOnly="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" ErrorMessage="Vehicle Number Should Not be blank" ControlToValidate="txt_VehicleNumber"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-6">
                                <label>Vehicle Details</label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txt_VehicleDetails" runat="server" ReadOnly="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic" ErrorMessage="Vehicle Details Should Not be blank" ControlToValidate="txt_VehicleDetails"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-6">
                                <label>Driver Name</label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txt_DriverName" runat="server" ReadOnly="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Display="Dynamic" runat="server" ErrorMessage="Driver Name Should Not be blank" ControlToValidate="txt_DriverName"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group" style="display:none;">
                            <div class="col-md-6">
                                <label>Driver ID</label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtDriverId" runat="server" ReadOnly="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" Display="Dynamic" runat="server" ErrorMessage="Driver Name Should Not be blank" ControlToValidate="txtDriverId"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-6">
                                <label>Driver Phone No</label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txt_Driver_Contact_No" runat="server" ReadOnly="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" Display="Dynamic" runat="server" ErrorMessage="Driver Contact Number Should Not be Blank" ControlToValidate="txt_Driver_Contact_No" ></asp:RequiredFieldValidator>
                                 <%--<asp:RegularExpressionValidator ID="txt_Driver_Contact_No1" runat="server" ControlToValidate="txt_Driver_Contact_No" ErrorMessage="Contact Number Should be max 10 Nmbrs" ValidationExpression="[0-9]{10}">
                                 </asp:RegularExpressionValidator>--%>
                            </div>
                           
                        </div>
                        <div class="form-group">
                            <div class="col-md-6">
                                <label>KTP/SIM</label>
                            </div>

                            <div class="col-md-6">
                                <asp:TextBox ID="txt_KTP" runat="server" ReadOnly="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" Display="Dynamic" runat="server" ErrorMessage="KTP/SIM Should Not be Blank" ControlToValidate="txt_KTP"></asp:RequiredFieldValidator>

                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-md-6">
                                <label>Date of Arrival</label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txt_Date" runat="server" ReadOnly="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" Display="Dynamic" ErrorMessage="Date Should not be Blank" ControlToValidate="txt_Date"></asp:RequiredFieldValidator>
                            </div>
                            <asp:CalendarExtender ID="Calender1" TargetControlID="txt_Date" runat="server" Format="dd/MM/yyyy"></asp:CalendarExtender>
                        </div>
                       

                        <div class="form-group">
                            <div class="col-md-6">
                                <label>Time of Arrival</label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txt_Time_Arrival" runat="server" ReadOnly="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" Display="Dynamic" ErrorMessage="Time Should Not be blank" ControlToValidate="txt_Time_Arrival"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        

                    </div>
                          
                        </div>
                    </div>
                </div>
                <div class="col-md-1">
                </div>
                <p style="padding: 11px 5px 0px 1px;">
                    <b>NOTE: Please take the printout which is required at the time of Delivery Transaction to check-in GSG premises.
                    </b>
                </p>
            </div>
        </form>
    </div>
       
    <%--</div>--%>
</body>
</html>
