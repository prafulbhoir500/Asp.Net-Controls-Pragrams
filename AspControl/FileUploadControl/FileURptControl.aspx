<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileURptControl.aspx.cs" Inherits="AspControl.FileUpload.FileUploadInRepeaterControl" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"
    TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Assets/css/bootstrap.css" rel="stylesheet" />
</head>
<body>
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

                        <asp:Repeater ID="rptAttachment1" runat="server">
                            <ItemTemplate>
                                <label class="form-label"><%#Eval("AttachmentName") %></label>

                                <asp:FileUpload ID="FileUpload1" CssClass="form-control w-50" runat="server" />
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Button ID="btnUploadFile" runat="server" Text="Upload" CssClass="btn btn-warning" OnClick="btnUploadFile_Click" />
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
                        <asp:Repeater ID="rptAttachment" runat="server">
                            <ItemTemplate>
                                <label class="form-label"><%#Eval("AttachmentName") %></label>
                                <asp:AsyncFileUpload ID="AsyncFileUpload1" runat="server" />
                            </ItemTemplate>
                        </asp:Repeater>


                    </div>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
