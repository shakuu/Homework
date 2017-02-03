<%@ Page
    MasterPageFile="~/Site.Master"
    Title="Countries"
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="Countries.aspx.cs"
    Inherits="DataSourceControls.WebClient.Countries" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="well">
        <h1>Task 1. Countries</h1>
    </div>

    <div class="well">
        <asp:EntityDataSource
            ID="ContinentsDataSource" runat="server"
            DefaultContainerName="CountriesDbEntities"
            ConnectionString="name=CountriesDbEntities"
            EntitySetName="Continents">
        </asp:EntityDataSource>

        <asp:ListBox
            ID="ContinentsListBox" runat="server"
            AutoPostBack="true"
            DataSourceID="ContinentsDataSource"
            DataTextField="Name"
            DataValueField="Id"></asp:ListBox>

        <asp:EntityDataSource
            ID="CountriesDataSource" runat="server"
            DefaultContainerName="CountriesDbEntities"
            ConnectionString="name=CountriesDbEntities"
            EntitySetName="Countries"
            Include="Continent, Language"
            EnableFlattening="true"
            Where="it.ContinentId=@ContinentId">
            <WhereParameters>
                <asp:ControlParameter
                    ControlID="ContinentsListBox"
                    Name="ContinentId"
                    DbType="Guid" 
                    DefaultValue="11111111-1111-1111-1111-111111111111"/>
            </WhereParameters>
        </asp:EntityDataSource>

        <asp:GridView ID="CountriesGridView" runat="server"
            DataSourceID="CountriesDataSource"
            DataKeyNames="Id"
            AutoGenerateColumns="false">
            <Columns>
                <asp:CommandField ShowSelectButton="true" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Population" HeaderText="Population" />
                <asp:BoundField DataField="Continent.Name" HeaderText="Continent" />
                <asp:BoundField DataField="Language.Name" HeaderText="Language" />
            </Columns>
        </asp:GridView>

        <asp:EntityDataSource
            ID="TownsDataSource" runat="server"
            DefaultContainerName="CountriesDbEntities"
            ConnectionString="name=CountriesDbEntities"
            EntitySetName="Towns"
            Include="Country, Country.Language, Country.Continent"
            EnableFlattening="false"
            Where="it.CountryId=@CountryId">
            <WhereParameters>
                <asp:ControlParameter
                    ControlID="CountriesGridView"
                    Name="CountryId"
                    DbType="Guid"
                    DefaultValue="11111111-1111-1111-1111-111111111111" />
            </WhereParameters>
        </asp:EntityDataSource>

        <asp:ListView
            ID="TownsListView" runat="server"
            DataSourceID="TownsDataSource"
            ItemType="DataSourceControls.Continents.Town">
            <ItemTemplate>
                <p>The marvelous town of <%#: Item.Name %> is situated in the beatiful country of <%#: Item.Country.Name %>, on the tremendous continent of <%#: Item.Country.Continent.Name %>. The great people living there speak the <%#: Item.Country.Language.Name %> language.</p>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
