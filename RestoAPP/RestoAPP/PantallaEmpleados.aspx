<%@ Page Title="" Language="C#" MasterPageFile="~/MasterResto.Master" AutoEventWireup="true" CodeBehind="PantallaEmpleados.aspx.cs" Inherits="RestoAPP.PantallaEmpleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .oculto{
            display: none;
        }
    </style>
    
    <asp:GridView ID="dgvEmpleados" runat="server" DataKeyNames="IDEmpleado" OnSelectedIndexChanged="dgvEmpleados_SelectedIndexChanged" 
        CssClass="table table-dark table-brodered" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="IDEmpleado" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto"/>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
            <asp:BoundField HeaderText="Cargo " DataField="Cargo" />
            <asp:BoundField HeaderText="Turno" DataField="Turno" />
            <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
            <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="✍" />
            <asp:CommandField HeaderText="Suspender" ShowSelectButton="true" SelectText="✍" />
        </Columns>
    </asp:GridView>
</asp:Content>
