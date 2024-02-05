<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="TPFinalNivel3CaceresNatalia.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Error</h3>
    <asp:Label Text="text" ID="lblError" runat="server" />
    <div class="mt-3">
        <asp:Button Text="Volver" ID="btnError" runat="server" OnClick="btnError_Click" />
    </div>
</asp:Content>
