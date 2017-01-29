<%@ Page
    MasterPageFile="~/Site.Master"
    Title="EmployeesJS"
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="EmployeesJS.aspx.cs"
    Inherits="WebFormsDataBinding.WebClient.EmployeesJS" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/WebForms/MSAjax/MicrosoftAjax.js" />
        </Scripts>
    </asp:ScriptManager>
    <h1>TEst</h1>
</asp:Content>
