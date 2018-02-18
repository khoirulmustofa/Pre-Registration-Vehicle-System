<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="GunungSteels.Home.Reports" %>

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
        .auto-style1 {
            text-align: center;
        }
 
        .top {
            width: 100%;
            height: 72px;
            background: #C0BDBD;
        }
        .btn {
    padding: 2px 12px;
       }
 
        .content-wrapper {
    
    background-color: #ffffff;
   
}
 
        .sidebar {
            background-color: #ffffff;
        }
       .main-sidebar {
    background-color: #FFFFFF;
}
    </style>
    <title></title>
</head>
<body class="hold-transition skin-grey sidebar-mini">
    <div class="wrapper">
         <header class="main-header" >
 
    <!-- Logo -->
    <a href="#" class="logo">
      <!-- mini logo for sidebar mini 50x50 pixels -->
      <span class="logo-mini" style="color:#CC0000"><b><img src="../images/gsg-icon.png" /></b></span>
        
        
      <!-- logo for regular state and mobile devices -->
      <span class="logo-lg" style="color:#CC0000"><b><img src="../images/Slogan-Logo-GSG-main-header.png" /></b></span>
    </a>
 
    <!-- Header Navbar -->
    <nav class="navbar navbar-static-top" role="navigation">
      <!-- Sidebar toggle button-->
      <a href="../images/Menu%20Top-01.png" class="sidebar-toggle" data-toggle="push-menu" role="button">
          
        <span class="sr-only">Toggle navigation</span>
      </a>
      <!-- Navbar Right Menu -->
      <div class="navbar-custom-menu">
        <ul class="nav navbar-nav">
          <!-- Messages: style can be found in dropdown.less-->
          <li class="dropdown messages-menu">
            <!-- Menu toggle button -->
           <%-- <a href="#" class="dropdown-toggle" data-toggle="dropdown">
              <i class="fa fa-envelope-o"></i>
              <span class="label label-success">4</span>
            </a>--%>
            <ul class="dropdown-menu">
              <li class="header">You have 4 messages</li>
              <li>
                <!-- inner menu: contains the messages -->
                <ul class="menu">
                  <li><!-- start message -->
                    <a href="#">
                      <div class="pull-left">
                        <!-- User Image -->
                        <img src="dist/img/" class="img-circle" alt="User Image">
                      </div>
                      <!-- Message title and timestamp -->
                      <h4>
                        Support Team
                        <small><i class="fa fa-clock-o"></i> 5 mins</small>
                      </h4>
                      <!-- The message -->
                      <p>Why not buy a new awesome theme?</p>
                    </a>
                  </li>
                  <!-- end message -->
                </ul>
                <!-- /.menu -->
              </li>
              <li class="footer"><a href="#">See All Messages</a></li>
            </ul>
          </li>
          <!-- /.messages-menu -->
 
          <!-- Notifications Menu -->
          <li class="dropdown notifications-menu">
            <!-- Menu toggle button -->
            <%--<a href="#" class="dropdown-toggle" data-toggle="dropdown">
              <i class="fa fa-bell-o"></i>
              <span class="label label-warning">10</span>
            </a>--%>
            <ul class="dropdown-menu">
              <li class="header">You have 10 notifications</li>
              <li>
                <!-- Inner Menu: contains the notifications -->
                <ul class="menu">
                  <li><!-- start notification -->
                    <a href="#">
                      <i class="fa fa-users text-aqua"></i> 5 new members joined today
                    </a>
                  </li>
                  <!-- end notification -->
                </ul>
              </li>
              <li class="footer"><a href="#">View all</a></li>
            </ul>
          </li>
          <!-- Tasks Menu -->
          <li class="dropdown tasks-menu">
            <!-- Menu Toggle Button -->
           <%-- <a href="#" class="dropdown-toggle" data-toggle="dropdown">
              <i class="fa fa-flag-o"></i>
              <span class="label label-danger">9</span>
            </a>--%>
            <ul class="dropdown-menu">
              <li class="header">You have 9 tasks</li>
              <li>
                <!-- Inner menu: contains the tasks -->
                <ul class="menu">
                  <li><!-- Task item -->
                    <a href="#">
                      <!-- Task title and progress text -->
                      <h3>
                        Design some buttons
                        <small class="pull-right">20%</small>
                      </h3>
                      <!-- The progress bar -->
                      <div class="progress xs">
                        <!-- Change the css width attribute to simulate progress -->
                        <div class="progress-bar progress-bar-aqua" style="width: 20%" role="progressbar"
                             aria-valuenow="20" aria-valuemin="0" aria-valuemax="100">
                          <span class="sr-only">20% Complete</span>
                        </div>
                      </div>
                    </a>
                  </li>
                  <!-- end task item -->
                </ul>
              </li>
              <li class="footer">
                <a href="#">View all tasks</a>
              </li>
            </ul>
          </li>
          <!-- User Account Menu -->
          <li class="dropdown user user-menu">
            <!-- Menu Toggle Button -->
            <a href="#" class="dropdown-toggle" data-toggle="dropdown">
              <!-- The user image in the navbar-->

                
                <img src="../images/User_new.png" class="user-image" alt="User Image"/>
              <%--<img src="dist/img/" class="user-image" alt="User Image">--%>
              <!-- hidden-xs hides the username on small devices so only the image appears. -->
              <span class="hidden-xs"></span>
            </a>
            <ul class="dropdown-menu">
              <!-- The user image in the menu -->
              <li class="user-header">
                  <img src="../images/User_new.png" class="img-circle" alt="User Image" />
                <%--<img src="dist/img/" class="img-circle" alt="User Image">--%>
 
                <p>
                  User Name
                  <small>Designation</small>
                </p>
              </li>
              <!-- Menu Body -->
              <li class="user-body">
                <div class="row">
                  <%--<div class="col-xs-4 text-center">
                    <a href="#">Followers</a>
                  </div>--%>
                  <div class="col-xs-4 text-center">
                    <a href="#">Change Password </a>
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
                    
                  <a href="#"><b> <img src="../images/Logout_new.png" /></b> <span style="color:red">Sign Out</span></a>
                </div>
              </li>
            </ul>
          </li>
          <!-- Control Sidebar Toggle Button -->
          <li>
         <!--   <a href="#" data-toggle="control-sidebar"><i class="fa fa-gears"></i></a> -->
          </li>
        </ul>
      </div>
    </nav>
  </header>
 
        <aside class="main-sidebar" style="background-color: #FFFFFF">
        <section class="sidebar">
            <ul class="sidebar-menu" data-widget="tree">
        <li><a href="Dashboard.aspx"><b> <img src="../images/Dashboard_new.png" /></b> <span style="color:black">Dashboard</span></a></li>
                
        <li><a href="../Customer/TransportRegistrationOrder.aspx"><b> <img src="../images/Vehicle-new.png" /></b> <span style="color:black">Vehicle Info</span></a></li>
        <li><a href="../Security/PRVS%20Dashboard.aspx"><b><img src="../images/History-01new.png" /></b> <span style="color:black">History</span></a></li>
        <li class="active"><a href="#"><b><img src="../images/Report-new.png" /></b> <span style="color:black">Reports</span></a></li>
 
                </ul>
 
            </section>
            </aside>
 
        <div class="content-wrapper">
     <section class="content container-fluid">
 
 
 
    <form id="form1" class="form-horizontal" runat="server">
                <div class="col-md-12 container content">
                    <div class="col-md-1"></div>
                <div class="col-md-5">
                    <div class="box box-info">
                        <div class="box-body">
                            <div class="form-group">
                                <div class="col-md-6">
                                    <label>Source</label>
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox ID="TextBox1" runat="server" ReadOnly="False"></asp:TextBox>
 
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-6">
                                    <label>Destination</label>
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox ID="TextBox2" runat="server" ReadOnly="False"></asp:TextBox>
 
                                </div>
                            </div>
                            
                            <div class="form-group">
                                <div class="col-md-6">
                                    <label>From Date</label>
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox ID="TextBox3" runat="server" ReadOnly="False"></asp:TextBox>
 
                                </div>
                            </div>
 
                            <div class="form-group">
                                <div class="col-md-6">
                                    <label>To Date</label>
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox ID="TextBox4" runat="server" ReadOnly="False"></asp:TextBox>
 
                                </div>
                            </div>
 
 
 
                            </div>
                        </div>
                    </div>
 
                    <div class="col-md-5">
                    <div class="box box-info">
                        <div class="box-body">
                            <div class="form-group">
                                <div class="col-md-6">
                                    <label>In-premise waiting</label>
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox ID="TextBox5" runat="server" ReadOnly="False"></asp:TextBox>
 
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-6">
                                    <label>Driver Mismatch</label>
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox ID="TextBox6" runat="server" ReadOnly="False"></asp:TextBox>
 
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-6">
                                    <label>Vehicle Mismatch</label>
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox ID="TextBox7" runat="server" ReadOnly="False"></asp:TextBox>
 
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-6">
                                    <label>Transporter</label>
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox ID="TextBox8" runat="server" ReadOnly="False"></asp:TextBox>
 
                                </div>
                            </div>
                             
 
                            </div>
                        </div>
                        </div>
 
 
 
            </div>
    <div>
    
    </div>
    </form>
 
 
            </section>
            </div>
        </div>
</body>
</html>