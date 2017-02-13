<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AJAX.EmployeesWebClient.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employees</title>
</head>
<body>
    <form id="form" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>

        <asp:EntityDataSource
            ID="EmployeesEntityDataSource" runat="server"
            DefaultContainerName="NorthwindEntities"
            ConnectionString="name=NorthwindEntities"
            EntitySetName="Employees"
            EnableFlattening="false">
        </asp:EntityDataSource>

        <div>

            <asp:UpdatePanel ID="EmployeesUpdatePanel" runat="server">
                <ContentTemplate>
                    <asp:GridView
                        ID="EmployeesGridView" runat="server"
                        DataSourceID="EmployeesEntityDataSource"
                        AutoGenerateColumns="false"
                        AutoGenerateSelectButton="false"
                        DataKeyNames="EmployeeID"
                        OnSelectedIndexChanged="OnEmployeeSelect">
                        <Columns>
                            <asp:CommandField ShowSelectButton="true" />
                            <asp:BoundField HeaderText="Title" DataField="Title" />
                            <asp:BoundField HeaderText="First Name" DataField="FirstName" />
                            <asp:BoundField HeaderText="Last Name" DataField="LastName" />
                        </Columns>
                    </asp:GridView>

                    <asp:UpdateProgress runat="server" AssociatedUpdatePanelID="EmployeesUpdatePanel">
                        <ProgressTemplate>
                            <h1 style="color: red;">LOADING DATA...</h1>
                        </ProgressTemplate>
                    </asp:UpdateProgress>

                    <asp:GridView ID="EmployeeOrdersGridView" runat="server">
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
