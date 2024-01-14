<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPFinalNivel3CaceresNatalia.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mb-5">
        <h1 class="text-center">Catálogo web de Artículos</h1>
        <div class="col"></div>
        <div class="col align-self-end">
            <div class="dropdown mt-4 mb-4">
                <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server">
                </asp:DropDownList>
            </div>
        </div>
        <div class="col align-self-end">
            <div class="dropdown mt-4 mb-4">
                <asp:DropDownList  ID="ddlCategoria" runat="server" CssClass="form-select">
                </asp:DropDownList>
                <%--<button class="btn btn-outline-info dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                    Seleccione Categoría
                </button>
                <ul class="dropdown-menu dropdown-menu-dark">--%>
               </div>
        </div>

        <div class="col align-self-start">
            <div>
                <div class="mt-4 mb-4">
                    <asp:TextBox runat="server" ID="txtBuscar" CssClass="form-control" />
                </div>
            </div>
        </div>
        <div class="col align-self-start">
            <div>
                <div class="mt-4 mb-4">
                    <asp:Button Text="Filtrar" ID="btnBuscar" OnClick="btnBuscar_Click" CssClass="btn btn-outline-primary" runat="server" />
                </div>
            </div>

        </div>
        <div class="col"></div>

    </div>

    <div class="row row-cols-1 row-cols-md-3 g-4">
        <%if (!IsPostBack)
            {

                foreach (dominio.Articulo art in listaArticulos)
                {
        %>


        <div class="col">
            <div class="card border-secondary text-center mb-3 h-100" style="max-width: 24rem;">
                <img src="<%:art.UrlImagen %>" alt="..." class="card-img-top" />
                <div class="card-body">
                    <h5 class="card-title"><%:art.Nombre %></h5>
                    <p class="card-text"><%:art.Descripcion%></p>
                    <a href="Detalle.aspx?id=<%:art.Id%>">Ver detalle</a>
                </div>
            </div>
        </div>


        <%
                }
                //    } else if (Session["listaFiltrada"] != null)
                //{
                //    foreach (dominio.Articulo art in lista)
                //    {

                //    }
            }
        %>
    </div>
</asp:Content>
