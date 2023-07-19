<%@ Page Title="" Language="C#" MasterPageFile="~/MasterResto.Master" AutoEventWireup="true" CodeBehind="PantallaMenu.aspx.cs" Inherits="RestoAPP.PantallaMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center ">
        <h2>Menus</h2>

    </div>

    <div class="container text-center">
        <div class="btn-group " role="group" aria-label="Basic outlined example">
            <asp:Button ID="Button1" class="btn btn-outline-success" OnClick="Button1_Click" runat="server" Text="Entrada" />
            <asp:Button ID="Button3" class="btn btn-outline-success" OnClick="Button3_Click" runat="server" Text="Principal" />
            <asp:Button ID="Button4" class="btn btn-outline-success" OnClick="Button4_Click" runat="server" Text="Postre" />
            <asp:Button ID="Button5" class="btn btn-outline-success" OnClick="Button5_Click" runat="server" Text="Bebidas" />
        </div>

    </div>


    <hr />

    <div id="cajas" class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater runat="server" ID="repRepetidor">
            <ItemTemplate>
                <div class="card text-bg-dark" style="width: 18rem;" >
                    <img src="<%#Eval("UrlImagen") %>" class="card-img-top" alt="..." style="width: 100%; height: 100%;">


                    <div class="card-body">
                        <h5 class="card-title"><%#Eval("Descripcion") %></h5>
                        <p class="card-text">Precio $ <%#Eval("Precio") %></p>
                    </div>
                    <%if (Session["Usuario"] != null)
                            if (((Dominio.Login)Session["Usuario"]).NivelAcceso <= 3)
                            {
                    %>
                    <div class="botonesMenus">
                        <asp:Button ID="btnModificar" runat="server" CssClass="card-link" Text="Modificar" OnClick="btnModificar_Click" CommandArgument='<%#Eval("ID") %>' />
                        <asp:Button ID="btnBorrar" runat="server" CssClass="card-link" Text="Borrar" OnClick="btnBorrar_Click" CommandArgument='<%#Eval("ID")%>' />
                    </div>
                    <%} %>
                </div>
                <br />
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <br />

</asp:Content>
