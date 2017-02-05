<%@ Page
    Title="Todos"
    MasterPageFile="~/Site.Master"
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="Todos.aspx.cs"
    Inherits="DataSourceControls.WebClient.Todos" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="well">
        <h1>Todos</h1>
    </div>

    <div class="well">
        <asp:EntityDataSource
            ID="TodosDataSource" runat="server"
            DefaultContainerName="MoreTodosDbEntities"
            ConnectionString="name=MoreTodosDbEntities"
            EntitySetName="Todos"
            EnableFlattening="False"
            EnableUpdate="True"
            EnableInsert="True"
            EnableDelete="True"
            EntityTypeFilter="Todo">
        </asp:EntityDataSource>

        <asp:ListView
            ID="TodosListView" runat="server"
            DataSourceID="TodosDataSource"
            ItemType="DataSourceControls.MoreTodosManager.Todo"
            DataKeyNames="Id"
            InsertItemPosition="LastItem"
            OnDataBound="Todos_DataBound">
            <AlternatingItemTemplate>
                <li style="background-color: #FFFFFF; color: #284775;">Id:
                    <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                    <br />
                    Body:
                    <asp:Label ID="BodyLabel" runat="server" Text='<%# Eval("Body") %>' />
                    <br />
                    CategoryType:
                    <asp:Label ID="CategoryTypeLabel" runat="server" Text='<%# Eval("CategoryType") %>' />
                    <br />
                    Title:
                    <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                    <br />
                    LastChange:
                    <asp:Label ID="LastChangeLabel" runat="server" Text='<%# Eval("LastChange") %>' />
                    <br />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                </li>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <li style="background-color: #999999;">Id:
                    <asp:Label ID="IdLabel1" runat="server" Text='<%# Eval("Id") %>' />
                    <br />
                    Body:
                    <asp:TextBox ID="BodyTextBox" runat="server" Text='<%# Bind("Body") %>' />
                    <br />
                    CategoryType:
                    <asp:TextBox ID="CategoryTypeTextBox" runat="server" Text='<%# Bind("CategoryType") %>' />
                    <br />
                    Title:
                    <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
                    <br />
                    LastChange:
                    <asp:TextBox ID="LastChangeTextBox" runat="server" Text='<%# Bind("LastChange") %>' />
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
                    <%--Id:
                    <asp:TextBox ID="IdTextBox" runat="server" Text='<%# Bind("Id") %>' />
                    <br />--%>
                    Body:
                    <asp:TextBox ID="BodyTextBox" runat="server" Text='<%# Bind("Body") %>' />
                    <br />
                    CategoryType:
                    <asp:TextBox ID="CategoryTypeTextBox" runat="server" Text='<%# Bind("CategoryType") %>' />
                    <br />
                    Title:
                    <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
                    <br />
                    <%--LastChange:
                    <asp:TextBox ID="LastChangeTextBox" runat="server" Text='<%# Bind("LastChange") %>' />
                    <br />--%>
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                </li>
            </InsertItemTemplate>
            <ItemSeparatorTemplate>
                <br />
            </ItemSeparatorTemplate>
            <ItemTemplate>
                <li style="background-color: #E0FFFF; color: #333333;">Id:
                    <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                    <br />
                    Body:
                    <asp:Label ID="BodyLabel" runat="server" Text='<%# Eval("Body") %>' />
                    <br />
                    CategoryType:
                    <asp:Label ID="CategoryTypeLabel" runat="server" Text='<%# Eval("CategoryType") %>' />
                    <br />
                    Title:
                    <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                    <br />
                    LastChange:
                    <asp:Label ID="LastChangeLabel" runat="server" Text='<%# Eval("LastChange") %>' />
                    <br />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                </li>
            </ItemTemplate>
            <LayoutTemplate>
                <ul id="itemPlaceholderContainer" runat="server" style="font-family: Verdana, Arial, Helvetica, sans-serif;">
                    <li runat="server" id="itemPlaceholder" />
                </ul>
                <div style="text-align: center; background-color: #5D7B9D; font-family: Verdana, Arial, Helvetica, sans-serif; color: #FFFFFF;">
                    <asp:DataPager ID="DataPager1" runat="server">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                        </Fields>
                    </asp:DataPager>
                </div>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <li style="background-color: #E2DED6; font-weight: bold; color: #333333;">Id:
                    <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                    <br />
                    Body:
                    <asp:Label ID="BodyLabel" runat="server" Text='<%# Eval("Body") %>' />
                    <br />
                    CategoryType:
                    <asp:Label ID="CategoryTypeLabel" runat="server" Text='<%# Eval("CategoryType") %>' />
                    <br />
                    Title:
                    <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                    <br />
                    LastChange:
                    <asp:Label ID="LastChangeLabel" runat="server" Text='<%# Eval("LastChange") %>' />
                    <br />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                </li>
            </SelectedItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
