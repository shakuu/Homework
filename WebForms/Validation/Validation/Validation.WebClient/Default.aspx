<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Validation.WebClient.Default" UnobtrusiveValidationMode="None" %>

<%@ Register Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxtoolkit" %>

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

        <div class="row">
            <div class="col s12">
                <div class="row">
                    <div class="input-field col s6">
                        <asp:TextBox ID="Username" CssClass="validate" runat="server"></asp:TextBox>
                        <label for="Username">Username</label>
                    </div>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Username" ErrorMessage="Username is Required." ValidationGroup="Logon" Display="None"></asp:RequiredFieldValidator>
                </div>

                <div class="row">
                    <div class="input-field col s6">
                        <asp:TextBox ID="Password" TextMode="Password" CssClass="validate" runat="server"></asp:TextBox>
                        <label for="Password">Password</label>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" ErrorMessage="Password is Required." ValidationGroup="Logon" Display="None"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="row">
                    <div class="input-field col s6">
                        <asp:TextBox ID="RepeatPassword" TextMode="Password" CssClass="validate" runat="server"></asp:TextBox>
                        <label for="RepeatPassword">Repeat Password</label>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="RepeatPassword" ErrorMessage="Matching passowrd is Required." ValidationGroup="Logon" Display="None"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ControlToValidate="RepeatPassword" ControlToCompare="Password" runat="server" ValidationGroup="Logon" ErrorMessage="Passwords must match." Display="None"></asp:CompareValidator>
                    </div>
                </div>

                <div class="row">
                    <asp:ValidationSummary runat="server" ValidationGroup="Logon" DisplayMode="BulletList" BorderColor="Salmon" BorderStyle="Solid" BorderWidth="5px" />
                </div>

                <div class="row">
                    <div class="input-field col s6">
                        <asp:TextBox ID="FirstName" CssClass="validate" runat="server"></asp:TextBox>
                        <label for="FirstName">First Name</label>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstName" ErrorMessage="First Name is Required." ValidationGroup="Personal" Display="None"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="row">
                    <div class="input-field col s6">
                        <asp:TextBox ID="LastName" CssClass="validate" runat="server"></asp:TextBox>
                        <label for="LastName">Last Name</label>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="LastName" ErrorMessage="Last Name is Required." ValidationGroup="Personal" Display="None"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="row">
                    <div class="input-field col s6">
                        <asp:TextBox ID="Age" TextMode="Number" CssClass="validate" runat="server"></asp:TextBox>
                        <label for="Age">Age</label>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Age" ErrorMessage="Age is Required." ValidationGroup="Personal" Display="None"></asp:RequiredFieldValidator>
                        <asp:RangeValidator runat="server" ControlToValidate="Age" MinimumValue="18" MaximumValue="81" ErrorMessage="Valid age is between 18 and 81." ValidationGroup="Personal" Display="None"></asp:RangeValidator>
                    </div>
                </div>

                <div class="row">
                    <asp:ValidationSummary runat="server" ValidationGroup="Personal" DisplayMode="BulletList" BorderColor="Salmon" BorderStyle="Solid" BorderWidth="5px" />
                </div>

                <div class="row">
                    <div class="input-field col s6">
                        <asp:TextBox ID="Email" TextMode="Email" CssClass="validate" runat="server"></asp:TextBox>
                        <label for="Email">Email</label>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" ErrorMessage="Email is Required." ValidationGroup="Address" Display="None"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator
                            runat="server" Display="None" ValidationGroup="Address"
                            ErrorMessage="Email address is incorrect!" ControlToValidate="Email"
                            ValidationExpression="[a-zA-Z][a-zA-Z0-9\-\.]*[a-zA-Z]@[a-zA-Z][a-zA-Z0-9\-\.]+[a-zA-Z]+\.[a-zA-Z]{2,4}">
                        </asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="row">
                    <div class="input-field col s6">
                        <asp:TextBox ID="Phone" CssClass="validate" runat="server"></asp:TextBox>
                        <label for="Phone">Phone</label>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Phone" ErrorMessage="Phone is Required." ValidationGroup="Address" Display="None"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator
                            runat="server" Display="None" ValidationGroup="Address"
                            ErrorMessage="Phone format: ###-###-##-##" ControlToValidate="Phone"
                            ValidationExpression="^[0-9]{3}-[0-9]{3}-[0-9]{2}-[0-9]{2}$">
                        </asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="row">
                    <div class="input-field col s6">
                        <asp:TextBox ID="Address" CssClass="validate" runat="server"></asp:TextBox>
                        <label for="Address">Address</label>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Address" ErrorMessage="Address is Required" ValidationGroup="Address" Display="None"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="row">
                    <asp:ValidationSummary runat="server" ValidationGroup="Address" DisplayMode="BulletList" BorderColor="Salmon" BorderStyle="Solid" BorderWidth="5px" />
                </div>

                <div class="row">
                    <asp:UpdatePanel runat="server" ChildrenAsTriggers="true" UpdateMode="Always" >
                        <ContentTemplate>
                            <div class="input-field col s6">
                                <asp:RadioButtonList ID="GenderSelect" AutoPostBack="true" OnSelectedIndexChanged="OnGenderSelectionChanged" runat="server">
                                    <asp:ListItem Text="Male"></asp:ListItem>
                                    <asp:ListItem Text="Female"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div class="input-field col s6">
                                <asp:RadioButtonList ID="Cars" Visible="false" runat="server">
                                    <asp:ListItem Text="BWM"></asp:ListItem>
                                    <asp:ListItem Text="Audi"></asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:RadioButtonList ID="Coffee" Visible="false" runat="server">
                                    <asp:ListItem Text="Black"></asp:ListItem>
                                    <asp:ListItem Text="Frappuccino"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="GenderSelect" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>

                <div class="row">
                    <p>
                        <asp:CheckBox ID="Agree" runat="server" />
                        <label for="Agree">I Agree</label>
                    </p>
                </div>

                <div class="row">
                    <button class="btn waves-effect waves-light" type="submit" name="action">
                        Submit
                    </button>
                </div>
            </div>
        </div>
    </form>

    <!--Import jQuery before materialize.js-->
    <script type="text/javascript" src="https://code.jquery.com/jquery-2.1.1.min.js"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/Scripts/materialize/materialize.min.js") %>"></script>
</body>
</html>
