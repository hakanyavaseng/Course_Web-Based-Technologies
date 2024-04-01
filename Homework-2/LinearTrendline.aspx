<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinearTrendline.aspx.cs" Inherits="Homework_2.LinearTrendline" %>

<%@ Register TagPrefix="dotnet" Namespace="dotnetCHARTING" Assembly="dotnetCHARTING" %>
<%@ Import Namespace="System.Drawing" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Trend Line</title>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
             <dotnet:Chart ID="Chart" runat="server" Width="568px" Height="344px">
	   </dotnet:Chart>
        </div>
    </form>
</body>
</html>
