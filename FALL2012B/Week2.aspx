<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Week2.aspx.cs" Inherits="FALL2012B.Week2" %>
<%@ Register src="login.ascx" tagname="login" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="pnlInput" runat="server">
        First Name : <asp:TextBox runat="server" ID="txtFname"></asp:TextBox><br />
        Last Name : <asp:TextBox runat="server" ID="txtLname"></asp:TextBox><br />
        <asp:Button runat="server" ID="cmdInput" Text="Submit" 
            onclick="cmdInput_Click" /> <asp:Button runat="server" ID="cmdCancel" Text="Cancel" />
    </asp:Panel>

    <asp:Panel ID="pnlOutput" runat="server">
        <asp:TextBox runat="server" ID="txtOutput" Height="288px" Width="365px" 
            TextMode="MultiLine"></asp:TextBox><br />
        <asp:Button runat="server" ID="btnRedo" Text="Redo" onclick="btnRedo_Click" />
      
    </asp:Panel>

  <uc1:login ID="login1" runat="server" />
    
</asp:Content>
