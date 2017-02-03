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
            EnableFlattening="false"
            Where="it.ContinentId=@ContinentId"
            EnableUpdate="true"
            EnableInsert="true">
            <WhereParameters>
                <asp:ControlParameter
                    ControlID="ContinentsListBox"
                    Name="ContinentId"
                    DbType="Guid"
                    DefaultValue="11111111-1111-1111-1111-111111111111" />
            </WhereParameters>
        </asp:EntityDataSource>

        <asp:GridView ID="CountriesGridView" runat="server"
            DataSourceID="CountriesDataSource"
            DataKeyNames="Id"
            AutoGenerateColumns="false"
            PageSize="5"
            AllowPaging="true"
            AllowSorting="true"
            ItemType="DataSourceControls.Continents.Country">
            <Columns>
                <asp:CommandField ShowSelectButton="true" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Population" HeaderText="Population" />
                <asp:TemplateField HeaderText="Continent">
                    <ItemTemplate>
                        <span><%#: Item.Continent.Name %></span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Language">
                    <ItemTemplate>
                        <span><%#: Item.Language.Name %></span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="true" />
            </Columns>
        </asp:GridView>

        <asp:EntityDataSource
            ID="TownsDataSource" runat="server"
            DefaultContainerName="CountriesDbEntities"
            ConnectionString="name=CountriesDbEntities"
            EntitySetName="Towns"
            Include="Country, Country.Language, Country.Continent"
            EnableFlattening="false"
            AutoPage="true"
            AutoSort="true"
            EnableUpdate="true"
            EnableInsert="true"
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
            ItemType="DataSourceControls.Continents.Town" DataKeyNames="Id" InsertItemPosition="LastItem">
            <AlternatingItemTemplate>
                <li style="background-color: #FFFFFF;color: #284775;">
                    Name:
                    <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                    <br />
                    Population:
                    <asp:Label ID="PopulationLabel" runat="server" Text='<%# Eval("Population") %>' />
                    <br />
                    Country:
                    <asp:Label ID="CountryLabel" runat="server" Text='<%# Eval("Country.Name") %>' />
                    <br />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                </li>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <li style="background-color: #999999;">
                    Name:
                    <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                    <br />
                    Population:
                    <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%# Bind("Population") %>' />
                    <br />
                    Country:
                    <asp:TextBox ID="CountryTextBox" runat="server" Text='<%# Bind("Country.Name") %>' />
                    <br />
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                </li>
            </EditItemTemplate>
            <EmptyDataTemplate>
                No data was returned.
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <li style="">
                    Name:
                    <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                    <br />
                    Population:
                    <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%# Bind("Population") %>' />
                    <br />
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                </li>
            </InsertItemTemplate>
            <ItemSeparatorTemplate>
                <br />
            </ItemSeparatorTemplate>
            <ItemTemplate>
                <li style="background-color: #E0FFFF;color: #333333;">
                    Name:
                    <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                    <br />
                    Population:
                    <asp:Label ID="PopulationLabel" runat="server" Text='<%# Eval("Population") %>' />
                    <br />
                    Country:
                    <asp:Label ID="CountryLabel" runat="server" Text='<%# Eval("Country.Name") %>' />
                    <br />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                </li>
            </ItemTemplate>
            <LayoutTemplate>
                <ul id="itemPlaceholderContainer" runat="server" style="font-family: Verdana, Arial, Helvetica, sans-serif;">
                    <li runat="server" id="itemPlaceholder" />
                </ul>
                <div style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF;">
                    <asp:DataPager ID="DataPager1" runat="server">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                        </Fields>
                    </asp:DataPager>
                </div>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <li style="background-color: #E2DED6;font-weight: bold;color: #333333;">
                    Name:
                    <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                    <br />
                    Population:
                    <asp:Label ID="PopulationLabel" runat="server" Text='<%# Eval("Population") %>' />
                    <br />
                    Country:
                    <asp:Label ID="CountryLabel" runat="server" Text='<%# Eval("Country.Name") %>' />
                    <br />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                </li>
            </SelectedItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
