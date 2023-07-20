<%@ Page Title="" Language="C#" MasterPageFile="~/MasterResto.Master" AutoEventWireup="true" CodeBehind="PantReserva.aspx.cs" Inherits="RestoAPP.PantReserva" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <%if (Session["Usuario"] == null)
                {
            %>
            <div class="container text-center ">
                <h2><strong>Reservación</strong></h2>
                <p>
                    Pasados 30 min despues de la hora de la reservacion la misma quedara anulada.
                </p>
            </div>

            <div class="cssReserva">

                <label for="DdlMesa" class="form-label">Seleccione Mesa</label>
                <br />
                <asp:DropDownList ID="DdlMesa" runat="server"></asp:DropDownList>
                <hr />


                <label for="txtCodigo" class="form-label">Ingrese DNI como codigo de reserva</label>
                <br />
                <asp:TextBox runat="server" ID="TxtCodigo" CssClass="form-control" Width="200px" />
                <hr />


                <label for="txtHora" class="form-label">Fecha de la Reserva:</label>
                <br />
                <asp:TextBox ID="txthora" runat="server" TextMode="DateTimeLocal" Width="200px"></asp:TextBox>
                <hr />


                <label for="txtCantidad" class="form-label">Ingrese cantidad de personas </label>
                <br />
                <asp:TextBox runat="server" ID="TxtCantidad" CssClass="form-control" Width="200px" TextMode="Number" />
                <hr />


                <label for="txtComentario" class="form-label">Ingrese comentario: </label>
                <br />
                <asp:TextBox runat="server" TextMode="MultiLine" ID="txtComentario" CssClass="form-control" Width="400px" />
                <hr />

                <div class="BotonesReservas">
                    <asp:Button Text="Aceptar" ID="btnAceptar" OnClick="btnAceptar_Click" runat="server" />
                    <button type="button" id="btnCancelar" href="/PantallaMenu.aspx">Cancelar</button>
                </div>
                <hr />
            </div>
            <%}
                else
                {%><%if (existen == false)
                       {

                %>
            <asp:Label ID="Label1" runat="server" Text="No existen Reservas por el Momento"></asp:Label>
            <%}
                else
                { %>
            <asp:GridView ID="dgvReserva" runat="server" DataKeyNames="CodigoReserva" CssClass="table table-dark table-brodered" AutoGenerateColumns="false"
                OnRowDeleting="dgvReserva_RowDeleting">
                <Columns>
                    <asp:BoundField HeaderText="IDmesa" DataField="IDmesa" />
                    <asp:BoundField HeaderText="fecha Reserva" DataField="HoraReserva" />
                    <asp:BoundField HeaderText="Codigo de Reserva " DataField="CodigoReserva" />
                    <asp:BoundField HeaderText="Comentario" DataField="Comentario" />
                    <asp:BoundField HeaderText="Cantidad de Clientes" DataField="CantidadClientes" />
                    <asp:CommandField ButtonType="Link" ShowDeleteButton="true" SelectText="✍" />
                </Columns>
            </asp:GridView>

            <%}
                }%>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <script>
        function validarReserva() {
            var textBox = document.getElementById('<%= txthora.ClientID %>');
            var textcantidad = document.getElementById('<%= TxtCantidad.ClientID %>');
            var txtCodigo = document.getElementById('<%= TxtCodigo.ClientID %>');
            var fechaReserva = new Date(textBox.value);
            if (textBox.value === "") {
                alert("Por favor, seleccione la fecha de reserva.");
                return false;
            }
            if (parseInt(textcantidad.value) <= 0) {
                alert("El valor seleccionado para la cantidad debe ser positivo y mayor a 0.");
                return false;
            }
            if (txtCodigo.value === "") {
                alert("Por favor, ingrese su DNI para tener un código de reserva.");
                return false;
            }
            return true;
        }

    </script>
    <script>
        return true;
        }
        var textBox = document.getElementById('<%= txthora.ClientID %>');
        var fechaActual = new Date();
        var fechaMinima = new Date();
        fechaMinima.setDate(fechaActual.getDate() + 1);
        fechaMinima.setHours(0, 0, 0, 0);
        var fechaMaxima = new Date();
        fechaMaxima.setDate(fechaActual.getDate() + 15);
        fechaMaxima.setHours(23, 0, 0, 0);
        textBox.min = fechaMinima.toISOString().slice(0, -8);
        textBox.max = fechaMaxima.toISOString().slice(0, -8);
    </script>
</asp:Content>
