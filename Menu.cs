using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HotelRefugioDelSol
{
    public class Menu
    {
        public void MostrarMenu()
        {
            ControladoraApartamentos apartamentos = new ControladoraApartamentos(); 
            ControladoraHuspedes huespedes = new ControladoraHuspedes();
            ControladoraReserva reservas = new ControladoraReserva();
            Estadistica estadistica = new Estadistica();

            string Input = string.Empty;
            Console.WriteLine("Bienvenido al Sistema de Reserva de 'Hotel Refugio del Sol'");
            while (Input != "salir")
            {
                Console.WriteLine("Ingrese la opcion deseada");
                Console.WriteLine("(1) Ingresar a la controladora de Huespedes");
                Console.WriteLine("(2) Ingresar a la controladora de Apartamentos");
                Console.WriteLine("(3) Ingresar a la controladora de Reservas");
                Console.WriteLine("(4) Ingresar a Estadisticas");
                Input = Console.ReadLine() ?? string.Empty;
                switch (Input)
                {
                    case "1":
                        MostrarMenuHuespedes(huespedes);
                        break;
                    case "2":
                        MostrarMenuApartamento(apartamentos); 
                        break;
                    case "3":
                        MostrarMenuReservas(apartamentos, reservas, huespedes);
                        break;
                    case "4":
                        MostrarMenuEstadisticas(reservas, apartamentos, huespedes, estadistica);
                        break;
                }
            }

        }

        public void MostrarMenuHuespedes(ControladoraHuspedes controladoraHuespedes)
        {
            string InputHuesped = string.Empty;
            Console.WriteLine("Controladora De Huespedes");
            Console.WriteLine("(1) Agregar Huesped");
            Console.WriteLine("(2) Buscar Huesped");
            Console.WriteLine("(3) Modificar Huesped");
            Console.WriteLine("(4) Eliminar Huesped");
            Console.WriteLine("(5) VOLVER AL MENU PRINCIPAL");
            InputHuesped= Console.ReadLine() ?? string.Empty;
            Console.Clear();
            switch (InputHuesped)
            {
                case "1":
                    Console.WriteLine("Ingrese el nombre del Huesped");     //Agregar verificacion de datos
                    string nombre = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Ingrese la cedula del Huesped");
                    int cedula = int.Parse(Console.ReadLine() ?? string.Empty);
                    Huesped huesped1 = new Huesped(nombre, cedula);
                    controladoraHuespedes.IngresoHuesped(huesped1);
                    Console.Clear();
                    Console.WriteLine("Agregado con exito");
                    Console.WriteLine("");
                    break;

                case "2":
                    Console.WriteLine("Ingrese la cedula del Huesped a buscar");
                    int cedula1 = int.Parse (Console.ReadLine() ?? string.Empty);
                    Huesped? huespedBuscado = controladoraHuespedes.BuscarHuespedPorCi(cedula1);
                    if (huespedBuscado != null)
                    {
                        controladoraHuespedes.MostrarHuesped(huespedBuscado);
                    }
                    else
                    { 
                        Console.WriteLine("Huesped no encontrado");
                        Console.Clear();
                    }
                    break;

                    case "3":
                    if (controladoraHuespedes.ListaHuespedes.Count > 0)
                    {
                        Console.WriteLine("Ingrese la cedula del Huesped a modificar");
                        int cedula2 = int.Parse(Console.ReadLine() ?? string.Empty);
                        Huesped? huesped2 = controladoraHuespedes.BuscarHuespedPorCi(cedula2);
                        if (huesped2 != null)
                        {
                            controladoraHuespedes.MostrarHuesped(huesped2);
                            Console.WriteLine("Ingrese el valor que desea modificar");
                            Console.WriteLine("(1) Nombre");
                            Console.WriteLine("(2) Cedula");
                            Console.WriteLine("(3) Nombre y Cedula");
                            string InputModificar = Console.ReadLine() ?? string.Empty;
                            controladoraHuespedes.ModificarHuesped(huesped2, InputModificar);

                        }
                    }
                    else
                    {
                        Console.WriteLine("No hay huespedes ingresados");
                    }
                    break;

                case "5":
                    MostrarMenu();
                    break;

                case "4":
                    Console.WriteLine("Ingrese la cedula del huesped a eliminar");
                    int cedula3 = int.Parse(Console.ReadLine() ?? string.Empty);
                    Huesped? huespedEliminar = controladoraHuespedes.BuscarHuespedPorCi(cedula3);
                    if (huespedEliminar != null) 
                    {
                        controladoraHuespedes.ListaHuespedes.Remove(huespedEliminar);
                        Console.Clear();
                        Console.WriteLine("Huesped eliminado correctamente");
                    }
                    break;

                default:
                    Console.WriteLine("La opcion ingresada no es valida");
                    Console.WriteLine(" ");
                    MostrarMenuHuespedes(controladoraHuespedes);
                    break;
            }
        }

        public void MostrarMenuApartamento(ControladoraApartamentos controladoraApartamento)
        {
            string inputApartamento = string.Empty;
            Console.WriteLine("Controladora De Apartamentos");
            Console.WriteLine("(1) Agregar Apartamento");
            Console.WriteLine("(2) Buscar Apartamento");
            Console.WriteLine("(3) Eliminar Apartameno");
            Console.WriteLine("(4) Listar Apartamentos disponibles");
            Console.WriteLine("(5) Modificar Apartamento");
            Console.WriteLine("(6) VOLVER AL MENU PRINCIPAL"); 

            inputApartamento = Console.ReadLine() ?? string.Empty;

            switch (inputApartamento) { 

                case  "1": //AGREGAR VERIFICACIONES 
                    string ubicacion = string.Empty;
                    int numero = 0;
                    int cantHabitaciones = 0;
                    bool estaVacio = true;
                    bool esCorrecto = false;
                    do
                    {
                        Console.WriteLine("Ingrese la ubicación del apartamento:");
                        ubicacion = Console.ReadLine() ?? string.Empty;
                        if (string.IsNullOrEmpty(ubicacion))
                        {
                            estaVacio = true;
                        }
                        else
                        {
                            estaVacio = false;
                            if (ubicacion == "noreste" || ubicacion == "sureste" || ubicacion == "noroeste" || ubicacion == "suroeste")
                            {
                                esCorrecto = true;
                            }
                        }
                    } while (estaVacio || !esCorrecto );

                    do
                    {
                        Console.WriteLine("Ingrese el número del apartamento:");
                        numero = int.Parse(Console.ReadLine() ?? string.Empty);
                    } while (numero == 0);

                    do {
                        Console.WriteLine("Ingrese la cantidad de habitaciones:");
                        cantHabitaciones = int.Parse(Console.ReadLine() ?? string.Empty);
                        
                    } while (cantHabitaciones == 0 );

                    Apartamento nuevoApartamento = new Apartamento(ubicacion, numero, cantHabitaciones);
                    controladoraApartamento.AgregarApartamento(nuevoApartamento);

                    Console.Clear();
                    Console.WriteLine("Agregado con exito");
                    Console.WriteLine("");

                    break;

                case "2":
                    int apartamentoBuscar = 0;
                    do
                    {
                        Console.WriteLine("Ingrese el numero del apartamento que desea buscar:");
                        apartamentoBuscar = int.Parse(Console.ReadLine() ?? string.Empty);
                    }while (apartamentoBuscar != int.Parse(string.Empty));
                    Apartamento? aptoBuscado = controladoraApartamento.BuscarApartamento(apartamentoBuscar);
                    if (aptoBuscado != null)
                    {
                        controladoraApartamento.MostrarApartamento(aptoBuscado.Numero);
                    } else 
                    {
                        Console.WriteLine("Apartamento no encontrado");
                    }

                    break;

                case "4":
                    Console.WriteLine("===== Apartamentos disponibles del hotel =====");
                    controladoraApartamento.ListarApartamentosDisponibles();
                    Console.WriteLine("");
                    Console.WriteLine("==============================================");

                    break;

                case "5":
                    Console.WriteLine("Ingrese el numero del apartamento que desea modificar");
                    int numApartamento = int.Parse(Console.ReadLine() ?? string.Empty);
                    Apartamento? apartamento = controladoraApartamento.BuscarApartamento(numApartamento);
                    if (apartamento != null)
                    {
                        if (controladoraApartamento.ListaApartamentos.Count > 0)
                        {

                            Console.Clear();
                            controladoraApartamento.MostrarApartamento(numApartamento);
                            Console.WriteLine("Ingrese la opcion del Apartamento que desea modificar: ");
                            Console.WriteLine("(1) Ubicacion");
                            Console.WriteLine("(2) Numero");
                            Console.WriteLine("(3) Cantidad de habitaciones");
                            Console.WriteLine("(4) Ubicacion, numero y cantidad de habitaciones");
                            Console.WriteLine("(5) Volver al inicio");
                            string InputModificar = Console.ReadLine() ?? string.Empty;
                            controladoraApartamento.ModificarApartamento(apartamento, InputModificar);
                        }
                        else
                        {
                            Console.WriteLine("No existen apartamentos ingresados");
                        }
                    }
                    break;

                case "6":
                    MostrarMenu();
                    break;

                case "3":
                    controladoraApartamento.ListarApartamentosDisponibles();
                    int numeroEliminar = int.Parse(string.Empty);
                    do
                    {
                        Console.WriteLine("Ingrese el numero del apartamento a eliminar");
                        numeroEliminar = int.Parse(Console.ReadLine() ?? string.Empty);
                    } while (numeroEliminar != int.Parse(string.Empty));
                    controladoraApartamento.EliminarApartamento(numeroEliminar);
                    break;


                default:
                    Console.WriteLine("La opcion ingresada no es valida");
                    Console.WriteLine(" ");
                    MostrarMenuApartamento(controladoraApartamento);   
                    break;
                 
            }

        }

        public void MostrarMenuReservas(ControladoraApartamentos controladoraApartamentos, ControladoraReserva controladoraReserva, ControladoraHuspedes controladoraHuspedes)
        {
            string inputReservas = string.Empty;
            Console.WriteLine("Controladora de reservas");
            Console.WriteLine("(1) Agregar reserva");
            Console.WriteLine("(2) Cancelar reserva");
            Console.WriteLine("(3) VOLVER AL MENU PRINCIPAL");

            inputReservas = Console.ReadLine() ?? string.Empty;

            switch (inputReservas)
            {
                case "1":
                    Console.WriteLine("Ingrese los siguientes datos para iniciar la reserva:");

                    Console.WriteLine("ID del apartamento:");
                    int idApartamento = int.Parse(Console.ReadLine() ?? string.Empty);
                    Apartamento? apartamento = controladoraApartamentos.BuscarApartamento(idApartamento);
                    if (apartamento == null)
                    {
                        Console.WriteLine("Apartamento no encontrado."); //Hay que hacer que lo vuelva a pedir cuando no lo encuente
                        return;
                    }

                    Console.WriteLine("Cédula del huésped:");
                    int cedulaHuesped = int.Parse(Console.ReadLine() ?? string.Empty);
                    Huesped? huesped = controladoraHuspedes.BuscarHuespedPorCi(cedulaHuesped);
                    if (huesped == null)
                    {
                        Console.WriteLine("Huésped no encontrado."); //aca lo mismo
                        return;
                    }


                    Console.WriteLine("Fecha de ingreso (formato: DD/MM/AAAA):");
                    DateTime fechaIngreso = DateTime.Parse(Console.ReadLine() ?? string.Empty);

                    Console.WriteLine("Fecha de egreso (formato: DD/MM/AAAA):");
                    DateTime fechaEgreso = DateTime.Parse(Console.ReadLine() ?? string.Empty);


                    Console.WriteLine("Cantidad de valijas:");
                    int cantValijas = int.Parse(Console.ReadLine() ?? string.Empty);


                    Console.WriteLine("Forma de ingreso (sumarino/helicoptero)");
                    string formaDeIngreso = Console.ReadLine() ?? string.Empty;


                    Reserva nuevaReserva = new Reserva(apartamento, huesped, fechaIngreso, fechaEgreso, cantValijas, formaDeIngreso);


                    controladoraReserva.AniadirReserva(nuevaReserva);
                break;

                case "2":
                    Console.WriteLine("Ingrese la cedula del huesped para cancelar su reserva:");
                    int cedula = int.Parse(Console.ReadLine() ?? string.Empty);

                    controladoraReserva.MostrarReservasPorHuesped(controladoraReserva.BuscarReservasPorHuesped(cedula));

                    Console.WriteLine("Ingrese el numero de ID de la reserva que desea cancelar");
                    int id = int.Parse(Console.ReadLine() ?? string.Empty);

                    bool resultado = controladoraReserva.CancelarReserva(id);
                    if (resultado)
                    {
                        Console.WriteLine("Eliminado correctamente.");
                    } else
                    {
                        Console.WriteLine("No se pudo eliminar.");
                    }

                break;

                case "3":
                    MostrarMenu();
                    break;

                default: Console.WriteLine("La opcion ingresada no es valida");
                    Console.WriteLine(" ");
                    MostrarMenuReservas(controladoraApartamentos,controladoraReserva, controladoraHuspedes);
                    break;
            }
        }


        public void MostrarMenuEstadisticas(ControladoraReserva controladoraReserva, ControladoraApartamentos controladoraApartamentos, ControladoraHuspedes controladoraHuspedes, Estadistica estadistica)
        {
            Estadistica controladoraEstadistica = new Estadistica();
            string inputEstadiaticas = string.Empty;
            Console.WriteLine("Controladora de estadisticas");
            Console.WriteLine("(1) ListarApartamentosDisponibles");
            Console.WriteLine("(2) Mostrar reservas del dia ");
            Console.WriteLine("(3) Listar huespedes alfabeticamente");
            Console.WriteLine("(4) Mostrar los diez apartamentos mas reservados");
            Console.WriteLine("(5) Listar reservas de un huesped");
            Console.WriteLine("(6) Volver al menu principal");


            inputEstadiaticas = Console.ReadLine() ?? string.Empty;

            switch (inputEstadiaticas)
            {
                case "1":
                    Console.WriteLine("======== Apartamentos disponibles ========");
                    controladoraApartamentos.ListarApartamentosDisponibles();
                    break;
                case "2":
                    Console.WriteLine("Ingrese la fecha del dia de hoy para ver las reservas: (formato: DD/MM/AAAA)");
                    DateTime fechaBusqueda = DateTime.Parse(Console.ReadLine() ?? string.Empty);
                    controladoraEstadistica.MostrarReservasDelDia(fechaBusqueda, controladoraReserva.ListaReservas);

                    break
                        ;
                case "3":
                    estadistica.ListarHuespedesPorAlfabeto(controladoraHuspedes.ListaHuespedes);
                    break;

                case "5":

                    Console.WriteLine("Ingrese la cedula del huesped al que desea buscar sus reservas: ");
                    int cedula1 = int.Parse(Console.ReadLine() ?? string.Empty);
                    Huesped? huespedBuscado = controladoraHuspedes.BuscarHuespedPorCi(cedula1);

                    if (huespedBuscado != null)
                    {


                        List<Reserva> listaDeReservasPorHuesped = controladoraReserva.BuscarReservasPorHuesped(cedula1);

                        if (listaDeReservasPorHuesped.Count > 0)
                        {
                            Console.WriteLine("Se encontraron las siguientes reservas del huesped con cedula: " + cedula1);
                            controladoraReserva.MostrarReservasPorHuesped(listaDeReservasPorHuesped);
                        }
                        else
                        {
                            Console.WriteLine("No se encontraron reservas del huesped con cedula: " + cedula1);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No se encontro el huesped con cedula:" + cedula1);
                    }


                    break;

                case "4":
                    Console.WriteLine("======= Los diez apartamento mas reservados =======");
                   estadistica.MostrarDiezAptosMasRerservados(controladoraApartamentos.ListaApartamentos);

                    break;

                case "6":
                    MostrarMenu();
                    break;

                default:
                    Console.WriteLine("La opcion ingresada no es valida");
                    Console.WriteLine(" ");
                    MostrarMenuEstadisticas(controladoraReserva, controladoraApartamentos, controladoraHuspedes, estadistica);
                    break;
            }

        }

    }
}

