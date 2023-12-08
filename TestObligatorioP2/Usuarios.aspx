<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="TestObligatorioP2.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">




    <style>
        .row {
            margin-bottom: 8px;
        }

        .bg-verde {
            background-color: #56afbb; /* Color verde personalizado */
        }

        .form-control {
            margin-bottom: 0.2cm;
        }
    </style>
    <div class="row">
        <div class="col-lg-12">
            <h3>Lista de Usuarios</h3>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-5">
            <asp:Label ID="lblErrorNombre" runat="server" Text="" ForeColor="Red"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Text="" placeholder="Nombre"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-5">
            <asp:Label ID="lblErrorContrasenia" runat="server" Text="" ForeColor="Red"></asp:Label>
            <asp:TextBox ID="txtContraseña" runat="server" CssClass="form-control" Text="" placeholder="Contraseña"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-5">
            <asp:CheckBox ID="chbVerClientes" runat="server" CssClass="form-control" Text=" Permiso para ver Clientes"></asp:CheckBox>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-5">
            <asp:CheckBox ID="chbVerAlquileres" runat="server" CssClass="form-control" Text=" Permiso para ver Alquileres"></asp:CheckBox>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-5">
            <asp:CheckBox ID="chbVerVentas" runat="server" CssClass="form-control" Text=" Permiso para ver Ventas"></asp:CheckBox>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-5">
            <asp:CheckBox ID="chbVerVehiculos" runat="server" CssClass="form-control" Text=" Permiso para ver Vehiculos"></asp:CheckBox>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-5">
            <asp:CheckBox ID="chbVerUsuarios" runat="server" CssClass="form-control" Text=" Permiso para ver Usuarios"></asp:CheckBox>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-5">
            <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="btnGuardar_Click" />
        </div>
    </div>


    <div class="row">
        <div class="col-lg-8">
            <asp:GridView ID="gvUsuarios" runat="server" CssClass="table bg-verde" Width="80%" BorderStyle="Solid" BorderWidth="2px" CellSpacing="5"
                OnRowCancelingEdit="gvUsuarios_RowCancelingEdit"
                OnRowDeleting="gvUsuarios_RowDeleting"
                DataKeyNames="Nombre"
                AutoGenerateColumns="false"
                OnRowEditing="gvUsuarios_RowEditing"
                OnRowUpdating="gvUsuarios_RowUpdating">

                <Columns>
                    <asp:TemplateField HeaderText="Nombre">
                        <ItemTemplate>
                            <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNombreGrid" runat="server" Text='<%# Bind("Nombre") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Contraseña">
                        <ItemTemplate>
                            <asp:Label ID="lblContraseña" runat="server" Text='<%# Bind("Contraseña") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtContraseñaGrid" runat="server" Text='<%# Bind("Contraseña") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true" />

                </Columns>


            </asp:GridView>
        </div>
    </div>
    <br />
    <br />
    <div class="row">
        <div class="col-lg-8">
            <asp:Label ID="lblErrorGrilla" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
            <asp:DataGrid ID="dgUsuarios" runat="server" CssClass="table" Width="80%" BorderStyle="Solid" BorderWidth="2px" CellSpacing="5">
            </asp:DataGrid>
        </div>
    </div>
</asp:Content>
