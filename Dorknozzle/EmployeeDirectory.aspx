<%@ Page Title="" Language="C#" MasterPageFile="~/Dorknozzle.master" AutoEventWireup="true" CodeBehind="EmployeeDirectory.aspx.cs" Inherits="Dorknozzle.EmployeeDirectory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHoder1" runat="server">
<h1> Employee Directory</h1>
    <asp:DataList ID="employeeList" runat="server" 
        onitemcommand="employeeList_ItemCommand">
    <ItemTemplate>
    <asp:Literal ID="extraDetailsLiteral" runat="server" EnableViewState="false" />
    Name: <strong><%#Eval ("Name") %></strong><br />
    Username: <strong><%#Eval ("Username") %></strong><br />
    <asp:LinkButton ID="detailsButton" runat ="server" Text=<%#"View more details about " +Eval("Name") %>
    CommandName ="MoreDetailsPlease" CommandArgument='<%#Eval("EmployeeID") + ";" +Eval("City")+";"+ Eval("State")%>' /><br />
     <asp:LinkButton ID="editButton" runat ="server" Text=<%#"Edit information about " +Eval("Name") %>
    CommandName ="editInfor" CommandArgument= <%#Eval("EmployeeID")%> />
    </ItemTemplate>


    <EditItemTemplate>
    Name: <asp:TextBox ID="nameTextBox" runat="server" Text=<%#Eval("Name") %> /><br />
    Username: <asp:TextBox ID="usernameTextBox" runat="server" Text=<%#Eval("Username") %> /><br />
    <asp:LinkButton ID="uptateButton" runat="server" Text ="Update" CommandName="UpdateItem" CommandArgument=<%#Eval("EmployeeID") %> />
    <asp:LinkButton ID="cancelButton" runat="server" Text ="Cancel" CommandName="CancelItem" CommandArgument=<%#Eval("EmployeeID") %> />
    </EditItemTemplate>
    <SeparatorTemplate>
    <hr/></SeparatorTemplate>
    </asp:DataList>
</asp:Content>
