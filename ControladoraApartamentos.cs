using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HotelRefugioDelSol
{
    public class ControladoraApartamentos
    {
        public List<Apartamento> ListaApartamentos {  get; set; }
        public ControladoraApartamentos()
        {
            ListaApartamentos = new List<Apartamento>();
        }

        public bool AgregarApartamento (Apartamento apartamento)
        {
            if (BuscarApartamento(apartamento.Numero) == null)
            {
                ListaApartamentos.Add(apartamento);
                Console.WriteLine("El apartamento fue agregado con exito!"); 
                return true;
            }
            else
            {
                Console.WriteLine("El apartamento con este número ya existe.");
                return false;
            }

        } 

        public void ModificarApartamento (Apartamento apartamento, string input)
        {
            if (input == "1")
            {
                Console.WriteLine("Ingrese la nueva ubicacion del apartamento: (noroeste|suroeste|noreste|sureste) ");
                string nuevaUbicacion = Console.ReadLine() ?? string.Empty;
                if (nuevaUbicacion != "noroeste" && nuevaUbicacion != "suroeste" && nuevaUbicacion != "noreste" && nuevaUbicacion != "sureste")
                {
                    do
                    {
                        Console.WriteLine("La ubicacion de los apartamentos solo acepta las siguientes opciones noroeste | suroeste | noreste | sureste ");
                        Console.WriteLine("Ingrese nuevamente la nueva ubicacion del apartamento: (noroeste|suroeste|noreste|sureste) ");
                        nuevaUbicacion = Console.ReadLine() ?? string.Empty;
                    } while (nuevaUbicacion != "noroeste" && nuevaUbicacion != "suroeste" && nuevaUbicacion != "noreste" && nuevaUbicacion != "sureste");
                }
                apartamento.Ubicacion = nuevaUbicacion;
                Console.WriteLine("La ubicacion del apartamento fue modificada corretamente. ");
                Console.WriteLine("");
            }
            else if (input == "2")
            {
                Console.WriteLine("Ingrese el nuevo numero del Apartamento");
                int nuevoNumero = int.Parse(Console.ReadLine() ?? string.Empty);
                if (nuevoNumero <= 0)
                {
                    do
                    {
                        Console.WriteLine("El numero del apartamento tiene que ser mayor a 0");
                        Console.WriteLine("Ingrese nuevamente el nuevo numero del Apartamento");
                        nuevoNumero = int.Parse(Console.ReadLine() ?? string.Empty);

                    } while (nuevoNumero <= 0);
                }
                apartamento.Numero = nuevoNumero;
                Console.WriteLine("El numero del apartamento fue modificado correctamente.");
                Console.WriteLine("");
            }
            else if (input == "3")
            {
                Console.WriteLine("Ingrese la nueva cantidad de habitaciones del apartamento: (3|4)");
                int nuevaCantidadDeHab = int.Parse(Console.ReadLine() ?? string.Empty);
                if (nuevaCantidadDeHab != 4 && nuevaCantidadDeHab != 3)
                {
                    do
                    {
                        Console.WriteLine("La cantidad de habitaciones del apartamento solo pueden ser 3 o 4:");
                        Console.WriteLine("Ingrese nuevamente la nueva cantidad de habitaciones del apartamento: (3|4)");
                        nuevaCantidadDeHab = int.Parse(Console.ReadLine() ?? string.Empty);

                    } while (nuevaCantidadDeHab != 4 && nuevaCantidadDeHab != 3);
                }
                apartamento.CantHabitaciones = nuevaCantidadDeHab;
                Console.WriteLine("La cantidad de habitaciones del apartamento fue modificada correctamente");
                Console.WriteLine("");
            }
            else if (input == "4")
            {
                Console.WriteLine("Ingrese la nueva ubicacion del apartamento: (noroeste|suroeste|noreste|sureste) ");
                string nuevaUbicacion = Console.ReadLine() ?? string.Empty;
                if (nuevaUbicacion != "noroeste" && nuevaUbicacion != "suroeste" && nuevaUbicacion != "noreste" && nuevaUbicacion != "sureste")
                {
                    do
                    {
                        Console.WriteLine("La ubicacion de los apartamentos solo acepta las siguientes opciones noroeste | suroeste | noreste | sureste ");
                        Console.WriteLine("Ingrese nuevamente la nueva ubicacion del apartamento: (noroeste|suroeste|noreste|sureste) ");
                        nuevaUbicacion = Console.ReadLine() ?? string.Empty;
                    } while (nuevaUbicacion != "noroeste" && nuevaUbicacion != "suroeste" && nuevaUbicacion != "noreste" && nuevaUbicacion != "sureste");
                }
                apartamento.Ubicacion = nuevaUbicacion;

                Console.WriteLine("Ingrese el nuevo numero del Apartamento");
                int nuevoNumero = int.Parse(Console.ReadLine() ?? string.Empty);
                if(nuevoNumero <= 0){ 
                    do
                    {
                        Console.WriteLine("El numero del apartamento tiene que ser mayor a 0");
                        Console.WriteLine("Ingrese nuevamente el nuevo numero del Apartamento");
                        nuevoNumero = int.Parse(Console.ReadLine() ?? string.Empty);

                    } while (nuevoNumero <= 0);
                }
                apartamento.Numero = nuevoNumero;

                Console.WriteLine("Ingrese la nueva cantidad de habitaciones del apartamento: (3|4)");
                int nuevaCantidadDeHab = int.Parse(Console.ReadLine() ?? string.Empty);
                if(nuevaCantidadDeHab != 4 && nuevaCantidadDeHab != 3)
                {
                    do
                    {
                        Console.WriteLine("La cantidad de habitaciones del apartamento solo pueden ser 3 o 4:");
                        Console.WriteLine("Ingrese nuevamente la nueva cantidad de habitaciones del apartamento: (3|4)");
                        nuevaCantidadDeHab = int.Parse(Console.ReadLine() ?? string.Empty);

                    } while (nuevaCantidadDeHab != 4 && nuevaCantidadDeHab != 3);
                }
                apartamento.CantHabitaciones = nuevaCantidadDeHab;
                Console.WriteLine("El apartamento fue modificado correctamente");
                Console.WriteLine("");

            }
            else 
            {
                Console.WriteLine("La opcion ingresada no es correcta");
                Console.WriteLine("");
            }
        }

        public void ListarApartamentosDisponibles()
        {
            List<Apartamento> apartamentosDisponibles = ListaApartamentos.FindAll(apto => apto.Estado == false);

            if (apartamentosDisponibles.Count > 0)
            {
                Console.WriteLine("=========Apartamentos disponibles =========");
                foreach (Apartamento apto in apartamentosDisponibles)
                {
                    Console.WriteLine($"Número: {apto.Numero}, Ubicación: {apto.Ubicacion}, Habitaciones: {apto.CantHabitaciones}, Precio: {apto.Precio} USD");
                }
                Console.WriteLine("===========================================");
            }
            else
            {
                Console.WriteLine("No hay apartamentos disponibles.");
            }
        }


        public Apartamento? BuscarApartamento(int numeroApartamento)
        {
            return ListaApartamentos.Find(apto => apto.Numero == numeroApartamento);
        }

        public void MostrarApartamento(int numeroApartamento)
        {
            Apartamento? apartamento = BuscarApartamento(numeroApartamento);

            if (apartamento != null)
            {
                Console.WriteLine($"Apartamento Número: {apartamento.Numero}");
                Console.WriteLine($"Ubicación: {apartamento.Ubicacion}");
                Console.WriteLine($"Habitaciones: {apartamento.CantHabitaciones}");
                Console.WriteLine($"Estado: {(apartamento.Estado ? "Reservado" : "Disponible")}");
                Console.WriteLine($"Precio: {apartamento.Precio} USD por noche");
                Console.WriteLine($"Veces reservado: {apartamento.CantVecesReservado}");
            }
            else
            {
                Console.WriteLine("Apartamento no encontrado.");
            }
        }

        public void EliminarApartamento(int numeroEliminar)
        {
            Apartamento? aptoAEliminar = BuscarApartamento(numeroEliminar);
            if (aptoAEliminar != null)
            {
                ListaApartamentos.Remove(aptoAEliminar);
                Console.Clear();
                Console.WriteLine("Apartamento eliminado correctamente");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Apartamento no encontrado");
            }
        }
    }
     
}
