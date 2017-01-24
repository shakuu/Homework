<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="CalculatorUserControl.ascx.cs"
    Inherits="WebFormsControls.WebFormsClient.UserControls.Calculator.CalculatorUserControl" %>

<div id="calculator" class="container">
    <div class="row">
        <input class="text-right" type="text" value="<%# this.Model.DisplayValue %>" disabled="disabled" />
    </div>
    <div class="row">
        <asp:Button ID="ButtonOne" runat="server" OnClick="OnButtonClick" Text="1" />
        <asp:Button ID="Button1" runat="server" OnClick="OnButtonClick" Text="2" />
        <asp:Button ID="Button2" runat="server" OnClick="OnButtonClick" Text="3" />
        <asp:Button ID="Button3" runat="server" OnClick="OnButtonClick" Text="+" />
    </div>
    <div class="row">
        <asp:Button ID="Button4" runat="server" OnClick="OnButtonClick" Text="4" />
        <asp:Button ID="Button5" runat="server" OnClick="OnButtonClick" Text="5" />
        <asp:Button ID="Button6" runat="server" OnClick="OnButtonClick" Text="6" />
        <asp:Button ID="Button7" runat="server" OnClick="OnButtonClick" Text="-" />
    </div>
    <div class="row">
        <asp:Button ID="Button8" runat="server" OnClick="OnButtonClick" Text="7" />
        <asp:Button ID="Button9" runat="server" OnClick="OnButtonClick" Text="8" />
        <asp:Button ID="Button10" runat="server" OnClick="OnButtonClick" Text="9" />
        <asp:Button ID="Button11" runat="server" OnClick="OnButtonClick" Text="X" />
    </div>
    <div class="row">
        <asp:Button ID="Button12" runat="server" OnClick="OnButtonClick" Text="0" />
        <asp:Button ID="Button13" runat="server" OnClick="OnButtonClick" Text="Clear" />
        <asp:Button ID="Button14" runat="server" OnClick="OnButtonClick" Text="/" />
        <asp:Button ID="Button15" runat="server" OnClick="OnButtonClick" Text="Sqrt" />
    </div>
    <div class="row">
        <asp:Button ID="Button16" runat="server" OnClick="OnButtonClick" Text="=" />
    </div>
</div>
