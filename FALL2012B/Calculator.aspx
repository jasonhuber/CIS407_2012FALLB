<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="FALL2012B.Calculator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    Num1: <asp:TextBox ID="txtNum1" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ErrorMessage="Must be a number" ValidationExpression="^\d+$" 
        ControlToValidate="txtNum1"></asp:RegularExpressionValidator>
        <br />

    Num2: <asp:TextBox ID="txtNum2" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ErrorMessage="Num2 must be filled in." ControlToValidate="txtNum2"></asp:RequiredFieldValidator>
    <br />
    <asp:Button runat="server" ID="cmdCalc" Text="Add!" onclick="cmdCalc_Click" />
    <asp:Label runat="server" ID="lblResult"></asp:Label>        
</asp:Content>
