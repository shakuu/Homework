<%@ Page
    MasterPageFile="~/Site.Master"
    Title="Calculator"
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="Calculator.aspx.cs"
    Inherits="WebFormsControls.WebFormsClient.Calculator" %>

<%@ Register Src="~/UserControls/Calculator/CalculatorUserControl.ascx" TagPrefix="uc" TagName="calculatorcontrol" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Task 5. Calculator</h1>
    </div>

    <div class="jumbotron">
        <uc:calculatorcontrol runat="server" />
    </div>

</asp:Content>
