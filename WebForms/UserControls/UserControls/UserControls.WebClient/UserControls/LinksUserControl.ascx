<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="LinksUserControl.ascx.cs"
    Inherits="UserControls.WebClient.UserControls.LinksUserControl" %>

<section id="links">
    <asp:DataList runat="server" ID="LinksDataList">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li class="link-item">
                <asp:Label runat="server">
                    <a style="color:<%#: FontColor %>; font-family:<%#: FontFace %>" href="<%#: Eval("Url") %>"><%#: Eval("Title") %></a>
                </asp:Label>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:DataList>
</section>
