<%@ Page Title="" Language="C#" MasterPageFile="~/Dorknozzle.master" AutoEventWireup="true" CodeBehind="HelpDesk.aspx.cs" Inherits="Dorknozzle.HelpDesk" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHoder1" runat="server">

    <h2>Employee Help Desk Request</h2>
<p>
Station Number: <br />
<asp:TextBox runat="server" ID="stationTextBox" />
<asp:RequiredFieldValidator ID="stationNumRed" runat="server" Display="None"
 ErrorMessage="<br/> You need to enter a station numner" ControlToValidate="stationTextBox">
</asp:RequiredFieldValidator>
    <ajaxToolkit:ValidatorCalloutExtender ID="stationNumRed_ValidatorCalloutExtender" 
        runat="server" BehaviorID="stationNumRed_ValidatorCalloutExtender" HighlightCssClass="fieldError"
        TargetControlID="stationNumRed">
    </ajaxToolkit:ValidatorCalloutExtender>
<asp:CompareValidator ID="stationNumCheck" runat="server" ErrorMessage="<br/>The valid must be a number"
ControlTovalidate="stationTextBox" Operator="DataTypeCheck" Type="Integer">
</asp:CompareValidator>
</p>
<p>
Problem Category:<br />
<asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" 
        DataTextField="Category" DataValueField="CategoryID">
    </asp:DropDownList>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DorknozzleConnectionString %>" 
        SelectCommand="SELECT * FROM [HelpDeskCategories]"></asp:SqlDataSource>

</p>
<p>
Problem Subject:<br />
<asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource2" 
        DataTextField="Subject" DataValueField="SubjectID">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DorknozzleConnectionString %>" 
        SelectCommand="SELECT * FROM [HelpDeskSubjects]"></asp:SqlDataSource>
</p>
<p>
Problem Description:<br />
<asp:TextBox ID="description" runat="server" runt="server" Columns="40" Rows="4" TextMode="MultiLine"></asp:TextBox>
    <ajaxToolkit:AnimationExtender ID="description_AnimationExtender" 
        runat="server" BehaviorID="description_AnimationExtender" 
        TargetControlID="description">
    </ajaxToolkit:AnimationExtender>
<asp:RequiredFieldValidator ID="descriptionReq" runat="server" ControlToValidate="description" ErrorMessage="<br/> You must enter a description!" Display="Dynamic"></asp:RequiredFieldValidator>
</p>
<p>
 <asp:Button ID="Button1" runat="server" Text="Submit Request" 
        onclick="Button1_Click" />
</p>
</asp:Content>
