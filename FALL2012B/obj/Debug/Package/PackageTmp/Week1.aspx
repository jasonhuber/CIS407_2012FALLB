<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Week1.aspx.cs" Inherits="FALL2012B.Week1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    



    Num1:
    <asp:TextBox ID="txtNum1" runat="server" Width="127px"></asp:TextBox>
    <br />
    Num2:
    <asp:TextBox ID="txtNum2" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" Text="Add!" />
    <br />
    <asp:Label ID="lblResult" runat="server"></asp:Label>
    



</asp:Content>
