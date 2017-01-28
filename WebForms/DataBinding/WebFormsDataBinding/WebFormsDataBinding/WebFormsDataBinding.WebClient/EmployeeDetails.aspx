<%@ Page
    MasterPageFile="~/Site.Master"
    Title="Employee Details"
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="EmployeeDetails.aspx.cs"
    Inherits="WebFormsDataBinding.WebClient.EmployeeDetails" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <a class="btn btn-default" href="Employees.aspx"></a>

    <div class="jumbotron">
        <asp:DetailsView ID="EmployeeDetailsView" runat="server"></asp:DetailsView>
    </div>
</asp:Content>
