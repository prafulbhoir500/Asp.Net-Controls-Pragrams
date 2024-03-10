<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileUpload.aspx.cs" Inherits="AspControl.FileUpload.FileUpload" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"
    TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Assets/css/bootstrap.css" rel="stylesheet" />
</head>
<body class="overflow-x-hidden">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="row justify-content-center">
            <div class="col-6">
                <div class="card">
                    <div class="card-header">
                        <h1 class="text-center">File Upload
                        </h1>
                    </div>
                    <div class="card-body">
                        <label class="form-label">
                            Upload File
                        </label>

                        <asp:FileUpload ID="FileUpload1" CssClass="form-control w-50" runat="server" />
                        <asp:Button ID="btnUploadFile" runat="server" Text="Upload" OnClick="btnUploadFile_Click" />
                    </div>

                </div>


            </div>
            <div class="col-6">
                <div class="card">
                    <div class="card-header">
                        <h1 class="text-center">File Upload Ajax
                        </h1>
                    </div>
                    <div class="card-body">
                        <label class="form-label">
                            Upload File
                        </label>
                        <asp:AsyncFileUpload ID="AsyncFileUpload1" runat="server" OnUploadedComplete="AsyncFileUpload1_UploadedComplete" CssClass="form-control" />

                    </div>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
