<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="AspControl.RepeaterControl.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Expense Calculator</h1>
            <asp:Repeater ID="rptExpenses" runat="server" OnItemDataBound="rptExpenses_ItemDataBound">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <th>Name</th>
                            <th>Per Person</th>
                            <th>Total</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtPerPerson" runat="server" CssClass="perPerson" AutoPostBack="true" OnTextChanged="txtPerPerson_TextChanged"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtPerPersonRate" runat="server" CssClass="perPersonRate" Text='<%# Eval("PerPersonRate") %>'></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="txtTotal" runat="server" Enabled="false"></asp:TextBox></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <tr>
                        <td><strong>Total:</strong></td>
                        <td>
                            <asp:Label ID="lblColumnTotalPer" runat="server"></asp:Label></td>

                        <td>
                            <asp:Label ID="lblColumnTotal" runat="server"></asp:Label></td>
                    </tr>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
