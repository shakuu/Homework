<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="TicTacToeUserControl.ascx.cs"
    Inherits="WebFormsControls.WebFormsClient.UserControls.TicTacToe.TicTacToeUserControl" %>

<div class="row">
    <asp:Button ID="_00" runat="server" Text="<%# this.Model.GameBoard[0][0] %>" OnClick="OnUserInput" />
    <asp:Button ID="_01" runat="server" Text="<%# this.Model.GameBoard[0][1] %>" OnClick="OnUserInput" />
    <asp:Button ID="_02" runat="server" Text="<%# this.Model.GameBoard[0][2] %>" OnClick="OnUserInput" />
</div>
<div class="row">
    <asp:Button ID="_10" runat="server" Text="<%# this.Model.GameBoard[1][0] %>" OnClick="OnUserInput" />
    <asp:Button ID="_11" runat="server" Text="<%# this.Model.GameBoard[1][1] %>" OnClick="OnUserInput" />
    <asp:Button ID="_12" runat="server" Text="<%# this.Model.GameBoard[1][2] %>" OnClick="OnUserInput" />
</div>
<div class="row">
    <asp:Button ID="_20" runat="server" Text="<%# this.Model.GameBoard[2][0] %>" OnClick="OnUserInput" />
    <asp:Button ID="_21" runat="server" Text="<%# this.Model.GameBoard[2][1] %>" OnClick="OnUserInput" />
    <asp:Button ID="_22" runat="server" Text="<%# this.Model.GameBoard[2][2] %>" OnClick="OnUserInput" />
</div>

<strong>Message: <%# this.Model.Message %></strong>