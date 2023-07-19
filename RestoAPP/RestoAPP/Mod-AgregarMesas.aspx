<%@ Page Title="" Language="C#" MasterPageFile="~/MasterResto.Master" AutoEventWireup="true" CodeBehind="Mod-AgregarMesas.aspx.cs" Inherits="RestoAPP.Mod_AgregarMesas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>


    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <hr />
            <div class="card text-center">
                <asp:Button ID="BtnAgregar" runat="server" Text="Aregar Mesa" OnClick="BtnAgregar_Click" />
                <div class="mb-3">
                    <asp:Label ID="LblTamaño" runat="server" Text="Tamaño de la Mesa"></asp:Label>
                    <asp:TextBox ID="TxtTamaño" runat="server" CssClass="form-Control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="LblDescrip" runat="server" Text="Descripcion"></asp:Label>
                    <asp:TextBox ID="TxtDescripcion" runat="server" CssClass="form-Control"></asp:TextBox>
                </div>


                <div>
                    <asp:Label ID="LblTurno" runat="server" Text="Turnos"></asp:Label>
                    <asp:DropDownList ID="DdlTurnos" runat="server" OnSelectedIndexChanged="DdlTurnos_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Text="Ambos Turnos" />
                        <asp:ListItem Text="8 a 16:00" />
                        <asp:ListItem Text="16:00 a 23:00" />
                    </asp:DropDownList>
                </div>
                <div class="card">
                    <asp:Label ID="Label1" runat="server" Text="Meseros Disponibles"></asp:Label>
                </div>
                <div class="mb-3">
                    <asp:DropDownList ID="DdlMesero" runat="server" CssClass="form-select" AutoPostBack="true"></asp:DropDownList>
                </div>
            </div>
            <hr />
            <asp:GridView ID="DgvMesas" runat="server" DataKeyNames="IDMesa" OnSelectedIndexChanged="DgvMesas_SelectedIndexChanged" OnRowDeleting="DgvMesas_RowDeleting" OnRowEditing="DgvMesas_RowEditing"
                CssClass="table table-Blue table-brodered" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="IDMesa" DataField="IDMesa" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
                    <asp:BoundField HeaderText="Tamaño" DataField="TamañoMesa" />
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                    <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkEstado" runat="server" Checked='<%# Convert.ToBoolean(Eval("Activo")) %>' Enabled="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Nombre" DataField="Empleado.Nombre" />
                    <asp:BoundField HeaderText="Apellido" DataField="Empleado.Apellido" />
                    <asp:BoundField HeaderText="Turno" DataField="Empleado.Turno" />
                    <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="✍" ButtonType="Button" />
                    <asp:CommandField HeaderText="Cambiar Mesero" ShowEditButton="true" SelectText="✍" ButtonType="Button" />
                    <asp:CommandField HeaderText="Eliminar Mesa" ShowDeleteButton="true" SelectText="✍" ButtonType="Button" />
                </Columns>
            </asp:GridView>





        </ContentTemplate>

    </asp:UpdatePanel>

    <script type="text/javascript">
        function validarCantidad() {
            var Cantidad = document.getElementById('<%= TxtTamaño.ClientID %>').value;
            if (bebida === "") {
                alert("El campo de Cantidad no puede estar vacío o ser 0.");
                return false;
            }
            if (isNaN(parseFloat(Cantidad)) && int.parse(Cantidad) > 0) {
                alert("El valor seleccionado para el precio debe ser numérico o mayor a 0.");
                return false;
            }

            return true;
        }

    </script>

</asp:Content>
