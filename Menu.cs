using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HotelRefugioDelSol
{
    public class Menu
    {
        public void MostrarMenu(ControladoraApartamentos apartamentos, ControladoraHuspedes huespedes, ControladoraReserva reservas, Estadistica estadistica)
        {
            string Input = string.Empty;
            Console.WriteLine("Bienvenido al Sistema de Reserva de 'Hotel Refugio del Sol'");
            Console.WriteLine(" ");
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
                        MostrarMenuReservas(apartamentos, reservas, huespedes, estadistica);
                        break;
                    case "4":
                        MostrarMenuEstadisticas(reservas, apartamentos, huespedes, estadistica);
                        break;
                    default:
                        Console.WriteLine($"La opcion {Input} no es valida.");
                        Console.WriteLine(" ");
                        break;
                }
            }

        }

        public void MostrarMenuHuespedes(ControladoraHuspedes controladoraHuespedes)
        {
            string InputHuesped = string.Empty;
            Console.WriteLine(" ");
            Console.WriteLine("Controladora De Huespedes");
            Console.WriteLine("(1) Agregar Huesped");
            Console.WriteLine("(2) Buscar Huesped");
            Console.WriteLine("(3) Modificar Huesped");
            Console.WriteLine("(4) Eliminar Huesped");
            Console.WriteLine("(5) VOLVER AL MENU PRINCIPAL");
            InputHuesped = Console.ReadLine() ?? string.Empty;
            Console.Clear();
            switch (InputHuesped)
            {
                case "1":
                    Console.WriteLine("Ingrese el nombre del Huesped");     //Agregar verificacion de datos
                    string nombre = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Ingrese la cedula del Huesped");
                    int cedula = int.Parse(Console.ReadLine() ?? string.Empty);
                    controladoraHuespedes.BuscarHuespedPorCi(cedula);
                    if (controladoraHuespedes.BuscarHuespedPorCi(cedula) == null)
                    {
                        Huesped huesped1 = new Huesped(nombre, cedula);
                        controladoraHuespedes.IngresoHuesped(huesped1);
                        Console.Clear();
                        Console.WriteLine("Agregado con exito");
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine($"Ya existe un huesped con la {cedula}");
                    }

                    break;

                case "2":
                    Console.WriteLine("Ingrese la cedula del Huesped a buscar");
                    int cedula1 = int.Parse(Console.ReadLine() ?? string.Empty);
                    Huesped? huespedBuscado = controladoraHuespedes.BuscarHuespedPorCi(cedula1);
                    if (huespedBuscado != null)
                    {
                        controladoraHuespedes.MostrarHuesped(huespedBuscado);
                    }
                    else
                    {
                        Console.WriteLine($"No hay un huesped con la cedula {cedula1} en el sistema");
                        Console.WriteLine(" ");
                    }
                    break;

                case "3":
                    if (controladoraHuespedes.ListaHuespedes.Count > 0)
                    {
                        Console.WriteLine("Ingrese la cedula del Huesped a modificar");
                        int cedula2 = int.Parse(Console.ReadLine() ?? string.Empty);
                        Huesped? huesped2 = controladoraHuespedes.BuscarHuespedPorCi(cedula2);
                        string InputModificar;
                        if (huesped2 != null)
                        {
                            do
                            {
                                Console.WriteLine("");
                                controladoraHuespedes.MostrarHuesped(huesped2);
                                Console.WriteLine("Ingrese el valor que desea modificar");
                                Console.WriteLine("(1) Nombre");
                                Console.WriteLine("(2) Cedula");
                                Console.WriteLine("(3) Nombre y Cedula");
                                Console.WriteLine("(4) Cancelar operacion.");
                                InputModificar = Console.ReadLine() ?? string.Empty;
                                controladoraHuespedes.ModificarHuesped(huesped2, InputModificar);
                            } while (InputModificar != "1" && InputModificar != "2" && InputModificar != "3" && InputModificar != "4");

                        }
                        else
                        {
                            Console.WriteLine("No hay huespedes ingresados");
                            Console.WriteLine("");
                        }

                    }
                    
                    break;

                case "5":
                    
                    break;

                case "4":
                    controladoraHuespedes.ListarHuesped(controladoraHuespedes.ListaHuespedes);
                    Console.WriteLine("Ingrese la cedula del huesped a eliminar");
                    int cedula3 = int.Parse(Console.ReadLine() ?? string.Empty);
                    Huesped? huespedEliminar = controladoraHuespedes.BuscarHuespedPorCi(cedula3);
                    if (huespedEliminar != null)
                    {
                       
                        controladoraHuespedes.ListaHuespedes.Remove(huespedEliminar);
                        Console.Clear();
                        Console.WriteLine("Huesped eliminado correctamente");
                    }
                    if(huespedEliminar == null)
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine($"No hay un huesped con el numero de cedula {cedula3} en el sistema");
                        Console.WriteLine(" ");
                    }
                    break;

                default:
                    Console.WriteLine($"La opcion {InputHuesped} no es valida");
                    Console.WriteLine(" ");
                    MostrarMenuHuespedes(controladoraHuespedes);
                    break;
            }
        }

        public void MostrarMenuApartamento(ControladoraApartamentos controladoraApartamento)
        {
            string inputApartamento = string.Empty;
            Console.WriteLine(" ");
            Console.WriteLine("Controladora De Apartamentos");
            Console.WriteLine("(1) Agregar Apartamento");
            Console.WriteLine("(2) Buscar Apartamento");
            Console.WriteLine("(3) Eliminar Apartamento");
            Console.WriteLine("(4) Modificar Apartamento");
            Console.WriteLine("(5) VOLVER AL MENU PRINCIPAL");

            inputApartamento = Console.ReadLine() ?? string.Empty;

            switch (inputApartamento)
            {

                case "1":
                    
                    string ubicacion = string.Empty;
                    int cantHabitaciones = 0;

                    Console.WriteLine("Ingrese la ubicación del apartamento: (noroeste|suroeste|noreste|sureste)");
                    ubicacion = Console.ReadLine() ?? string.Empty;
                    if (ubicacion != "noroeste" && ubicacion != "suroeste" && ubicacion != "noreste" && ubicacion != "sureste")
                    {
                        do
                        {
                            Console.WriteLine("La ubicacion de los apartamentos solo acepta las siguientes opciones noroeste | suroeste | noreste | sureste ");
                            Console.WriteLine("Ingrese nuevamentela ubicación del apartamento: (noroeste|suroeste|noreste|sureste)");
                            ubicacion = Console.ReadLine() ?? string.Empty;
                        } while (ubicacion != "noroeste" && ubicacion != "suroeste" && ubicacion != "noreste" && ubicacion != "sureste");
                    }
                    Console.WriteLine("Ingrese la cantidad de habitaciones: (3 o 4)");
                    cantHabitaciones = int.Parse(Console.ReadLine() ?? string.Empty);
                    if (cantHabitaciones != 3 && cantHabitaciones != 4)
                    {
                        do
                        {
                            Console.WriteLine("La cantidad de habitaciones del apartamento solo pueden ser 3 o 4:");
                            Console.WriteLine("Ingrese nuevamente la cantidad de habitaciones: (3 o 4)");
                            cantHabitaciones = int.Parse(Console.ReadLine() ?? string.Empty);

                        } while (cantHabitaciones != 3 && cantHabitaciones != 4);
                    }

                    Apartamento nuevoApartamento = new Apartamento(ubicacion, cantHabitaciones);
                    controladoraApartamento.AgregarApartamento(nuevoApartamento);

                    Console.Clear();
                    Console.WriteLine("El apartamento fue agregado con exito.");
                    Console.WriteLine("");

                    break;

                case "2":
                    int apartamentoBuscar;
                    Console.WriteLine("Numeros de apartamentos para buscar");
                    controladoraApartamento.ListarApartamentos(controladoraApartamento.ListaApartamentos);
                    Console.WriteLine("Ingrese el numero del apartamento que desea buscar:");
                    apartamentoBuscar = int.Parse(Console.ReadLine() ?? string.Empty);
                    Apartamento? aptoBuscado = controladoraApartamento.BuscarApartamento(apartamentoBuscar);
                    if (aptoBuscado != null)
                    {
                        controladoraApartamento.MostrarApartamento(aptoBuscado.Numero);
                        Console.WriteLine(" ");
                    }
                    else
                    {
                        Console.WriteLine("Apartamento no encontrado");
                        Console.WriteLine(" ");
                    }

                    break;

                    case "4":

                    if (controladoraApartamento.ListaApartamentos.Count > 0)
                    {
                        Console.WriteLine("Numeros de apartamentos para buscar");
                        controladoraApartamento.ListarApartamentos(controladoraApartamento.ListaApartamentos);
                        Console.WriteLine("Ingrese el numero del apartamento que desea modificar");
                        int numApartamento = int.Parse(Console.ReadLine() ?? string.Empty);
                        Apartamento? apartamento = controladoraApartamento.BuscarApartamento(numApartamento);
                        if (apartamento != null)
                        {
                            Console.Clear();
                            controladoraApartamento.MostrarApartamento(numApartamento);
                            Console.WriteLine(" ");
                            Console.WriteLine("Ingrese la opcion del Apartamento que desea modificar: ");
                            Console.WriteLine("(1) Ubicacion");
                            Console.WriteLine("(2) Cantidad de habitaciones");
                            Console.WriteLine("(3) Ubicacion y cantidad de habitaciones");
                            Console.WriteLine("(4) Volver al inicio");
                            string InputModificar = Console.ReadLine() ?? string.Empty;
                            controladoraApartamento.ModificarApartamento(apartamento, InputModificar);
                        }
                        else
                        {
                            Console.WriteLine($"No existe un apartamento con el numero {numApartamento}");
                            Console.WriteLine(" ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No hay apartamentos ingresados.");
                        Console.WriteLine(" ");
                    }

                    break;

                case "5":
                    
                    break;

                case "3":
                    foreach (Apartamento apto in controladoraApartamento.ListaApartamentos)
                    {
                        controladoraApartamento.MostrarApartamento(apto.Numero);
                        Console.WriteLine(" ");
                    }
                    int numeroEliminar;

                    Console.WriteLine("Ingrese el numero del apartamento a eliminar");
                    Console.WriteLine(" ");
                    numeroEliminar = int.Parse(Console.ReadLine() ?? string.Empty);
                    controladoraApartamento.EliminarApartamento(numeroEliminar);
                    break;


                default:
                    Console.WriteLine($"La opcion {inputApartamento} no es valida");
                    Console.WriteLine(" ");
                    MostrarMenuApartamento(controladoraApartamento);
                    break;

            }

        }

        public void MostrarMenuReservas(ControladoraApartamentos controladoraApartamentos, ControladoraReserva controladoraReserva, ControladoraHuspedes controladoraHuspedes, Estadistica estadisticas)
        {
            string inputReservas = string.Empty;
            Console.WriteLine(" ");
            Console.WriteLine("Controladora de reservas");
            Console.WriteLine("(1) Agregar reserva");
            Console.WriteLine("(2) Cancelar reserva");
            Console.WriteLine("(3) VOLVER AL MENU PRINCIPAL");

            inputReservas = Console.ReadLine() ?? string.Empty;

            switch (inputReservas)
            {
                case "1":
                    Console.WriteLine("Ingrese los siguientes datos para iniciar la reserva:");
                    Console.WriteLine("");
                    Console.WriteLine("Fecha de ingreso (formato: DD/MM/AAAA):");
                    bool Inputok = false;
                    DateTime resultadoIngreso;
                    do
                    {
                        string fechaIngreso = (Console.ReadLine() ?? string.Empty);
                        Inputok = DateTime.TryParse(fechaIngreso, out resultadoIngreso);
                        if (!Inputok)
                        {
                            Console.WriteLine("Ingrese una fecha valida");
                        }
                    } while (!Inputok);
                    
                    DateTime resultadoEgreso;
                    do
                    {
                        bool InputoEgresoOk = false;
                        do
                        {
                            Console.WriteLine("Fecha de egreso (formato: DD/MM/AAAA):");
                            string fechaEgreso = Console.ReadLine() ?? string.Empty;
                            InputoEgresoOk = DateTime.TryParse(fechaEgreso, out resultadoEgreso);
                            if (!InputoEgresoOk)
                            {
                                Console.WriteLine("Ingrese una Fecha Valida");
                            }
                        }while(!InputoEgresoOk);

                        if (((resultadoEgreso - resultadoIngreso).Days > 30) || (resultadoEgreso <= resultadoIngreso))
                        {
                            Console.WriteLine("La reserva no puede exceder los 30 días ni tener una fecha de egreso menor a la de ingreso. Por favor, ingrese una nueva fecha de egreso.");
                        }

                    } while (((resultadoEgreso - resultadoIngreso).Days > 30) || (resultadoEgreso <= resultadoIngreso));

                    List<Apartamento> aptosDisp = controladoraReserva.ApartamentosDisponiblesEnFecha(controladoraApartamentos.ListaApartamentos, controladoraReserva.ListaReservas, resultadoIngreso, resultadoEgreso);

                    if (aptosDisp.Count > 0)
                    {
                        estadisticas.ListarApartamentosDisponibles(aptosDisp);
                        Console.WriteLine(" ");
                        int idAptoOk;
                        Apartamento? apartamento;
                            do
                            {
                                Console.WriteLine("ID del apartamento:");
                                string idApartamento = Console.ReadLine() ?? string.Empty;
                                bool inputOk = estadisticas.CheaquearNumero(idApartamento, out idAptoOk);
                            } while (!Inputok);
                            apartamento = controladoraApartamentos.BuscarApartamento(idAptoOk);
                        
                            if (apartamento == null)
                                {
                                    Console.WriteLine("Apartamento no encontrado.");
                                    Console.WriteLine(" ");
                                    return;
                                }
                        estadisticas.ListarHuespedesPorAlfabeto(controladoraHuspedes.ListaHuespedes);
                        int inputHuespedInt;
                        bool inputHuespedOk;
                        do
                        {
                            Console.WriteLine("Cédula del huésped:");

                            string cedulaHuesped = Console.ReadLine() ?? string.Empty;
                            inputHuespedOk = estadisticas.CheaquearNumero(cedulaHuesped, out inputHuespedInt); 
                        } while (!inputHuespedOk);
                        Huesped ? huesped = controladoraHuspedes.BuscarHuespedPorCi(inputHuespedInt);
                        if (huesped == null)
                        {
                            Console.WriteLine("Huésped no encontrado.");
                            Console.WriteLine(" ");
                            return;
                        }

                        int cantValijas;                        
                        do
                        {
                            Console.WriteLine("Cantidad de valijas: (No puede ingresar con mas de 5 valijas");
                            cantValijas = int.Parse(Console.ReadLine() ?? string.Empty);

                        } while (cantValijas > 5);



                        string formaDeIngreso;
                        do
                        {
                            Console.WriteLine("Forma de ingreso ( (1)- submarino || (2)- helicoptero ):");
                            formaDeIngreso = Console.ReadLine() ?? string.Empty;

                            if (formaDeIngreso != "1" && formaDeIngreso != "2")
                            {
                                Console.WriteLine("Por favor, ingrese una forma de ingreso válida  (1)- submarino o (2)- helicoptero.");
                            }

                        } while (formaDeIngreso != "1" && formaDeIngreso != "2");


                        Reserva nuevaReserva = new Reserva(apartamento, huesped, resultadoIngreso, resultadoEgreso, cantValijas, formaDeIngreso);


                        controladoraReserva.AniadirReserva(nuevaReserva);
                        Console.WriteLine(" ");
                    }
                    else
                    {
                        Console.WriteLine("No hay apartamentos disponibles entre estas fechas.");
                    }
              
                    break;

                case "2":
                    
                    estadisticas.ListarHuespedesPorAlfabeto(controladoraHuspedes.ListaHuespedes);
                    Console.WriteLine(" ");
                    Console.WriteLine("Ingrese la cedula del huesped para cancelar su reserva:");
                    int cedula = int.Parse(Console.ReadLine() ?? string.Empty);
                    if (controladoraReserva.BuscarReservasPorHuesped(cedula).Count > 0)
                    {
                        controladoraReserva.MostrarReservasPorHuesped(controladoraReserva.BuscarReservasPorHuesped(cedula));

                        Console.WriteLine("Ingrese el numero de ID de la reserva que desea cancelar");
                        int id = int.Parse(Console.ReadLine() ?? string.Empty);

                        bool resultado = controladoraReserva.CancelarReserva(id);
                        if (resultado)
                        {
                            Console.WriteLine("La reserva fue cancelada correctamente.");
                            Console.WriteLine(" ");
                        }
                        else
                        {
                            Console.WriteLine("No se pudo eliminar la reserva.");
                            Console.WriteLine(" ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No se encontro reservas de este huesped para eliminar.");
                        Console.WriteLine(" ");
                    }

                    break;

                case "3":
                    
                    break;

                default:
                    Console.WriteLine($"La opcion {inputReservas} no es valida");
                    Console.WriteLine(" ");
                    MostrarMenuReservas(controladoraApartamentos, controladoraReserva, controladoraHuspedes, estadisticas);
                    break;
            }
        }


        public void MostrarMenuEstadisticas(ControladoraReserva controladoraReserva, ControladoraApartamentos controladoraApartamentos, ControladoraHuspedes controladoraHuspedes, Estadistica estadistica)
        {
            Estadistica controladoraEstadistica = new Estadistica();
            string inputEstadiaticas = string.Empty;
            Console.WriteLine(" ");
            Console.WriteLine("Controladora de estadisticas");
            Console.WriteLine("(1) Listar Apartamentos Disponibles en una fecha");
            Console.WriteLine("(2) Mostrar reservas del dia ");
            Console.WriteLine("(3) Listar huespedes alfabeticamente");
            Console.WriteLine("(4) Mostrar los diez apartamentos mas reservados");
            Console.WriteLine("(5) Listar reservas de un huesped");
            Console.WriteLine("(6) Volver al menu principal");


            inputEstadiaticas = Console.ReadLine() ?? string.Empty;

            switch (inputEstadiaticas)
            {
                case "1":
                    Console.WriteLine("Fecha de ingreso (formato: DD/MM/AAAA):");
                    bool Inputok = false;
                    DateTime resultadoIngreso;
                    do
                    {
                        string fechaIngreso = (Console.ReadLine() ?? string.Empty);
                        Inputok = DateTime.TryParse(fechaIngreso, out resultadoIngreso);
                        if (!Inputok)
                        {
                            Console.WriteLine("Ingrese una fecha valida");
                        }
                    } while (!Inputok);

                    DateTime resultadoEgreso;
                    do
                    {
                        bool InputoEgresoOk = false;
                        do
                        {
                            Console.WriteLine("Fecha de egreso (formato: DD/MM/AAAA):");
                            string fechaEgreso = Console.ReadLine() ?? string.Empty;
                            InputoEgresoOk = DateTime.TryParse(fechaEgreso, out resultadoEgreso);
                            if (!InputoEgresoOk)
                            {
                                Console.WriteLine("Ingrese una Fecha Valida");
                            }
                        } while (!InputoEgresoOk);

                        if (((resultadoEgreso - resultadoIngreso).Days > 30) || (resultadoEgreso <= resultadoIngreso))
                        {
                            Console.WriteLine("La reserva no puede exceder los 30 días ni tener una fecha de egreso menor a la de ingreso. Por favor, ingrese una nueva fecha de egreso.");
                        }

                    } while (((resultadoEgreso - resultadoIngreso).Days > 30) || (resultadoEgreso <= resultadoIngreso));

                    List<Apartamento> aptosDisp = controladoraReserva.ApartamentosDisponiblesEnFecha(controladoraApartamentos.ListaApartamentos, controladoraReserva.ListaReservas, resultadoIngreso, resultadoEgreso);
                    foreach (Apartamento a in aptosDisp)
                    {
                        controladoraApartamentos.MostrarApartamento(a.Numero);
                        Console.WriteLine("");
                    }

                    break;
                case "2":
                    Console.WriteLine("Ingrese la fecha del dia de hoy para ver las reservas: (formato: DD/MM/AAAA)");
                    Console.WriteLine(" ");
                    bool Inputokk = false;
                    DateTime resultadoIngreso1;
                    do
                    {
                        string fechaIngreso = (Console.ReadLine() ?? string.Empty);
                        Inputokk = DateTime.TryParse(fechaIngreso, out resultadoIngreso1);
                        if (!Inputokk)
                        {
                            Console.WriteLine("Ingrese una fecha valida");
                        }
                    } while (!Inputokk);
                    controladoraEstadistica.MostrarReservasDelDia(resultadoIngreso1, controladoraReserva.ListaReservas);

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
                            Console.WriteLine(" ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No se encontro el huesped con cedula:" + cedula1);
                        Console.WriteLine(" ");
                    }


                    break;

                case "4":
                    Console.WriteLine("======= Los diez apartamento mas reservados =======");
                    estadistica.MostrarDiezAptosMasRerservados(controladoraApartamentos);

                    break;

                case "6":
                   
                    break;

                default:
                    Console.WriteLine($"La opcion {inputEstadiaticas} no es valida");
                    Console.WriteLine(" ");
                    MostrarMenuEstadisticas(controladoraReserva, controladoraApartamentos, controladoraHuspedes, estadistica);
                    break;
            }

        }

        public void preCarga(ControladoraApartamentos aptos, ControladoraHuspedes huesped)
        {
            Huesped huesped1 = new Huesped("Juan", 1);
            Huesped huesped2 = new Huesped("Ale", 2);
            huesped.ListaHuespedes.Add(huesped1);
            huesped.ListaHuespedes.Add(huesped2);

            Apartamento apto1 = new Apartamento("noroeste", 3);
            Apartamento apto2 = new Apartamento("sureste", 4);
            aptos.ListaApartamentos.Add(apto1);
            aptos.ListaApartamentos.Add(apto2);
        }
    }
}




