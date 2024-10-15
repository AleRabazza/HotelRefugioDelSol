using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HotelRefugioDelSol
{
    internal class Menu
    {
        public void MostrarMenu()
        {
            string Input = string.Empty;
            Console.WriteLine("Bienvenido al Sistema de Reserva de 'Hotel Refugio del Sol'");
            while (Input != "salir")
            {
                Console.WriteLine("Ingrese la opcion deseada");
                Console.WriteLine("(1) Ingresar a la controladora de Huespedes");
                Console.WriteLine("(2) Ingresar a la controladora de Apartamentos");
                Console.WriteLine("(3) Ingresar a la controladora de Reservas");
                Console.WriteLine("(4) Ingresar a Estadisticas");
                Input = Console.ReadLine();
                switch (Input)
                {
                    case "1":

                        break;
                }
            }

        }

        public void MostrarMenuHuespedes()
        {
            ControladoraHuspedes ControladoraHuespedes = new ControladoraHuspedes();
            string InputHuesped = string.Empty;
            Console.WriteLine("Controladora De Huespedes");
            Console.WriteLine("(1) Agregar Huesped");
            Console.WriteLine("(2) Buscar Huesped");
            Console.WriteLine("(3) Listar Huespedes por alfabeto");
            Console.WriteLine("(4) Modificar Huesped");
            Console.WriteLine("(5) VOLVER AL MENU PRINCIPAL");

            switch (InputHuesped)
            {
                case "1":
                    Console.WriteLine("Ingrese el nombre del Huesped");     //Agregar verificacion de datos
                    string nombre = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Ingrese la cedula del Huesped");
                    int cedula = int.Parse(Console.ReadLine() ?? string.Empty);
                    Huesped huesped1 = new Huesped(nombre, cedula);
                    ControladoraHuespedes.IngresoHuesped(huesped1);
                    Console.Clear();
                    Console.WriteLine("Agregado con exito");
                    Console.WriteLine("");
                    break;

                case "2":
                    Console.WriteLine("Ingrese la cedula del Huesped a buscar");
                    int cedula1 = int.Parse (Console.ReadLine() ?? string.Empty);
                    Huesped? huespedBuscado = ControladoraHuespedes.BuscarHuespedPorCi(cedula1);
                    if (huespedBuscado != null)
                    {
                        ControladoraHuespedes.MostrarHuesped(huespedBuscado);
                    }
                    else
                    { 
                        Console.WriteLine("Huesped no encontrado"); 
                    }
                    break;

                case "3":
                    ControladoraHuespedes.ListarHuespedesPorAlfabeto();
                    break;

                case "4":
                    Console.WriteLine("Ingrese la cedula del Huesped a modificar");
                    int cedula2 = int.Parse(Console.ReadLine() ?? string.Empty);
                    Huesped? huesped2 = ControladoraHuespedes.BuscarHuespedPorCi(cedula2);
                    if (huesped2 != null)
                    {
                        ControladoraHuespedes.MostrarHuesped(huesped2);
                        Console.WriteLine("Ingrese el valor que desea modificar");
                        Console.WriteLine("(1) Nombre");
                        Console.WriteLine("(2) Cedula");
                        string InputModificar = Console.ReadLine();
                        if (InputModificar != null) 
                        {
                            
                        }
                    }
                    break;
            }
        }

    }
}

