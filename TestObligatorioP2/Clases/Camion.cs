using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestObligatorioP2.Clases
{
    public class Camion : Vehiculo
    {

        public int CapacidadCarga { get; set; }

        public int getcapacidadCarga() { return this.CapacidadCarga; }
        public void setcapacidadCarga(int capacidadCarga) { this.CapacidadCarga = capacidadCarga; }
    }
}