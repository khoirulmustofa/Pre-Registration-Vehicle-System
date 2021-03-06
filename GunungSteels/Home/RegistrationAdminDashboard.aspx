﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationAdminDashboard.aspx.cs" Inherits="GunungSteels.Home.RegistrationAdminDashboard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../admin-lte/css/AdminLTE.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../admin-lte/css/skins/skin-grey.min.css" rel="stylesheet" />
    <link href="../Content/font-awesome.min.css" rel="stylesheet" />
    <%--<link href="../Content/DataTables.min.css" rel="stylesheet" />--%>
    <link href="../admin-lte/css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <%--<link href="../admin-lte/css/trirand/ui.jqgrid.css" rel="stylesheet" type="text/css" />--%>


    <script src="../Scripts/jquery-3.1.1.min.js" type="text/javascript"></script>
    <%--<script src="../admin-lte/js/trirand/jquery.jqGrid.min.js" type="text/javascript"></script>--%>
    <%--<script src="../admin-lte/js/trirand/i18n/grid.locale-en.js" type="text/javascript"></script>--%>
    <script src="../admin-lte/js/adminlte.min.js" type="text/javascript"></script>
    <script src="../Scripts/bootstrap.min.js" type="text/javascript"></script>


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
        
        .active
        {
            font-weight: bold;
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
              </header>
            </div>
            <div class="col-md-6" style="height: 70px;">
                <label style="padding: 25px 20%; float: left;">
                    <b>REGISTRATION ADMIN DASHBOARD</b></label>
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
                  <div class="col-xs-2 text-center">
                    <a href="../PRVSSecurity/ChangePassword.aspx">Change Password </a>
                  </div>
                    
                </div>
                <!-- /.row -->
              </li>
              <!-- Menu Footer-->
              <li class="user-footer">
               
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
    <form id="form1" runat="server">
    <div class="col-md-12 container content">
        <div class="col-md-3">
        </div>
        <div class="col-md-6">
            <div class="box box-info">
                <div class="box-body">
                    <div class="form-group">
                        <div class="col-md-6">
                            <label>
                                QR Code
                            </label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtQRCode" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <%--<div class="form-group">
                        <div class="col-md-6">
                            <label>
                                Delivery Order No.
                            </label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtDeliveryOrderNo" runat="server"></asp:TextBox>
                        </div>
                    </div>--%>
                    <br />
                    <div class="form-group">
                        <div class="col-md-6">
                        </div>
                        <div class="col-md-6 pull-right">
                            <asp:Button ID="btn_Search" runat="server" Text="Search" OnClick="btn_Search_Click1" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-3 pull-right">
           
            <asp:HyperLink ID="HyperLink2" CssClass="active" runat="server" 
                  NavigateUrl="../PRVSRegistration/Registration.aspx" target="_blank"
               Font-Underline="true">Go To Registration Team Access URL </asp:HyperLink></br>
        </div>
    </div>
    <center>
        <div>
            <br />
            <br />
            <h3>
            </h3>
        </div>
    </center>
    <br />
    <br />
    <div class="form-group">
        <div class="col-md-3">
            <label>
            </label>
        </div>
        <label>
            Token Status Details
        </label>
      
        <div id="grdVwSalesDetails">
            <div>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging"
                    PageSize="5" Width="1006px">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EmptyDataTemplate>
                        <table cellspacing="0" rules="all" style="font-family: Arial; font-size: 11pt; width: 1006px;
                            border-collapse: collapse;">
                            <tr style="color:White;background-color:#5D7B9D;font-weight:bold;">
                                <th scope="col" width="100px">
                                    Token No.
                                </th>
                                <th scope="col" width="100px">
                                    QR Code
                                </th>
                                <th scope="col" width="100">
                                    Driver Name
                                </th>
                                <th scope="col" width="100px">
                                    Company Name
                                </th>
                                <th scope="col" width="100px">
                                    Customer Name
                                </th>
                                <th scope="col" width="100px">
                                    Token Status
                                </th>
                            </tr>
                            <tr>
                                <td colspan="6" align="center">
                                    No Record Available.
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:BoundField DataField="DO_TOKEN_NO" HeaderText="Token No." ItemStyle-Width="100">
                            <ItemStyle Width="100px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="QR_CODE" HeaderText="QR Code" ItemStyle-Width="40">
                            <ItemStyle Width="100px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="DRIVER_NAME" HeaderText="Driver Name" ItemStyle-Width="40">
                            <ItemStyle Width="100px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="COMPANY_NAME" HeaderText="Company Name" ItemStyle-Width="100">
                            <ItemStyle Width="100px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="CUSTOMER_NAME" HeaderText="Customer Name" ItemStyle-Width="40">
                            <ItemStyle Width="100px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="TOKEN_STATUS" HeaderText="Token Status" ItemStyle-Width="40">
                            <ItemStyle Width="100px"></ItemStyle>
                        </asp:BoundField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                        PageButtonCount="4" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </div>
        </div>

        <br />
        <br />
    </div>
    
    </form>
</body>
</html>
