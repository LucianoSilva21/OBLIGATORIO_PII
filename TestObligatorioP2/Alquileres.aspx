<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Alquileres.aspx.cs" Inherits="TestObligatorioP2.Alquileres" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

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
            <h3>Alquileres</h3>
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
    <div class="LabelTitulo">
        <asp:Label ID="LabelTitulo" runat="server" Text="Elige tu vehiculo:" AssociatedControlID="DropDownListAutos"></asp:Label>
    </div>
    <asp:Label ID="lblErrorAuto" runat="server" Text="" ForeColor="Red"></asp:Label>

    <asp:DropDownList ID="DropDownListAutos" runat="server" CssClass="styled-dropdown" DataSource='<%# TestObligatorioP2.Clases.BaseDeDatos.VehiculosDisponibles() %>' DataTextField="mostrarDatos" DataValueField="Matricula">
    </asp:DropDownList>



    <div class="LabelTitulo">
        <asp:Label ID="Label2" runat="server" Text="Elige al cliente:" AssociatedControlID="DropDownListClientes"></asp:Label>
    </div>
    <asp:DropDownList ID="DropDownListClientes" runat="server" CssClass="styled-dropdown" DataSource='<%# TestObligatorioP2.Clases.BaseDeDatos.listaClientes %>' DataTextField="mostrarDatos" DataValueField="Cedula">
    </asp:DropDownList>
    <br />

    <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>

    <div class="row">
        <div class="col-lg-4 d-flex justify-content-start align-items-center">
            <asp:TextBox ID="txtDias" runat="server" CssClass="form-control" Text="" placeholder="Cantidad de días" OnTextChanged="txtDias_TextChanged" Style="width: 80%;" />
            <asp:Button ID="btnActualizar" runat="server" CssClass="btn btn-primary" Text="Actualizar" OnClick="btnActualizar_Click" Style="margin-left: 10px;" />
        </div>
    </div>


    <div class="row">
        <div class="col-lg-8">
            <asp:Panel ID="PanelContenedor" runat="server" BorderStyle="Solid" BorderWidth="1px" Width="180px">
                <asp:Label ID="LabelPrecio" runat="server" Text="" Visible="false" Style="font-size: 16px;"></asp:Label>
            </asp:Panel>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-8">
            <asp:Panel ID="PanelPrecioTotal" runat="server" BorderStyle="Solid" BorderWidth="1px" Width="150px">
                <asp:Label ID="LabelPrecioTotal" runat="server" Text="" Visible="false" Style="font-size: 16px;"></asp:Label>
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
            <asp:GridView ID="gvAlquileres" runat="server" CssClass="table bg-azul" Width="80%" BorderStyle="Solid" BorderWidth="2px" CellSpacing="5"
                OnRowCancelingEdit="gvAlquileres_RowCancelingEdit"
                OnRowDeleting="gvAlquileres_RowDeleting"
                DataKeyNames="Codigo"
                AutoGenerateColumns="false"
                OnRowEditing="gvAlquileres_RowEditing"
                OnRowUpdating="gvAlquileres_RowUpdating">


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


                    <asp:TemplateField HeaderText="FechaAlquiler">
                        <ItemTemplate>
                            <asp:Label ID="lblFechaAlquiler" runat="server" Text='<%# Bind("FechaAlquiler") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Dias">
                        <ItemTemplate>
                            <asp:Label ID="lblDias" runat="server" Text='<%# Bind("Dias") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Precio">
                        <ItemTemplate>
                            <asp:Label ID="lblPrecio" runat="server" Text='<%# Bind("Precio") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="AutoDevuelto">
                        <ItemTemplate>
                            <asp:Label ID="lblAutoDevuelto" runat="server" Text='<%# Bind("AutoDevuelto") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:CheckBox ID="txtAutoDevueltoGrid" runat="server" HeaderText="Auto Devuelto" DataField="AutoDevuelto" SortExpression="AutoDevuelto" />
                        </EditItemTemplate>
                    </asp:TemplateField>

                    
                    <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate>
                            <asp:Label ID="lblEstado" runat="server" Text='<%# Bind("Estado") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true" />
                </Columns>
            </asp:GridView>
        </div>
    </div>


</asp:Content>
