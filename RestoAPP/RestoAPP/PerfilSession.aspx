<%@ Page Title="" Language="C#" MasterPageFile="~/MasterResto.Master" AutoEventWireup="true" CodeBehind="PerfilSession.aspx.cs" Inherits="RestoAPP.PerfilSession" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap/5.3.0/css/bootstrap.min.css" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap/5.3.0/js/bootstrap.bundle.min.js"></script>
    <style>
        .modal-dialog-centered {
            display: flex;
            align-items: center;
            min-height: calc(100% - (0.5rem * 2));
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="position-absolute top-50 start-50 translate-middle">
        <%if (ListaEmpleados.Count > 0)
            {%>
        <div class="card text-center mb-3" style="width: 18rem;">
            <div class="card-body">
                <h5 class="card-title"><%=ListaEmpleados[0].Nombre +" "+ ListaEmpleados[0].Apellido%></h5>
                <p class="card-text">Dni: <%=ListaEmpleados[0].Dni%></p>
                <p class="card-text">Cargo: <%=ListaEmpleados[0].Cargo%></p>
                <p class="card-text">Sueldo: <%=ListaEmpleados[0].sueldo%></p>
                <p class="card-text">Turno: <%=ListaEmpleados[0].Turno%></p>
                <p class="card-text">Codigo: <%=ListaEmpleados[0].Codigo%></p>
            </div>
            <div>
                <asp:Button runat="server" Text="Cerrar Session" ID="btnCerrar" CssClass="btn btn-primary" OnClick="btnCerrar_Click" />
                <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#modalEditarPerfil">
                    Cambiar Datos de la Sesión
                </button>
            </div>
        </div>
        <% }%>
    </div>
    <!-- Modal para edición de perfil -->
    <div class="modal fade" id="modalEditarPerfil" tabindex="-1" role="dialog" aria-labelledby="modalEditarPerfilLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalEditarPerfilLabel">Editar perfil</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <label for="txtNombreUsuario">Nombre de usuario:</label>
                    <input type="text" id="txtNombreUsuario" class="form-control" />
                    <label for="txtContraseña">Contraseña actual:</label>
                    <input type="password" id="txtContraseña" class="form-control" />
                    <label for="txtContraseñaNueva">Contraseña nueva:</label>
                    <input type="password" id="TextPassNew" class="form-control" />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                    <button type="button" class="btn btn-primary" id="btnGuardar">Guardar</button>
                </div>
            </div>
        </div>
    </div>
    <script>
        document.getElementById('btnGuardar').addEventListener('click', function () {
            var nombreUsuario = $("#txtNombreUsuario").val();
            var contraseña = $("#txtContraseña").val();
            var PassNew = $('#TextPassNew').val();

            // Realizar las validaciones necesarias antes de guardar
            if (contraseña != "" || contraseña != '<%= ((Dominio.Login)Session["Usuario"]).Contraseña %>') {
                // Actualizar los valores en el objeto Login almacenado en Session
                var login = <%= ((Dominio.Login)Session["Usuario"]) %>;
                login.Usuario = nombreUsuario;
                login.Contraseña = PassNew;

            // Actualizar el objeto Login en Session
            <%= $"Session.Remove(\"Usuario\");" %>
            <%= $"Session.Add(\"Usuario\", login);" %>
            } else {
            // Mostrar mensaje de error
            <%= $"Session.Add(\"Error\", \"La contraseña es incorrecta o no se ha ingresado nada.\");" %>
                window.location.href = "Error.aspx";
            }

            // Cerrar el modal
            var modal = new bootstrap.Modal(document.getElementById('modalEditarPerfil'));
            modal.hide();
        });
    </script>
</asp:Content>
