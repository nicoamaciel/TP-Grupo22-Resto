<%@ Page Title="" Language="C#" MasterPageFile="~/MasterResto.Master" AutoEventWireup="true" CodeBehind="PantallaEmpleados.aspx.cs" Inherits="RestoAPP.PantallaEmpleados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="dgvEmpleados" runat="server" DataKeyNames="IDEmpleado" OnSelectedIndexChanged="dgvEmpleados_SelectedIndexChanged"
                OnRowDeleting="dgvEmpleados_RowDeleting" CssClass="table table-dark table-brodered" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="IDEmpleado" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                    <asp:BoundField HeaderText="Cargo " DataField="Cargo" />
                    <asp:BoundField HeaderText="Turno" DataField="Turno" />
                    <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
                    <asp:CommandField ButtonType="Link" ShowSelectButton="true" ShowDeleteButton="true" SelectText="✍" />
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
