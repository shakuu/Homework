<%@ Page
    MasterPageFile="~/Site.Master"
    Title="StudentRegistration"
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="StudentRegistration.aspx.cs"
    Inherits="WebFormsControls.WebFormsClient.StudentRegistration" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Task 3. Students and Courses</h1>
    </div>

    <div class="jumbotron">
        <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
        <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
        <asp:TextBox ID="FacultyNumber" TextMode="Number" runat="server"></asp:TextBox>
        <asp:DropDownList ID="University" runat="server">
            <asp:ListItem Text="Sofia University" Value="0"></asp:ListItem>
            <asp:ListItem Text="Varna University" Value="1"></asp:ListItem>
            <asp:ListItem Text="Kaspichan University" Value="2"></asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="Specialty" runat="server">
            <asp:ListItem Text="Math" Value="0"></asp:ListItem>
            <asp:ListItem Text="Physics" Value="1"></asp:ListItem>
            <asp:ListItem Text="History" Value="2"></asp:ListItem>
        </asp:DropDownList>
        <asp:ListBox ID="Courses" SelectionMode="Multiple" runat="server">
            <asp:ListItem Text="Math 101" Value="0"></asp:ListItem>
            <asp:ListItem Text="Physics 101" Value="1"></asp:ListItem>
            <asp:ListItem Text="History 101" Value="2"></asp:ListItem>
        </asp:ListBox>
        <asp:Button Text="Submit" runat="server" OnClick="OnSubmit" />
    </div>
</asp:Content>

