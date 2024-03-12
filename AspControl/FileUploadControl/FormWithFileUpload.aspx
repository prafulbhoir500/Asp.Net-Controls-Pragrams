<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormWithFileUpload.aspx.cs" Inherits="AspControl.FileUploadControl.FormWithFileUpload" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"
    TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Assets/css/bootstrap.css" rel="stylesheet" />
</head>
<body class="container-fluid">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="d-flex justify-content-end">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
        </div>
        <div class="row justify-content-center">
            <div class="col-8">
                <div class="card">
                    <div class="card-body">
                        <div class="mb-3">
                            <label class="form-label">
                                Full Name
                            </label>
                            <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label class="form-label">
                                E-mail
                            </label>
                            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>

                        <div class="mb-3">
                            <label class="form-label">
                                Mobile No
                            </label>
                            <asp:TextBox ID="txtMobile" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>

                        <div class="mb-3">
                            <label class="form-label">
                                Address
                            </label>
                            <asp:TextBox ID="txtAdd" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>

                    </div>
                </div>
            </div>
        </div>

        <div class="card">
            <div class="card-header">
                <h1 class="text-center">Upload File
                </h1>
            </div>
            <div class="card-body">
                <asp:Repeater ID="rptAttachment" runat="server">
                    <ItemTemplate>
                        <label class="form-label"><%#Eval("AttachmentName") %></label>
                        <asp:HiddenField ID="AttachmentTypeID" runat="server" Value='<%#Eval("AttachmentTypeID") %>' />

                        <asp:AsyncFileUpload ID="AsyncFileUpload1" runat="server" OnUploadedComplete="AsyncFileUpload1_UploadedComplete" ClientIDMode="AutoID"  />

                        <asp:LinkButton ID="btnFile" runat="server" PostBackUrl='<%#Eval("AttachmentPath") %>'>view</asp:LinkButton>
                    </ItemTemplate>
                </asp:Repeater>


            </div>
        </div>
    </form>
</body>
</html>
