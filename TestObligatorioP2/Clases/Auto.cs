using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestObligatorioP2.Clases
{
    public class Auto : Vehiculo
    {

        public int CantPasajeros { get; set; }
        public int getCantPasajeros() { return this.CantPasajeros; }
        public void setCantPasajeros(int cantPasajeros) { this.CantPasajeros = cantPasajeros; }
    }
}