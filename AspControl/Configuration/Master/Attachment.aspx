<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Attachment.aspx.cs" Inherits="AspControl.Configuration.Master.Attachment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Assets/css/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="row justify-content-center">
            <div class="col-6">
                <div class="card">
                    <div class="card-header">
                        <h1 class="text-center">File Upload
                        </h1>
                    </div>
                    <div class="card-body">
                        <div class="mb-3">
                            <label class="form-label">Tab Name</label>
                            <asp:TextBox ID="txtTabName" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>

                        <div class="mb-3">
                            <label class="form-label">Attachment Name</label>
                            <asp:TextBox ID="txtAttachmentName" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <asp:CheckBox ID="chkIsActive" runat="server" Checked="true" />
                        </div>

                        <div class="mb-3">
                            <asp:Button ID="btnSave" runat="server" SkinID="btn-Save" OnClick="btnSave_Click" />
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </form>
</body>
</html>
