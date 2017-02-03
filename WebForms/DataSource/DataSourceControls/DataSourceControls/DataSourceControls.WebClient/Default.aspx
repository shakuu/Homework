<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DataSourceControls.WebClient._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Countries</h1>
    </div>

    <asp:ListBox 
        ID="ContinentsListBox" runat="server" 
        DataSourceID="ContinentsDataSource"
        DataTextField="Name" DataValueField="Id"></asp:ListBox>

    <asp:EntityDataSource
        ID="ContinentsDataSource"
        ConnectionString="name=ContinentsEntities"
        DefaultContainerName="ContinentsEntities"
        EntitySetName="Continents"
        runat="server">
    </asp:EntityDataSource>

</asp:Content>
