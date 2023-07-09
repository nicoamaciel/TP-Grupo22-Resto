<%@ Page Title="" Language="C#" MasterPageFile="~/MasterResto.Master" AutoEventWireup="true" CodeBehind="PantallaPedidos.aspx.cs" Inherits="RestoAPP.PantallaPedidos" %>

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
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="criterio" runat="server" />
                    <asp:TextBox runat="server" ID="txtComida" CssClass="form-control" />
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Button ID="BtnFiltrarComida" runat="server" Text="Aceptar" OnClick="BtnFiltrarComida_Click" />
                </div>
            </div>
        </div>

    </div>
    <hr />
    <div id="cajas1" class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater runat="server" ID="Rpt_Comida" OnItemDataBound="Rpt_Comida_ItemDataBound">
            <ItemTemplate>
                <div class="card" style="width: 18rem;">
                    <div class="card-body">
                        <p class="card-text"><%#Eval("descripcion") %> Precio $ <%#Eval("Precio") %></p>
                    </div>
                    <div class="card-body">
                        <asp:CheckBox ID="CbxComida" runat="server" />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <hr />

    <div class="row">
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
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Criterio" runat="server" />
                    <asp:TextBox runat="server" ID="TxtBebida" CssClass="form-control" />
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Button ID="btnBuscarBebida" runat="server" Text="Aceptar" OnClick="btnBuscarBebida_Click" />
                </div>
            </div>
        </div>
    </div>
    <hr />
    <div id="cajas" class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater runat="server" ID="Rpt_Bebida" OnItemDataBound="Rpt_Bebida_ItemDataBound">
            <ItemTemplate>
                <div class="card" style="width: 18rem;">
                    <div class="card-body">
                        <p class="card-text"><%#Eval("descripcion") %> Precio $ <%#Eval("Precio") %></p>
                    </div>
                    <div class="card-body">
                        <asp:CheckBox ID="CbxBebida" runat="server" />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <hr />
    <asp:GridView ID="dgvPedidos" runat="server" DataKeyNames="IDPedido" OnSelectedIndexChanged="dgvPedidos_SelectedIndexChanged"
        CssClass="table table-dark table-brodered" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="IDPedido" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
            <asp:BoundField HeaderText="Mesa" DataField="IDMesa" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
            <asp:BoundField HeaderText="Comida" DataField="Menu" />
            <asp:BoundField HeaderText="Bebida " DataField="Bebida" />
            <asp:BoundField HeaderText="Cuenta" DataField="Cuenta" />
            <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="✍" />
            <asp:CommandField HeaderText="Cancelar" ShowSelectButton="true" SelectText="✍" />
        </Columns>
    </asp:GridView>

    <script>
        function selectOnlyOne(checkbox) {
            var checkboxes = document.querySelectorAll('#<%= Rpt_Comida.ClientID %> input[type="checkbox"]');
            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i] !== checkbox) {
                    checkboxes[i].checked = false;
                }
            }
        }

        function selectOnlyOneBebida(checkbox) {
            var checkboxes = document.querySelectorAll('#<%= Rpt_Bebida.ClientID %> input[type="checkbox"]');
            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i] !== checkbox) {
                    checkboxes[i].checked = false;
                }
            }
        }
    </script>
    <script type="text/javascript">
        function validarComida() {
            var comida = document.getElementById('<%= txtComida.ClientID %>').value;
            if (comida === "") {
                alert("El campo de comida no puede estar vacío.");
                return false;
            }
            return true;
        }

        function validarBebida() {
            var bebida = document.getElementById('<%= TxtBebida.ClientID %>').value;
            if (bebida === "") {
                alert("El campo de bebida no puede estar vacío.");
                return false;
            }
            return true;
        }
    </script>

</asp:Content>
