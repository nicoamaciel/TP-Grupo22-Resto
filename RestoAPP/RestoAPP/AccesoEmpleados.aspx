<%@ Page Title="" Language="C#" MasterPageFile="~/MasterResto.Master" AutoEventWireup="true" CodeBehind="AccesoEmpleados.aspx.cs" Inherits="RestoAPP.AccesoEmpleados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="position-absolute top-50 start-50 translate-middle">
                <div class="card text-center mb-3" style="width: 18rem;">
                    <div class="card-body">
                        <h2>Usuario</h2>
                        <asp:TextBox ID="TextUser" runat="server"></asp:TextBox>

                        <h2>Contraseña</h2>
                        <asp:TextBox ID="TextPass" runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                    <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />

                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


