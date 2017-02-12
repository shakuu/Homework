<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FileUpload.WebClient.Default" UnobtrusiveValidationMode="None" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>File Upload</title>

    <!--Import materialize.css-->
    <link type="text/css" rel="stylesheet" href="<%= ResolveUrl("~/Content/materialize/css/materialize.min.css") %>" media="screen,projection" />

    <!--Let browser know website is optimized for mobile-->
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server">
        </asp:ScriptManager>

        <div class="well">
            <h1>File Upload</h1>
        </div>
        <section id="file-upload">

            <asp:UpdateProgress AssociatedUpdatePanelID="FileUploadUpdatePanel" runat="server" DynamicLayout="false">
                <ProgressTemplate>
                    Uploading Files...
                </ProgressTemplate>
            </asp:UpdateProgress>

            <asp:UpdatePanel ID="FileUploadUpdatePanel" runat="server">
                <ContentTemplate>
                    <asp:FileUpload ID="ZipFileUpload" runat="server" />
                    <asp:Button ID="UploadButton" runat="server" CssClass="waves-effect waves-light btn" Text="Upload File" OnClick="OnUpload" />
                    <asp:RegularExpressionValidator
                        ID="RegularExpressionValidator1"
                        runat="server"
                        ErrorMessage="Only zip file is allowed!"
                        ValidationExpression="^.+(.zip|.ZIP)$"
                        ControlToValidate="ZipFileUpload">
                    </asp:RegularExpressionValidator>
                    <h3 id="FilesCount" runat="server"></h3>
                    <asp:Repeater ID="UploadedFiles" runat="server">
                        <ItemTemplate>
                            <div class="file">
                                <h3><%#: Eval("FileName") %></h3>
                                <p><%#: Eval("Content") %></p>
                            </div>
                            <hr />
                        </ItemTemplate>
                    </asp:Repeater>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="UploadButton" />
                </Triggers>
            </asp:UpdatePanel>

        </section>
    </form>

    <!--Import jQuery before materialize.js-->
    <script type="text/javascript" src="https://code.jquery.com/jquery-2.1.1.min.js"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/Scripts/materialize/materialize.min.js") %>"></script>
</body>
</html>
