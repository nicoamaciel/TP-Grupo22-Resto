<%@ Page Title="" Language="C#" MasterPageFile="~/MasterResto.Master" AutoEventWireup="true" CodeBehind="PerfilSession.aspx.cs" Inherits="RestoAPP.PerfilSession" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="position-absolute top-50 start-50 translate-middle">
        <asp:Repeater runat="server" ID="repEmpleados" >
            <ItemTemplate>
                <div class="card text-center mb-3" style="width: 18rem;">
                    <div class="card-body">
                        <h5 class="card-title"><%# Eval("Nombre") %> <%# Eval("Apellido") %></h5>
                        <p class="card-text">Dni: <%# Eval("Dni") %></p>
                        <p class="card-text">Cargo: <%# Eval("Cargo") %></p>
                        <p class="card-text">Sueldo: <%# Eval("Sueldo") %></p>
                        <p class="card-text">Turno: <%# Eval("Turno") %></p>
                        <p class="card-text">Codigo: <%# Eval("Codigo") %></p>
                    </div>
                    <div>
                        <asp:Button runat="server" Text="Cerrar Sesión" ID="btnCerrar" CssClass="btn btn-primary" OnClick="btnCerrar_Click" />
                        <asp:Button runat="server" Text="Cambiar Datos de la Sesión" ID="BtnCambiar" CssClass="btn btn-primary" OnClick="BtnCambiar_Click" />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>
    <%if (Cambiar == true)
        { %>
    <div class="card text-center mb-3" role="document">
        <h5 class="card-title">Editar perfil</h5>
        <div class="card-body">
            <label for="txtNombreUsuario">Nombre de usuario:</label>
            <asp:TextBox runat="server" ID="txtNombreUsuario" class="form-control" />
            <label for="txtContraseña">Contraseña actual:</label>
            <asp:TextBox runat="server" type="password" ID="txtContraseña" class="form-control" />

            <label for="txtContraseñaNueva">Contraseña nueva:</label>
            <asp:TextBox runat="server" ID="TxtPassNew" class="form-control" />

        </div>
        <div class="card-footer">
            <asp:Button runat="server" ID="BtnCancelar" class="btn btn-secondary" Text="Cerrar" OnClick="BtnCancelar_Click" />
            <asp:Button runat="server" class="btn btn-primary" ID="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click" />
        </div>
    </div>
    <% }%>
</asp:Content>
