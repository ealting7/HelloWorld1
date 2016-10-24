<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
</asp:Content>


<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <table class="table1">
        <tr>
            <td colspan="2" class="tdsolid">
                <asp:Label ID="Label1" CssClass="lblSayHelloItem" runat="server" Text="Erik Alting:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="tddotted" style="background-color: #ffd530;">
                <asp:Label ID="Label3" CssClass="lblSayHelloSubItem" runat="server"  Font-Bold="true" Text="Education:"></asp:Label>
            </td>

            <td class="tddotted" >

                <div class="fontresume">

                    INDIANA UNIVERSITY PURDUE UNIVERSITY
                    <br />	
                    Indianapolis, IN
                    <br />
                    BS in Media Arts and Science
                    <br />
                    December 2001
                    <br />
                    •	Area of study:  Informatics, programming
                    <br />
                    <br />
                    UNIVERSITY OF INDIANAPOLIS
                    <br />
                    Indianapolis, IN
                    <br />
                    •	Area of study: CIS/ Political Science
                    <br />
                    August 1997 – May 1999
                     <br />

                </div>

            </td>
        </tr>
        <tr>
            <td class="tddotted" style="background-color: #ffd530;">
                <asp:Label ID="Label4" CssClass="lblSayHelloSubItem" runat="server"  Font-Bold="true"
                    Text="Technical Expertise:"></asp:Label>
            </td>
            <td class="tddotted">

                <div class="fontresume">

                    Visual Basic 6.0 (12 years) <br />
                    Microsoft Visual Studio 6.0 <br />
                    ASP.NET (6 years) <br />
                    Visual Studio 2010 <br />
                    SQL Server 8.0 and 2008 <br />
                    Microsoft SQL Server Management Tool <br />
                    Surround SCM Source Control Tool <br />
                    TortoiseSVN <br />
                    SubVersion 1.0 <br />
                    Visual Basic <br />
                    C# <br />
                    AJAX <br />
                    SQL <br />
                    Crystal Reports (7.0 and 9)  <br />
                    VB Script <br />
                    JavaScript <br />
                    Java (minimal experience) <br />
                    SourceSafe <br />
                    HTML <br />
                    Macromedia Fireworks <br />
                    Adobe Photoshop <br />
                    Adobe Illustrator  <br />
                    Macromedia Flash <br />
                
                </div>

                </td>
        </tr>
        <tr>
            <td class="tddotted" style="background-color: #ffd530;">
                <asp:Label ID="Label5" CssClass="lblSayHelloSubItem"  runat="server"  Font-Bold="true" Text="Work Experience:"></asp:Label>
            </td>
            <td class="tddotted">
                
                <div class="fontresume">

                    02/08-Present 
                    <br />
                    <br />
                    DYNAMIC BUSINESS MANAGEMENT SOLUTIONS (DBMS)
                    <br />
                    Indianapolis, IN
                    <br />
                    <br />
                    *IT Manager/Senior Software Engineer
                    <br />    
                    <br />
                    -DBMS’s sole programmer that has been responsible for writing and maintaining all care management software applications for DBMS.  
                     This includes developing new modules and updating existing modules for the ICMS (Integrated Care Management System) client/server 
                     application.  ICMS tracks a patient’s health and wellness lifecycle.  Along with the ICMS application, I am in charge of maintenance 
                     and new development for our client web portals. 
                     <br />
                     <br />
                     <br />
                     3/03-01/08
                     <br />
                     <br />
                     ZOTEC PARTNERS
                     <br />
                     Carmel, IN
                     <br />
                     <br />
                    *Software Engineer
                    <br />
                    <br />
                    -Responsible for writing healthcare software applications.  Specifically engineered RIS and patient 
                    appointment scheduling applications that would schedule, check in, track medical procedure(s) through 
                    to completion, check out, and medical document transcription.  Many of my responsibilities included 
                    customization of software based on client specifications
                    <br />
                    <br />
                    <br />
                    2/02-2/03          
                    <br />
                    <br />
                    SIGMA MICRO CORPORATIONS
                    <br />
                    Indianapolis, IN
                    <br />
                    <br />
                    *Web Site Developer/Programmer
                    <br />
                    <br />
                    <br />
                    10/00-1/01	
                    <br />
                    <br />
                    INDIANAPOLIS LIFE INSURANCE COMPANY
                    <br />
                    Indianapolis, IN
                    <br />
                    <br />
                    *Intern Web Developer/ Programmer
                    <br />

                </div>

            </td>
        </tr>

    </table>

</asp:Content>
