<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPFinalNivel3CaceresNatalia.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col"></div>
        <div class="col-4">
            <h2>Login</h2>
            <div class="mt-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
            </div>
            <div class="mt-3">
                <label class="form-label">Password</label>
                <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" TextMode="Password" />
            </div>
            <div class="mt-4">
                <asp:Button Text="Ingresar" ID="btnLogin" CssClass="btn btn-outline-light me-2"
                    runat="server" OnClick="btnLogin_Click" />
                <a  class="btn btn-outline-secondary" href="#">Cancelar</a>
            </div>
        </div>
        <div class="col"></div>
    </div>
</asp:Content>
