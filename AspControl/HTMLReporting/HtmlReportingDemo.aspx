<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HtmlReportingDemo.aspx.cs" Inherits="AspControl.HTMLReporting.HtmlReportingDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnViewReportbasic" runat="server" Text="View Report Basic" OnClick="btnViewReportbasic_Click" />
            <asp:Button ID="btnViewReport" runat="server" Text="View Report" OnClick="btnViewReport_Click" />
            <asp:Button ID="btnViewReportWithPageSize" runat="server" Text="View Report Page Size" OnClick="btnViewReportWithPageSize_Click" />
            <asp:Button ID="btnViewReportInvoice" runat="server" Text="View Report Invoice" OnClick="btnViewReportInvoice_Click" />
        </div>
    </form>
</body>
</html>
