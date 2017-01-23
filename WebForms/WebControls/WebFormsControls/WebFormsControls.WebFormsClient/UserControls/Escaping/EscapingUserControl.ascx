<%@ Control
    ValidateRequestMode="Disabled"
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="EscapingUserControl.ascx.cs"
    Inherits="WebFormsControls.WebFormsClient.UserControls.Escaping.EscapingUserControl" %>

<div class="form-group">
    <asp:TextBox CssClass="form-control" ID="TextToEscape" runat="server"></asp:TextBox>
</div>

<div class="form-group">
    <asp:Button OnClick="OnButtonEscapeClick" runat="server" Text="Escape Text" />
</div>

<asp:Label ID="LabelEnteredText" runat="server" />
