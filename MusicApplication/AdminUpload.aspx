<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminUpload.aspx.cs" Inherits="MusicApplication.AdminUpload" %>

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
            <h1>Add Song...</h1>
            <p>
                <asp:Label ID="Label1" runat="server" Text="Song Name: "></asp:Label>
                <asp:TextBox ID="songName" runat="server"></asp:TextBox>
            </p>
            <p>
                Catageory:
                <asp:DropDownList ID="catageory" runat="server">
                    <asp:ListItem Selected="True" Value="bollywood">Bollywood</asp:ListItem>
                    <asp:ListItem Value="hollywood">Hollywood</asp:ListItem>
                    <asp:ListItem Value="tellywood">Tellywood</asp:ListItem>
                    <asp:ListItem Value="albumSong">Album song</asp:ListItem>
                    <asp:ListItem Value="others">Others</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
                <asp:Label ID="Label2" runat="server" Text="Select Image:"></asp:Label>
                <asp:FileUpload ID="imageUpload" runat="server" />
            </p>
            <p>
                <asp:Label ID="Label3" runat="server" Text="Select Song: "></asp:Label>
                <asp:FileUpload ID="songUpload" runat="server" />
            </p>
            <p>
                <asp:Label ID="lblMessage" runat="server" Font-Bold="true"></asp:Label>
            </p>
            <p>
                <asp:Button ID="uploadButton" runat="server" Text="Upload" OnClick="uploadButton_Click" />
            &nbsp;&nbsp;&nbsp;
                <asp:Button ID="adminHome" runat="server" OnClick="adminHome_Click" Text="Home Page" />
            </p>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
        </div>
    </form>
</body>
</html>
