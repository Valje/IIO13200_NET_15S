<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="indexMP.aspx.cs" Inherits="indexMP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Jee</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lbllHello" runat="server" Text="..."></asp:Label>

    <h1>To 22.10.2015</h1>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Eka sivuni</asp:HyperLink>
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Viinit.aspx">Maailman viinit</asp:HyperLink>
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/DemoxOy.aspx">Maailman viiniloppahuulet</asp:HyperLink>
    <h1>To 29.10.2015</h1>
        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/DemoSQL.aspx">Demo SqlDataSource</asp:HyperLink>
</asp:Content>

