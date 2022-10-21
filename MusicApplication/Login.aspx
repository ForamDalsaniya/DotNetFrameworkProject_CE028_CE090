<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MusicApplication.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        
        <div>
            <h2 class="auto-style1">Sign In</h2>
            <div class="auto-style1" id="msg" runat="server">
                <asp:RequiredFieldValidator ID="userRequired" runat="server" ControlToValidate="UserLogin" ErrorMessage="User name is required" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="passwordRequired" runat="server" ControlToValidate="PasswordLogin" ErrorMessage="Password is required" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <p class="auto-style1">
                User Name:
                <asp:TextBox ID="UserLogin" runat="server"></asp:TextBox>
            </p>
            <p class="auto-style1">
                Password:&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="PasswordLogin" runat="server" TextMode="Password"></asp:TextBox>
            </p>
            <p class="auto-style1">
                <a onserverclick="RecoverPassword" runat="server">Forgot Password?</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href="Registration.aspx">New User?</a></p>
            <p class="auto-style1">
                <asp:Button ID="Button_login" runat="server" Text="SignIn" OnClick="Button_login_Click" />
            </p>
        </div>
        
    </form>
</body>
</html>
