<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FriendDemographic.aspx.cs" Inherits="FriendDemographic" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
</asp:Content>



<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
    <table class="table1">

        <tr>

            <td colspan="2">
                <asp:Label ID="Label1" CssClass="lblSayHelloItem" runat="server" Text="I Remember You:"></asp:Label>
                <asp:Label ID="lblFriendName" CssClass="lblSayHelloItem" runat="server" Text="" Visible="false"></asp:Label>
            </td>

        </tr>

        <tr>

            <td>
                <asp:Label ID="Label2" CssClass="lblSayHelloSubItem" runat="server" Text="Birthday:"></asp:Label>
            </td>

            <td>
                <asp:TextBox ID="txtBirthday" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="txtBirthday_CalendarExtender" runat="server" Enabled="True" Format="MM/dd/yyyy" TargetControlID="txtBirthday">
                </asp:CalendarExtender>
            </td>

        </tr>

        <tr>

            <td>
                <asp:Label ID="Label3" CssClass="lblSayHelloSubItem" runat="server" 
                    Text="Cell Number:"></asp:Label>
            </td>

            <td>
                <asp:TextBox ID="txtCellNumber" runat="server" MaxLength="20"></asp:TextBox>
            </td>

        </tr>

        <tr>

            <td>
                <asp:Label ID="Label4" CssClass="lblSayHelloSubItem" runat="server" 
                    Text="Email Address:"></asp:Label>
            </td>

            <td>
                <asp:TextBox ID="txtEmailAddress" runat="server" MaxLength="50"></asp:TextBox>
            </td>

        </tr>

        <tr>

            <td>
                <asp:Label ID="Label5" CssClass="lblSayHelloSubItem" runat="server" 
                    Text="Favorite Food:"></asp:Label>
            </td>

            <td>
                <asp:TextBox ID="txtFavoriteFood" runat="server" MaxLength="100"></asp:TextBox>
            </td>

        </tr>

        <tr>

            <td>
                <asp:Button ID="cmdRemember" runat="server" CssClass="cmdSayHello" Text="Remember" onclick="cmdRemember_Click" />
                <asp:Button ID="cmdPickADifferentFriend" runat="server" CssClass="cmdSayHello" 
                    Text="Pick A Different Friend" onclick="cmdPickADifferentFriend_Click" />
            </td>

            <td>
            </td>

        </tr>


        <tr>

            <td colspan="2">
                <asp:Label ID="lblFriendDemographicError" CssClass="lblSayHelloError" runat="server" Text="" Visible="false"></asp:Label>
            </td>

        </tr>

        
    </table>


    <asp:ScriptManager ID="scriptMnger" runat="server"></asp:ScriptManager>

</asp:Content>