<%@ Page
    Title="HelloCookie"
    MasterPageFile="~/Site.Master"
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="HelloCookie.aspx.cs"
    Inherits="StateManagement.WebClient.HelloCookie" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h1>Hello Cookie</h1>
    <h2 runat="server" id="CookieContent"></h2>
</asp:Content>
