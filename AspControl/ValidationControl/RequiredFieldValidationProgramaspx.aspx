<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequiredFieldValidationProgramaspx.aspx.cs" Inherits="AspControl.ValidationControl.RequiredFieldValidationProgramaspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Assets/css/bootstrap.css" rel="stylesheet" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
</head>
<body>
    <form id="loginForm" runat="server">
        <div class="container mt-5">
            <h2 class="mb-4">Login</h2>
            <div class="mb-3">
                <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail" CssClass="form-label" Text="Email"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" ValidationGroup="LoginGroup"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required" Display="Dynamic" ValidationGroup="LoginGroup" CssClass="invalid-feedback"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required" Display="Dynamic" ValidationGroup="OtpLoginGroup" CssClass="invalid-feedback"></asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword" CssClass="form-label" Text="Password"></asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" ValidationGroup="LoginGroup"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required" Display="Dynamic" ValidationGroup="LoginGroup" CssClass="invalid-feedback"></asp:RequiredFieldValidator>
            </div>
            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary" ValidationGroup="LoginGroup" OnClick="btnLogin_Click" />
            <asp:Button ID="btnOtpLogin" runat="server" Text="OTP Login" CssClass="btn btn-secondary" CausesValidation="false" ValidationGroup="OtpLoginGroup" OnClick="btnOtpLogin_Click" />
        </div>
    </form>

   
</body>
</html>
