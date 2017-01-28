<%@ Page
    Title="Home Page"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Default.aspx.cs"
    Inherits="WebFormsDataBinding.WebClient._Default" %>

<%@ Register Src="~/UserControls/CarsUserControl.ascx" TagPrefix="uc" TagName="complicatedcars" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Cars</h1>
    </div>

    <uc:complicatedcars runat="server" />

</asp:Content>
