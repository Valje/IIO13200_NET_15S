<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TestaaTeema.aspx.cs" Inherits="TestaaTeema" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Testataan teeman vaihtoa</h1>
    <p>Teema voi määrittää HTML-elementtien, ja ASP.NET-kontrollien ulkoasua tai myös kuvia.</p>
    <asp:textbox runat="server"></asp:textbox>
    <p>Vaihda teema näistä linkeistä:</p>
    <asp:hyperlink runat="server" NavigateUrl="TestaaTeema.aspx?theme=Simppeli">Simppeli</asp:hyperlink>
    <br />
    <asp:hyperlink runat="server" NavigateUrl="TestaaTeema.aspx?theme=Punainen">Punainen</asp:hyperlink>
    <br />
    <asp:Image ID="myImage" runat="server" SkinID="logo"></asp:Image>
</asp:Content>

