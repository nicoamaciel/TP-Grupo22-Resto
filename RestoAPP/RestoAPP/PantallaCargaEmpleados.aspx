<%@ Page Title="" Language="C#" MasterPageFile="~/MasterResto.Master" AutoEventWireup="true" CodeBehind="PantallaCargaEmpleados.aspx.cs" Inherits="RestoAPP.PantallaCargaEmpleados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="column center wrap">
                <div class="col-6  ">
                    <div class="mb-3 oculto">
                        <label for="txtId" class="form-label">Id</label>
                        <asp:TextBox runat="server" ID="txtId" CssClass="form-control" Enabled="false" />
                    </div>
                    <div class="mb-3">
                        <label for="txtNombre" class="form-label">Nombre: </label>
                        <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                    </div>
                    <div class="mb-3">
                        <label for="txtApellido" class="form-label">Apellido: </label>
                        <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" />
                    </div>
                    <div class="mb-3">
                        <label for="txtDNI" class="form-label">DNI: </label>
                        <asp:TextBox runat="server" ID="txtDNI" CssClass="form-control" />
                    </div>
                    <div class="mb-3">
                        <label for="ddlCargo" class="form-label">Cargo: </label>
                        <asp:DropDownList ID="ddlCargo" CssClass="form-select" runat="server"></asp:DropDownList>
                    </div>
                    <div class="mb-3">
                        <label for="txtSueldo" class="form-label">Sueldo: </label>
                        <asp:TextBox ID="txtSueldo" CssClass="form-select" runat="server"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="txtCodigo" class="form-label">Codigo: </label>
                        <asp:TextBox ID="TxtCodigo" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="DdlTurno" class="form-label">Turno: </label>
                        <asp:DropDownList ID="DdlTurno" runat="server" OnSelectedIndexChanged="DdlTurno_SelectedIndexChanged">
                            <asp:ListItem Text="Mañana/Tarde" />
                            <asp:ListItem Text="Noche" />
                        </asp:DropDownList>
                        <asp:TextBox ID="TxtTurno" runat="server" Enabled="false" CssClass="oculto"></asp:TextBox>
                        <asp:TextBox ID="TxtHorario" runat="server" Enabled="false"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" runat="server" />
                        <a href="/PantallaEmpleados.aspx">Cancelar</a>
                    </div>

                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
