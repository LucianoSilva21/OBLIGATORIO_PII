using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestObligatorioP2.Clases;
using static System.Net.Mime.MediaTypeNames;

namespace TestObligatorioP2
{
    public partial class Vehiculos : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.FindControl("lnkAlquileres").Visible = BaseDeDatos.usuarioLogeado.getVerAlquileres();
            Master.FindControl("lnkVentas").Visible = BaseDeDatos.usuarioLogeado.getVerVentas();
            Master.FindControl("lnkVehiculos").Visible = BaseDeDatos.usuarioLogeado.getVerVehiculos();
            Master.FindControl("lnkUsuarios").Visible = BaseDeDatos.usuarioLogeado.getVerUsuarios();
            Master.FindControl("lnkClientes").Visible = BaseDeDatos.usuarioLogeado.getVerClientes();

            if (!IsPostBack)  // Only bind data on initial page load, not on postback
            {
                gvVehiculos.DataSource = BaseDeDatos.listaVehiculos;
                gvVehiculos.DataBind();
            }
        }
        private bool IsNumeric(string value)
        {
            int result;
            return int.TryParse(value, out result);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {




            if (string.IsNullOrEmpty(txtMatricula.Text.Trim()))
            {
                lblErrorMessage.Text = "Ingrese la matrícula del vehículo.";
                return;
            }

            // Verificar si la marca está vacía
            if (string.IsNullOrEmpty(txtMarca.Text.Trim()))
            {
                lblErrorMarca.Text = "Ingrese la marca del vehículo.";
                return;
            }

            // Verificar si el modelo está vacío
            if (string.IsNullOrEmpty(txtModelo.Text.Trim()))
            {
                lblErrorModelo.Text = "Ingrese el modelo del vehículo.";
                return;
            }

            // Verificar si el color está vacío
            if (string.IsNullOrEmpty(txtColor.Text.Trim()))
            {
                lblErrorColor.Text = "Ingrese el color del vehículo.";
                return;
            }

            string Matricula = txtMatricula.Text.Trim();

            // Verificar si ya existe un vehículo con la misma matrícula
            if (BaseDeDatos.listaVehiculos.Any(vehiculoo => vehiculoo.Matricula == Matricula))
            {
                lblErrorMessage.Text = "Ya existe un vehículo con la misma matrícula.";
                return;
            }

            Vehiculo vehiculo;

            if (rblTipoVehiculo.SelectedValue == "Auto")
            {
                Auto auto = new Auto();
                string CantPasajeros = txtCantPasajeros.Text.Trim();
                if (IsNumeric(CantPasajeros) && Convert.ToInt32(CantPasajeros) > 0)
                {
                    auto.setCantPasajeros(Convert.ToInt32(txtCantPasajeros.Text));
                    vehiculo = auto;
                }
                else
                {
                    lblErrorMessageCP.Text = "Ingrese una cantidad de pasajeros válida.";
                    return;
                }
            }
            else if (rblTipoVehiculo.SelectedValue == "Camion")
            {



                Camion camion = new Camion();
                string capCarga = txtCapacidadCarga.Text.Trim();
                if (IsNumeric(capCarga) && Convert.ToInt32(capCarga) > 0)
                {
                    camion.setcapacidadCarga(Convert.ToInt32(txtCapacidadCarga.Text));
                    vehiculo = camion;
                }
                else
                {
                    lblErrorMessageCC.Text = "Ingrese una capacidad de carga válida.";
                    return;
                }


            }
            else if (rblTipoVehiculo.SelectedValue == "Moto")
            {
                Moto moto = new Moto();
                string cilindrada = txtCilindrada.Text.Trim();
                if (IsNumeric(cilindrada) && Convert.ToInt32(cilindrada) > 0)
                {
                    moto.setcilindrada(Convert.ToInt32(txtCilindrada.Text));
                    vehiculo = moto;

                }
                else
                {
                    lblErrorMessageMoto.Text = "Ingrese una cilindrada válida.";
                    return;
                }


            }
            else
            {
                LabelTP.Text = "Seleccione un tipo de vehículo.";
                return;
            }
            try
            {
                vehiculo.UrlImagen = txtUrlImagen.Text;

            }
            catch (Exception ex)
            {
                // Manejo de la excepción
                Console.WriteLine("Error al cargar la imagen: " + ex.Message);
            }
            try
            {
                vehiculo.UrlImagen2 = txtUrlImagen2.Text;

            }
            catch (Exception ex)
            {
                // Manejo de la excepción
                Console.WriteLine("Error al cargar la imagen: " + ex.Message);
            }
            try
            {
                vehiculo.UrlImagen3 = txtUrlImagen3.Text;

            }
            catch (Exception ex)
            {
                // Manejo de la excepción
                Console.WriteLine("Error al cargar la imagen: " + ex.Message);
            }




            vehiculo.Matricula = Matricula;
            vehiculo.Modelo = txtModelo.Text;
            vehiculo.Marca = txtMarca.Text;
            vehiculo.Color = txtColor.Text;
            vehiculo.Estado = true;


            string anio = txtAnio.Text.Trim();
            if (IsNumeric(anio) && Convert.ToInt32(anio) > 0)
            {
                vehiculo.Anio = Convert.ToInt32(txtAnio.Text);
            }
            else
            {
                lblErrorAnio.Text = "Ingrese una cantidad de años válida.";
                return; // Sale del método si la validación falla
            }


            string kilometraje = txtKilometraje.Text.Trim();
            if (IsNumeric(kilometraje) && Convert.ToInt32(kilometraje) > 0)
            {
                vehiculo.Kilometros = Convert.ToInt32(txtKilometraje.Text);
            }
            else
            {
                lblErrorKilometraje.Text = "Ingrese una cantidad de kilómetros válida.";
                return; // Sale del método si la validación falla
            }

            string PrecioVenta = txtPrecioVenta.Text.Trim();
            if (IsNumeric(PrecioVenta) && Convert.ToInt32(PrecioVenta) > 0)
            {
                vehiculo.PrecioVenta = Convert.ToInt32(txtPrecioVenta.Text);
            }
            else
            {
                lblErrorPrecioVenta.Text = "Ingrese un precio válido.";
                return; // Sale del método si la validación falla
            }

            string PrecioAlquiler = txtPrecioAlquiler.Text.Trim();
            if (IsNumeric(PrecioAlquiler) && Convert.ToInt32(PrecioAlquiler) > 0)
            {
                vehiculo.PrecioAlquiler = Convert.ToInt32(txtPrecioAlquiler.Text);
            }
            else
            {
                lblErrorPrecioAlquiler.Text = "Ingrese un precio válido.";
                return; // Sale del método si la validación falla
            }

            BaseDeDatos.listaVehiculos.Add(vehiculo);

            this.gvVehiculos.DataSource = BaseDeDatos.listaVehiculos;
            this.gvVehiculos.DataBind();



        }
        
        protected void gvVehiculos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Vehiculo vehiculo = (Vehiculo)e.Row.DataItem;
                Label lblAtributoEspecial = (Label)e.Row.FindControl("lblAtributoEspecial");
                TextBox txtAtributoEspecialGrid = (TextBox)e.Row.FindControl("txtAtributoEspecialGrid");



                if (lblAtributoEspecial != null && txtAtributoEspecialGrid != null)
                {
                    if (vehiculo is Auto auto)
                    {
                        lblAtributoEspecial.Text = auto.CantPasajeros.ToString();
                        txtAtributoEspecialGrid.Text = auto.CantPasajeros.ToString();
                    }
                    else if (vehiculo is Moto moto)
                    {
                        lblAtributoEspecial.Text = moto.Cilindrada.ToString();
                        txtAtributoEspecialGrid.Text = moto.Cilindrada.ToString();
                    }
                    else if (vehiculo is Camion camion)
                    {
                        lblAtributoEspecial.Text = camion.CapacidadCarga.ToString();
                        txtAtributoEspecialGrid.Text = camion.CapacidadCarga.ToString();
                    }
                }

            }
        }


        protected void gvVehiculos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string matricula = this.gvVehiculos.DataKeys[e.RowIndex].Values[0].ToString();

            foreach (var vehiculo in BaseDeDatos.listaVehiculos)
            {
                if (vehiculo.Matricula == matricula)
                {
                    BaseDeDatos.listaVehiculos.Remove(vehiculo);
                    break;
                }
            }
            this.gvVehiculos.EditIndex = -1;
            this.gvVehiculos.DataSource = BaseDeDatos.listaVehiculos;
            this.gvVehiculos.DataBind();
        }

        protected void gvVehiculos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.gvVehiculos.EditIndex = -1;
            this.gvVehiculos.DataSource = BaseDeDatos.listaVehiculos;
            this.gvVehiculos.DataBind();
        }

        protected void gvVehiculos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.gvVehiculos.EditIndex = e.NewEditIndex;
            this.gvVehiculos.DataSource = BaseDeDatos.listaVehiculos;
            this.gvVehiculos.DataBind();
        }

        protected void gvVehiculos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            GridViewRow filaSeleccionada = gvVehiculos.Rows[e.RowIndex];
            string matricula = this.gvVehiculos.DataKeys[e.RowIndex].Values[0].ToString();


            string marca = (filaSeleccionada.FindControl("txtMarcaGrid") as TextBox).Text;
            string modelo = (filaSeleccionada.FindControl("txtModeloGrid") as TextBox).Text;
            string color = (filaSeleccionada.FindControl("txtcolorGrid") as TextBox).Text;


            if (string.IsNullOrEmpty(marca))
            {

                LabelErrorGrilla.Text = "Ingrese la marca del vehículo.";
                return;
            }

            // Verificar si el modelo está vacío
            if (string.IsNullOrEmpty(modelo))
            {
                LabelErrorGrilla.Text = "Ingrese el modelo del vehículo.";
                return;
            }

            // Verificar si el color está vacío
            if (string.IsNullOrEmpty(color))
            {
                LabelErrorGrilla.Text = "Ingrese el color del vehículo.";
                return;
            }

            int anioFinal = 0;
            string anio = (filaSeleccionada.FindControl("txtAnioGrid") as TextBox).Text;
            if (IsNumeric(anio) && anio.Length > 0)
            {
                anioFinal = Convert.ToInt32(anio);
            }
            else
            {
                LabelErrorGrilla.Text = "Ingrese una cantidad de años válida.";
                return; // Sale del método si la validación falla
            }


            int KilometrajeFinal = 0;
            string kilometraje = (filaSeleccionada.FindControl("txtKilometrajeGrid") as TextBox).Text;
            if (IsNumeric(kilometraje) && kilometraje.Length > 0)
            {
                KilometrajeFinal = Convert.ToInt32(kilometraje);
            }
            else
            {
                LabelErrorGrilla.Text = "Ingrese una cantidad de kilómetros válida.";
                return; // Sale del método si la validación falla
            }


            int precioventaFinal = 0;
            string PrecioVenta = (filaSeleccionada.FindControl("txtPrecioVentaGrid") as TextBox).Text;
            if (IsNumeric(PrecioVenta) && PrecioVenta.Length > 0)
            {
                precioventaFinal = Convert.ToInt32(PrecioVenta);
            }
            else
            {
                LabelErrorGrilla.Text = "Ingrese un precio válido.";
                return; // Sale del método si la validación falla
            }

            int precioAlqulerFinal = 0;
            string PrecioAlquiler = (filaSeleccionada.FindControl("txtPrecioAlquilerGrid") as TextBox).Text;
            if (IsNumeric(PrecioAlquiler) && PrecioAlquiler.Length > 0)
            {
                precioAlqulerFinal = Convert.ToInt32(PrecioAlquiler);
            }
            else
            {
                LabelErrorGrilla.Text = "Ingrese un precio válido.";
                return; // Sale del método si la validación falla
            }

            int cantPasajerosFinal = 0;
            string CantPasajeros = (filaSeleccionada.FindControl("txtAtributoEspecialGrid") as TextBox).Text;
            if (IsNumeric(CantPasajeros) && CantPasajeros.Length > 0)
            {
                cantPasajerosFinal = Convert.ToInt32(CantPasajeros);
            }
            else
            {
                LabelErrorGrilla.Text = "Ingrese una cantidad de pasajeros válida.";
                return; // Sale del método si la validación falla
            }


            int capacidadCargaFinal = 0;
            string capacidadCarga = (filaSeleccionada.FindControl("txtAtributoEspecialGrid") as TextBox).Text;
            if (IsNumeric(capacidadCarga) && capacidadCarga.Length > 0)
            {
                capacidadCargaFinal = Convert.ToInt32(capacidadCarga);
            }
            else
            {
                LabelErrorGrilla.Text = "Ingrese una capacidad de carga válida.";
                return; // Sale del método si la validación falla
            }



            int cilindradaFinal = 0;
            string cilindrada = (filaSeleccionada.FindControl("txtAtributoEspecialGrid") as TextBox).Text;
            if (IsNumeric(cilindrada) && cilindrada.Length > 0)
            {
                cilindradaFinal = Convert.ToInt32(cilindrada);
            }
            else
            {
                LabelErrorGrilla.Text = "Ingrese una cilindrada válida.";
                return; // Sale del método si la validación falla
            }


            foreach (var vehiculo in BaseDeDatos.listaVehiculos)
            {
                if (vehiculo.Matricula == matricula)
                {
                    if (vehiculo is Camion camion)
                    {
                        camion.setcapacidadCarga(capacidadCargaFinal);
                    }
                    else if (vehiculo is Moto moto)
                    {
                        moto.setcilindrada(cilindradaFinal);

                    }
                    else if (vehiculo is Auto auto)
                    {
                        auto.setCantPasajeros(cantPasajerosFinal);

                    }

                    vehiculo.Marca = marca;
                    vehiculo.Modelo = modelo;
                    vehiculo.Color = color;
                    vehiculo.PrecioVenta = precioventaFinal;
                    vehiculo.PrecioAlquiler = precioAlqulerFinal;
                    vehiculo.Kilometros = KilometrajeFinal;
                    vehiculo.Anio = anioFinal;
                }
            }


            this.gvVehiculos.EditIndex = -1;
            this.gvVehiculos.DataSource = BaseDeDatos.listaVehiculos;
            this.gvVehiculos.DataBind();
        }
        protected string ObtenerAtributoEspecial(object vehiculo)
        {

            if (vehiculo is Auto auto)
            {
                return  "Cant. Pasajeros: "+ auto.CantPasajeros.ToString();

            }
            if (vehiculo is Moto moto)
            {
                return "Cilindrada: " + moto.Cilindrada.ToString();

            }
            if (vehiculo is Camion camion)
            {
                return "Toneladas: " + camion.CapacidadCarga.ToString();
            }
            else
            {
                return string.Empty;
            }


        }



        protected void dgVehiculos_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Vehiculo vehiculo = (Vehiculo)e.Item.DataItem;

                // Encuentra la etiqueta correspondiente al atributo especial
                Label lblAtributoEspecial = (Label)e.Item.FindControl("lblAtributoEspecial");

                // Ajusta el texto de la etiqueta según el tipo de vehículo
                if (vehiculo is Camion)
                {
                    lblAtributoEspecial.Text = ((Camion)vehiculo).CapacidadCarga.ToString();
                }
                else if (vehiculo is Auto)
                {
                    lblAtributoEspecial.Text = ((Auto)vehiculo).CantPasajeros.ToString();
                }
                else if (vehiculo is Moto)
                {
                    lblAtributoEspecial.Text = ((Moto)vehiculo).Cilindrada.ToString();
                }

                // Oculta la columna del URL de la imagen
                e.Item.Cells[8].Visible = false; // Ajusta el índice según la posición de la columna
            }
        }

        protected void rblTipoVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (rblTipoVehiculo.SelectedValue == "Auto")
            {
                txtCantPasajeros.Visible = true;
                txtCapacidadCarga.Visible = false;
                txtCilindrada.Visible = false;

            }
            else if (rblTipoVehiculo.SelectedValue == "Moto")
            {
                txtCantPasajeros.Visible = false;
                txtCapacidadCarga.Visible = false;
                txtCilindrada.Visible = true;
            }
            else if (rblTipoVehiculo.SelectedValue == "Camion")
            {
                txtCantPasajeros.Visible = false;

                txtCapacidadCarga.Visible = true;
                txtCilindrada.Visible = false;

            }
        }
    }
}