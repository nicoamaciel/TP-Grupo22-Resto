<%@ Page Title="" Language="C#" MasterPageFile="~/MasterResto.Master" AutoEventWireup="true" CodeBehind="PantallaMenu.aspx.cs" Inherits="RestoAPP.PantallaMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div id="cajas" class="row row-cols-1 row-cols-md-3 g-4" >
        <asp:Repeater runat="server" ID="repRepetidor" >
            <ItemTemplate>
            <div class="card" style="width: 18rem;">
                      <img src="<%#Eval("UrlImagen") %>" class="card-img-top" alt="..." style="width:100%;height:100%;">
           

                <div class="card-body">
                    <h5 class="card-title"><%#Eval("Descripcion") %></h5>
                    <p class="card-text"><%#Eval("Precio") %></p>

                </div>
  <ul class="list-group list-group-flush">
    <li class="list-group-item">An item</li>
    <li class="list-group-item">A second item</li>
    <li class="list-group-item">A third item</li>
  </ul>
  <div class="card-body">
    <a href="#" class="card-link">Card link</a>
    <a href="#" class="card-link">Another link</a>
  </div>
</div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
</asp:Content>
