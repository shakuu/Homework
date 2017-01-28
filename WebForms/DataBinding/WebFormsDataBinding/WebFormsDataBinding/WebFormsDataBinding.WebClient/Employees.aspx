<%@ Page
    MasterPageFile="~/Site.Master"
    Title="Task 2."
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="Employees.aspx.cs"
    Inherits="WebFormsDataBinding.WebClient.Employees" %>

<%@ Register Src="~/UserControls/EmployeesUserControl.ascx" TagPrefix="uc" TagName="employees" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <uc:employees runat="server" />
</asp:Content>
