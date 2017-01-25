<%@ Page
    MasterPageFile="~/Site.Master"
    Title="TicTacToe"
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="TicTacToe.aspx.cs"
    Inherits="WebFormsControls.WebFormsClient.TicTacToe" %>

<%@ Register Src="~/UserControls/TicTacToe/TicTacToeUserControl.ascx" TagPrefix="uc" TagName="tictactoe" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Task 4. Tic Tac Toe</h1>
    </div>

    <div class="jumbotron">
        <uc:tictactoe runat="server" />
    </div>
</asp:Content>
