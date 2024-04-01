<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Homework_2._Default" %>

<%@ Register TagPrefix="dotnet" Namespace="dotnetCHARTING" Assembly="dotnetCHARTING" %>
<%@ Import Namespace="System.Drawing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="text-align:center">
        <!-- First Chart -->
        <dotnet:Chart id="Chart1" runat="server" />

    </div>
</asp:Content>
