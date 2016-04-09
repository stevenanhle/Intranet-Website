<%@ Page Title="" Language="C#" MasterPageFile="~/Dorknozzle.master" AutoEventWireup="true" CodeBehind="AdminNewsletter.aspx.cs" Inherits="Dorknozzle.AdminNewsletter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHoder1" runat="server">
<h1>Create Newsletter</h1>
<p1>
 <asp:Label ID="resultLabel" runat="server" ForeColor="Red" />
</p1>
<p>
To:<br />
<asp:TextBox ID="toTextBox" runat="server" />
</p>
<p>
Subject:<br/>
<asp:TextBox ID="subjectTextBox" runat="server" />
</p>
<p>
Introduction:<br />
<asp:TextBox ID="introTextBox" runat="server" TextMode="MultiLine" Width="300" Height="100" />
</p>
<p>
Employee of The Month:<br />
<asp:TextBox ID="employeeTextBox" runat="server" />
</p>
<p>
Featured Event:<br />
<asp:TextBox ID="eventTextBox" runat="server" />
</p>
<p>
<asp:Button ID="sendNewsLetterButton" runat="server" Text="Send Newsletter" 
        onclick="sendNewsLetterButton_Click" />
</p>
</asp:Content>
