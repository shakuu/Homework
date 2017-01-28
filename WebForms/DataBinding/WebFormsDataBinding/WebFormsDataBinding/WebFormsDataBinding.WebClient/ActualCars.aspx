<%@ Page
    MasterPageFile="~/Site.Master"
    Title="Task 1."
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="ActualCars.aspx.cs"
    Inherits="WebFormsDataBinding.WebClient.ActualCars" %>

<%@ Register Src="~/UserControls/ActualCarsUserControl.ascx" TagPrefix="uc" TagName="actualcars" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <uc:actualcars runat="server" />
</asp:Content>
