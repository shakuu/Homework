<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="CarsUserControl.ascx.cs"
    Inherits="WebFormsDataBinding.WebClient.UserControls.CarsUserControl" %>

<div class="jumbotron">
    <asp:DropDownList ID="Makes" runat="server" AutoPostBack="true" OnSelectedIndexChanged="OnChangeSelection"></asp:DropDownList>
    <asp:DropDownList ID="Models" runat="server" AutoPostBack="true" OnSelectedIndexChanged="OnChangeSelection"></asp:DropDownList>
    <asp:CheckBoxList ID="Options" runat="server" AutoPostBack="true" OnSelectedIndexChanged="OnChangeSelection"></asp:CheckBoxList>
</div>

<div class="jumbotron">
    <asp:GridView ID="MatchingCars" runat="server"></asp:GridView>
</div>
