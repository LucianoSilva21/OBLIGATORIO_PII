using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestObligatorioP2.Clases
{
    public class Moto : Vehiculo
    {

        public int Cilindrada { get; set; }

        public int getcilindrada() { return this.Cilindrada; }
        public void setcilindrada(int cilindrada) { this.Cilindrada = cilindrada; }

    }
}