using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;

namespace TestObligatorioP2.Clases
{
    public abstract class BaseDeDatos
    {
        public static List<Cliente> listaClientes = new List<Cliente>();

        public static List<Vehiculo> listaVehiculos = new List<Vehiculo>();
        public static List<Usuario> listaUsuarios = new List<Usuario>();
        public static Usuario usuarioLogeado;
        public static List<Alquiler> listaAlquileres = new List<Alquiler>();
        public static List<Venta> listaVentas = new List<Venta>();
        public static bool cargarDatos = true;

        public static List<Vehiculo> VehiculosDisponibles()
        {
            List<Vehiculo> listaVehiculosDisponibles = new List<Vehiculo>();

            foreach (var vehiculo in listaVehiculos)
            {
                if (vehiculo.getEstado() == true)
                {
                    listaVehiculosDisponibles.Add(vehiculo);
                }
            }
            return listaVehiculosDisponibles;
        }

        public static List<Vehiculo> VehiculosActivos()
        {
            List<Vehiculo> listaVehiculosActivos = new List<Vehiculo>();
            foreach (var vehiculo in listaVehiculos)
            {
                if (vehiculo.getEstado() == false)
                {
                    listaVehiculosActivos.Add(vehiculo);
                }
            }
            return listaVehiculosActivos;
        }
        public static void CargarDatosIniciales()
        {
            Usuario usuario = new Usuario();
            usuario.setNombre("Admin");
            usuario.setContraseña("Admin");
            usuario.setverAlquileres(true);
            usuario.setverClientes(true);
            usuario.setverVehiculos(true);
            usuario.setverUsuarios(true);
            usuario.setverVentas(true);

            listaUsuarios.Add(usuario);

            Auto auto1 = new Auto { Matricula = "auto1", Marca = "Nissan", Modelo = "Sentra", Anio = 2022, Kilometros = 20000, Color = "Rojo", PrecioVenta = 34990, PrecioAlquiler = 9500, UrlImagen = "https://fotos.perfil.com/2021/10/04/nissan-sentra-1239315.jpg", UrlImagen2 = "https://fotos.perfil.com/2021/10/04/nissan-sentra-1239318.jpg", UrlImagen3 = "https://fotos.perfil.com/2021/10/04/nissan-sentra-1239317.jpg", Estado = true, CantPasajeros = 6 };
            Camion Camion1 = new Camion { Matricula = "camion1", Marca = "Mercedes", Modelo = "Atego", Anio = 2022, Kilometros = 70000, Color = "Blanco", PrecioVenta = 80000, PrecioAlquiler = 13500, UrlImagen = "https://http2.mlstatic.com/D_NQ_NP_971973-MLU72182666676_102023-O.webp", UrlImagen2 = "https://http2.mlstatic.com/D_NQ_NP_642164-MLU70649969979_072023-O.webp", UrlImagen3 = "https://http2.mlstatic.com/D_NQ_NP_725969-MLU72182666688_102023-O.webp", Estado = true, CapacidadCarga = 10 };
            Moto Moto1 = new Moto { Matricula = "moto1", Marca = "Baccio", Modelo = "PX", Anio = 2022, Kilometros = 3000, Color = "Gris", PrecioVenta = 1299, PrecioAlquiler = 1500, UrlImagen = "https://http2.mlstatic.com/D_NQ_NP_2X_898113-MLU41826056500_052020-F.webp", UrlImagen2 = "https://http2.mlstatic.com/D_NQ_NP_2X_959764-MLU45296894177_032021-F.webp", UrlImagen3 = "https://http2.mlstatic.com/D_NQ_NP_2X_959230-MLU45296846667_032021-F.webp", Estado = true, Cilindrada = 125 };

            listaVehiculos.Add(auto1);
            listaVehiculos.Add(Moto1);
            listaVehiculos.Add(Camion1);


            Cliente cliente1 = new Cliente { nombre = "Alejandro", apellido = "Garnacho", cedula = "54898504" };
            Cliente cliente2 = new Cliente { nombre = "Karim", apellido = "Benzema", cedula = "11111111" };
            Cliente cliente3 = new Cliente { nombre = "Ronald", apellido = "Araujo", cedula = "53177208" };

            listaClientes.Add(cliente1);
            listaClientes.Add(cliente3);
            listaClientes.Add(cliente2);
            cargarDatos = false;
        }

        public static void guardarUsuarioLogeado(Usuario usuario)
        {
            usuarioLogeado = usuario;
        }



    }
}