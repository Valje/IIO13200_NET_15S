<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DemoxOy2.aspx.cs" Inherits="DemoxOy2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:GridView ID="gvCustomers2" runat="server" EmptyDataText="There are no data records to display.">
            </asp:GridView>
        <asp:Label ID="errorMessage" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
