<%@ Page Title="" Language="C#" MasterPageFile="~/MasterResto.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="RestoAPP.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <a>Error</a>
    <asp:Label Text="text" ID="lblError" runat="server" />
    <a href="PantallaMenu.aspx" class="btn btn-primary">VOLVER</a>
    <script>
        function redirigir() {
            window.location.href = "PantallaMenu.aspx";
        }
        setTimeout(redirigir, 5000);
    </script>
</asp:Content>
