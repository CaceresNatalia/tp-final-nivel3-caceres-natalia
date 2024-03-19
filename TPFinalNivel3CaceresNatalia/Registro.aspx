<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TPFinalNivel3CaceresNatalia.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col"></div>
        <div class="col-4">
    <h2>Creá tu perfil de usuario</h2>
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label class="form-label">Password</label>
                <asp:TextBox ID="txtPassword" CssClass="form-control" TextMode="Password" runat="server" />
            </div>
            <asp:Button Text="Registrarse" ID="btnRegistro" OnClick="btnRegistro_Click" CssClass="btn btn-primary me-3" runat="server" />
            <a href="Default.aspx">Cancelar</a>
        </div>
        <div class="col"></div>
    </div>
</asp:Content>
