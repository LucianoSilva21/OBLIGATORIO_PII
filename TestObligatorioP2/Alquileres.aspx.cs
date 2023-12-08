using Antlr.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestObligatorioP2.Clases;

namespace TestObligatorioP2
{
    public partial class Alquileres : System.Web.UI.Page
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
                gvAlquileres.DataSource = BaseDeDatos.listaAlquileres;
                gvAlquileres.DataBind();
            }
        }

        private bool IsNumeric(string value)
        {
            int result;
            return int.TryParse(value, out result);
        }
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            Alquiler alquiler = new Alquiler();
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
            alquiler.setCedula(DropDownListClientes.SelectedItem.Value);
            int numeroMasAltoo = 0;
            foreach (var numalquiler in BaseDeDatos.listaAlquileres)
            {
                if (numalquiler.getCodigo() > numeroMasAltoo)
                {
                    numeroMasAltoo = numalquiler.getCodigo();
                }
            }
            int nuevoCodigoAlquiler = numeroMasAltoo + 1;

            string dias = txtDias.Text.Trim();
            if (IsNumeric(dias) && Convert.ToInt32(dias) > 0)
            {
                alquiler.Dias = Convert.ToInt32(txtDias.Text);
            }
            else
            {
                lblErrorMessage.Text = "Ingrese una cantidad de días válida.";
                return; // Sale del método si la validación falla
            }
            int precio = 0;
            foreach (var vehiculo in BaseDeDatos.VehiculosDisponibles())
            {
                if (vehiculo.getMatricula() == matriculaSeleccionada)
                {
                    precio = vehiculo.getPrecioAlquiler() * alquiler.getDias();
                    vehiculo.setEstado(false);
                    break;
                }
            }
            alquiler.setCodigo(nuevoCodigoAlquiler);
            alquiler.setPrecio(precio);
            alquiler.setFechaAlquiler(DateTime.Now);
            alquiler.setMatricula(matriculaSeleccionada);
            alquiler.setNombreUsuario(BaseDeDatos.usuarioLogeado.Nombre);

            BaseDeDatos.listaAlquileres.Add(alquiler);
            DropDownListAutos.DataSource = BaseDeDatos.VehiculosDisponibles();
            DropDownListAutos.DataTextField = "Matricula";
            DropDownListAutos.DataBind();
            this.gvAlquileres.DataSource = BaseDeDatos.listaAlquileres;
            this.gvAlquileres.DataBind();
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
                LabelPrecio.Text = $"Precio por dia: ${autoSeleccionado.getPrecioAlquiler()}";

                LabelPrecio.Visible = true;

                string dias = txtDias.Text.Trim();
                if (IsNumeric(dias) && dias.Length > 0)
                {
                    int diasP = Convert.ToInt32(dias);
                    LabelPrecioTotal.Text = $"Precio total: ${autoSeleccionado.getPrecioAlquiler() * diasP}";
                    LabelPrecioTotal.Visible = true;
                }
                else
                {
                    lblErrorMessage.Text = "Ingrese una cantidad de días válida.";
                    return; // Sale del método si la validación falla
                }
            }
            else
            {
                LabelPrecio.Visible = false;

            }
            DropDownListAutos.DataBind();

            this.gvAlquileres.DataSource = BaseDeDatos.listaAlquileres;
            this.gvAlquileres.DataBind();
        }
        protected void txtDias_TextChanged(object sender, EventArgs e)
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
                LabelPrecio.Text = $"Precio por dia: ${autoSeleccionado.getPrecioAlquiler()}";

                LabelPrecio.Visible = true;
                string dias = txtDias.Text.Trim();
                if (IsNumeric(dias) && dias.Length > 0)
                {
                    LabelPrecioTotal.Text = $"Precio total: ${autoSeleccionado.getPrecioAlquiler() * Convert.ToInt32(txtDias.Text)}";
                    LabelPrecioTotal.Visible = true;
                }
                else
                {
                    lblErrorMessage.Text = "Ingrese una cantidad de días válida.";
                    return; // Sale del método si la validación falla
                }
            }
            else
            {
                LabelPrecio.Visible = false;
            }
        }
        protected void gvAlquileres_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int codigo = Convert.ToInt32(this.gvAlquileres.DataKeys[e.RowIndex].Values[0]);
            foreach (var alquiler in BaseDeDatos.listaAlquileres)
            {
                if (alquiler.Codigo == codigo)
                {
                    foreach (var vehiculo in BaseDeDatos.listaVehiculos)
                    {
                        if (vehiculo.Matricula  == alquiler.Matricula)
                        {
                            vehiculo.setEstado(true);
                            break;
                        }
                    }
                    BaseDeDatos.listaAlquileres.Remove(alquiler);
                    break;
                }
            }
            this.gvAlquileres.EditIndex = -1;
            this.gvAlquileres.DataSource = BaseDeDatos.listaAlquileres;
            this.gvAlquileres.DataBind();
        }
        protected void gvAlquileres_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.gvAlquileres.EditIndex = -1;
            this.gvAlquileres.DataSource = BaseDeDatos.listaAlquileres;
            this.gvAlquileres.DataBind();
        }
        protected void gvAlquileres_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.gvAlquileres.EditIndex = e.NewEditIndex;
            this.gvAlquileres.DataSource = BaseDeDatos.listaAlquileres;
            this.gvAlquileres.DataBind();
            DropDownListAutos.DataBind();

        }
        protected void gvAlquileres_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow filaSeleccionada = gvAlquileres.Rows[e.RowIndex];
            string codigo = this.gvAlquileres.DataKeys[e.RowIndex].Values[0].ToString();

            CheckBox chkAutoDevueltoGrid = (CheckBox)filaSeleccionada.FindControl("txtAutoDevueltoGrid");
            bool nuevoValorAutoDevuelto = chkAutoDevueltoGrid.Checked;
            string matricula = "";
            foreach (var alquiler in BaseDeDatos.listaAlquileres)
            {
                if (alquiler.getCodigo() == Convert.ToInt32(codigo))
                {
                    alquiler.AutoDevuelto = nuevoValorAutoDevuelto;
                    matricula = alquiler.getMatricula();
                }


            }
            foreach (var auto in BaseDeDatos.listaVehiculos)
            {

                if (auto.getMatricula() == matricula)
                {
                    auto.setEstado(nuevoValorAutoDevuelto);
                }
            }
            this.gvAlquileres.EditIndex = -1;
            this.gvAlquileres.DataSource = BaseDeDatos.listaAlquileres;
            this.gvAlquileres.DataBind();
        }
    }
}