<%@ Page
    MasterPageFile="~/Site.Master"
    Title="Countries"
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="Countries.aspx.cs"
    Inherits="DataSourceControls.WebClient.Countries" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h1>Hello World</h1>

    <asp:EntityDataSource
        ID="ContinentsDataSource" runat="server"
        DefaultContainerName="CountriesDbEntities"
        ConnectionString="name=CountriesDbEntities"
        EntitySetName="Continents">
    </asp:EntityDataSource>

    <asp:ListBox
        ID="ContinentsListBox" runat="server"
        DataSourceID="ContinentsDataSource"
        DataTextField="Name"
        DataValueField="Id"></asp:ListBox>

    <asp:EntityDataSource ID="CountriesDataSource" runat="server"
        DefaultContainerName="CountriesDbEntities"
        ConnectionString="name=CountriesDbEntities"
        EntitySetName="Countries"
        Where="it.ContinentId=@ContinentId">
        <WhereParameters>
            <asp:ControlParameter
                ControlID="ContinentsListBox"
                Name="ContinentId"
                DbType="Guid" />
        </WhereParameters>
    </asp:EntityDataSource>

    <asp:GridView ID="CountriesGridView" runat="server"
        DataSourceID="CountriesDataSource">
    </asp:GridView>
</asp:Content>
