<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Vehiculos.aspx.cs" Inherits="TestObligatorioP2.Vehiculos" %>

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
            <h3>Catalogo Vehículos</h3>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-6">
            <!-- Primera columna -->

            <asp:Label ID="LabelTP" runat="server" Text="" ForeColor="Red"></asp:Label>
            <asp:RadioButtonList ID="rblTipoVehiculo" runat="server" OnSelectedIndexChanged="rblTipoVehiculo_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Text="Camión" Value="Camion" />
                <asp:ListItem Text="Auto" Value="Auto" />
                <asp:ListItem Text="Moto" Value="Moto" />
            </asp:RadioButtonList>


            <asp:Label ID="lblErrorMessageCC" runat="server" Text="" ForeColor="Red"></asp:Label>
            <asp:TextBox ID="txtCapacidadCarga" runat="server" CssClass="form-control" Text="" placeholder="Capacidad de carga"></asp:TextBox>


            <asp:Label ID="lblErrorMessageCP" runat="server" Text="" ForeColor="Red"></asp:Label>
            <asp:TextBox ID="txtCantPasajeros" runat="server" CssClass="form-control" Text="" placeholder="Cantidad de pasajeros"></asp:TextBox>


            <asp:Label ID="lblErrorMessageMoto" runat="server" Text="" ForeColor="Red"></asp:Label>
            <asp:TextBox ID="txtCilindrada" runat="server" CssClass="form-control" Text="" placeholder="Cilindrada de la moto"></asp:TextBox>


            <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
            <asp:TextBox ID="txtMatricula" runat="server" CssClass="form-control" Text="" placeholder="Matricula del vehiculo"></asp:TextBox>


            <asp:Label ID="lblErrorMarca" runat="server" Text="" ForeColor="Red"></asp:Label>
            <asp:TextBox ID="txtMarca" runat="server" CssClass="form-control" Text="" placeholder="Marca del vehiculo"></asp:TextBox>


            <asp:Label ID="lblErrorModelo" runat="server" Text="" ForeColor="Red"></asp:Label>
            <asp:TextBox ID="txtModelo" runat="server" CssClass="form-control" Text="" placeholder="Modelo del vehiculo"></asp:TextBox>



        </div>

        <div class="col-lg-6">
            <!-- Segunda columna -->


            <asp:Label ID="lblErrorColor" runat="server" Text="" ForeColor="Red"></asp:Label>
            <asp:TextBox ID="txtColor" runat="server" CssClass="form-control" Text="" placeholder="Color del vehiculo"></asp:TextBox>


            <asp:Label ID="lblErrorAnio" runat="server" Text="" ForeColor="Red"></asp:Label>
            <asp:TextBox ID="txtAnio" runat="server" TextMode="Number" CssClass="form-control" Text="" placeholder="Año del vehiculo"></asp:TextBox>



            <asp:Label ID="lblErrorKilometraje" runat="server" Text="" ForeColor="Red"></asp:Label>
            <asp:TextBox ID="txtKilometraje" runat="server" TextMode="Number" CssClass="form-control" Text="" placeholder="Kilometros del vehiculo"></asp:TextBox>



            <asp:Label ID="lblErrorPrecioVenta" runat="server" Text="" ForeColor="Red"></asp:Label>
            <asp:TextBox ID="txtPrecioVenta" runat="server" TextMode="Number" CssClass="form-control" Text="" placeholder="Precio de venta del vehiculo"></asp:TextBox>



            <asp:Label ID="lblErrorPrecioAlquiler" runat="server" Text="" ForeColor="Red"></asp:Label>
            <asp:TextBox ID="txtPrecioAlquiler" runat="server" TextMode="Number" CssClass="form-control" Text="" placeholder="Precio de alquiler por día del vehiculo"></asp:TextBox>



            <asp:TextBox ID="txtUrlImagen" runat="server" CssClass="form-control" placeholder="URL imagen del vehiculo" />
            <asp:TextBox ID="txtUrlImagen2" runat="server" CssClass="form-control" placeholder="URL imagen del vehiculo" />
            <asp:TextBox ID="txtUrlImagen3" runat="server" CssClass="form-control" placeholder="URL imagen del vehiculo" />


        </div>
        <div class="col-lg-5">
            <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="btnGuardar_Click" />
        </div>
    </div>

    <asp:Label ID="LabelErrorGrilla" runat="server" Text="" ForeColor="Red"></asp:Label>

    <div class="row">
        <div class="col-lg-8">
            <asp:GridView ID="gvVehiculos" runat="server" CssClass="table bg-verde" Width="80%" BorderStyle="Solid" BorderWidth="2px" CellSpacing="5"
                OnRowCancelingEdit="gvVehiculos_RowCancelingEdit"
                OnRowDeleting="gvVehiculos_RowDeleting"
                DataKeyNames="Matricula"
                AutoGenerateColumns="false"
                OnRowEditing="gvVehiculos_RowEditing"
                OnRowUpdating="gvVehiculos_RowUpdating"
                OnRowDataBound="gvVehiculos_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Marca">
                        <ItemTemplate>
                            <asp:Label ID="lblMarca" runat="server" Text='<%# Bind("Marca") %>'></asp:Label>

                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtMarcaGrid" runat="server" Text='<%# Bind("Marca") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Modelo">
                        <ItemTemplate>
                            <asp:Label ID="lblModelo" runat="server" Text='<%# Bind("Modelo") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtModeloGrid" runat="server" Text='<%# Bind("Modelo") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Anio">
                        <ItemTemplate>
                            <asp:Label ID="lblAnio" runat="server" Text='<%# Bind("Anio") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAnioGrid" runat="server" Text='<%# Bind("Anio") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Kilometraje">
                        <ItemTemplate>
                            <asp:Label ID="lblKilometraje" runat="server" Text='<%# Bind("kilometros") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtKilometrajeGrid" runat="server" Text='<%# Bind("kilometros") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Color">
                        <ItemTemplate>
                            <asp:Label ID="lblColor" runat="server" Text='<%# Bind("Color") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtColorGrid" runat="server" Text='<%# Bind("Color") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="PrecioVenta">
                        <ItemTemplate>
                            <asp:Label ID="lblPrecioVenta" runat="server" Text='<%# Bind("PrecioVenta") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPrecioVentaGrid" runat="server" Text='<%# Bind("PrecioVenta") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="PrecioAlquiler">
                        <ItemTemplate>
                            <asp:Label ID="lblPrecioAlquiler" runat="server" Text='<%# Bind("PrecioAlquiler") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPrecioAlquilerGrid" runat="server" Text='<%# Bind("PrecioAlquiler") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="AtributoEspecial">
                        <ItemTemplate>
                            <asp:Label ID="lblAtributoEspecial" runat="server" Text='<%# ObtenerAtributoEspecial(Container.DataItem) %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAtributoEspecialGrid" runat="server" Text='<%# ObtenerAtributoEspecial(Container.DataItem) %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>



                    <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate>
                            <asp:Label ID="lblEstado" runat="server" Text='<%# Bind("Estado") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="txtEstadoGrid" runat="server" Text='<%# Bind("Estado") %>'></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Imagen">
                        <ItemTemplate>
                            <asp:Image ID="imgVehiculo" runat="server" ImageUrl='<%# Bind("UrlImagen") %>' Width="180" Height="145" />
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Imagen">
                        <ItemTemplate>
                            <asp:Image ID="imgVehiculo2" runat="server" ImageUrl='<%# Bind("UrlImagen2") %>' Width="180" Height="145" />
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Imagen">
                        <ItemTemplate>
                            <asp:Image ID="imgVehiculo3" runat="server" ImageUrl='<%# Bind("UrlImagen3") %>' Width="180" Height="145" />
                        </ItemTemplate>
                    </asp:TemplateField>





                    <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true" />
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
