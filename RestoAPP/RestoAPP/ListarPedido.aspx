<%@ Page Title="" Language="C#" MasterPageFile="~/MasterResto.Master" AutoEventWireup="true" CodeBehind="ListarPedido.aspx.cs" Inherits="RestoAPP.ListarPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center ">
        <h2>Mesa </h2>
    </div>
    <div id="cajas" class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater runat="server" ID="repRepetidor">
            <ItemTemplate>
                <div class="card" style="width: 18rem;">  
                    <div class="card-body">
                        <h5 class="card-title"><%#Eval("") %></h5>
                        <p class="card-text">Precio $ <%#Eval("") %></p>
                    </div>
                    <div class="card-body">
                        <asp:Button ID="btnModificarPedido" runat="server" CssClass="card-link" Text="Modificar"  CommandArgument='<%#Eval("") %>' />
                        <asp:Button ID="btnBorrarPedido" runat="server" CssClass="card-link" Text="Borrar"  CommandArgument='<%#Eval("")%>' />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>



</asp:Content>
