
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;

namespace TestObligatorioP2.Clases
{
    public class Cliente
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string cedula { get; set; }
        public string mostrarDatos
        {
            get
            {
                return $"Cedula: {cedula} - Nombre: {nombre} {apellido}";
            }
        }
        public void setApellido(string apellido) { this.apellido = apellido; }
        public string getApellido() { return this.apellido; }
        public string getNombre() { return this.nombre; }
        public string getCedula() { return this.cedula; }
        public void setNombre(string nombre) { this.nombre = nombre; }
        public void setCedula(string cedula) { this.cedula = cedula; }
    }
}