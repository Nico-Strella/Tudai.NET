<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TUDAI.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Nicolás</h1>
    <asp:Label CssClass="" Text="Nicolás" runat="server"></asp:Label>

    <h2>Filtro</h2>
    <div class="form-group">
        <asp:TextBox ID="txt_autor" runat="server" placeholder="Autor" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">            
        <asp:DropDownList ID="ddl_categorias" runat="server" DataValueField="Id" DataTextField="Nombre">
        </asp:DropDownList>            
    </div>
    <div class="form-group">
        <asp:Button ID="btn_filtrar" runat="server" OnClick="Filtrar" Text="Filtrar" CssClass="btn btn-default"/>
    </div>

    <h2>Noticias</h2>
    <asp:GridView ID="gvNoticias" runat="server" CssClass="table table-hover table-light table-striped" GridLines="None" BorderStyle="None"
        AutoGenerateColumns="false" DataKeyNames="id" OnRowCommand="gvNoticias_RowCommand">
        <Columns>
            <asp:BoundField DataField="id" Visible="false"/>
            <asp:BoundField HeaderText="Title" DataField="titulo"/>
            <asp:BoundField HeaderText="Date" DataField="fecha"/>
            <asp:BoundField HeaderText="Body" DataField="cuerpo"/>
            <asp:BoundField HeaderText="Autor" DataField="autor"/>
            <asp:ButtonField ButtonType="Link" Text="Edit" CommandName="editar"/>
            <asp:ButtonField ButtonType="Link" Text="Show" CommandName="mostrar"/>
        </Columns>
    </asp:GridView>
</asp:Content>
