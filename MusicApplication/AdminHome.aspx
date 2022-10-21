<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="MusicApplication.AdminHome" %>

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
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="adminUpload" runat="server" OnClick="adminUpload_Click" Text="Upload Song" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Home Page" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="userList" runat="server" OnClick="userList_Click" Text="User List" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="adminLogOut" runat="server" OnClick="adminLogOut_Click" Text="Log Out" />
        </div>
    </form>
</body>
</html>
