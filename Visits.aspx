<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Visits.aspx.cs" Inherits="Visits" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
</asp:Content>


<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <table class="table1">
        <tr>
            <td class="tddotted">
                <asp:Label ID="Label1" CssClass="lblSayHelloItem" runat="server" Text="Visits:"></asp:Label>
            </td>
            <td class="tddotted">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grdvwPeopleMet" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" CellPadding="4" 
                    DataKeyNames="visit_id, friend_id" 
                    EmptyDataText="Well?!? Say Hello" Font-Size="X-Small" ForeColor="#333333" 
                    GridLines="Both" OnPageIndexChanging="grdvwPeopleMet_PageIndexChanging" 
                    OnSelectedIndexChanged="grdvwPeopleMet_SelectedIndexChanged" PageSize="5" 
                    Visible="False">
                    <Columns>
                        <asp:CommandField SelectText="SELECT" ShowSelectButton="True" />
                        <asp:BoundField DataField="visit_id" HeaderText="Visit ID" Visible="False" />
                        <asp:BoundField DataField="friend_id" HeaderText="Visit ID" Visible="False" />
                        <asp:BoundField DataField="name" HeaderText="Friend" />
                        <asp:BoundField DataField="visit_date" HeaderText="Visit Date" />
                        <asp:BoundField DataField="browser_type" HeaderText="Browser" />
                        <asp:BoundField DataField="browser_platform" HeaderText="Platform" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFF99" ForeColor="DarkBlue" />
                    <AlternatingRowStyle BackColor="#FFFF99" ForeColor="DarkBlue" />
                    <EmptyDataRowStyle BackColor="Silver" BorderStyle="None" Font-Bold="True" 
                        ForeColor="Red" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
