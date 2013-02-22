<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="FALL2012B.AddUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
login: <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox><br />
password: <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox><br />
First: <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox><br />
Last: <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox><br />
Email: <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ControlToValidate="txtEmail" ErrorMessage="Email format bad." 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
    <br />

<asp:Button ID="cmdAddUser" runat="server" text="Add User" style="height: 26px" 
        onclick="cmdAddUser_Click" />

<asp:Label ID="lblError" runat="server" Visible="false"></asp:Label>

</asp:Content>
