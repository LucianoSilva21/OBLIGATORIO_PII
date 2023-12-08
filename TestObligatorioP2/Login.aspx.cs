using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestObligatorioP2.Clases;

namespace TestObligatorioP2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.FindControl("lnkAlquileres").Visible = false;
            Master.FindControl("lnkVentas").Visible = false;
            Master.FindControl("lnkVehiculos").Visible = false;
            Master.FindControl("lnkUsuarios").Visible = false;
            Master.FindControl("lnkClientes").Visible = false;
            Master.FindControl("lnkLogin").Visible = false;
            if (!Page.IsPostBack && BaseDeDatos.cargarDatos)
            { BaseDeDatos.CargarDatosIniciales(); }
        }
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            bool loginCorrecto = false;
            foreach (var user in BaseDeDatos.listaUsuarios)
            {
                if (user.getNombre() == txtNombre.Text && user.getContraseña() == txtContrasenia.Text)
                {
                    BaseDeDatos.guardarUsuarioLogeado(user);

                    if (BaseDeDatos.usuarioLogeado.getVerVehiculos())
                        Response.Redirect("Vehiculos.aspx");

                    if (BaseDeDatos.usuarioLogeado.getVerClientes())
                        Response.Redirect("Clientes.aspx");

                    if (BaseDeDatos.usuarioLogeado.getVerAlquileres())
                        Response.Redirect("Alquileres.aspx");

                    if (BaseDeDatos.usuarioLogeado.getVerVentas())
                        Response.Redirect("Ventas.aspx");

                    if (BaseDeDatos.usuarioLogeado.getVerUsuarios())
                        Response.Redirect("Usuarios.aspx");
                    loginCorrecto = true;
                }
            }
            if (!loginCorrecto)
            {
                lblError.Visible = true;
                lblError.Text = "usuario y/o contraseña incorrectas.";
            }
        }
    }
}