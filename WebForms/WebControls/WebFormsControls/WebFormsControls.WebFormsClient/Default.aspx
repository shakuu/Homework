<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsControls.WebFormsClient._Default" %>

<%@ Register Src="~/UserControls/RandomNumber/GenerateRandomNumber.ascx" TagPrefix="uc" TagName="getrandomnumber" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Task 1. Random</h1>
    </div>

    <div class="jumbotron">
        <uc:getrandomnumber runat="server"></uc:getrandomnumber>
    </div>

</asp:Content>
