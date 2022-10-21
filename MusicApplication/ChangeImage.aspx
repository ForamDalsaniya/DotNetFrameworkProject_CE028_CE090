<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeImage.aspx.cs" Inherits="MusicApplication.ChangeImage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Change" />
            <br />
            <br />
            <asp:Label ID="lblMsg" runat="server" Font-Bold="true"></asp:Label>
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Go to Home Page" />
        </div>
    </form>
</body>
</html>
