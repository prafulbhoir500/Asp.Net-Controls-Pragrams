<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileUpload_ProfilePhoto.aspx.cs" Inherits="AspControl.FileUploadControl.FileUpload_ProfilePhoto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <%-- <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous"/>--%>
    <style>
        .file-upload {
            display: inline-block;
            padding: 0 12px;
            height: 36px;
            line-height: 36px;
            color: wheat;
            background-color: #808080;
            cursor: pointer;
        }

            .file-upload input[type="file"] {
                display: none;
            }
    </style>
    <script>
        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    document.getElementById('imgview').src = e.target.result;

                    //$('#imgview').attr('src', e.target.result);
                };

                reader.readAsDataURL(input.files[0]);
            }
        }
        // function displayImage(input) {
        //     debugger;
        //    if (input.files && input.files[0]) {
        //        var reader = new FileReader();

        //        reader.onload = function (e) {
        //            document.getElementById('imgPreview').src = e.target.result;

        //            //$('#imgview').attr('src', e.target.result);
        //        }

        //        reader.readAsDataURL(input.files[0]);
        //    }
        //}
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <%-- <div>
            <h2>Upload Image</h2>
            <input type="file" id="fileUpload" onchange="displayImage(this)" />
            <br />
            <asp:Button ID="btnUpload" runat="server" Text="Upload" />
            <br />
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            <br />
            <img id="imgPreview" src="#" alt="Uploaded Image" style="max-width: 200px; max-height: 200px; display: none;" />
        </div>--%>

        <div class="row">
            <div class="col">
                <center>
                    <img id="imgview" height="150px" width="100px" src="" />
                </center>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <hr>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <asp:FileUpload onchange="readURL(this);" class="btn btn-primary" ID="FileUpload1" runat="server" />
            </div>
        </div>

        <hr />
        <%--<asp:FileUpload ID="FileUpload2" CssClass="file-upload" runat="server" />--%>
        <div class="file-upload">
            <input type="file" />
            <asp:Label ID="Label1" runat="server" Text="Label" CssClass="d-inline-block"></asp:Label>

        </div>

    </form>
</body>
</html>
