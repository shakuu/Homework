<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UserControls.WebClient.Default" %>

<%@ Register Src="~/UserControls/LinksUserControl.ascx" TagPrefix="uc" TagName="linkslist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Controls</title>
</head>
<body>
    <form id="form" runat="server">

        <div>
            <uc:linkslist FontColor="red" FontFace="'Verdana'" runat="server" />
        </div>

    </form>
</body>
</html>
