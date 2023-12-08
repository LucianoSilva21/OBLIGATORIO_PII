using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestObligatorioP2;
using TestObligatorioP2.Clases;

namespace TestObligatorioP2
{

    public partial class Ventas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.FindControl("lnkAlquileres").Visible = BaseDeDatos.usuarioLogeado.getVerAlquileres();
            Master.FindControl("lnkVentas").Visible = BaseDeDatos.usuarioLogeado.getVerVentas();
            Master.FindControl("lnkVehiculos").Visible = BaseDeDatos.usuarioLogeado.getVerVehiculos();
            Master.FindControl("lnkUsuarios").Visible = BaseDeDatos.usuarioLogeado.getVerUsuarios();
            Master.FindControl("lnkClientes").Visible = BaseDeDatos.usuarioLogeado.getVerClientes();
            if (!IsPostBack)
            {
                // Solo realizar el enlace de datos la primera vez que se carga la página
                DropDownListAutos.DataBind();
                DropDownListClientes.DataBind();
                gvVentas.DataSource = BaseDeDatos.listaVentas;
                gvVentas.DataBind();
            }
        }
        protected void DropDownListAutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Vehiculo autoSeleccionado = null;
            // Obtén el precio del vehículo seleccionado (aquí asumo que hay una propiedad "Precio" en tu clase Auto)
            string matriculaSeleccionada = DropDownListAutos.SelectedValue;
            foreach (var vehiculo in BaseDeDatos.VehiculosDisponibles())
            {
                if (vehiculo.getMatricula() == matriculaSeleccionada)
                {
                    autoSeleccionado = vehiculo;
                }
            }
            // Muestra el precio en el Label
        }
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            Venta venta = new Venta();
            string matriculaSeleccionada = DropDownListAutos.SelectedValue;

            if (BaseDeDatos.VehiculosDisponibles().Count == 0)
            {
                lblErrorAuto.Text = "No hay vehículos disponibles.";
                return; // Sale del método si la validación falla
            }
            // Verificar si la matrícula seleccionada es nula o vacía
            if (string.IsNullOrEmpty(matriculaSeleccionada))
            {
                lblErrorAuto.Text = "Seleccione un vehículo válido.";
                return; // Sale del método si la validación falla
            }
            venta.setCedula(DropDownListClientes.SelectedItem.Value);

            int precio = 0;
            foreach (var vehiculo in BaseDeDatos.VehiculosDisponibles())
            {
                if (vehiculo.getMatricula() == matriculaSeleccionada)
                {
                    precio = vehiculo.getPrecioVenta();
                    vehiculo.setEstado(false);
                    break;
                }
            }
            int numeroMasAltoo = 0;
            foreach (var numVenta in BaseDeDatos.listaVentas)
            {
                if (numVenta.getID() > numeroMasAltoo)
                {
                    numeroMasAltoo = numVenta.getID();
                }
            }
            venta.setID(numeroMasAltoo);
            venta.setPrecio(precio);
            venta.setFechaVenta(DateTime.Now);
            venta.setMatricula(matriculaSeleccionada);
            venta.setNombreUsuario(BaseDeDatos.usuarioLogeado.Nombre);
            BaseDeDatos.listaVentas.Add(venta);
            DropDownListAutos.DataSource = BaseDeDatos.VehiculosDisponibles();
            DropDownListAutos.DataTextField = "Matricula";
            DropDownListAutos.DataBind();
            this.gvVentas.DataSource = BaseDeDatos.listaVentas;
            this.gvVentas.DataBind();
        }
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Vehiculo autoSeleccionado = null;
            // Obtén el precio del vehículo seleccionado (aquí asumo que hay una propiedad "Precio" en tu clase Auto)
            string matriculaSeleccionada = DropDownListAutos.SelectedValue;
            foreach (var vehiculo in BaseDeDatos.VehiculosDisponibles())
            {
                if (vehiculo.getMatricula() == matriculaSeleccionada)
                {
                    autoSeleccionado = vehiculo;
                }
            }
            // Muestra el precio en el Label
            if (autoSeleccionado != null)
            {
                LabelPrecio.Text = $"Precio del vehiculo: U$S{autoSeleccionado.getPrecioVenta()}";

                LabelPrecio.Visible = true;
            }
            else
            {
                LabelPrecio.Visible = false;
            }
            DropDownListAutos.DataBind();

            this.gvVentas.DataSource = BaseDeDatos.listaVentas;
            this.gvVentas.DataBind();
        }
        protected void gvVentas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int codigo = Convert.ToInt32(this.gvVentas.DataKeys[e.RowIndex].Values[0]);
            foreach (var venta in BaseDeDatos.listaVentas)
            {
                if (venta.Id == codigo)
                {

                    foreach (var vehiculo in BaseDeDatos.listaVehiculos)
                    {
                        if (vehiculo.Matricula == venta.Matricula)
                        {
                            vehiculo.setEstado(true);
                            break;
                        }
                    }
                    BaseDeDatos.listaVentas.Remove(venta);
                    break;
                }
            }
            this.gvVentas.EditIndex = -1;
            this.gvVentas.DataSource = BaseDeDatos.listaVentas;
            this.gvVentas.DataBind();
        }
    }
}
