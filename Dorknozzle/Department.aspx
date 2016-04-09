<%@ Page Title="" Language="C#" MasterPageFile="~/Dorknozzle.master" AutoEventWireup="true" CodeBehind="Department.aspx.cs" Inherits="Dorknozzle.Department" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHoder1" runat="server">
<h1>Dorknozzle</h1>
<asp:GridView ID="departmentGrid" runat="server" AllowPaging="True" 
        onpageindexchanging="departmentGrid_PageIndexChanging" PageSize="4" 
        AllowSorting="True" onsorting="departmentGrid_Sorting">
</asp:GridView>
</asp:Content>
