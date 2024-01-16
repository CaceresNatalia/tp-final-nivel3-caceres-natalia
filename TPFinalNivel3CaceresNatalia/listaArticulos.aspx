<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="listaArticulos.aspx.cs" Inherits="TPFinalNivel3CaceresNatalia.listaArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-3"></div>
        <div class="col-6">
            <h2>Lista de artículos</h2>
            <asp:GridView ID="dgvArticulos" runat="server" CssClass="table"
                AutoGenerateColumns="false" DataKeyNames="Id" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="Código" DataField="Codigo" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Marca" DataField="Marca" />
                    <asp:BoundField HeaderText="Categoría" DataField="Categoria" />
                    <asp:BoundField HeaderText="Precio" DataField="Precio" />
                    <asp:CommandField HeaderText="Editar" ShowSelectButton="true" SelectText="🖋️" />
                </Columns>
            </asp:GridView>
            <a href="formularioArticulo.aspx" class="btn btn-outline-info">Agregar</a>
        </div>
        <div class="col-3"></div>
    </div>
</asp:Content>
