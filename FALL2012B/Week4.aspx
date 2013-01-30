<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Week4.aspx.cs" Inherits="FALL2012B.Week4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <table>
                <tr>
                    <td>trackerid</td>
                    <td>key</td>
                    <td>value</td>
                    <td>when</td>
                    <td>&nbsp;</td>
                </tr>
                 <tr>
                    <td><asp:TextBox id="txtTrackerId" runat="server"></asp:TextBox></td>
                    <td><asp:TextBox id="txtKey" runat="server"></asp:TextBox></td>
                    <td><asp:TextBox id="txtValue" runat="server"></asp:TextBox></td>
                    <td>when</td>
                    <td><asp:Button ID="cmdSearch" runat="server" text="Search" OnClick="cmdSearch_OnClick"  /></td>
                </tr>
    <asp:Repeater ID="rptDisplay" runat="server">
        <ItemTemplate>
                <tr>
                    <td><%# DataBinder.Eval (Container.DataItem, "UserTrackerId") %></td>
                    <td><%# DataBinder.Eval (Container.DataItem, "trackkey") %></td>
                    <td colspan="2"><%# DataBinder.Eval (Container.DataItem, "value") %></td>
                    <td><%# DataBinder.Eval (Container.DataItem, "trackwhen") %></td>
                </tr>
        </ItemTemplate>
    </asp:Repeater>
      </table>
</asp:Content>
