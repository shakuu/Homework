<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsIntroPartTwo.WebFormsClient._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <asp:Label CssClass="lead" ID="ExecutingAssembly" runat="server"></asp:Label>
    </div>

    <div class="jumbotron">
        <asp:TextBox ID="Name" runat="server"></asp:TextBox>
        <asp:Button runat="server" OnClick="ButtonPrintName_Click" CssClass="btn btn-success" Text="Print Name" />
        <asp:Label ID="NameLabel" runat="server"></asp:Label>
    </div>

    <div class="jumbotron">
        <asp:Panel ID="PrintPanel" runat="server"></asp:Panel>
    </div>

</asp:Content>
