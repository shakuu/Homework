<%@ Page
    Title="Add More"
    MasterPageFile="~/Site.Master"
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="AddCountriesAgain.aspx.cs"
    Inherits="DataSourceControls.WebClient.AddCountriesAgain" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <section id="heading">
        <h1>Add Towns</h1>
    </section>
    <div class="well">
        <asp:EntityDataSource
            ID="TownsDataSource" runat="server"
            DefaultContainerName="CountriesDbEntities"
            ConnectionString="name=CountriesDbEntities"
            EntitySetName="Towns"
            Include="Country, Country.Continent, Country.Language"
            EnableFlattening="false"
            EnableInsert="true">
        </asp:EntityDataSource>

        <asp:ListView
            ID="TownsListView" runat="server"
            DataSourceID="TownsDataSource" DataKeyNames="Id" InsertItemPosition="LastItem">
            <AlternatingItemTemplate>
                <li style="background-color: #FFFFFF;color: #284775;">Id:
                    <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                    <br />
                    Name:
                    <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                    <br />
                    Population:
                    <asp:Label ID="PopulationLabel" runat="server" Text='<%# Eval("Population") %>' />
                    <br />
                    CountryId:
                    <asp:Label ID="CountryIdLabel" runat="server" Text='<%# Eval("Country.Name") %>' />
                    <br />
                </li>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <li style="background-color: #999999;">Id:
                    <asp:Label ID="IdLabel1" runat="server" Text='<%# Eval("Id") %>' />
                    <br />
                    Name:
                    <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                    <br />
                    Population:
                    <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%# Bind("Population") %>' />
                    <br />
                    CountryId:
                    <asp:TextBox ID="CountryIdTextBox" runat="server" Text='<%# Bind("CountryId") %>' />
                    <br />
                    Country:
                    <asp:TextBox ID="CountryTextBox" runat="server" Text='<%# Bind("Country") %>' />
                    <br />
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                </li>
            </EditItemTemplate>
            <EmptyDataTemplate>
                No data was returned.
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <li style="">Id:
                    <asp:TextBox ID="IdTextBox" runat="server" Text='<%# Bind("Id") %>' />
                    <br />
                    Name:
                    <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                    <br />
                    Population:
                    <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%# Bind("Population") %>' />
                    <br />
                    Country:
                    <asp:TextBox ID="CountryTextBox" runat="server" Text='<%# Bind("Country.Name") %>' />
                    <br />
                    Language:
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Country.Language.Name") %>' />
                    <br />
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                </li>
            </InsertItemTemplate>
            <ItemSeparatorTemplate>
                <br />
            </ItemSeparatorTemplate>
            <ItemTemplate>

                <li style="background-color: #E0FFFF;color: #333333;">Id:
                    <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                    <br />
                    Name:
                    <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                    <br />
                    Population:
                    <asp:Label ID="PopulationLabel" runat="server" Text='<%# Eval("Population") %>' />
                    <br />
                    CountryId:
                    <asp:Label ID="CountryIdLabel" runat="server" Text='<%# Eval("CountryId") %>' />
                    <br />
                    Country:
                    <asp:Label ID="CountryLabel" runat="server" Text='<%# Eval("Country") %>' />
                    <br />
                </li>

            </ItemTemplate>
            <LayoutTemplate>
                <ul id="itemPlaceholderContainer" runat="server" style="font-family: Verdana, Arial, Helvetica, sans-serif;">
                    <li runat="server" id="itemPlaceholder" />
                </ul>
                <div style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF;">
                </div>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <li style="background-color: #E2DED6;font-weight: bold;color: #333333;">Id:
                    <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                    <br />
                    Name:
                    <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                    <br />
                    Population:
                    <asp:Label ID="PopulationLabel" runat="server" Text='<%# Eval("Population") %>' />
                    <br />
                    CountryId:
                    <asp:Label ID="CountryIdLabel" runat="server" Text='<%# Eval("CountryId") %>' />
                    <br />
                    Country:
                    <asp:Label ID="CountryLabel" runat="server" Text='<%# Eval("Country") %>' />
                    <br />
                </li>
            </SelectedItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
