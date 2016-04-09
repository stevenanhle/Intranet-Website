<%@ Page Title="" Language="C#" MasterPageFile="~/Dorknozzle.master" AutoEventWireup="true" CodeBehind="AdminTools.aspx.cs" Inherits="Dorknozzle.AdminTools" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHoder1" runat="server">
Select an employee to update: <br />
    <asp:DropDownList ID="Employee" runat="server" AutoPostBack="True" 
        onselectedindexchanged="Employee_SelectedIndexChanged">
    </asp:DropDownList>

    <br />
    <br />
    <br />
    <span class="updateLabel">Name:</span><asp:TextBox ID="Name" runat="server"></asp:TextBox>
    <asp:Label ID="erroLabel" runat="server"></asp:Label>
    <br />
    <span class="updateLabel">Username:</span><asp:TextBox ID="Username" runat="server"></asp:TextBox><br />
    <span class="updateLabel">Department:</span><asp:TextBox ID="Department" runat="server"></asp:TextBox><br />
    <span class="updateLabel">Telephone:</span><asp:TextBox ID="Telephone" runat="server"></asp:TextBox><br />
    <span class="updateLabel">City:</span><asp:TextBox ID="City" runat="server"></asp:TextBox><br />
    <span class="updateLabel">State:</span><asp:TextBox ID="State" runat="server"></asp:TextBox><br />
    <asp:Button ID="Update" runat="server" Text="Update Employee" 
        onclick="Update_Click" />
</asp:Content>
