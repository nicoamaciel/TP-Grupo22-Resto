<%@ Page Title="" Language="C#" MasterPageFile="~/MasterResto.Master" AutoEventWireup="true" CodeBehind="PantModBebidas.aspx.cs" Inherits="RestoAPP.PantModBebidas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <div class="row ">
        <div class="col-6 vstack gap-2 col-md-5 mx-auto">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" Enabled="false" />
            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio: </label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripcion: </label>
                <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtTipoBebida" class="form-label">Tipo Bebida: </label>
                <asp:TextBox runat="server" ID="txtTipoBebida" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" runat="server" />
                <a href="/PantallaMenu.aspx">Cancelar</a>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="mb-3">
                    <label for="txtImagenUrl" class="form-label">Url Imagen</label>
                    <asp:TextBox runat="server" ID="txtImagenUrl" CssClass="form-control"
                        AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged" />
                </div>
                <asp:Image ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png"
                    runat="server" ID="imgBebida" Width="60%" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <script type="text/javascript">
        function validarPrecio() {
            var Cantidad = document.getElementById('<%= txtPrecio.ClientID %>').value;
            if (bebida === "") {
                alert("El Precio no puede estar vacío o ser 0.");
                return false;
            }
            if (isNaN(parseFloat(Cantidad)) && parseFloat(Cantidad) > 0) {
                alert("El valor seleccionado para el precio debe ser numérico o mayor a 0.");
                return false;
            }

            return true;
        }

    </script>
</asp:Content>
