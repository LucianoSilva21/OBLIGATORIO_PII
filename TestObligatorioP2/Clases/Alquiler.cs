using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestObligatorioP2.Clases
{
    public class Alquiler
    {
        public int Codigo { get; set; }
        public string Cedula { get; set; }
        public string NombreUsuario { get; set; }
        public string Matricula { get; set; }
        public DateTime FechaAlquiler { get; set; }
        public int Dias { get; set; }
        public int Precio { get; set; }
        public bool AutoDevuelto { get; set; }
        public string Estado
        {
            get
            {
                if (!AutoDevuelto && DateTime.Now > FechaAlquiler.AddDays(Dias))
                {
                    return "Atrasado";
                }
                else if (!AutoDevuelto)
                {
                    return "Al dia";
                }
                else
                {
                    return "Entregado";
                }
            }
        }
        public void setCedula(string Cedula) { this.Cedula = Cedula; }
        public void setNombreUsuario(string NombreUsuario) { this.NombreUsuario = NombreUsuario; }
        public void setMatricula(string Matricula) { this.Matricula = Matricula; }
        public void setFechaAlquiler(DateTime FechaAlquiler) { this.FechaAlquiler = FechaAlquiler; }
        public void setDias(int Dias) { this.Dias = Dias; }
        public void setPrecio(int Precio) { this.Precio = Precio; }
        public void setAutoDevuelto(bool AutoDevuelto) { this.AutoDevuelto = AutoDevuelto; }
        public void setCodigo(int codigo) { this.Codigo = codigo; }
        public int getCodigo() { return this.Codigo; }
        public bool getAutoDevuelto() { return this.AutoDevuelto; }
        public string getCedula() { return this.Cedula; }
        public string getMatricula() { return this.Matricula; }
        public string getNombreUsuario() { return this.NombreUsuario; }
        public DateTime getFechaAlquiler() { return this.FechaAlquiler; }
        public int getDias() { return this.Dias; }
        public int getPrecio() { return this.Precio; }
    }
}