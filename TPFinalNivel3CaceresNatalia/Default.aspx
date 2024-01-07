<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPFinalNivel3CaceresNatalia.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Catálogo web de Artículos</h1>

    <div class="row row-cols-1 row-cols-md-3 g-4">

        <%
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
        %>
    </div>
</asp:Content>
