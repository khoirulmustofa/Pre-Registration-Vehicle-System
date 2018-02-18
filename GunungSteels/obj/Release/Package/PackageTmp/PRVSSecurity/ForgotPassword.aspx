<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="GunungSteels.PRVSSecurity.ForgotPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../admin-lte/css/AdminLTE.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
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
    </style>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
    </style>
</head>
<body>
    <div class="top">
        <img src="../images/gsg_logo2.png" style="float:left;"/>
       
        <div style="float: left; width: 316px;">
            
            <div style="float: left;">
                
            </div>

        </div>

        <div style="float: left; width: 75%; float: left; height: 70px;">
            <label style="padding: 10px 20%; float: left;"><b>VEHICLE REGISTRATION SYSTEM</b></label>

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
                                     <label>Forgot Password</label>
                                     </div>

                                 <div class="col-md-3">
                                     </div>
                                 </div>
                        <div class="form-group">
                                <div class="col-md-6">
                                    <label>Enter Email</label>
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>

                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-6">
                                    </div>
                                <div class="col-md-6">
                                    
                                      <asp:Button ID="btn_Send" runat="server" Text="Send" OnClick="btn_Send_Click" />
                                </div>
                                
                            </div>
                          
                            

                            
                            <div class="form-group">
                                <div class="col-md-6">
                                    
                                    <asp:Label ID="lblMessage" runat="server" />
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
