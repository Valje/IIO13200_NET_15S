<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LevynTiedot.aspx.cs" Inherits="LevynTiedot" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>XMLDataSource testi</title>
</head>
<body>
    <form id="form2" runat="server">
    <div>
    <!--1. DataSourcen määrittely -->
        <asp:XmlDataSource ID="srcMuuvit" 
            DataFile="~/App_Data/Movies.xml"
            runat="server"></asp:XmlDataSource>
        <asp:XmlDataSource ID="srcLevyt"
            DataFile ="~/App_Data/LevykauppaX.xml"     
            runat="server"></asp:XmlDataSource>
                                                                        <!-- esim. genre[@name='Rock'] -->
        <asp:XmlDataSource ID="srcBiisit"
            DataFile ="~/App_Data/LevykauppaX.xml"    
            runat="server"></asp:XmlDataSource>

        <h2>Levykaupan erikoistarjoukset</h2>
        <asp:Repeater ID="Repeater3" DataSourceID="srcLevyt" runat="server">
            <ItemTemplate>
                <img src="images/<%# Eval("ISBN") %>.jpg"/>
                </br></br>
                <h3><b><%# Eval("Artist") %>: <%# Eval("Title") %></b></h3>
                </br>
                <b>ISBN:</b><%# Eval("ISBN") %></br>
                <b>Hinta:</b> <%# Eval("Price") %>
                </br></br>
            </ItemTemplate>
        </asp:Repeater>

        <asp:Repeater ID="Repeater1" DataSourceID="srcBiisit" runat="server">
            <HeaderTemplate>
                <b>Levyn biisit: </b>
            </HeaderTemplate>
            <ItemTemplate>
                <%# Eval("name") %></br>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    </form>
    </body>
</html>