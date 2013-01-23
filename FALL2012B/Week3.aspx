<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Week3.aspx.cs" Inherits="FALL2012B.Week3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    Hi here is my date:
     <br />
    <asp:GridView ID="grdTracker" runat="server" AllowPaging="True" 
    AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
    BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
    DataKeyNames="UserTrackerId" DataSourceID="HuberTrackerDB" GridLines="Vertical">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                ShowSelectButton="True" />
            <asp:BoundField DataField="UserTrackerId" HeaderText="UserTrackerId" 
                ReadOnly="True" SortExpression="UserTrackerId" />
            <asp:BoundField DataField="TrackKey" HeaderText="TrackKey" 
                SortExpression="TrackKey" />
            <asp:BoundField DataField="value" HeaderText="value" SortExpression="value" />
            <asp:BoundField DataField="trackwhen" HeaderText="trackwhen" 
                SortExpression="trackwhen" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
    </asp:GridView>
<asp:SqlDataSource ID="HuberTrackerDB" runat="server" 
    ConnectionString="<%$ ConnectionStrings:HuberTrackerConnection %>" 
    DeleteCommand="DELETE FROM [Huber_Tracker12] WHERE [UserTrackerId] = @UserTrackerId" 
    InsertCommand="INSERT INTO [Huber_Tracker12] ([UserTrackerId], [TrackKey], [value], [trackwhen]) VALUES (@UserTrackerId, @TrackKey, @value, @trackwhen)" 
    SelectCommand="SELECT * FROM [Huber_Tracker12] ORDER BY [trackwhen] DESC" 
    UpdateCommand="UPDATE [Huber_Tracker12] SET [TrackKey] = @TrackKey, [value] = @value, [trackwhen] = @trackwhen WHERE [UserTrackerId] = @UserTrackerId">
    <DeleteParameters>
        <asp:Parameter Name="UserTrackerId" Type="Object" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="UserTrackerId" Type="Object" />
        <asp:Parameter Name="TrackKey" Type="String" />
        <asp:Parameter Name="value" Type="String" />
        <asp:Parameter Name="trackwhen" Type="DateTime" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="TrackKey" Type="String" />
        <asp:Parameter Name="value" Type="String" />
        <asp:Parameter Name="trackwhen" Type="DateTime" />
        <asp:Parameter Name="UserTrackerId" Type="Object" />
    </UpdateParameters>
</asp:SqlDataSource>
</asp:Content>
