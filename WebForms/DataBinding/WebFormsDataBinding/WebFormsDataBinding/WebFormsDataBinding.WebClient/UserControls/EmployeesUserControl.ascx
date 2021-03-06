﻿<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="EmployeesUserControl.ascx.cs"
    Inherits="WebFormsDataBinding.WebClient.UserControls.EmployeesUserControl" %>

<div class="jumbotron">
    <asp:GridView ID="EmployeesGridView" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="FullName" HeaderText="Full Name" />
            <asp:HyperLinkField Text="Details" DataNavigateUrlFields="Id"
                DataNavigateUrlFormatString="~/EmployeeDetails?id={0}" />
        </Columns>
    </asp:GridView>
</div>
