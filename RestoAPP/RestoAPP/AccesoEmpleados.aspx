<%@ Page Title="" Language="C#" MasterPageFile="~/MasterResto.Master" AutoEventWireup="true" CodeBehind="AccesoEmpleados.aspx.cs" Inherits="RestoAPP.AccesoEmpleados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="position-absolute top-50 start-50 translate-middle">
        <div class="card text-center mb-3" style="width: 18rem;">
            <h3>Ingreso para Empleados</h3>
            <div class="card-body">
                <h2>Usuario</h2>
                <asp:TextBox ID="TextUser" runat="server"></asp:TextBox>

                <h2>Pass</h2>
                <asp:TextBox ID="TextPass" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />

        </div>
    </div>
</asp:Content>


