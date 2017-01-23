<%@ Control Language="C#"
    AutoEventWireup="true"
    CodeBehind="ImageUserControl.ascx.cs"
    Inherits="WebFormsIntroduction.WebFormsClient.ViewControls.ImageUserControl" %>

<div class="form-group">
    <asp:TextBox runat="server" ID="ImageText"></asp:TextBox>
</div>
<div class="form-group">
    <img src="<%# Model.ImageUrl %>" />
</div>
<div class="form-group">
    <asp:Button CssClass="btn btn-primary" Text="Display Image" OnClick="DisplayImage_Click" runat="server" />
</div>
