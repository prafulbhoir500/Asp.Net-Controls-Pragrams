<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileUploadInRepeaterControl.aspx.cs" Inherits="AspControl.FileUploadControl.FileUploadInRepeaterControl" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"
    TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Assets/css/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript">
        function uploadComplete(sender, args) {
            debugger;
            // Get the reference to the AsyncFileUpload control
            var asyncFileUpload = document.getElementById(sender.id);

            // Check if asyncFileUpload is not null and its parentNode is not null
            if (asyncFileUpload && asyncFileUpload.parentNode) {
                // Traverse up the DOM to find the parent row element
                var row = asyncFileUpload.parentNode.parentNode; // Assuming two levels up from AsyncFileUpload is the row

                // Find the label within the row using querySelector
                var lblFileName = row.querySelector("label[id$='_lblFileName']");

                // Update the label text with the uploaded file name
                if (lblFileName) {
                    lblFileName.innerText = args.get_fileName();
                }
            }
        }


    </script>

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

                        <asp:Repeater ID="rptAttachment1" runat="server">
                            <ItemTemplate>
                                <div class="row">
                                    <div class="col-6">
                                        <label class="form-label"><%#Eval("AttachmentName") %></label>
                                        <asp:HiddenField ID="AttachmentTypeID" runat="server" Value='<%#Eval("AttachmentID") %>' />
                                        <asp:FileUpload ID="FileUpload1" CssClass="form-control w-50" runat="server" />
                                    </div>
                                    <div class="col-6">
                                        <asp:Label ID="lblFileName" runat="server" Text="Label" ClientIDMode="Static"></asp:Label>
                                    </div>
                                </div>

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
                                <div class="row">
                                    <div class="col-6">
                                        <label class="form-label"><%#Eval("AttachmentName") %></label>
                                        <asp:HiddenField ID="AttachmentTypeID" runat="server" Value='<%#Eval("AttachmentID") %>' />

                                        <asp:AsyncFileUpload ID="AsyncFileUpload1" runat="server" OnUploadedComplete="AsyncFileUpload1_UploadedComplete" OnClientUploadComplete="uploadComplete" ClientIDMode="AutoID" />
                                    </div>
                                    <div class="col-6">
                                        <asp:Label ID="lblFileName" runat="server" Text="Label" ClientIDMode="Static"></asp:Label>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>


                    </div>
                </div>
            </div>

            <div class="col-6">
                <div class="card">
                    <div class="card-header">
                        <h1 class="text-center">File Upload
                        </h1>
                    </div>
                    <div class="card-body">

                        <asp:Repeater ID="rptAttachment2" runat="server">
                            <ItemTemplate>


                                <div class="row">
                                    <div class="col-4">
                                        <label class="form-label"><%#Eval("AttachmentName") %></label>
                                        <asp:HiddenField ID="AttachmentTypeID" runat="server" Value='<%#Eval("AttachmentID") %>' />
                                        <asp:FileUpload ID="FileUpload1" CssClass="form-control" runat="server" />
                                    </div>
                                    <div class="col-4">
                                        <asp:Label ID="lblFileName" runat="server" Text="Label" ClientIDMode="Static"></asp:Label>
                                    </div>
                                    <div class="col-4">
                                        <asp:Button ID="btnFileUpload" runat="server" Text="Upload" CssClass="btn btn-warning" OnClick="btnFileUpload_Click" />
                                    </div>
                                </div>


                            </ItemTemplate>
                        </asp:Repeater>
                    </div>

                </div>


            </div>

        </div>
    </form>
</body>
</html>
