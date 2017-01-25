<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="TicTacToeUserControl.ascx.cs"
    Inherits="WebFormsControls.WebFormsClient.UserControls.TicTacToe.TicTacToeUserControl" %>

<div class="row">
    <asp:Button ID="_00" runat="server" Text="<%# this.Model.GameBoard[0][0] %>" OnClick="OnUserInput"/>
    <asp:Button ID="_01" runat="server" Text="<%# this.Model.GameBoard[0][1] %>" OnClick="OnUserInput"/>
    <asp:Button ID="_02" runat="server" Text="<%# this.Model.GameBoard[0][2] %>" OnClick="OnUserInput"/>
</div>

<strong>Message: <%# this.Model.Message %></strong>