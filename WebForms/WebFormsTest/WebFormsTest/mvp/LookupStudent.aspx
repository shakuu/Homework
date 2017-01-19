<%@ Page Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="LookupStudent.aspx.cs"
    Inherits="WebFormsTest.mvp.LookupStudent" %>

<%@ Register Src="~/mvp/LookupStudentControl.ascx" TagPrefix="uc" TagName="LookupStudent" %>
<%--<%@ Register Src="/StudentSubjects.ascx" TagPrefix="uc1" TagName="StudentSubjects" %>--%>
<asp:Content ContentPlaceHolderID="content" runat="server">
    <h1>Lookup Student</h1>
    <uc:LookupStudent runat="server" />
    <h1>Student Subjects</h1>
    <%--<uc1:StudentSubjects  runat="server" />--%>
</asp:Content>
