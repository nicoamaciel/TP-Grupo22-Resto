<%@ Page Title="" Language="C#" MasterPageFile="~/MasterResto.Master" AutoEventWireup="true" CodeBehind="PantallaPedidos.aspx.cs" Inherits="RestoAPP.PantallaPedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container text-center ">
                <div class="card-title">
                    <h3>Pedido para mesa: </h3>
                    <asp:TextBox runat="server" ID="TxtIDMesa" CssClass="form-control" Enabled="false" Width="100px" />
                </div>
                <div class="btn-group " role="group" aria-label="Basic outlined example">

                    <asp:Button ID="Button2" class="btn btn-outline-primary" OnClick="BtnAgregarPedido_Click" runat="server" Text="Agregar Pedido" />
                </div>
            </div>
            <hr />


            <div class="container text-center">
                <div class="row">
                    <div class="col">
                        <div class="cssPedirPlato">

                            <asp:Label Text="Buscar plato: " runat="server" Width="200px" text-align="left" />
                            <br />
                            <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-select" ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" Width="200px">
                                <asp:ListItem Text="Todos" />
                                <asp:ListItem Text="Tipo" />
                                <asp:ListItem Text="Precio" />
                            </asp:DropDownList>
                            <br />
                            <asp:DropDownList runat="server" ID="ddlCriterio" AutoPostBack="true" CssClass="form-select" Width="200px"></asp:DropDownList>
                            <br />
                            <asp:Label Text="Ingrese cantidad: " ID="lblCampo" runat="server" Width="200px" />
                            <asp:TextBox runat="server" ID="txtComida" CssClass="form-control" Width="200px" TextMode="Number" />
                            <br />
                            <asp:Button ID="BtnFiltrarComida" runat="server" Text="Filtrar Menu" OnClick="BtnFiltrarComida_Click" Width="200px" />
                            <hr />
                            <asp:DropDownList runat="server" ID="DdlComida" CssClass="form-select" Width="200px"></asp:DropDownList>


                        </div>
                    </div>
                    <div class="col">
                        <%--BEBIDAS--%>
                        <div class="cssPedirBebida">

                            <asp:Label Text="Buscar bebida: " runat="server" Width="200px" />
                            <br />
                            <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-select" ID="DdlCamposBebidas" OnSelectedIndexChanged="DdlCamposBebidas_SelectedIndexChanged" Width="200px">
                                <asp:ListItem Text="Todos" />
                                <asp:ListItem Text="Precio" />
                                <asp:ListItem Text="Descripcion" />
                            </asp:DropDownList>
                            <br />
                            <asp:DropDownList runat="server" AutoPostBack="true" ID="DdlCriterioBebida" CssClass="form-select" Width="200px"></asp:DropDownList>
                            <br />
                            <asp:Label Text="Ingrese cantidad:" ID="Label1" runat="server" Width="200px" />
                            <asp:TextBox runat="server" ID="TxtBebida" CssClass="form-control" Width="200px" TextMode="Number" />
                            <br />
                            <asp:Button ID="btnBuscarBebida" runat="server" Text="Filtrar Bebidas" OnClick="btnBuscarBebida_Click" Width="200px" />
                            <hr />
                            <asp:DropDownList ID="DdlBebida" runat="server" CssClass="form-control" Width="200px"></asp:DropDownList>


                        </div>
                    </div>

                </div>
            </div>


            <br />
            <div class="container text-center">
                <div class="btn-group " role="group" aria-label="Basic outlined example">
                    <asp:Button ID="ButtonListar" class="btn btn-outline-success" OnClick="ButtonListar_Click" runat="server" Text="Listar Pedidos" />
                    <asp:Button ID="Button1" class="btn btn-outline-success" runat="server" Text="Limpiar mesa" />
                    <asp:Button ID="BtnAgregarPedido" class="btn btn-outline-success" OnClick="BtnAgregarPedido_Click" runat="server" Text="Agregar Pedido" />
                </div>
            </div>

            <br />
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
        </ContentTemplate>
    </asp:UpdatePanel>

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
