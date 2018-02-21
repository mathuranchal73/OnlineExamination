<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="examination.aspx.cs" Inherits="Online_Examination.examination" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Examination</title>
    
    <style type="text/css">
        fieldset {margin: 1em 0 0 0;  padding: 0;}
legend {margin-left: 1em; color: #000000; font-weight: bold; padding: 0;}
label {float: left; width: 10em; margin-right: 1em; text-align: right;}

fieldset ol {padding: 1em 1em 0 1em; list-style: none;}
fieldset {float: left; clear: both; width: 92%; 
margin: 0 0 .5em 0; padding: 0; border: 1px solid #BFBAB0;
            height: 472px;
        }
fieldset li {float: left; clear: left; width: 50%; padding-bottom: 1ex;}

.text{color:Gray;}
.contactTypeRadio label{width: 50%;}
        .auto-style2 {}
    </style>
    
</head>

<body>
    <form id="form1" runat="server">
    <h2>Examination</h2>
    <table width="100%" bgcolor="#dddddd">
    <tr>
    <td>
        Subject :
        <asp:Label ID="lblSubject" runat="server" Width="154px" Font-Bold="True" Font-Names="Verdana" ForeColor="Red"></asp:Label></td>
    <td>
        Question :
        <asp:Label ID="lblQno" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="Red"></asp:Label></td>
    </tr>
    <tr>
    <td>
        Started At :
        <asp:Label ID="lblStime" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="Red"></asp:Label></td>
    <td style="height: 22px">
        Current Time :<asp:Label ID="lblCtime" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="Red"></asp:Label></td>

    </tr>
    <tr>
    <td>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        Total Time :<asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#FF3300"></asp:Label>
        </td>
    <td style="height: 22px">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                Time Remaining: <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#FF3300" ></asp:Label>
                <asp:Timer ID="Timer1" runat="server" Interval="1000" ontick="Timer1_Tick">
                </asp:Timer>
            </ContentTemplate>
        </asp:UpdatePanel>
        </td>

    </tr>
       
    </table>
    
    <p />
    <b>Question</b>
    <br />
    <b><pre runat="server" id="question" style="background-color:#eeeeee">question</pre> </b>
    <p></p>
    <table>
    <tr>
    <td>
       
    <asp:RadioButton ID="rbAns1" runat="server" GroupName="answer" />
    </td>
    <td style="width: 3px">
    <pre runat="server" id="ans1"></pre>
    </td>
    </tr>
    
    <tr>
    <td>
    <asp:RadioButton ID="rbAns2" runat="server" GroupName="answer" />
    </td>
    <td style="width: 3px">
    <pre runat="server" id="ans2"></pre>
    </td>
    </tr>
    
    <tr>
    <td>
    <asp:RadioButton ID="rbAns3" runat="server" GroupName="answer" />
    </td>
    <td style="width: 3px">
    <pre runat="server" id="ans3"></pre>
    </td>
    </tr>
    
    <tr>
    <td>
    <asp:RadioButton ID="rbAns4" runat="server" GroupName="answer" />
    </td>
    <td style="width: 3px">
    <pre runat="server" id="ans4"></pre>
    </td>
    </tr>
    
    </table>
        <br />
        <asp:Button ID="btnPrev" runat="server" Text="Previous" OnClick="btnPrev_Click" />&nbsp;<asp:Button ID="btnNext"
            runat="server" Text="Next" Width="75px" OnClick="btnNext_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel Exam" Width="115px" OnClick="btnCancel_Click" />
        
        <br />
        <br />
        <br />
        


        <fieldset>
                <legend>Results
                    </legend>
            <asp:Panel ID="Panel1" runat="server">
                 <asp:DataList ID="DataList1" runat="server" 
             CssClass="auto-style2" Width="746px"><HeaderTemplate>
   
     <h2>Review Questions</h2>
     <hr size=5 style="color:red" />
    </HeaderTemplate>
            <ItemTemplate>
             
                <pre style="color:Red;background-color:#eeeeee">Answer</pre>
               <asp:RadioButton ID="RadioButton1" runat="server"/><asp:Label ID="NationalityLabel" runat="server"
                    Text='<%# DataBinder.Eval( Container.DataItem,"YourAnswer")%>' />
                
                
   
                
        
        
    
    
 
    
    </ItemTemplate>
   
    
     <SeparatorTemplate>
     <hr size="2" style="color:Red" />
    </SeparatorTemplate>
    
    
    
    <FooterTemplate>
      <hr size=5 style="color:red" />
      
    </FooterTemplate>
    </asp:DataList>
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server">
            </asp:Panel>
            <asp:Panel ID="Panel3" runat="server">
             </asp:Panel>
            <asp:Panel ID="Panel4" runat="server">
             </asp:Panel>
            <asp:Panel ID="Panel5" runat="server">
             </asp:Panel>
            </fieldset>
            
        
    </form>
</body>
</html>

