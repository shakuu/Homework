<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsIntroduction.WebFormsClient._Default" %>

<%@ Register Src="~/ViewControls/CalculatorUserControl.ascx" TagPrefix="uc" TagName="calculator" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET WebForms Calculator</h1>
    </div>

    <div class="jumbotron">
        <uc:calculator runat="server" />
    </div>

</asp:Content>
