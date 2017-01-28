<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="EmployeesUserControl.ascx.cs"
    Inherits="WebFormsDataBinding.WebClient.UserControls.EmployeesUserControl" %>

<asp:GridView ID="EmployeesGridView" runat="server" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField DataField="FullName" HeaderText="Full Name" />
        <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="Id"
            DataNavigateUrlFormatString="EmployeeDetails.aspx?id={0}" />
    </Columns>
</asp:GridView>
