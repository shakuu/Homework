<%@ Page
    MasterPageFile="~/Site.Master"
    Title="Trees"
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="Trees.aspx.cs"
    Inherits="WebFormsDataBinding.WebClient.Trees" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <asp:TreeView ID="MyTree" runat="server" DataSourceID="BookstoreXmlDataSource">
    </asp:TreeView>
    <asp:XmlDataSource ID="BookstoreXmlDataSource" runat="server" DataFile="~/Bookstore.xml"></asp:XmlDataSource>
</asp:Content>
