using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestObligatorioP2.Clases
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public bool verClientes { get; set; }
        public bool verUsuarios { get; set; }
        public bool verVentas { get; set; }
        public bool verVehiculos { get; set; }
        public bool verAlquileres { get; set; }
        public bool verLogin{ get; set; }

        public void setNombre(string nombre) { this.Nombre = nombre; }
        public string getNombre() { return this.Nombre; }
        public string getContraseña() { return this.Contraseña; }
        public void setContraseña(string contra) { this.Contraseña = contra; }
        public bool getVerClientes() { return this.verClientes; }
        public bool getVerUsuarios() { return this.verUsuarios; }
        public bool getVerVentas() { return this.verVentas; }
        public bool getVerVehiculos() { return this.verVehiculos; }
        public bool getVerAlquileres() { return this.verAlquileres; }
        public bool getVerLogin() { return this.verLogin; }

        public void setverLogin(bool e) { this.verLogin = e; }
        public void setverClientes(bool e) { this.verClientes = e; }
        public void setverUsuarios(bool e) { this.verUsuarios = e; }
        public void setverVentas(bool e) { this.verVentas = e; }
        public void setverVehiculos(bool e) { this.verVehiculos = e; }
        public void setverAlquileres(bool e) { this.verAlquileres = e; }



    }
}