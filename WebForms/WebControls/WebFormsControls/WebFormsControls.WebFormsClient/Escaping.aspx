<%@ Page
    MasterPageFile="~/Site.Master"
    Title="Escaping"
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="Escaping.aspx.cs"
    Inherits="WebFormsControls.WebFormsClient.Escaping" %>

<%@ Register Src="~/UserControls/Escaping/EscapingUserControl.ascx" TagPrefix="uc" TagName="escaping" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Task 2. Escaping</h1>
    </div>

    <div class="jumbotron">
        <uc:escaping runat="server"></uc:escaping>
    </div>

</asp:Content>
