<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="reviewquestions.aspx.cs" Inherits="Online_Examination.reviewquestions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DataList ID="DataList1" runat="server" Width="100%">
    <HeaderTemplate>
     <a href="showresult.aspx">Show Result</a>
     <h2>Review Questions</h2>
     <hr size=5 style="color:red" />
    </HeaderTemplate>
    
    <ItemTemplate>
    <pre style="color:Red;background-color:#eeeeee"><%# DataBinder.Eval( Container.DataItem,"QuestionText")%></pre>
    <pre>1.<%# DataBinder.Eval( Container.DataItem,"Answer1") %></pre>
    <pre>2.<%# DataBinder.Eval( Container.DataItem,"Answer2") %></pre>
    <pre>3.<%# DataBinder.Eval( Container.DataItem,"Answer3") %></pre>
    <pre>4.<%# DataBinder.Eval( Container.DataItem,"Answer4") %></pre>
    <pre>Correct Answer :<%# DataBinder.Eval( Container.DataItem,"CorrectAnswer") %></pre>
    <pre>Your Answer    :<%# DataBinder.Eval( Container.DataItem,"YourAnswer") %></pre>
    </ItemTemplate>
    
     <SeparatorTemplate>
     <hr size="2" style="color:Red" />
    </SeparatorTemplate>
    
    
    
    <FooterTemplate>
      <hr size=5 style="color:red" />
      <a href="showresult.aspx">Show Result</a>
    </FooterTemplate>
    </asp:DataList>

</asp:Content>
