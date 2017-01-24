<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="CalculatorUserControl.ascx.cs"
    Inherits="WebFormsControls.WebFormsClient.UserControls.Calculator.CalculatorUserControl" %>

<div id="calculator">
    <div class="row">
        <section class="container col-xs-2"></section>
        <section class="container col-xs-8">
            <div class="row form-group">
                <input class="text-right form-control col-xs-12" type="text" value="<%# this.Model.DisplayValue %>" disabled="disabled" />
            </div>
            <div class="row form-group">
                <asp:Button class="btn btn-default col-xs-3" ID="ButtonOne" runat="server" OnClick="OnButtonClick" Text="1" />
                <asp:Button class="btn btn-default col-xs-3" ID="Button1" runat="server" OnClick="OnButtonClick" Text="2" />
                <asp:Button class="btn btn-default col-xs-3" ID="Button2" runat="server" OnClick="OnButtonClick" Text="3" />
                <asp:Button class="btn btn-default col-xs-3" ID="Button3" runat="server" OnClick="OnButtonClick" Text="+" />
            </div>
            <div class="row form-group">
                <asp:Button class="btn btn-default col-xs-3" ID="Button4" runat="server" OnClick="OnButtonClick" Text="4" />
                <asp:Button class="btn btn-default col-xs-3" ID="Button5" runat="server" OnClick="OnButtonClick" Text="5" />
                <asp:Button class="btn btn-default col-xs-3" ID="Button6" runat="server" OnClick="OnButtonClick" Text="6" />
                <asp:Button class="btn btn-default col-xs-3" ID="Button7" runat="server" OnClick="OnButtonClick" Text="-" />
            </div>
            <div class="row form-group">
                <asp:Button class="btn btn-default col-xs-3" ID="Button8" runat="server" OnClick="OnButtonClick" Text="7" />
                <asp:Button class="btn btn-default col-xs-3" ID="Button9" runat="server" OnClick="OnButtonClick" Text="8" />
                <asp:Button class="btn btn-default col-xs-3" ID="Button10" runat="server" OnClick="OnButtonClick" Text="9" />
                <asp:Button class="btn btn-default col-xs-3" ID="Button11" runat="server" OnClick="OnButtonClick" Text="X" />
            </div>
            <div class="row form-group">
                <asp:Button class="btn btn-default col-xs-3" ID="Button12" runat="server" OnClick="OnButtonClick" Text="0" />
                <asp:Button class="btn btn-default col-xs-3" ID="Button13" runat="server" OnClick="OnButtonClick" Text="Clear" />
                <asp:Button class="btn btn-default col-xs-3" ID="Button14" runat="server" OnClick="OnButtonClick" Text="/" />
                <asp:Button class="btn btn-default col-xs-3" ID="Button15" runat="server" OnClick="OnButtonClick" Text="Sqrt" />
            </div>
            <div class="row form-group">
                <div class="col-xs-3"></div>
                <asp:Button class="btn btn-default col-xs-6" ID="Button16" runat="server" OnClick="OnButtonClick" Text="=" />
            </div>
        </section>
    </div>
</div>
