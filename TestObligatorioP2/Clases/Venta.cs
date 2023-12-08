using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestObligatorioP2.Clases
{
    public class Venta
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string NombreUsuario { get; set; }
        public string Matricula { get; set; }
        public DateTime FechaVenta { get; set; }
        public int Precio { get; set; }
        public void setID(int id) { this.Id = id; }
        public void setCedula(string Cedula) { this.Cedula = Cedula; }
        public void setNombreUsuario(string NombreUsuario) { this.NombreUsuario =NombreUsuario;}
        public void setMatricula(string Matricula) { this.Matricula = Matricula; }
        public void setFechaVenta(DateTime FechaVenta) { this.FechaVenta = FechaVenta; }
        public void setPrecio(int Precio) { this.Precio = Precio; }
        public int getID() { return this.Id; }
        public string getCedula() { return this.Cedula; }
        public string getMatricula() { return this.Matricula; }
        public string getNombreUsuario() { return this.NombreUsuario; }
        public DateTime getFechaVenta() { return this.FechaVenta; }
        public int getPrecio() { return this.Precio; }
    }
}