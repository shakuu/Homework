<%@ Page
    MasterPageFile="~/Site.Master"
    Title="Repeater"
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="EmployeesPartThree.aspx.cs"
    Inherits="WebFormsDataBinding.WebClient.EmployeesPartThree" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <asp:Repeater ID="Employees" ItemType="WebFormsDataBinding.Employees.Models.EmployeeNames" runat="server">
            <ItemTemplate>
                <h4><a href="/EmployeeDetails?id=<%#: Item.Id %>"><%#: Item.FullName %></a></h4>
                <br />
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
