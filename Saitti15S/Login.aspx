<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Label">Nimesi</asp:Label>
        <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator 
            ID="RequiredFieldValidatorName" 
            runat="server" 
            ErrorMessage="Nimi puuttuu" 
            ControlToValidate="tbName"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Label">Sähköpostiosoitteesi</asp:Label>
        <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator 
            ID="RequiredFieldValidator1" 
            runat="server" 
            ErrorMessage="Sähköposti puuttuu" 
            ControlToValidate="tbEmail"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator 
            ID="RegularExpressionValidatorEmail" 
            runat="server" 
            ControlToValidate="tbEmail"
            ErrorMessage="Sähköposti on virheellinen"
            ValidationExpression="^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$"></asp:RegularExpressionValidator>
        <br />
        <asp:Button ID="btnLogin" Text="Sisään" runat="server" OnClick="btnLogin_Click" />
    </div>
    </form>
</body>
</html>
