<%@ Page Title="" Language="C#" MasterPageFile="~/MasterResto.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RestoAPP.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <hr />

    <div class="container text-center">
        <div class="row">
            <div class="col">
            <asp:Button ID="ButtonM1" class="btn btn-primary btn-lg" OnClick="ButtonM1_Click" runat="server" Text="Mesa 1" />
            </div>
            <div class="col">
                <asp:Button ID="ButtonM2" class="btn btn-primary btn-lg" OnClick="ButtonM2_Click" runat="server" Text="Mesa 2" />
            </div>
            <div class="col">
                <asp:Button ID="ButtonM3" class="btn btn-primary btn-lg" OnClick="ButtonM3_Click" runat="server" Text="Mesa 3" />
            </div>
            <div class="col">
                <asp:Button ID="Button4" class="btn btn-primary btn-lg" OnClick="Button4_Click" runat="server" Text="Mesa 4" />
            </div>
            <div class="col">
                <asp:Button ID="Button5" class="btn btn-primary btn-lg" OnClick="Button5_Click" runat="server" Text="Mesa 5" />
            </div>
            <div class="col">
                <asp:Button ID="Button6" class="btn btn-primary btn-lg" OnClick="Button6_Click" runat="server" Text="Mesa 6" />
            </div>

        </div>
    </div>


</asp:Content>
