<%@ Page Title="" Language="C#" MasterPageFile="~/MasterResto.Master" AutoEventWireup="true" CodeBehind="PantallaModMenu.aspx.cs" Inherits="RestoAPP.PantallaModMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="cssModMenu">

        <label for="txtId" class="form-label">Id</label>
        <asp:TextBox runat="server" ID="txtId" CssClass="form-control" Enabled="false" Width="300px" />

        <label for="ddlTipo" class="form-label">Tipo de Plato: </label>
        <asp:DropDownList ID="ddlTipo" CssClass="form-select" runat="server" Width="300px">
            <asp:ListItem Text="Comida Fria" />
            <asp:ListItem Text="Comida Caliente" />
            <asp:ListItem Text="Postre Frio" />
            <asp:ListItem Text="Postre Caliente" />
        </asp:DropDownList>

        <label for="txtPrecio" class="form-label">Precio: </label>
        <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" Width="300px" />


        <label for="txtDescripcion" class="form-label">Descripcion: </label>
        <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" Width="300px" />


        <br />
        <label for="DdlClase" class="form-label">Clase: </label>
        <asp:DropDownList ID="DdlClase" runat="server" Width="300px">
            <asp:ListItem Text="Entrada" />
            <asp:ListItem Text="Principal" />
            <asp:ListItem Text="Postre" />
        </asp:DropDownList>
    </div>
    <br />
    <div class="row">
        <asp:Button Text="Aceptar" ID="btnAceptar" OnClick="btnAceptar_Click" runat="server" />
        <asp:Button Text="Cancelar" ID="btnCancelar" runat="server" />

    </div>
    <hr />

    <div="row">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <label for="txtImagenUrl" class="form-label">Url Imagen</label>
            <asp:TextBox runat="server" ID="txtImagenUrl" CssClass="form-control"
                AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged" />

            <asp:Image ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png"
                runat="server" ID="imgMenu" Width="60%" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </div>
    <script type="text/javascript">
        function validarPrecio() {
            var Cantidad = document.getElementById('<%= txtPrecio.ClientID %>').value;
            if (bebida === "" || parseInt(bebida) <= 0) {
                alert("El Precio no puede estar vacío o ser 0.");
                return false;
            }

            return true;
        }

    </script>

</asp:Content>
