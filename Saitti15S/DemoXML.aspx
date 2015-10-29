<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DemoXML.aspx.cs" Inherits="DemoSQL" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>XMLDataSource testi</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <!--1. DataSourcen määrittely -->
        <asp:XmlDataSource ID="srcMuuvit" 
            DataFile="~/App_Data/Movies.xml"
            runat="server"></asp:XmlDataSource>
        <asp:XmlDataSource ID="srcLevyt"
            DataFile ="~/App_Data/LevykauppaX.xml"
            XPath="Records/genre/record"        
            runat="server"></asp:XmlDataSource>
                                                                        <!-- esim. genre[@name='Rock'] -->

        <h2>Levykaupan erikoistarjoukset</h2>
        <asp:Repeater ID="Repeater3" DataSourceID="srcLevyt" runat="server">
            <HeaderTemplate>
                <table>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><img src="images/<%# Eval("ISBN") %>.jpg" width="100"/></td>
                    <td><b><%# Eval("Artist") %>: <%# Eval("Title") %></b></br>
                    <b>ISBN:</b> <a href="LevynTiedot.aspx?ISBN=<%# Eval("ISBN") %>"><%# Eval("ISBN") %></a></br></br>
                    <b>Hinta:</b> <%# Eval("Price") %></td>
                </tr>


            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        















        </br></br></br></br>
        </br></br></br></br>
        </br></br></br></br>
        </br></br></br></br>
        </br></br></br></br>
        </br></br></br></br>

        <!--2. DataKontrolli data esittämistä varten-->
        <h2>Kinnfino ylpeänä esittää XML-muuveja</h2>
        <asp:GridView ID="gvMuuvit"
            DataSourceID="srcMuuvit" 
            runat="server"></asp:GridView>
    <!--2b. Vaihtoehtoinen tapa esittää käyttäen Repeater-kontrollia-->
        <h2>Repeaterilla</h2>
        <asp:Repeater ID="Repeater1" DataSourceID="srcMuuvit" runat="server">
            <HeaderTemplate>
                <table border="1">
                    <tr>
                        <td>Nimi</td>
                        <td>Maa</td>
                        <td>Ohjaaja</td>
                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                        <td><%# Eval("Name") %></td>
                        <td><%# Eval("Country") %></td>
                        <td><%# Eval("Director") %></td>
                </tr>
            </ItemTemplate>

            <FooterTemplate>
                </table>
            </FooterTemplate>

        </asp:Repeater>

        <h2>Ja taas</h2>
        <asp:Repeater ID="Repeater2" DataSourceID="srcMuuvit" runat="server">
            <ItemTemplate>
                <b><%# Eval("Name") %></b>
                directed by <%# Eval("Director") %> </br>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
