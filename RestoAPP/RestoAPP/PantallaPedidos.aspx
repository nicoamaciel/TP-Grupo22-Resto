<%@ Page Title="" Language="C#" MasterPageFile="~/MasterResto.Master" AutoEventWireup="true" CodeBehind="PantallaPedidos.aspx.cs" Inherits="RestoAPP.PantallaPedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center ">
        <h2>Pedido Mesa</h2>
        <h5 class="card-title"><%#Eval("") %></h5>
    </div>
    <div class="container text-center">
        <div class="btn-group " role="group" aria-label="Basic outlined example">
            <asp:Button ID="BtnPedido" class="btn btn-outline-primary" OnClick="BtnPedido_Click" runat="server" Text="Cargar Pedido" />
            <asp:Button ID="ButtonListar" class="btn btn-outline-primary" OnClick="ButtonListar_Click" runat="server" Text="Listar Pedidos" />
        </div>

    </div>




</asp:Content>
