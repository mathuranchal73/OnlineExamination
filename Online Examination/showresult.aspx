<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="showresult.aspx.cs" Inherits="Online_Examination.showresult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <h2>
    Examination Result</h2>
    &nbsp;
    <br />
    <table bgcolor="#eeeeee" border=1>
        <tr>
            <td>
                Subject:
            </td>
            <td>
                <asp:Label ID="lblSubject" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td>
                Starting Time :
            </td>
            <td>
                <asp:Label ID="lblStime" runat="server" Text="Label"></asp:Label></td>
        </tr>
        
        <tr>
            <td>
                Time Taken In Minutes : 
            </td>
            <td>
                <asp:Label ID="lblMin" runat="server" Text="Label"></asp:Label></td>
        </tr>
        
                <tr>
            <td>
               No. of Questions :
            </td>
            <td>
                <asp:Label ID="lblNquestions" runat="server"></asp:Label></td>
        </tr>
        
                <tr>
            <td>
                No. of correct answers :
            </td>
            <td>
                <asp:Label ID="lblNcans" runat="server" Text="Label"></asp:Label></td>
        </tr>

        <tr>
            <td>
                Grade : 
            </td>
            <td>
                <asp:Label ID="lblGrade" runat="server" Text="Label"></asp:Label></td>
        </tr>


    </table>
    <br />
    <a  href="reviewquestions.aspx">Review Questions</a>
    <form runat="server">
    <asp:LinkButton ID="lbRank" runat="server" OnClick="lbRank_Click">Rank The Result</asp:LinkButton><a  href="Home.aspx">Home</a><br />
    <br /></form>
    <asp:Label ID="lblRank" runat="server"></asp:Label><br />
    
        
    
</asp:Content>
