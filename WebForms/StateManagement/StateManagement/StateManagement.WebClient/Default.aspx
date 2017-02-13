<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StateManagement.WebClient.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="content" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>

        <div>
            <h3>Task 1</h3>
            <p>User Agent: <%= Request.UserAgent %></p>
            <p>Remote host IP address: <%= Request.UserHostAddress %></p>
        </div>

        <div>
            <h3>Task 2</h3>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:Label ID="TaskTwoOutput" runat="server"></asp:Label>
                    <asp:TextBox ID="TaskTwoContent" runat="server"></asp:TextBox>
                    <asp:Button runat="server" Text="Submit text" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
