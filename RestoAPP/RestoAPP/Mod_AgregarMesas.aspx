<%@ Page Title="" Language="C#" MasterPageFile="~/MasterResto.Master" AutoEventWireup="true" CodeBehind="Mod_AgregarMesas.aspx.cs" Inherits="RestoAPP.Mod_AgregarMesas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <hr />
            <div class="cssModAgregarMesa">
                       
                    <div ="row">

                    <label for="TxtTamaño" class="form-label" runat="server">Tamaño de la Mesa</label>
                    <asp:TextBox ID="TxtTamaño" runat="server" CssClass="form-Control" TextMode="Number" Width="300px"></asp:TextBox>
    
                    </div>
                
                    <div ="row">
                    <label for="TxtDescripcion" class="form-label" width="200px">Descripcion</label>
                    <asp:TextBox ID="TxtDescripcion" runat="server" CssClass="form-Control" Width="380px"></asp:TextBox>
                    </div>
                
                    <div ="row">
                    <label for="DdlTurnos" class="form-label">Turnos</label>
                    <asp:DropDownList ID="DdlTurnos" runat="server" OnSelectedIndexChanged="DdlTurnos_SelectedIndexChanged" AutoPostBack="true" Width="400px">
                        <asp:ListItem Text="Mostrar Ambos Turnos" />
                        <asp:ListItem Text="8 a 16:00" />
                        <asp:ListItem Text="16:00 a 23:00" />
                    </asp:DropDownList>
                    </div>
                
                    <% if (edit == true)
                        { %>
                    <asp:Label ID="Label1" runat="server" Text="Elija el mesero para la Mesa Existente"></asp:Label>
                    <br />
                    <%} %>
                    <label for="DdlMesero" class="form-label" width="200px">Meseros Disponibles</label>
                    <div="row">
                    <asp:DropDownList ID="DdlMesero" runat="server"  CssClass="form-select" AutoPostBack="true" Width="300px"></asp:DropDownList>
                    <hr />
                    <asp:Button ID="BtnAgregar" runat="server" Text="Aregar Mesa" OnClick="BtnAgregar_Click" />
                    </div>

            </div>
        </ContentTemplate>

    </asp:UpdatePanel>
    <hr />

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:GridView ID="DgvMesas" runat="server" DataKeyNames="IDMesa" CssClass="table table-dark table-brodered" AutoGenerateColumns="false"
                OnRowDeleting="DgvMesas_RowDeleting"
                OnRowEditing="DgvMesas_RowEditing"
                OnRowUpdating="DgvMesas_RowUpdating"
                OnRowCancelingEdit="DgvMesas_RowCancelingEdit">
                <Columns>
                    <asp:TemplateField HeaderText="TamañoMesa">
                        <ItemTemplate>
                            <asp:Label ID="LblTamaño" runat="server" Text='<%#Bind("TamañoMesa")%>' /></label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TxtTamañoDVG" runat="server" Text='<%#Bind("TamañoMesa")%>' TextMode="Number" oninput="validarNoNegativo(this)"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Descripcion">
                        <ItemTemplate>
                            <asp:Label ID="LblIDMesa" runat="server" Text='<%#Bind("Descripcion")%>' /></label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TxtDescripcion" runat="server" Text='<%#Bind("Descripcion")%>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Activo">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkEstado" runat="server" Checked='<%# Convert.ToBoolean(Eval("Activo")) %>' Enabled="false" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:CheckBox ID="chkEstado" runat="server" Checked='<%# Convert.ToBoolean(Eval("Activo")) %>' Enabled="true" />
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField HeaderText="Nombre" DataField="Empleado.Nombre" ReadOnly="true" />
                    <asp:BoundField HeaderText="Apellido" DataField="Empleado.Apellido" ReadOnly="true" />
                    <asp:BoundField HeaderText="Turno" DataField="Empleado.Turno" ReadOnly="true" />

                    <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>

    </asp:UpdatePanel>

    <script type="text/javascript">
        function validarCantidad() {
            var Cantidad = document.getElementById('<%= TxtTamaño.ClientID %>').value;
            var descripcion = document.getElementById('<%= TxtDescripcion.ClientID %>').value;
            if (Cantidad === "" || parseInt(Cantidad) <= 0) {
                alert("El campo de Cantidad no puede estar vacío o ser 0.");
                return false;
            }
            if (descripcion === "") {
                alert("El campo de descripción no puede estar vacío.");
                return false;
            }
            return true;
        }

    </script>
    <script type="text/javascript">
        function validarNoNegativo(input) {
            var value = parseInt(input.value);

            if (isNaN(value) || value <= 0) {
                input.value = ""; // Si se ingresa un número no válido o 0, limpiamos el campo
            }
        }
    </script>
</asp:Content>
