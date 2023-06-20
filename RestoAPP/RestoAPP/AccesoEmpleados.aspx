<%@ Page Title="" Language="C#" MasterPageFile="~/MasterResto.Master" AutoEventWireup="true" CodeBehind="AccesoEmpleados.aspx.cs" Inherits="RestoAPP.AccesoEmpleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Para Ingresar debes loguearte</h1>

    <h2>Usuario</h2>
    <asp:TextBox ID="TextUser" runat="server"></asp:TextBox>

    <h2>Pass</h2>
    <asp:TextBox ID="TextPass" runat="server" TextMode="Password"></asp:TextBox>

    <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />

</asp:Content>

