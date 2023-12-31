﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterResto.Master" AutoEventWireup="true" CodeBehind="PantallaPedidos.aspx.cs" Inherits="RestoAPP.PantallaPedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
     <div class="container text-center ">
        <h2>Pedido Mesa</h2>
        <h5 class="card-title">
            <asp:TextBox runat="server" ID="TxtIDMesa" CssClass="form-control" Enabled="false" />
        </h5>
    </div>
    <div class="container text-center">
        <div class="btn-group " role="group" aria-label="Basic outlined example">
            <asp:Button ID="ButtonListar" class="btn btn-outline-primary" OnClick="ButtonListar_Click" runat="server" Text="Listar Pedidos" />
            <asp:Button ID="BtnAgregarPedido" class="btn btn-outline-primary" OnClick="BtnAgregarPedido_Click" runat="server" Text="Agregar Pedido" />

        </div>

    </div>
    <hr />
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Campo" ID="lblCampo" runat="server" />
                <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-select" ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                    <asp:ListItem Text="Todos" />
                    <asp:ListItem Text="Tipo" />
                    <asp:ListItem Text="Precio" />
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Criterio" runat="server" />
                <asp:DropDownList runat="server" ID="ddlCriterio" AutoPostBack="true" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:TextBox runat="server" ID="txtComida" CssClass="form-control" />
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Button ID="BtnFiltrarComida" runat="server" Text="Filtrar Menu" OnClick="BtnFiltrarComida_Click" />

                <asp:DropDownList runat="server" ID="DdlComida" CssClass="form-select"></asp:DropDownList>
            </div>
        </div>
    </div>
    <hr />

    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Mostrar por:" ID="Label1" runat="server" />
                <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-select" ID="DdlCamposBebidas" OnSelectedIndexChanged="DdlCamposBebidas_SelectedIndexChanged">
                    <asp:ListItem Text="Todos" />
                    <asp:ListItem Text="Precio" />
                    <asp:ListItem Text="Descripcion" />
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Criterio" runat="server" />
                <asp:DropDownList runat="server" AutoPostBack="true" ID="DdlCriterioBebida" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:TextBox runat="server" ID="TxtBebida" CssClass="form-control" />
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Button ID="btnBuscarBebida" runat="server" Text="Filtrar Bebidas" OnClick="btnBuscarBebida_Click" />
                <asp:DropDownList ID="DdlBebida" runat="server"></asp:DropDownList>
            </div>
        </div>
    </div>
    <hr />
    <asp:GridView ID="dgvPedidos" runat="server" DataKeyNames="IDPedido" OnSelectedIndexChanged="dgvPedidos_SelectedIndexChanged" OnRowDeleting="dgvPedidos_RowDeleting"
        CssClass="table table-dark table-brodered" AutoGenerateColumns="false" OnRowDataBound="dgvPedidos_RowDataBound">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="IDPedido" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
            <asp:BoundField HeaderText="Mesa" DataField="IDMesa" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
            <asp:BoundField HeaderText="Comida" DataField="Plato.descripcion" />
            <asp:BoundField HeaderText="Precio" DataField="plato.Precio" />
            <asp:BoundField HeaderText="Bebida " DataField="Bebida.descripcion" />
            <asp:BoundField HeaderText="Precio" DataField="bebida.Precio" />
            <asp:BoundField HeaderText="Total" DataField="Cuenta" />
            <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="✍" ButtonType="Button" />
            <asp:CommandField HeaderText="Cancelar" ShowDeleteButton="true" SelectText="✍" ButtonType="Button" />
        </Columns>
    </asp:GridView>


    <script type="text/javascript">
        function validarComida() {
            var comida = document.getElementById('<%= txtComida.ClientID %>').value;
            var ddlCamposComida = document.getElementById('<%= ddlCampo.ClientID %>');
            var selectedOption = ddlCamposComida.options[ddlCamposComida.selectedIndex].value;
            if (comida === "" && selectedOption === "Precio") {
                alert("El campo de comida no puede estar vacío cuando el campo seleccionado es 'Precio'.");
                return false;
            }
            if (selectedOption === "Precio") {
                var comida = document.getElementById('<%= txtComida.ClientID %>').value;

                if (isNaN(parseFloat(comida))) {
                    alert("El valor seleccionado para el precio debe ser numérico.");
                    return false;
                }
            }
            return true;
        }
        function validarBebida() {
            var bebida = document.getElementById('<%= TxtBebida.ClientID %>').value;
            var ddlCamposBebidas = document.getElementById('<%= DdlCamposBebidas.ClientID %>');
            var selectedOption = ddlCamposBebidas.options[DdlCamposBebidas.selectedIndex].value;
            if (bebida === "" && selectedOption != "Todos") {
                alert("El campo de bebida no puede estar vacío.cuando el campo seleccionado es 'Precio'.");
                return false;
            }
            if (selectedOption != "Todos") {
                if (isNaN(parseFloat(bebida))) {
                    alert("El valor seleccionado para el precio debe ser numérico.");
                    return false;
                }
            }
            return true;
        }

    </script>

</asp:Content>
