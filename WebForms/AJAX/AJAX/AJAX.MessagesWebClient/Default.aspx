<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AJAX.MessagesWebClient.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Messages</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>

        <div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:Repeater ID="MessagesRepeater" runat="server"
                        ItemType="AJAX.MessagesWebClient.Message">
                        <HeaderTemplate>
                            <h1>Messages</h1>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div>
                                <span><%#: Item.PostedOn.ToShortTimeString() %></span>
                                <span><%#: Item.Content %></span>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:TextBox ID="AddMessageTextBox" runat="server"></asp:TextBox>
                    <asp:Button OnClick="OnNewMessage" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
