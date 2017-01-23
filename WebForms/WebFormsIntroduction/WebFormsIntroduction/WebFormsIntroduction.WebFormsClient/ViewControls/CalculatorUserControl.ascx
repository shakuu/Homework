<%@ Control Language="C#"
    AutoEventWireup="true"
    CodeBehind="CalculatorUserControl.ascx.cs"
    Inherits="WebFormsIntroduction.WebFormsClient.ViewControls.CalculatorUserControl" %>

<div class="form-group">
    <asp:TextBox CssClass="form-control" ID="ValueA" runat="server"></asp:TextBox>
</div>
<div class="form-group">
    <asp:TextBox CssClass="form-control" ID="ValueB" runat="server"></asp:TextBox>
</div>
<div class="form-group">
    <strong>
        <asp:Label CssClass="from-control" runat="server">Result: <%# Model.Result %></asp:Label>
    </strong>
</div>
<div class="form-group">
    <asp:Button CssClass="btn btn-primary" Text="Sum" OnClick="Sum_Click" runat="server" />
</div>
