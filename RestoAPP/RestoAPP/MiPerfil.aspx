<%@ Page Title="" Language="C#" MasterPageFile="~/MasterResto.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="RestoAPP.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="position-absolute top-50 start-50 translate-middle">
        <%if (ListaEmpleados.Count > 0)
            {%>
        <div class="card text-center mb-3" style="width: 18rem;">
            <div class="card-body">
                <h5 class="card-title"><%=ListaEmpleados[0].Nombre +" "+ ListaEmpleados[0].Apellido%></h5>
                <p class="card-text">Dni: <%=ListaEmpleados[0].Dni%></p>
                <p class="card-text">Cargo: <%=ListaEmpleados[0].Cargo%></p>
                <p class="card-text">Sueldo: <%=ListaEmpleados[0].sueldo%></p>
                <p class="card-text">Turno: <%=ListaEmpleados[0].Turno%></p>
                <p class="card-text">Codigo: <%=ListaEmpleados[0].Codigo%></p>
            </div>
            <div>
                <asp:Button Text="Cerrar Session" ID="btnCerrar" CssClass="btn btn-primary" OnClick="btnCerrar_Click" runat="server" />
                <asp:Button Text="Cambiar Datos de la Session" ID="btnSession" CssClass="btn btn-primary" OnClick="btnSession_Click" runat="server" />
            </div>
        </div>
        <% }%>
    </div>


</asp:Content>
