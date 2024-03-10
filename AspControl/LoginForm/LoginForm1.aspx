<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm1.aspx.cs" Inherits="AspControl.LoginForm.LoginForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Assets/css/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <main class="container-fluid">
            <div class="row justify-content-center vh-100 align-content-center">
                <div class="col-5">
                    <div class="card">
                        <div class="card-header">
                            <h1 class="text-center">User Login</h1>
                        </div>
                        <div class="card-body">
                            <div class="mb-3">
                                <label class="form-label">E-mail</label>
                                <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <div class="mb-3">
                                <label class="form-label">Password</label>
                                <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <div class="mb-3">
                                <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-success px-3" Text="Login" OnClick="btnLogin_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </main>
    </form>
</body>
</html>
