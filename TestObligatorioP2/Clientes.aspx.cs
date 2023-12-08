using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestObligatorioP2.Clases;
using Validator;

namespace TestObligatorioP2
{
    public partial class Clientes : System.Web.UI.Page
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
                gvClientes.DataSource = BaseDeDatos.listaClientes;
                gvClientes.DataBind();
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string cedula = txtCedula.Text.Trim();
            // Verificar si ya existe un usuario con la misma cédula
            if (BaseDeDatos.listaClientes.Any(clientee => clientee.cedula == cedula))
            {
                lblErrorMessage.Text = "Ya existe un usuario con la misma cédula.";
                return;
            }
            Cliente cliente = new Cliente();
            if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
            {
                lblErrorNombre.Text = "Ingrese el nombre del usuario.";
                return;
            }
            if (string.IsNullOrEmpty(txtApellido.Text.Trim()))
            {
                lblErrorApellido.Text = "Ingrese el apellido del usuario.";
                return;
            }
            cliente.nombre = txtNombre.Text;
            cliente.apellido = txtApellido.Text;
            try
            {
                if (CIValidator.Validate(cedula))
                {
                    cliente.cedula = txtCedula.Text;
                }
                else
                {
                    lblErrorMessage.Text = "Cédula inválida. Por favor, ingrese una cédula correcta.";
                    return; // Sale del método si la validación falla
                }
            }
            catch (Exception)
            {
                lblErrorMessage.Text = "Cédula inválida. Por favor, ingrese una cédula correcta.";
                return; // Sale del método si la validación falla
            }
            BaseDeDatos.listaClientes.Add(cliente);
            gvClientes.DataSource = BaseDeDatos.listaClientes;
            gvClientes.DataBind();
        }


        protected void gvClientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string cedula = this.gvClientes.DataKeys[e.RowIndex].Values[0].ToString();

            foreach (var cliente in BaseDeDatos.listaClientes)
            {
                if (cliente.cedula == cedula)
                {
                    BaseDeDatos.listaClientes.Remove(cliente);
                    break;
                }
            }

            this.gvClientes.EditIndex = -1;
            this.gvClientes.DataSource = BaseDeDatos.listaClientes;
            this.gvClientes.DataBind();

            this.gvClientes.DataSource = BaseDeDatos.listaClientes;
            this.gvClientes.DataBind();

        }

        protected void gvClientes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.gvClientes.EditIndex = -1;
            this.gvClientes.DataSource = BaseDeDatos.listaClientes;
            this.gvClientes.DataBind();
        }

        protected void gvClientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.gvClientes.EditIndex = e.NewEditIndex;
            this.gvClientes.DataSource = BaseDeDatos.listaClientes;
            this.gvClientes.DataBind();
        }

        protected void gvClientes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            GridViewRow filaSeleccionada = gvClientes.Rows[e.RowIndex];
            string cedula = this.gvClientes.DataKeys[e.RowIndex].Values[0].ToString();

            if (string.IsNullOrEmpty((filaSeleccionada.FindControl("txtNombreGrid") as TextBox).Text))
            {
                lblErrorGrilla.Text = "Ingrese un nombre válido.";
                return;
            }

            if (string.IsNullOrEmpty((filaSeleccionada.FindControl("txtApellidoGrid") as TextBox).Text))
            {
                lblErrorGrilla.Text = "Ingrese un apellido válido.";
                return;
            }
            string nombre = (filaSeleccionada.FindControl("txtNombreGrid") as TextBox).Text;
            string apellido = (filaSeleccionada.FindControl("txtApellidoGrid") as TextBox).Text;


            Cliente cliente = BaseDeDatos.listaClientes.FirstOrDefault(c => c.cedula == cedula);

            if (cliente != null)
            {
                // Actualizar solo el nombre y apellido, no la cédula
                cliente.nombre = nombre;
                cliente.apellido = apellido;
            }
            this.gvClientes.EditIndex = -1;
            this.gvClientes.DataSource = BaseDeDatos.listaClientes;
            this.gvClientes.DataBind();
        }
    }
}












