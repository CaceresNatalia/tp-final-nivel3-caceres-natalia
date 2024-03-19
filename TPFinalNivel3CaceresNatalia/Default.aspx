<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPFinalNivel3CaceresNatalia.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scriptmanager1" runat="server" AsyncPostBackTimeout="60000"></asp:ScriptManager>
    <div class="row mb-5">
        <h1 class="text-center">Catálogo web de Artículos</h1>
        <div class="col"></div>
        <div class="col align-self-end">
            <div class="dropdown mt-4 mb-4">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:Button Text="Seleccionar Marca" ID="btnSeleccionarMarca" OnClick="btnSeleccionarMarca_Click" CssClass="btn btn-outline-primary mb-4" runat="server" />
                        <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"
                            AutoPostBack="true">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="col align-self-end">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="dropdown mt-4 mb-4">
                        <asp:Button Text="Seleccionar Categoría" ID="btnSeleccionarCat"
                            CssClass="btn btn-outline-primary mb-4" OnClick="btnSeleccionarCat_Click" runat="server" />
                        <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select"
                            AutoPostBack="true">
                        </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="col align-self-start">
        <div>
            <div class="mt-4 mb-4">
                <asp:TextBox runat="server" ID="txtBuscar" CssClass="form-control" />
            </div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mt-4 mb-4">
                        <asp:Button ID="btnLimpiar" OnClick="btnLimpiar_Click" CssClass="btn btn-outline-info" Text="Limpiar Filtros" runat="server" />

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
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

    <div class="row row-cols-1 row-cols-md-3 g-4">
        <%if (!IsPostBack)
            {

                foreach (dominio.Articulo art in (List<dominio.Articulo>)Session["listaArticulos"])
                {
        %>


        <div class="col">
            <div class="card border-secondary text-center mb-3 h-100" style="max-width: 24rem;">
                <%if (Helper.Validaciones.IsImageValid(art.UrlImagen) && Helper.Validaciones.isImageAccesible(art.UrlImagen))
                    {
                %>
                <img src="<%:art.UrlImagen %>" alt="..." class="card-img-top" />
                <%  }
                    else
                    {
                %>
                <img src="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png" alt="..." class="card-img-top" />
                <%} %>
                <div class="card-body">
                    <h5 class="card-title"><%:art.Nombre %></h5>
                    <p class="card-text"><%:art.Descripcion%></p>
                    <a href="Detalle.aspx?id=<%:art.Id%>">Ver detalle</a>
                </div>
            </div>
        </div>



        <%
                }
            }
            if (IsPostBack && listaFiltrada != null)
            {

                foreach (dominio.Articulo art in listaFiltrada)
                {
        %>
        <div class="col">
            <div class="card border-secondary text-center mb-3 h-100" style="max-width: 24rem;">
                <%if (Helper.Validaciones.IsImageValid(art.UrlImagen) && Helper.Validaciones.isImageAccesible(art.UrlImagen))
                    {
                %>
                <img src="<%:art.UrlImagen %>" alt="..." class="card-img-top" />
                <%  }
                    else
                    {
                %>
                <img src="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png" alt="..." class="card-img-top" />
                <%} %>
                <div class="card-body">
                    <h5 class="card-title"><%:art.Nombre %></h5>
                    <p class="card-text"><%:art.Descripcion%></p>
                    <a href="Detalle.aspx?id=<%:art.Id%>">Ver detalle</a>
                </div>
            </div>
        </div>
        <%
                }
            }
        %>
    </div>
    <div class="text-center">
        <asp:Label Text="" ID="lblAdvertencia" runat="server" />
    </div>
</asp:Content>
