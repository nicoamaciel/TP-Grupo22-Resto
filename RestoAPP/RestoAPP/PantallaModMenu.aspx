<%@ Page Title="" Language="C#" MasterPageFile="~/MasterResto.Master" AutoEventWireup="true" CodeBehind="PantallaModMenu.aspx.cs" Inherits="RestoAPP.PantallaModMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="cssModMenu">

        <label for="txtId" class="form-label">Id</label>
        <asp:TextBox runat="server" ID="txtId" CssClass="form-control" Enabled="false" />

        <label for="ddlTipo" class="form-label">Tipo de Plato: </label>
        <asp:DropDownList ID="ddlTipo" CssClass="form-select" runat="server"></asp:DropDownList>

        <label for="txtPrecio" class="form-label">Precio: </label>
        <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />


        <label for="txtDescripcion" class="form-label">Descripcion: </label>
        <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" />


        <label for="txtClase" class="form-label">Clase: </label>
        <asp:TextBox runat="server" ID="txtClase" CssClass="form-control" />

        <br />
        <div class="row">
            <asp:Button Text="Aceptar" ID="btnAceptar" OnClick="btnAceptar_Click" runat="server" />
            <asp:Button Text="Cancelar" ID="btnCancelar" runat="server" />

        </div>
        <hr />


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
    <div class="row">
        <div class="col-6">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger" runat="server" />
                    </div>

                    <%if (ConfirmaEliminacion)
                        { %>
                    <div class="mb-3">
                        <asp:CheckBox Text="Confirmar Eliminación" ID="chkConfirmaEliminacion" runat="server" />
                        <asp:Button Text="Eliminar" ID="btnConfirmaEliminar" OnClick="btnConfirmaEliminar_Click" CssClass="btn btn-outline-danger" runat="server" />
                    </div>
                    <%} %>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>
</asp:Content>
