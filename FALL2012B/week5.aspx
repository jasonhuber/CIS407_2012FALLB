<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="week5.aspx.cs" Inherits="FALL2012B.week5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        Please enter your check amounts: <br />
        Check #1: <asp:TextBox ID="txtCheck1" runat="server"></asp:TextBox><br />
        Check #2: <asp:TextBox ID="txtCheck2" runat="server"></asp:TextBox><br />
        Check #3: <asp:TextBox ID="txtCheck3" runat="server"></asp:TextBox><br />
        Check #4: <asp:TextBox ID="txtCheck4" runat="server"></asp:TextBox><br />
        Check #5: <asp:TextBox ID="txtCheck5" runat="server"></asp:TextBox><br />
        <asp:Button id="btnGo" runat="server" Value="Go" onclick="btnGo_Click" 
            Text="Go" />
        <br />
        <br />
        <asp:Label ID="lblBalance" runat="server"></asp:Label>
    </div>
</asp:Content>
