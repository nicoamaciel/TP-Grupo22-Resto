<%@ Page Title="" Language="C#" MasterPageFile="~/MasterResto.Master" AutoEventWireup="true" CodeBehind="PantRecaudacion.aspx.cs" Inherits="RestoAPP.PantRecaudacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <div class="row">
        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Campo" ID="lblCampo" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlCampo" AutoPostBack="true" CssClass="form-select">
                        <asp:ListItem Text="del dia" />
                        <asp:ListItem Text="del Año" />
                        <asp:ListItem Text="del mes" />
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Criterio" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlCriterio" AutoPostBack="true" CssClass="form-select">
                        <asp:ListItem Text="de la fecha" />
                        <asp:ListItem Text="Mayor a" />
                        <asp:ListItem Text="Menor a" />
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:TextBox ID="txtFecha" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="(Opcional)N° de DNI del vendedor" runat="server" />
                    <asp:TextBox ID="TxtMesero" runat="server" CssClass="form-control" />
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Button ID="BtnFiltrar" runat="server" Text="Aceptar" OnClick="BtnFiltrar_Click" />
                </div>
            </div>

        </div>

    </div>
    <hr />
    <div id="cajas1" class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater runat="server" ID="Rpt_Pedidos">
            <ItemTemplate>
                <div class="card" style="width: 18rem;">
                    <div class="card-body">
                        <p class="card-text"><%#Eval("descripcion") %> Precio $ <%#Eval("Precio") %></p>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <hr />
    <script>
        var textBox = document.getElementById('<%= txtFecha.ClientID %>');
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
