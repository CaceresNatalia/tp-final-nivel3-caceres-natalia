<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="TPFinalNivel3CaceresNatalia.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div>
            <h2>Detalle</h2>
        </div>
        <div>
            <p>Acá podés ver más información del artículo seleccionado. </p>
        </div>
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtMarca" class="form-label">Marca</label>
                <asp:TextBox runat="server" ID="txtMarca" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtCategoria" class="form-label">Categoría</label>
                <asp:TextBox runat="server" ID="txtCategoria" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción</label>
                <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" />
            </div>
        </div>
    </div>
    <div class="col-6">
        <div class="mb-3">
            <asp:Image ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png"
                ID="imgArticulo" Width="60%" runat="server" />
        </div>
        <div class="mb-3">
            <label for="txtPrecio" class="form-label">Precio $</label>
            <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
        </div>
    </div>


</asp:Content>
