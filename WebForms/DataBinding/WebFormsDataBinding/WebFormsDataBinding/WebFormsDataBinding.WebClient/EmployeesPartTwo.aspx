<%@ Page
    MasterPageFile="~/Site.Master"
    Title="List View"
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="EmployeesPartTwo.aspx.cs"
    Inherits="WebFormsDataBinding.WebClient.EmployeesPartTwo" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="EmployeesListView" runat="server"
        ItemType="WebFormsDataBinding.Employees.Models.EmployeeNames">
        <LayoutTemplate>
            <h3>Employees</h3>
            <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
        </LayoutTemplate>

        <ItemSeparatorTemplate>
            <hr />
        </ItemSeparatorTemplate>

        <ItemTemplate>
            <div>
                <h4><a href="/EmployeeDetails?id=<%#: Item.Id %>"><%#: Item.FullName %></a></h4>
            </div>
        </ItemTemplate>
    </asp:ListView>

    <asp:DataPager ID="DataPagerCustomers" runat="server"
        PagedControlID="EmployeesListView" PageSize="5"
        QueryStringField="page">
        <Fields>
            <asp:NextPreviousPagerField ShowFirstPageButton="true"
                ShowNextPageButton="false" ShowPreviousPageButton="false" />
            <asp:NumericPagerField />
            <asp:NextPreviousPagerField ShowLastPageButton="true"
                ShowNextPageButton="false" ShowPreviousPageButton="false" />
        </Fields>
    </asp:DataPager>
</asp:Content>
