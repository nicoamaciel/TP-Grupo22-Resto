<%@ Page Title="" Language="C#" MasterPageFile="~/MasterResto.Master" AutoEventWireup="true" CodeBehind="MesasUser.aspx.cs" Inherits="RestoAPP.MesasUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />

    <%if (Session["Usuario"] != null && ((Dominio.Login)Session["Usuario"]).NivelAcceso == 1)
        { %>
    <div class="container text-center">
        <div class="mb-3">
            <label for="ddlEmpleado" class="form-label">Meseros:</label>
            <asp:DropDownList ID="DdlMesero" runat="server" classselect="form-select"></asp:DropDownList>
            <asp:Button ID="btnBuscar" runat="server" CssClass="btn-primary" OnClick="btnBuscar_Click" Text="Buscar" />
        </div>
    </div>
    <%} %>
    <div id="cajas" class="container text-center">
        <div class="row row-cols-1 row-cols-md-3 g-4 justify-content-center ">
            <asp:Repeater runat="server" ID="repRepetidor">
                <ItemTemplate>

                    <div>
                        <asp:Button ID="btnMesa" runat="server" Text='<%# Eval("IDmesa") %>' OnClick="btnMesa_Click" CommandArgument='<%# Eval("IDmesa") %>' />
                        </br>
                        <asp:Button ID="btnPagar" runat="server" Text="Pagar" OnClick="btnPagar_Click" CommandArgument='<%# Eval("IDmesa") %>'></asp:Button>
                        <asp:Button ID="BtnCancelarPedido" runat="server" Text="Cancelar" OnClick="BtnCancelarPedido_Click" CommandArgument='<%# Eval("IDmesa") %>'></asp:Button>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
