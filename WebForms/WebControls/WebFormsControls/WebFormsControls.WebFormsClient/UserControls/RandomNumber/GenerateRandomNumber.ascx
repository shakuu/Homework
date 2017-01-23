<%@ Control Language="C#"
    AutoEventWireup="true"
    CodeBehind="GenerateRandomNumber.ascx.cs"
    Inherits="WebFormsControls.WebFormsClient.UserControls.RandomNumber.GenerateRandomNumber" %>

<h3>Generated Value: <%# Model.RandomValue %></h3>
<div class="form-group">
    <asp:TextBox CssClass="form-control" ID="MinimumValue" runat="server"></asp:TextBox>
</div>
<div class="form-group">
    <asp:TextBox CssClass="form-control" ID="MaximumValue" runat="server"></asp:TextBox>
</div>
<div class="form-group">
    <asp:Button OnClick="OnButtonGenerateClick" runat="server" Text="Generate Random Number" />
</div>
