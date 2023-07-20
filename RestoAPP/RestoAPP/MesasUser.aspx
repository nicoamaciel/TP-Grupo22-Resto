<%@ Page Title="" Language="C#" MasterPageFile="~/MasterResto.Master" AutoEventWireup="true" CodeBehind="MesasUser.aspx.cs" Inherits="RestoAPP.MesasUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <%if (Session["Usuario"] != null && ((Dominio.Login)Session["Usuario"]).NivelAcceso == 1)
                { %>
            <div class="container text-center">
                <div class="mb-3">
                    <label for="ddlEmpleado" class="form-label">Turno:</label>
                    <asp:DropDownList ID="DdlTurno" runat="server" classselect="form-select" AutoPostBack="true" OnSelectedIndexChanged="DdlTurno_SelectedIndexChanged">
                        <asp:ListItem Text="Ambos Turnos" />
                        <asp:ListItem Text="Mañana/Tarde" />
                        <asp:ListItem Text="Noche" />
                    </asp:DropDownList>
                    <label for="ddlEmpleado" class="form-label">Meseros:</label>
                    <asp:DropDownList ID="DdlMesero" runat="server" classselect="form-select"></asp:DropDownList>
                    <asp:Button ID="btnBuscar" runat="server" CssClass="btn-primary" OnClick="btnBuscar_Click" Text="Buscar" />
                    <asp:Button ID="btnCambiarMesas" runat="server" CssClass="btn-primary" OnClick="btnCambiarMesas_Click" Text="Modificar/Agregar Mesas" />
                </div>
            </div>
            <%}
            %>
            <div class="buscarReserva">
                <asp:Button ID="BtnReserva" runat="server" Text="Buscar reserva" OnClick="BtnReserva_Click" />
                <asp:TextBox ID="TxtReserva" runat="server"></asp:TextBox>
                <hr />
            </div>

            <div id="cajas" class="container text-center">
                <div class="row row-cols-1 row-cols-md-3 g-4 justify-content-center ">
                    <asp:Repeater runat="server" ID="repRepetidor">
                        <ItemTemplate>
                            <div>
                                <asp:Button ID="btnMesa" runat="server" Text='<%#Eval("descripcion") %>' OnClick="btnMesa_Click" CommandArgument='<%# Eval("IDmesa") %>' />
                                </br>
                        <asp:Button ID="btnPagar" runat="server" Text="Pagar" OnClick="btnPagar_Click" CommandArgument='<%# Eval("IDmesa") %>'></asp:Button>
                                <asp:Button ID="BtnCancelarPedido" runat="server" Text="Cancelar" OnClick="BtnCancelarPedido_Click" CommandArgument='<%# Eval("IDmesa") %>'></asp:Button>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
