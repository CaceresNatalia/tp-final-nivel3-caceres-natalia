<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="TPFinalNivel3CaceresNatalia.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="row">
        <div class="text-center">
            <h2>Detalle</h2>
            <p>Acá podés ver más información del artículo seleccionado. </p>
        </div>
        <div class="row">



            <div class="col"></div>
            <div class="col-5">
                <div class="mb-3">
                    <label for="txtCodigo" class="form-label">Código</label>
                    <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />
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
                <div class="mb-3">
                    <label for="txtPrecio" class="form-label">Precio $</label>
                    <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
                </div>
            </div>

            <div class="col-5">
                <div class="mb-3">
                    <asp:Image ImageUrl="" ID="imgArticulo" CssClass="rounded mx-auto d-block" Width="60%" runat="server" />
                </div>
                <div class="text-center">
                    <a class="btn btn-primary" href="Default.aspx">Volver</a>
                </div>
            </div>
            <div class="col"></div>
        </div>
</asp:Content>
