<%@ Page Title="HelloWorld" Language="C#" AutoEventWireup="true"CodeFile="Hello.aspx.cs" Inherits="Hello" %>


<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">

    <title></title>



        <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />

</head>
<body>

    <form id="form1" runat="server">


    <table class="table1">
        <tr>
            <td  class="tdsolid">
                <asp:Label ID="lblSayHello" CssClass="lblInroduceYourself" runat="server" Text="" Visible="false"></asp:Label>
            </td>
            <td class="tdsolid">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="cmdCloseWindow" runat="server" CssClass="cmdSayHello" Text="Close Window" onclick="cmdCloseWindow_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        </table>



    </form>
</body>
</html>
