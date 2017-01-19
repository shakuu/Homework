<%@ Control Language="C#"
    AutoEventWireup="true"
    CodeBehind="LookupStudentControl.ascx.cs"
    Inherits="WebFormsTest.mvp.LookupStudentControl" %>
<div>
    <fieldset>
        <legend>Enter Student Id</legend>
        <asp:TextBox runat="server" ID="studentId" MaxLength="9" />
        <p>
            <asp:Button ID="Button1" runat="server" Text="Find By Id" OnClick="FindClick" />
            <asp:Button ID="Button2" runat="server" Text="Get All" OnClick="FindAll" />
        </p>
    </fieldset>
    <div>
        <asp:DetailsView ID="results" runat="server" DataSource="<%# Model.Students %>" />
    </div>
    <asp:GridView ID="GridView1" runat="server" DataSource="<%# Model.Students %>"></asp:GridView>
</div>
