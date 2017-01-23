<%@ Control Language="C#"
    AutoEventWireup="true"
    CodeBehind="CalculatorUserControl.ascx.cs"
    Inherits="WebFormsIntroduction.WebFormsClient.ViewControls.CalculatorUserControl" %>

<asp:TextBox ID="ValueA" runat="server"></asp:TextBox>
<asp:TextBox ID="ValueB" runat="server"></asp:TextBox>
<asp:Label runat="server">Result: <%# Model.Result %></asp:Label>
<asp:Button Text="Sum" OnClick="Sum_Click" runat="server" />