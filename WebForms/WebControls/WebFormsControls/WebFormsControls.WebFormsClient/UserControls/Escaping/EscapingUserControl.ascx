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
<br />
<strong>Label (unescaped):
</strong>
<br />
<asp:Label ID="LabelEnteredText" runat="server" />
<hr />
<br />
<strong>HTML escaped literal:
</strong>
<br />
<asp:Literal ID="LiteralEnteredText" runat="server" Mode="Encode" />
<hr />
<br />
<strong>&lt;%: some text %&gt;:</strong><br />
<%: this.Model.EscapedText %>

<textarea><%: Model.EscapedText %></textarea>
