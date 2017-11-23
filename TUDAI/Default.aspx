<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TUDAI.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Nicolás</h1>
    <asp:Label CssClass="" Text="Nicolás" runat="server"></asp:Label>
    <h2>Noticias</h2>

    <asp:GridView ID="gvNoticias" runat="server" CssClass="table table-hover" GridLines="None" BorderStyle="None"
        AutoGenerateColumns="false" DataKeyNames="id" OnRowCommand="gvNoticias_RowCommand">
        <Columns>
            <asp:BoundField DataField="id" Visible="false"/>
            <asp:BoundField HeaderText="Title" DataField="titulo"/>
            <asp:BoundField HeaderText="Date" DataField="fecha"/>
            <asp:BoundField HeaderText="Body" DataField="cuerpo"/>
            <asp:ButtonField ButtonType="Link" Text="Edit" CommandName="editar"/>
            <asp:ButtonField ButtonType="Link" Text="Show" CommandName="mostrar"/>
        </Columns>
    </asp:GridView>

</asp:Content>
