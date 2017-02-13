<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Validation.WebClient.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Validation</title>

    <!--Import materialize.css-->
    <link type="text/css" rel="stylesheet" href="<%= ResolveUrl("~/Content/materialize/css/materialize.min.css") %>" media="screen,projection" />

    <!--Let browser know website is optimized for mobile-->
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
</head>
<body>
    <form id="form" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>

        <div>
        </div>
    </form>

    <!--Import jQuery before materialize.js-->
    <script type="text/javascript" src="https://code.jquery.com/jquery-2.1.1.min.js"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/Scripts/materialize/materialize.min.js") %>"></script>
</body>
</html>
