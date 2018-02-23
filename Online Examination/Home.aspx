<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="OnlineExam.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
     <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                </hgroup>
                <asp:Image ID="profile_img" runat="server" width="125" height="125" style="float:left; margin:0 15px 15px 0; clear:left;padding:4px; border:1px solid #D8D9DE;" />
                <hgroup>
                <h1><asp:Label ID="name" runat="server"></asp:Label></h1> 
            </hgroup>
            <p>
                To learn more about ASP.NET, visit <a href="http://asp.net" title="ASP.NET Website">http://asp.net</a>.
                The page features <mark>videos, tutorials, and samples</mark> to help you get the most from ASP.NET.
                If you have any questions about ASP.NET visit
                <a href="http://forums.asp.net/18.aspx" title="ASP.NET Forum">our forums</a>.
            </p>
        </div>
    </section> 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">    <asp:Button ID="Submit" runat="server" Height="67px" text="Submit" OnClick="Submit_Exam" />    
    <td><asp:DropDownList ID="ddlSubjects" runat="server" DataSourceID="MySQLConnection" DataTextField="sname" DataValueField="sname">
            </asp:DropDownList></td><td></td>
               <asp:SqlDataSource  runat="server" ID="MySQLConnection" ProviderName="<%$ ConnectionStrings:MySQLConnection.ProviderName %>" ConnectionString="<%$ ConnectionStrings:MySQLConnection %>"  SelectCommand="SELECT sname FROM dbo.oe_subjects"></asp:SqlDataSource>  <b>Note</b>
    <ul>
    <li>Each exam contains 5 question.</li><li>Use Next and Previous buttons to navigate between questions</li><li>Result is displayed after the last questions is answered</li><li>CANCEL button can be used to cancel the exam</li><li>No time limitation. However the time taken is stored in database</li></ul>
    
    <br />   
        </form>
 
</asp:Content>
    