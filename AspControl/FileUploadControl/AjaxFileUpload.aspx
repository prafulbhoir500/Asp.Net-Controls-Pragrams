<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxFileUpload.aspx.cs" Inherits="AspControl.FileUploadControl.AjaxFileUpload" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"
    TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Assets/css/bootstrap.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
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
            //location.reload();
        }
        function BindRepeater() {
            debugger;
            // Call the server-side method to rebind the Repeater
            PageMethods.BindRepeaterOnUpload(onSuccess, onFailure);
        }

        function onSuccess(response) {
            // If the binding operation is successful, you can handle any additional logic here
        }

        function onFailure(error) {
            // If the binding operation fails, you can handle the error here
            alert("Failed to bind repeater: " + error.get_message());
        }

            //__doPostBack('<%= UpdatePanel1.ClientID %>', '');
    </script>
</head>
<body class="container">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>

        <div class="row">

            <div class="col-5">
                <div class="mt-5">
                    <h2 class="mb-4">Registration Form</h2>
                    <div class="row mb-3">
                        <div class="col-6">

                            <label for="txtFirstName" class="form-label">First Name:</label>

                            <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>

                        </div>
                        <div class="col-6">

                            <label for="txtLastName" class="form-label">Last Name:</label>

                            <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>


                    </div>

                    <div class="row mb-3">
                        <label for="txtEmail" class="col-sm-4 col-form-label">Email:</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <label for="txtPassword" class="col-sm-4 col-form-label">Password:</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <label for="txtConfirmPassword" class="col-sm-4 col-form-label">Confirm Password:</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <div class="col-sm-8 offset-sm-2">
                            <asp:Button ID="btnRegister" Text="Register" CssClass="btn btn-primary" runat="server" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-7">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>



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
                                                <asp:Label ID="lblFileName" runat="server" Text='<%#Eval("TabName").ToString()==""?"No File Available":Eval("TabName").ToString() %>' ClientIDMode="Static"></asp:Label>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                    <SeparatorTemplate>
                                        <hr />
                                    </SeparatorTemplate>
                                </asp:Repeater>


                            </div>
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

        </div>


    </form>

    <%-- <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script>
        function uploadComplete(sender, args) {
            // Trigger update of the UpdatePanel containing the Repeater after file upload
            __doPostBack('<%= UpdatePanel1.ClientID %>', '');
        }
    </script>--%>
</body>
</html>
