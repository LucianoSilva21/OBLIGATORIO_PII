<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="TestObligatorioP2.Clientes" %>

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
            <h3>Lista de Clientes</h3>
        </div>
    </div>

    <asp:Label ID="lblErrorNombre" runat="server" Text="" ForeColor="Red"></asp:Label>

    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Text="" placeholder="Nombre"></asp:TextBox>
        </div>
    </div>

    <asp:Label ID="lblErrorApellido" runat="server" Text="" ForeColor="Red"></asp:Label>

    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" Text="" placeholder="Apellido"></asp:TextBox>
        </div>
    </div>
    <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>

    <div class="row">
        <div class="col-lg-5">
            <asp:TextBox ID="txtCedula" runat="server" CssClass="form-control" Text="" placeholder="Cedula"></asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-5">
            <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="btnGuardar_Click" />
        </div>
    </div>
    <asp:Label ID="lblErrorGrilla" runat="server" Text="" ForeColor="Red"></asp:Label>


    <div class="row">
        <div class="col-lg-8">
            <asp:GridView ID="gvClientes" runat="server" CssClass="table bg-verde" Width="80%" BorderStyle="Solid" BorderWidth="2px" CellSpacing="5"
                OnRowCancelingEdit="gvClientes_RowCancelingEdit"
                OnRowDeleting="gvClientes_RowDeleting"
                DataKeyNames="cedula"
                AutoGenerateColumns="false"
                OnRowEditing="gvClientes_RowEditing"
                OnRowUpdating="gvClientes_RowUpdating">

                <Columns>
                    <asp:TemplateField HeaderText="Cedula">
                        <ItemTemplate>
                            <asp:Label ID="lblCedula" runat="server" Text='<%# Bind("Cedula") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre">
                        <ItemTemplate>
                            <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNombreGrid" runat="server" Text='<%# Bind("Nombre") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Apellido">
                        <ItemTemplate>
                            <asp:Label ID="lblApellido" runat="server" Text='<%# Bind("Apellido") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtApellidoGrid" runat="server" Text='<%# Bind("Apellido") %>'></asp:TextBox>
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
            <asp:DataGrid ID="dgClientes" runat="server" CssClass="table" Width="80%" BorderStyle="Solid" BorderWidth="2px" CellSpacing="5">
            </asp:DataGrid>
        </div>
    </div>
</asp:Content>
