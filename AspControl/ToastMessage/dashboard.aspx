<%@ Page Title="" Language="C#" MasterPageFile="~/ToastMessage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="AspControl.ToastMessage.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        // Wait for the document to be fully loaded
        document.addEventListener("DOMContentLoaded", function () {
            // Show the toast message
            var toastEl = document.getElementById("myToast");
            var toast = new bootstrap.Toast(toastEl);

            // Function to show and hide the toast message after a certain duration
            function showToastWithDuration() {
                toast.show();
                setTimeout(function () {
                    toast.hide();
                }, 3000); // Change 3000 to the desired duration in milliseconds (e.g., 5000 for 5 seconds)
            }

            // Show the toast message when the document is loaded
            showToastWithDuration();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <div class="container mt-5">
        <h2>Sign Up</h2>
            <div class="mb-3">
                <label for="txtUsername">Username</label>
                <input type="text" id="txtUsername" class="form-control" runat="server" />
                <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername" ErrorMessage="Username is required." ForeColor="Red" />
            </div>
            <div class="mb-3">
                <label for="txtEmail">Email</label>
                <input type="email" id="txtEmail" class="form-control" runat="server" />
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required." ForeColor="Red" />
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid email address." ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
            </div>
            <div class="mb-3">
                <label for="txtPassword">Password</label>
                <input type="password" id="txtPassword" class="form-control" runat="server" />
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required." ForeColor="Red" />
            </div>
            <button type="submit" class="btn btn-primary">Sign Up</button>
    
        <asp:Literal ID="litMessage" runat="server" />
    </div>
    <div id="myToast" class="toast align-items-center text-white bg-primary border-0" role="alert" aria-live="assertive" aria-atomic="true">
        <div class="d-flex">
            <div class="toast-body">
                Welcome to Modernize! Easy to customize the Template!!!
            </div>
            <button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast" aria-label="Close"></button>
        </div>
    </div>
   
    

</asp:Content>
