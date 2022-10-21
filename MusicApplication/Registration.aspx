<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="MusicApplication.Registration" %>

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
        <div class="auto-style1">

            <h2><strong>Sign Up</strong></h2>
            <div id="error" runat="server">
                <asp:RequiredFieldValidator ID="rfirstnameRequired" runat="server" ControlToValidate="firstName" ErrorMessage="First name is required" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <asp:RequiredFieldValidator ID="ruserRequired" runat="server" ControlToValidate="userName" ErrorMessage="User name is required" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <asp:RequiredFieldValidator ID="remailRequired" runat="server" ControlToValidate="email" ErrorMessage="Email is required" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <asp:RequiredFieldValidator ID="rpasswordRequired" runat="server" ControlToValidate="password" ErrorMessage="Password is required" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
            </div>
            <p>
                First Name: <strong>
                <asp:TextBox ID="firstName" runat="server"></asp:TextBox>
                </strong>
            </p>
            <p>
                Last Name:&nbsp;
                <asp:TextBox ID="lastName" runat="server"></asp:TextBox>
            </p>
            <p>
                User Name:&nbsp;<asp:TextBox ID="userName" runat="server"></asp:TextBox>
            </p>
            <p>
                Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="email" runat="server" TextMode="Email"></asp:TextBox>
            </p>
            <p>
                Password:&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
            </p>
            <p>
                <a href="Login.aspx">Already a Member?</a></p>
            <p>
                <asp:Button ID="signUp" runat="server" Text="Sign Up" OnClick="signUp_Click" />
            </p>
            <p>
                &nbsp;</p>

        </div>
    </form>
</body>
</html>
