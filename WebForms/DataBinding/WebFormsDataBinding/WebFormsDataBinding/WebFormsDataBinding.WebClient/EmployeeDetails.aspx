﻿<%@ Page
    MasterPageFile="~/Site.Master"
    Title="Employee Details"
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="EmployeeDetails.aspx.cs"
    Inherits="WebFormsDataBinding.WebClient.EmployeeDetails" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <a id="ButtonBack" runat="server" class="btn btn-default" href="/Employees"><p>Back</p></a>

    <div class="jumbotron">
        <asp:DetailsView ID="EmployeeDetailsView" runat="server"></asp:DetailsView>
    </div>
</asp:Content>
