<%@ Page
    Title="Login Cookie"
    MasterPageFile="~/Site.Master"
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="HelloCookieLogin.aspx.cs"
    Inherits="StateManagement.WebClient.HelloCookieLogin" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h1>Hello Cookie Login</h1>
    <div class="row">
        <div class="input-field col s6">
            <input runat="server" placeholder="Username" id="Username" type="text" class="validate">
            <label for="Username">Username</label>
        </div>
        <div class="input-field col s6">
            <input runat="server" id="Password" type="password" class="validate">
            <label for="password">Password</label>
        </div>
    </div>
    <asp:Button runat="server" Text="Submit" CssClass="btn waves-effect waves-light" OnClick="OnSubmit" />
</asp:Content>
