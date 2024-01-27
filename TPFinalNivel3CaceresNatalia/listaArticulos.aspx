<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="listaArticulos.aspx.cs" Inherits="TPFinalNivel3CaceresNatalia.listaArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Lista de artículos</h2>
    <div class="row">
        <hr />
        <div class="col-6">
            <div class="mb-3">
                <asp:Label for="txtFiltroRapido" CssClass="form-label" Text="Filtro" runat="server" />
                <asp:TextBox ID="txtFiltroRapido" AutoPostBack="true" OnTextChanged="txtFiltroRapido_TextChanged" CssClass="form-control" runat="server" />
            </div>
        </div>

        <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
            <div class="mb-3">
                <asp:CheckBox Text="Filtro avanzado" ID="chkFiltroAvanzado"
                    OnCheckedChanged="chkFiltroAvanzado_CheckedChanged"
                    AutoPostBack="true" runat="server" CssClass="" />
            </div>
        </div>
            <div class="mb-3">
                <asp:Button Text="Limpiar Filtros" ID="btnLimpiarFiltros" CssClass="btn btn-outline-primary" 
                    OnClick="btnLimpiarFiltros_Click" runat="server" />
            </div>
        <%if (chkFiltroAvanzado.Checked)
            {
        %>

        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Campo" ID="lblCampo" CssClass="form-label" runat="server" />
                    <asp:DropDownList ID="ddlCampo" CssClass="form-control"
                        OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" AutoPostBack="true"
                        runat="server">
                        <asp:ListItem Text="Seleccionar" />
                        <asp:ListItem Text="Nombre" />
                        <asp:ListItem Text="Categoría" />
                        <asp:ListItem Text="Marca" />
                        <asp:ListItem Text="Precio" />
                    </asp:DropDownList>
                    <asp:Label Text="" ID="lblSeleccionar" runat="server" />
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Criterio" ID="lblCriterio" CssClass="form-label" runat="server" />
                    <asp:DropDownList ID="ddlCriterio" CssClass="form-control" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Filtro" runat="server" />
                    <asp:TextBox ID="txtFiltro" CssClass="form-control" runat="server" />
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Button Text="Buscar" ID="btnBuscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" runat="server" />
            </div>
        </div>
        <%

            }
        %>
    </div>
    <hr />
    <asp:GridView ID="dgvArticulos" runat="server" CssClass="table"
        AutoGenerateColumns="false" DataKeyNames="Id" 
        OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged " 
        OnPageIndexChanging="dgvArticulos_PageIndexChanging" AllowPaging="true"
        PageSize="5">
        <Columns>
            <asp:BoundField HeaderText="Código" DataField="Codigo" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Marca" DataField="Marca" />
            <asp:BoundField HeaderText="Categoría" DataField="Categoria" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" DataFormatString="{0:F2}" />
            <asp:CommandField HeaderText="Editar" ShowSelectButton="true" SelectText="🖋️" />
        </Columns>
    </asp:GridView>
        <a href="formularioArticulo.aspx" class="btn btn-outline-info">Agregar</a>

</asp:Content>
