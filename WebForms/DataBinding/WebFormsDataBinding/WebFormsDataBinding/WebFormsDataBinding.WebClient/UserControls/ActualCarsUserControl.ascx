﻿<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="ActualCarsUserControl.ascx.cs"
    Inherits="WebFormsDataBinding.WebClient.UserControls.ActualCarsUserControl" %>


<div class="jumbotron">
    <asp:DropDownList ID="Makes" runat="server" AutoPostBack="true" OnSelectedIndexChanged="OnMakeSelectionChanged"></asp:DropDownList>
    <asp:DropDownList ID="Models" runat="server"></asp:DropDownList>
    <asp:CheckBoxList ID="Options" runat="server"></asp:CheckBoxList>
    <asp:Button CssClass="btn btn-success" runat="server" OnClick="OnCreateCarFormSubmit" />
</div>

<div class="jumbotron">
    <asp:DetailsView ID="CreatedCar" runat="server"></asp:DetailsView>
</div>
