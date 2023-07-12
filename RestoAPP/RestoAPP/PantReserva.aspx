<%@ Page Title="" Language="C#" MasterPageFile="~/MasterResto.Master" AutoEventWireup="true" CodeBehind="PantReserva.aspx.cs" Inherits="RestoAPP.PantReserva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container text-center ">
        <h2>Desea Hacer una reservacion</h2>
        <h4>Tenga en cuenta q la mesa solicitada comenzara a estar habilitada 30min antes hasta 30min despues de la hora pedida, pasado ese tiempo la reserva quedara anulada</h4>
        <h4>Si su Dni ya tiene una reserva solo se modificara la q ya tenia</h4>
    </div>

    <div class="row ">
        <div class="mb-3">
            <label for="txtId" class="form-label">MESA</label>
            <asp:DropDownList ID="DdlMesa" runat="server"></asp:DropDownList>
        </div>
        <div class="mb-3">
            <label for="txtCodigo" class="form-label">Escriba su DNI este le servira como su codigo de Reserva</label>
            <asp:TextBox runat="server" ID="TxtCodigo" CssClass="form-control" />
        </div>
        <div class="mb-3">
            <label for="txtHora" class="form-label">Fecha de la Reserva:</label>
            <asp:TextBox ID="txthora" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label for="txtCantidad" class="form-label">Indique la cantidad de personas </label>
            <asp:TextBox runat="server" ID="TxtCantidad" CssClass="form-control" />
        </div>
        <div class="mb-3">
            <label for="txtComentario" class="form-label">Escriba algun detalle que crea conveniente que debamos saber con anticipacion: </label>
            <asp:TextBox runat="server" TextMode="MultiLine" ID="txtComentario" CssClass="form-control" />
        </div>

        <div class="mb-3">
            <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" runat="server" />
            <button type="button" class="btn btn-secundary" href="/PantallaMenu.aspx">Cancelar</button>
        </div>
    </div>

    <script>
        var textBox = document.getElementById('<%= txthora.ClientID %>');
        var fechaActual = new Date();
        var fechaMinima = new Date();
        fechaMinima.setDate(fechaActual.getDate() + 1);
        fechaMinima.setHours(0, 0, 0, 0);
        var fechaMaxima = new Date();
        fechaMaxima.setDate(fechaActual.getDate() + 15);
        fechaMaxima.setHours(23, 0, 0, 0);
        textBox.min = fechaMinima.toISOString().slice(0, -8);
        textBox.max = fechaMaxima.toISOString().slice(0, -8);
    </script>
</asp:Content>
