<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
</asp:Content>



<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
<table class="table1">
        <tr>
            <td class="tddotted">
                <asp:Label ID="Label1" CssClass="lblSayHelloItem" runat="server" Text="Say Hello:"></asp:Label>
            </td>
            <td class="tddotted">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="tdsolid">
                <asp:Label ID="Label2" CssClass="lblSayHelloSubItem" runat="server" Text="Your Name:"></asp:Label>
            </td>
            <td class="tdsolid">
                <asp:TextBox ID="txtIntroduceYourself" runat="server" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="cmdIntroduceYourself" runat="server" CssClass="cmdSayHello" 
                    Text="Introduce Yourself" onclick="cmdIntroduceYourself_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblHelloError" CssClass="lblSayHelloError" runat="server" Text="" Visible="false"></asp:Label>
            </td>
        </tr>
        </table>

</asp:Content>
