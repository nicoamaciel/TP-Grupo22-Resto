<%@ Page Title="" Language="C#" MasterPageFile="~/MasterResto.Master" AutoEventWireup="true" CodeBehind="MesasUser.aspx.cs" Inherits="RestoAPP.MesasUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
<div id="cajas" class="row row-cols-1 row-cols-md-3 g-4 justify-content-center ">
    <asp:Repeater runat="server" ID="repRepetidor">
        <ItemTemplate>
            <div class="container text-center">
                <div class="row">
                    <div class="col mx-auto p-2 align-middle">
                        <pre>
                            <button type="button" class="btn btn-primary btn-lg "><%# Eval("ID") %></button>
                            <h4>Mesero a cargo</h4>
                            <h4><%#Eval("Mesero.Nombre") %> <%#Eval("Mesero.Apellido") %></h4>
                            <h4 class="estado" style="display: none;"><%# Eval("Activo") %></h4>
                        </pre>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>

</asp:Content>
