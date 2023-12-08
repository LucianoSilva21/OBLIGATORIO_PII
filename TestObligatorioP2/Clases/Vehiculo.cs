using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestObligatorioP2.Clases
{
    public class Vehiculo
    {
        public string Matricula { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public int Kilometros { get; set; }
        public string Color { get; set; }
        public int PrecioVenta { get; set; }
        public int PrecioAlquiler { get; set; }
        public string UrlImagen { get; set; }
        public string UrlImagen2 { get; set; }
        public string UrlImagen3 { get; set; }
        public bool Estado { get; set; } //FALSE = ALQUILADO Y TRUE = DISPONIBLE.
        public string mostrarDatos
        {
            get
            {
                return $"Matricula: {Matricula} - Marca: {Marca} - Modelo: {Modelo}";
            }
        }

        public void setMatricula(string matricula) { this.Matricula = matricula; }
        public string getMatricula() { return this.Matricula; }
        public void setMarca(string marca) { this.Marca = marca; }
        public string getMarca() { return this.Marca; }
        public bool getEstado() { return this.Estado; }
        public void setEstado(bool Estado) { this.Estado = Estado; }
        public void setModelo(string modelo) { this.Modelo = modelo; }
        public string getModelo() { return this.Modelo; }
        public void setAnio(int anio) { this.Anio = anio; }
        public int getAnio() { return this.Anio; }
        public void setKilometros(int kilometros) { this.Kilometros = kilometros; }
        public int getKilometros() { return this.Kilometros; }
        public void setColor(string color) { this.Color = color; }
        public string getColor() { return this.Color; }
        public void setPrecioVenta(int precioVenta) { this.PrecioVenta = precioVenta; }
        public int getPrecioVenta() { return this.PrecioVenta; }
        public void setPrecioAlquiler(int precioAlquiler) { this.PrecioAlquiler = precioAlquiler; }
        public int getPrecioAlquiler() { return this.PrecioAlquiler; }



    }
}