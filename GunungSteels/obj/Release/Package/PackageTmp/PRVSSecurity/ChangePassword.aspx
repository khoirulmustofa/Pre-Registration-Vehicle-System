<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="GunungSteels.PRVSSecurity.ChangePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
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

               function ShowPopUp() {
             $("#modal_dialog_Success").dialog({
                 title: "Change Password Confirmation",
                 buttons: {
                     Close: function () {
                         $(this).dialog('close');
                          //window.location.href = '<%=Page.ResolveUrl("Dashboard.aspx") %>';
                     }
                 },
                 modal: true
             });
             return false;
         }

         function ShowFailurePopUp() {
             $("#modal_dialog_Failure").dialog({
                 title: "Change Password Confirmation",
                 buttons: {
                     Close: function () {
                         $(this).dialog('close');
                     }
                 },
                 modal: true
             });
             return false;
         }

         function ShowInvalidUserPopUp() {
             $("#modal_dialog_Invalid_Customer").dialog({
                 title: "Change Password Confirmation",
                 buttons: {
                     Close: function () {
                         $(this).dialog('close');
                     }
                 },
                 modal: true
             });
             return false;
         }

         function ShowErrorPopUp() {
             $("#modal_dialog_Error").dialog({
                 title: "Change Password Error",
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
    </style>
</head>
<body>

<div id="modal_dialog_Success" style="display: none">
        Password changed successfully.
    </div>
    <div id="modal_dialog_Error" style="display: none">
        Either New Password and Confirm password are not same or New Paasword is empty.
    </div>
    <div id="modal_dialog_Failure" style="display: none">
        Invalid current password.
    </div>
    <div id="modal_dialog_Invalid_Customer" style="display: none">
        User does not exist.
    </div>

    <div>
                
             <div class="col-md-3" style="padding-top:6px;background:#DCDBD9; height: 70px;padding-top:10px">
            <div class="col-md-12" style="background:#C0BDBD">
                <img src="../images/Slogan-Logo-GSG-Nov2017[2]_New.png" style="float:left;"  />
            </div>
                 
        </div>
        <div class="col-md-9" style="background:#C0BDBD">
       
          <div class="col-md-3" ></div>
 
        <div class="col-md-6" style="height: 70px;">
            <label style="padding: 10px 20%; padding-top: 25px;float: left;"><b>VEHICLE REGISTRATION SYSTEM</b></label>
 
        </div>
             <div class="col-md-3" ></div>
            <header class="main-header" >
 
   
    
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
            <a href="#" class="dropdown-toggle" data-toggle="dropdown">
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

    
       
     <form id="form2" class="form-horizontal" runat="server">

        <div class="col-md-12 container content">
            <div class="col-md-3"></div>
                <div class="col-md-6">
                    <div class="box box-info">
                        <div class="box-body">
                             <div class="form-group">
                                 <div class="col-md-3">
                                     </div>
                                 <div class="col-md-6">
                                     <label>Change password</label>
                                     </div>

                                 <div class="col-md-3">
                                     </div>
                                 </div>
                        <div class="form-group">
                                <div class="col-md-6">
                                    <label>Enter Current Password</label>
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtCurrentPsw" runat="server" Width="120px" TextMode="Password"></asp:TextBox>

                                </div>
                            </div>
                           <div class="form-group">
                                <div class="col-md-6">
                                    <label>Enter New Password</label>
                                </div>
                                <div class="col-md-6">
                                     <asp:TextBox ID="txtNewPsw" runat="server" Width="120px" TextMode="Password"></asp:TextBox>

                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-6">
                                    <label>Confirm Password</label>
                                </div>
                                <div class="col-md-6">
                                     <asp:TextBox ID="txtConfirmPsw" runat="server" Width="120px" TextMode="Password"></asp:TextBox>

                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-6">
                                    </div>
                                <div class="col-md-6">
                                    
                                     <asp:Button ID="btnchangepass" runat="server" Text="Change Password" OnClick="btnchangepass_Click1"  />
                                </div>
                                
                            </div>
                            <div class="form-group">
                                <div class="col-md-6">
                                    
                                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                </div>
                                
                            </div>

                            
                             </div>

                        </div>
                    </div>
             <div class="col-md-3"></div>

            </div>
         </form>
</body>
</html>