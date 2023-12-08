using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestObligatorioP2.Clases;

namespace TestObligatorioP2
{
    public partial class Usuarios : System.Web.UI.Page
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
                gvUsuarios.DataSource = BaseDeDatos.listaUsuarios;
                gvUsuarios.DataBind();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
            {
                lblErrorNombre.Text = "El nombre no puede estar vacío.";
                return;
            }
            // Verificar si la marca está vacía
            if (string.IsNullOrEmpty(txtContraseña.Text.Trim()))
            {
                lblErrorContrasenia.Text = "La contraseña no puede estar vacío.";
                return;
            }
            string Nombre = txtNombre.Text.Trim();

            // Verificar si ya existe un vehículo con la misma matrícula
            if (BaseDeDatos.listaUsuarios.Any(usuarioo => usuarioo.Nombre == Nombre))
            {
                lblErrorNombre.Text = "Ya existe un usuario con el mismo nombre.";
                return;
            }
            Usuario usuario = new Usuario();
            usuario.setNombre(txtNombre.Text);
            usuario.setContraseña(txtContraseña.Text);
            usuario.setverAlquileres(chbVerAlquileres.Checked);
            usuario.setverClientes(chbVerClientes.Checked);
            usuario.setverUsuarios(chbVerUsuarios.Checked);
            usuario.setverVentas(chbVerVentas.Checked);
            usuario.setverVehiculos(chbVerVehiculos.Checked);
            usuario.setverLogin(true);

            BaseDeDatos.listaUsuarios.Add(usuario);
            this.gvUsuarios.DataSource = BaseDeDatos.listaUsuarios;
            this.gvUsuarios.DataBind();
        }

        protected void gvUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string nombre = this.gvUsuarios.DataKeys[e.RowIndex].Values[0].ToString();
            if (nombre.Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                // If it's the admin user, cancel the deletion process
                return;
            }
            foreach (var usuario in BaseDeDatos.listaUsuarios)
            {
                if (usuario.Nombre == nombre)
                {
                    BaseDeDatos.listaUsuarios.Remove(usuario);
                    break;
                }
            }
            this.gvUsuarios.EditIndex = -1;
            this.gvUsuarios.DataSource = BaseDeDatos.listaUsuarios;
            this.gvUsuarios.DataBind();
        }

        protected void gvUsuarios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.gvUsuarios.EditIndex = -1;
            this.gvUsuarios.DataSource = BaseDeDatos.listaUsuarios;
            this.gvUsuarios.DataBind();
        }

        protected void gvUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
        {



            this.gvUsuarios.EditIndex = e.NewEditIndex;
            this.gvUsuarios.DataSource = BaseDeDatos.listaUsuarios;
            this.gvUsuarios.DataBind();
        }

        protected void gvUsuarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow filaSeleccionada = gvUsuarios.Rows[e.RowIndex];
            if (string.IsNullOrEmpty(this.gvUsuarios.DataKeys[e.RowIndex].Values[0].ToString()))
            {
                lblErrorGrilla.Text = "El nombre no puede estar vacío.";
                return;
            }

            // Verificar si la marca está vacía
            if (string.IsNullOrEmpty((filaSeleccionada.FindControl("txtContraseñaGrid") as TextBox).Text))
            {
                lblErrorGrilla.Text = "La contraseña no puede estar vacío.";
                return;
            }

            string Nombre = txtNombre.Text.Trim();

            // Verificar si ya existe un vehículo con la misma matrícula
            if (BaseDeDatos.listaUsuarios.Any(usuarioo => usuarioo.Nombre == Nombre))
            {
                if (txtNombre.Text != Nombre)
                {
                    lblErrorGrilla.Text = "Ya existe un usuario con el mismo nombre.";
                    return;
                }
            }


            string nombre = this.gvUsuarios.DataKeys[e.RowIndex].Values[0].ToString();
            if (nombre.Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                // If it's the admin user, cancel the editing process
                gvUsuarios.EditIndex = -1;
                gvUsuarios.DataSource = BaseDeDatos.listaUsuarios;
                gvUsuarios.DataBind();
                return;
            }

            string contraseña = (filaSeleccionada.FindControl("txtContraseñaGrid") as TextBox).Text;



            foreach (var usuario in BaseDeDatos.listaUsuarios)
            {
                if (usuario.Nombre == nombre)
                {
                    usuario.Contraseña = contraseña;
                }
            }
            this.gvUsuarios.EditIndex = -1;
            this.gvUsuarios.DataSource = BaseDeDatos.listaUsuarios;
            this.gvUsuarios.DataBind();

            this.gvUsuarios.DataSource = BaseDeDatos.listaUsuarios;
            this.gvUsuarios.DataBind();

        }
    }
}