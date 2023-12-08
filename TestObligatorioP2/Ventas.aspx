<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="TestObligatorioP2.Ventas" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <style>
        .row {
            margin-bottom: 8px;
            border-color: #14625f
        }

        .bg-azul {
            background-color: #0000FF;
        }

        .table.bg-azul th,
        .table.bg-azul td {
            background-color: #56afbb;
            color: #ffffff; /* Color del texto en celdas */
            border-color: #14625f
        }
    </style>

    <div class="row">
        <div class="col-lg-12">
            <h3>Ventas</h3>
        </div>
    </div>

    <style type="text/css">
        .styled-dropdown {
            width: 200px; /* Ancho personalizado */
            padding: 5px; /* Espaciado interno */
            font-size: 18px; /* Tamaño de fuente */
            border: 2px solid #e7ede9; /* Borde del cuadro de lista desplegable */
            border-radius: 4px; /* Bordes redondeados */
            background-color: #56afbb; /* Color de fondo */
            color: #000000; /* Color del texto */
        }

        .dropdown-container {
            margin-bottom: 10px; /* Espacio entre el título y el DropDownList */
        }

        .LabelTitulo {
            font-size: 18px; /* Tamaño de la letra del título */
        }
    </style>
    <asp:Label ID="lblErrorAuto" runat="server" Text="" ForeColor="Red"></asp:Label>

    <div class="LabelTitulo">
        <asp:Label ID="LabelTitulo" runat="server" Text="Elige tu vehiculo:" AssociatedControlID="DropDownListAutos"></asp:Label>
    </div>
    <asp:DropDownList ID="DropDownListAutos" runat="server" CssClass="styled-dropdown" DataSource='<%# TestObligatorioP2.Clases.BaseDeDatos.VehiculosDisponibles() %>' DataTextField="mostrarDatos" DataValueField="Matricula" AutoPostBack="true" OnSelectedIndexChanged="DropDownListAutos_SelectedIndexChanged">
    </asp:DropDownList>



    <div class="LabelTitulo">
        <asp:Label ID="Label2" runat="server" Text="Elige al cliente:" AssociatedControlID="DropDownListClientes"></asp:Label>
    </div>
    <asp:DropDownList ID="DropDownListClientes" runat="server" CssClass="styled-dropdown" DataSource='<%# TestObligatorioP2.Clases.BaseDeDatos.listaClientes %>' DataTextField="mostrarDatos" DataValueField="Cedula">
    </asp:DropDownList>
    <br />

    <asp:Button ID="btnActualizar" runat="server" CssClass="btn btn-primary" Text="Actualizar" OnClick="btnActualizar_Click" Style="margin-left: 10px;" />

    <div class="row">
        <div class="col-lg-8">
            <asp:Panel ID="PanelContenedor" runat="server" BorderStyle="Solid" BorderWidth="1px" Width="180px">
                <asp:Label ID="LabelPrecio" runat="server" Text="" Visible="false" Style="font-size: 16px;"></asp:Label>
            </asp:Panel>
        </div>
    </div>


    <div class="row">
        <div class="col-lg-5">
            <asp:Button ID="btnConfirmar" runat="server" CssClass="btn btn-primary" Text="Confirmar" OnClick="btnConfirmar_Click" />
        </div>
    </div>

    <div class="row">
        <div class="col-lg-8">
            <asp:GridView ID="gvVentas" runat="server" CssClass="table bg-azul" Width="80%" BorderStyle="Solid" BorderWidth="2px" CellSpacing="5"
                DataKeyNames="Id"
                AutoGenerateColumns="false"
                OnRowDeleting="gvVentas_RowDeleting">


                    <Columns>
                        <asp:TemplateField HeaderText="Cedula">
                            <ItemTemplate>
                                <asp:Label ID="lblCedula" runat="server" Text='<%# Bind("Cedula") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="NombreUsuario">
                            <ItemTemplate>
                                <asp:Label ID="lblNombreUsuario" runat="server" Text='<%# Bind("NombreUsuario") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Matricula">
                            <ItemTemplate>
                                <asp:Label ID="lblMatricula" runat="server" Text='<%# Bind("Matricula") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="FechaVenta">
                            <ItemTemplate>
                                <asp:Label ID="lblFechaVenta" runat="server" Text='<%# Bind("FechaVenta") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Precio">
                            <ItemTemplate>
                                <asp:Label ID="lblPrecio" runat="server" Text='<%# Bind("Precio") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:CommandField ButtonType="Link" ShowDeleteButton="true" />
                    </Columns>
            </asp:GridView>
        </div>
    </div>


</asp:Content>
