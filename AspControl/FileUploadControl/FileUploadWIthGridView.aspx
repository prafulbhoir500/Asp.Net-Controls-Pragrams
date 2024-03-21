<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileUploadWIthGridView.aspx.cs" Inherits="AspControl.FileUploadControl.FileUploadWIthGridView" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"
    TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Assets/css/bootstrap.css" rel="stylesheet" />
    <script>
        function uploadComplete(sender, args) {
            debugger;
            // Get the reference to the AsyncFileUpload control
            var asyncFileUpload = document.getElementById(sender.id);

            // Find the corresponding Label in the same Repeater item
            var lblFileName = getParentRepeaterItem(asyncFileUpload).querySelector(".col-6:last-child .form-label");

            // Display the file name
            lblFileName.textContent = args.get_fileName();
        }

        function getParentRepeaterItem(element) {
            // Traverse up the DOM to find the parent repeater item
            while (element && !element.classList.contains("repeater-item")) {
                element = element.parentNode;
            }
            return element;
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div>
            <div class="card-body">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="Attachment Name">
                <ItemTemplate>
                    <asp:Label ID="lblAttachmentName" runat="server" Text='<%# Eval("AttachmentName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="File Upload">
                <ItemTemplate>
                    <asp:HiddenField ID="AttachmentTypeID" runat="server" Value='<%# Eval("AttachmentID") %>' />
                    <asp:AsyncFileUpload ID="AsyncFileUpload1" runat="server" OnUploadedComplete="AsyncFileUpload1_UploadedComplete" OnClientUploadComplete="uploadComplete" ClientIDMode="AutoID" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Uploaded File">
                <ItemTemplate>
                    <asp:Label ID="lblFileName" runat="server" Text='<%# Eval("TabName").ToString()=="" ? "No File Available" : Eval("TabName").ToString() %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>

        </div>
    </form>
</body>
</html>
