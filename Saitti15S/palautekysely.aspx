<%@ Page Language="C#" AutoEventWireup="true" CodeFile="palautekysely.aspx.cs" Inherits="palautekysely" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow>
                <asp:TableCell>PVM</asp:TableCell>
                <asp:TableCell>
                    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Nimi</asp:TableCell>
                <asp:TableCell>
                    <asp:textbox runat="server" ID="tbNimi" Width="300" />
                    <asp:RequiredFieldValidator ErrorMessage="Kenttä pakollinen" ControlToValidate="tbNimi" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Olen oppinut</asp:TableCell>
                <asp:TableCell>
                    <asp:textbox runat="server" ID="tbOlenOppinut" Width="300" TextMode="MultiLine" Rows="4" />
                    <asp:RequiredFieldValidator ErrorMessage="Kenttä pakollinen" ControlToValidate="tbOlenOppinut" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Haluaisin oppia</asp:TableCell>
                <asp:TableCell>
                    <asp:textbox runat="server" ID="tbHaluaisinOppia" Width="300" TextMode="MultiLine" Rows="4" />
                    <asp:RequiredFieldValidator ErrorMessage="Kenttä pakollinen" ControlToValidate="tbHaluaisinOppia" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Hyvää kurssissa</asp:TableCell>
                <asp:TableCell>
                    <asp:textbox runat="server" ID="tbHyvaa" Width="300" TextMode="MultiLine" Rows="4" />
                    <asp:RequiredFieldValidator ErrorMessage="Kenttä pakollinen" ControlToValidate="tbHyvaa" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Huonoa kurssissa</asp:TableCell>
                <asp:TableCell>
                    <asp:textbox runat="server" ID="tbHuonoa" Width="300" TextMode="MultiLine" Rows="4" />
                    <asp:RequiredFieldValidator ErrorMessage="Kenttä pakollinen" ControlToValidate="tbHuonoa" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Muuta</asp:TableCell>
                <asp:TableCell>
                    <asp:textbox runat="server" ID="tbMuuta" Width="300" TextMode="MultiLine" Rows="4" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell>
                    <asp:button ID="btnLaheta" text="Lähetä" runat="server" OnClick="btnLaheta_Click" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    </form>
</body>
</html>
