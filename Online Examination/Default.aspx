<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OnlineExam._Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>
<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Modify this template to jump-start your ASP.NET application.</h2>
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
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
        
   <hgroup class="title">        
        <h2>Use the form below to create a new account.</h2>
    </hgroup>

                        
                        <fieldset>

                        <legend>SIGN UP</legend>

                        <ol>
                            <li>
                                <asp:Label runat="server" >First Name</asp:Label>
                                <asp:TextBox runat="server" ID="fname" />
                                <asp:RequiredFieldValidator runat="server" ErrorMessage="The first name field is required." ControlToValidate="fname" CssClass="field-validation-error"></asp:RequiredFieldValidator>                                
                            </li>
                            <li>
                                <asp:Label runat="server" >Last Name</asp:Label>
                                <asp:TextBox runat="server" ID="lname" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="lname"
                                    CssClass="field-validation-error" ErrorMessage="The last name field is required." />                              
                            </li>
                            <li>
                                <asp:Label runat="server" >User name</asp:Label>
                                <asp:TextBox runat="server" ID="UserName" AutoPostBack="True" OnTextChanged="Username_Changed" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                                    CssClass="field-validation-error" ErrorMessage="The user name field is required." />

                                <asp:Label runat="server" CssClass="field-validation-error" ID="Username_available"/>
                            </li>
                            <li>
                                <asp:Label runat="server" >Email address</asp:Label>
                                <asp:TextBox runat="server" ID="Email" TextMode="Email" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                    CssClass="field-validation-error" ErrorMessage="The email address field is required." />
                            </li>
                            
                            
                                <li>
                                <asp:Label runat="server" >Password</asp:Label> 
                                <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>                              
                                <asp:PasswordStrength ID="PasswordStrength1" runat="server" TargetControlID="Password" StrengthIndicatorType="BarIndicator"></asp:PasswordStrength>                        
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="field-validation-error" ErrorMessage="The password field is required." />
                                </li>
                            
                            <li>
                                <asp:Label runat="server" >Confirm password</asp:Label>
                                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                                     CssClass="field-validation-error" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                     CssClass="field-validation-error" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                            </li>
                            <li>
                            
                                <asp:Label runat="server" >Profile Image</asp:Label>
                                <asp:AsyncFileUpload ID="AsyncFileUpload1" UploadingBackColor="#82CAFA" CompleteBackColor = "green" OnUploadedComplete="doUpload" OnClientUploadComplete="clientMessage" ThrobberID="Throbber" runat="server" />                           
                                <asp:Image ID="Throbber"   ImageUrl = "~/Images/throbber.gif" runat="server"  />
                                <asp:Label ID="Label3" runat="server"></asp:Label>
                            </li>
                            <li>
                            <a href="#A2"  id="A1">Terms & Conditions</a><br><br>
                            <asp:CheckBox ID="terms" runat="server" />
                            </li>
                            <li>
                            <recaptcha:RecaptchaControl ID="recaptcha" runat="server" PrivateKey="6Le-at0SAAAAAB_rsjFJNIPn2mt48JAjqwVAJF7j" PublicKey="6Le-at0SAAAAAPl-x1HnnvMudDiQwrhBuWIOub7U" Theme="clean" />  
                            <asp:Label ID="captcharesult" runat="server"  CssClass="field-validation-error" Visible="false" ></asp:Label>
                            </li>
                        </ol>
                        <asp:Button runat="server" CommandName="MoveNext" Text="Register" OnClick="Register" />
                    </fieldset>
        
</asp:Content>
