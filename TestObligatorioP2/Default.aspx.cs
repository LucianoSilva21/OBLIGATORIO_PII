using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestObligatorioP2.Clases;

namespace TestObligatorioP2
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (BaseDeDatos.usuarioLogeado != null)
            {
                Master.FindControl("lnkAlquileres").Visible = BaseDeDatos.usuarioLogeado.getVerAlquileres();
                Master.FindControl("lnkVentas").Visible = BaseDeDatos.usuarioLogeado.getVerVentas();
                Master.FindControl("lnkVehiculos").Visible = BaseDeDatos.usuarioLogeado.getVerVehiculos();
                Master.FindControl("lnkUsuarios").Visible = BaseDeDatos.usuarioLogeado.getVerUsuarios();
                Master.FindControl("lnkClientes").Visible = BaseDeDatos.usuarioLogeado.getVerClientes();
            }
            else
            {
                Master.FindControl("lnkAlquileres").Visible = false;
                Master.FindControl("lnkVentas").Visible = false;
                Master.FindControl("lnkVehiculos").Visible = false;
                Master.FindControl("lnkUsuarios").Visible = false;
                Master.FindControl("lnkClientes").Visible = false;
            }

        }
    }
}