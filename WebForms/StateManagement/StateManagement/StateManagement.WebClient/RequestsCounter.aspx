<%@ Page MasterPageFile="~/Site.Master" Title="RequestsCount" Language="C#" AutoEventWireup="true" CodeBehind="RequestsCounter.aspx.cs" Inherits="StateManagement.WebClient.RequestsCounter" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <section id="count-application-state">
        <h1>Count App State</h1>
        <h2>Count: <%= Application["RequestsCount"] %></h2>
    </section>
</asp:Content>
