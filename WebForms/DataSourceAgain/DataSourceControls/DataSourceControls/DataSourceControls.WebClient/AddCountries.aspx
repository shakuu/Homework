<%@ Page
    Title="Add Countries"
    MasterPageFile="~/Site.Master"
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="AddCountries.aspx.cs"
    Inherits="DataSourceControls.WebClient.AddCountries" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="well">
        <h1>Add Continent</h1>
        <asp:TextBox ID="AddContinentName" runat="server"></asp:TextBox>
        <asp:Button Text="Add Continent" runat="server" OnClick="OnAddContinent" />
    </div>

    <div class="well">
        <h1>Add Language</h1>
        <asp:TextBox ID="AddLanguageName" runat="server"></asp:TextBox>
        <asp:Button Text="Add Language" runat="server" OnClick="OnAddLanguage" />
    </div>

    <div class="well">
        <h1>Add Country</h1>
        <span>Name:
            <asp:TextBox ID="AddCountryName" runat="server"></asp:TextBox></span>
        <br />
        <span>Population:
            <asp:TextBox ID="AddCountryPopulation" runat="server"></asp:TextBox></span>
        <br />
        <span>Continent:
            <asp:DropDownList
                ID="AddCountryContinentsDropDownList" runat="server"
                DataTextField="Name" DataValueField="Id">
            </asp:DropDownList></span>
        <br />
        <span>Language:
            <asp:DropDownList
                ID="AddCountryLanguagesDropDownList" runat="server"
                DataTextField="Name" DataValueField="Id">
            </asp:DropDownList></span>
        <br />
        <asp:Button Text="Add Country" runat="server" OnClick="OnAddCountry" />
    </div>

    <div class="well">
        <h1>Add Flag</h1>
        <asp:FileUpload ID="FlagFileUpload" runat="server" />
        <br />
        <span>Country:
            <asp:DropDownList
                ID="AddFlagCountriesDropDownList" runat="server"
                DataTextField="Name" DataValueField="Id">
            </asp:DropDownList></span>
        <br />
        <asp:Button Text="Add Flag" runat="server" OnClick="OnAddFlag" />
    </div>

    <div class="well">
        <h1>Add Town</h1>
        <span>Name:
            <asp:TextBox ID="AddTownName" runat="server"></asp:TextBox></span>
        <br />
        <span>Population:
            <asp:TextBox ID="AddTownPopulation" runat="server"></asp:TextBox></span>
        <br />
        <span>Country:
            <asp:DropDownList
                ID="AddTownCountriesDropDownList" runat="server"
                DataTextField="Name" DataValueField="Id">
            </asp:DropDownList></span>
        <br />
        <asp:Button Text="Add Town" runat="server" OnClick="OnAddTown" />
    </div>

    <div class="well">
        <h1>Browse by Continent</h1>
        <asp:EntityDataSource
            ID="ContinentsDataSource" runat="server"
            DefaultContainerName="CountriesDbEntities"
            ConnectionString="name=CountriesDbEntities"
            EntitySetName="Continents"
            EnableFlattening="false">
        </asp:EntityDataSource>

        <asp:EntityDataSource
            ID="CountriesByContinent" runat="server"
            DefaultContainerName="CountriesDbEntities"
            ConnectionString="name=CountriesDbEntities"
            EntitySetName="Countries"
            Include="Language, CountryFlag"
            EnableFlattening="false"
            Where="it.ContinentId=@ContinentId">
            <WhereParameters>
                <asp:ControlParameter
                    ControlID="ContinentsGridView"
                    Name="ContinentId"
                    DbType="Guid"
                    DefaultValue="11111111-1111-1111-1111-111111111111" />
            </WhereParameters>
        </asp:EntityDataSource>

        <asp:EntityDataSource
            ID="TownsByCountry" runat="server"
            DefaultContainerName="CountriesDbEntities"
            ConnectionString="name=CountriesDbEntities"
            EntitySetName="Towns"
            EnableFlattening="false"
            Where="it.CountryId=@CountryId">
            <WhereParameters>
                <asp:ControlParameter
                    ControlID="CountriesByContinentGridView"
                    Name="CountryId"
                    DbType="Guid"
                    DefaultValue="11111111-1111-1111-1111-111111111111" />
            </WhereParameters>
        </asp:EntityDataSource>

        <div class="row">
            <div class="col-md-4">
                <asp:GridView
                    ID="ContinentsGridView" runat="server"
                    DataKeyNames="Id"
                    DataSourceID="ContinentsDataSource"
                    AutoGenerateColumns="false"
                    ItemType="DataSourceControls.Continents.Continent">
                    <Columns>
                        <asp:CommandField ShowSelectButton="true" />
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <span><%#: Item.Name %></span>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-md-4">
                <asp:GridView
                    ID="CountriesByContinentGridView" runat="server"
                    DataKeyNames="Id"
                    DataSourceID="CountriesByContinent"
                    AutoGenerateColumns="false"
                    ItemType="DataSourceControls.Continents.Country">
                    <Columns>
                        <asp:CommandField ShowSelectButton="true" />
                        <asp:TemplateField HeaderText="Flag">
                            <ItemTemplate>
                                <img src="data:image/png;base64,<%#: Item.CountryFlag?.ImageBase64 %>" alt="country flag" width="50" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <span><%#: Item.Name %></span>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Language">
                            <ItemTemplate>
                                <span><%#: Item.Language.Name %></span>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-md-4">
                <asp:GridView
                    ID="TownsByCountryGridView" runat="server"
                    DataKeyNames="Id"
                    DataSourceID="TownsByCountry"
                    AutoGenerateColumns="false"
                    ItemType="DataSourceControls.Continents.Town">
                    <Columns>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <span><%#: Item.Name %></span>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
