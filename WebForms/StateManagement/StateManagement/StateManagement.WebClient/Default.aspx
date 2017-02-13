<%@ Page
    Title="Task 1"
    MasterPageFile="~/Site.Master"
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="Default.aspx.cs"
    Inherits="StateManagement.WebClient.Default" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div>
        <h3>Task 1</h3>
        <p>User Agent: <%= Request.UserAgent %></p>
        <p>Remote host IP address: <%= Request.UserHostAddress %></p>
    </div>

    <div>
        <h3>Task 2</h3>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:Label ID="TaskTwoOutput" runat="server"><%= string.Join(", ", (Session["TaskTwoList"] as List<string>)?? new List<string>()) %></asp:Label>
                <br />
                <asp:TextBox ID="TaskTwoContent" runat="server"></asp:TextBox>
                <asp:Button runat="server" Text="Submit text" OnClick="OnSubmitText" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
