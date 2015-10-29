<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DemoxOy.aspx.cs" Inherits="DemoxOy" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:GridView ID="gvCustomers" runat="server" EmptyDataText="There are no data records to display.">
            </asp:GridView>
        <asp:Label ID="errorMessage" runat="server"></asp:Label>
    </form>
</body>
</html>
