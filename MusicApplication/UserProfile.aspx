<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="MusicApplication.UserProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .Box{
            border: 3px solid black;
            margin:auto;
            padding:10px;
            width: 400px;
        }
        .Picture{
            height:50px;
            width:50px;
            border-radius:50%;
            border:2px solid black;
        }
        .ChangeImage {
            border-radius: 50%;
            border: none;
        }
        .auto-style1 {
            font-weight: normal;
        }
        .auto-style2 {
            text-align: center;
        }
    </style>
</head>
<body>
    <div class="Box">    
        <form id="form1" runat="server">
            <div class="auto-style2">
                <h4 id="sessionUser" runat="server" style="text-align:center">
                    <asp:Image ID="Image1" ImageUrl="~/profile-icon.png" CssClass="Picture" runat="server" />
                    <asp:Button ID="userPicture" runat="server" CssClass="ChangeImage" Text="+" OnClick="userPicture_Click" />
                </h4>
                
                <h4 runat="server" id="suser" style="text-align:center"></h4>
                <p runat="server" style="text-align:center">
                    <asp:Label ID="Label1" runat="server" CssClass="auto-style1" Text="First Name"></asp:Label>
                    &nbsp;<asp:TextBox ID="cFirstName" runat="server"></asp:TextBox>
                </p>
                <p runat="server" style="text-align:center">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="cFirstName" ErrorMessage="First Name cannot be blank" ForeColor="Red"></asp:RequiredFieldValidator>
                </p>
                <p runat="server" style="text-align:center">
                    <asp:Label ID="Label2" runat="server" Text="Last Name"></asp:Label>
                    &nbsp;<asp:TextBox ID="cLastName" runat="server"></asp:TextBox>
                </p>
                <p runat="server" style="text-align:center">&nbsp;</p>
                <p runat="server" style="text-align:center">
                    <asp:Label ID="Label3" runat="server" Text="User Name"></asp:Label>
                    &nbsp;<asp:TextBox ID="cUserName" runat="server"></asp:TextBox>
                </p>
                <p runat="server" style="text-align:center">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cUserName" ErrorMessage="User name can not be blank" ForeColor="Red"></asp:RequiredFieldValidator>
                </p>
                <asp:Label ID="error" runat="server" Font-Bold="true"></asp:Label>
                <p runat="server" style="text-align:center">
                    <asp:Button ID="changeProfile" runat="server" OnClick="changeProfile_Click" Text="Change" />
                &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Home Page" />
                </p>
            </div>
        </form>
    </div>

</body>
</html>
