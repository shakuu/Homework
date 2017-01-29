<%@ Page
    MasterPageFile="~/Site.Master"
    Title="EmployeesJS"
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="EmployeesJS.aspx.cs"
    Inherits="WebFormsDataBinding.WebClient.EmployeesJS" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h1>Employees With JS</h1>
    <div class="jumbotron" id="employees-container">
        <asp:GridView ID="EmployeesGridView" runat="server">
        </asp:GridView>
    </div>

    <script src="<%= ResolveUrl("~/Scripts/jquery-1.10.2.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Scripts/Employees/popup.js") %>" type="text/javascript"></script>

</asp:Content>

