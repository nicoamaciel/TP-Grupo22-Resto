<%@ Page Title="" Language="C#" MasterPageFile="~/MasterResto.Master" AutoEventWireup="true" CodeBehind="PantallaMenu.aspx.cs" Inherits="RestoAPP.PantallaMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center">
        <h2>Menus
        </h2>

    </div>

    <div class="container text-center">
        <div class="btn-group " role="group" aria-label="Basic outlined example">
            <asp:Button ID="Button1" class="btn btn-outline-primary" OnClick="Button1_Click" runat="server" Text="Entrada" />
            <asp:Button ID="Button3" class="btn btn-outline-primary" runat="server" Text="Principal" />
            <asp:Button ID="Button4" class="btn btn-outline-primary" runat="server" Text="Postre" />
            <asp:Button ID="Button5" class="btn btn-outline-primary" runat="server" Text="Bebidas" />
        </div>

    </div>


    <hr />

    <div id="cajas" class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater runat="server" ID="repRepetidor">
            <ItemTemplate>
                <div class="card" style="width: 18rem;">
                    <img src="<%#Eval("UrlImagen") %>" class="card-img-top" alt="..." style="width: 100%; height: 100%;">


                    <div class="card-body">
                        <h5 class="card-title"><%#Eval("Descripcion") %></h5>
                        <p class="card-text">Precio $ <%#Eval("Precio") %></p>

                    </div>
                    <div class="card-body">
                        <a href="#" class="card-link">Card link</a>
                        <a href="#" class="card-link">Another link</a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>



</asp:Content>
