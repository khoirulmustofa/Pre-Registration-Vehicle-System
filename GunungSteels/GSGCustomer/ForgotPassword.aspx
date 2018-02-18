<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs"
    Inherits="GunungSteels.GSGCustomer.ForgotPassword" %>

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
        .auto-style1
        {
            text-align: center;
        }
        
        .top
        {
            width: 100%;
            height: 72px;
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
            height: 26px;
        }
    </style>

    <script type="text/javascript">

              function ShowPopUp() {
            $("#modal_dialog_Success").dialog({
                title: "Forgot Password Confirmation",
                buttons: {
                    Close: function () {
                        $(this).dialog('close');
                        window.location.href = '<%=Page.ResolveUrl("User_Login.aspx") %>';
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
</head>
<body>
    <div id="modal_dialog_Success" style="display: none">
        Password is sent to your Email.
    </div>
    <div id="modal_dialog_Error" style="display: none">
        Please enter your Email Id to recover password.
    </div>
    <div id="modal_dialog_Invalid_Customer" style="display: none">
        This Email Id is not registered.
    </div>
    <div class="top">
        <img src="../images/Slogan-Logo-GSG-Nov2017[2]_New.png" style="float: left;" />
        <div style="float: left; width: 316px;">
            <div style="float: left;">
            </div>
        </div>
        <div style="float: left; width: 75%; float: left; height: 70px;">
            <label style="padding: 10px 20%; float: left;">
                <b>CUTOMER ORDER REGISTRAION</b></label>
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
                                Forgot Password</label>
                        </div>
                        <div class="col-md-3">
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-6">
                            <label>
                                Enter Email</label>
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
        <div class="col-md-3">
        </div>
    </div>
    </form>
</body>
</html>
