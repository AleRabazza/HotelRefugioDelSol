using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Console.WriteLine("Ingrese la nueva ubicacion del apartamentos");
                string nuevaUbicacion = Console.ReadLine() ?? string.Empty;
                apartamento.Ubicacion = nuevaUbicacion;
            }
            else if (input == "2")
            {
                Console.WriteLine("Ingrese el nuevo numero del Apartamento");
                int nuevoNumero = int.Parse(Console.ReadLine() ?? string.Empty);
                apartamento.Numero = nuevoNumero;
            }
            else if (input == "3")
            {
                Console.WriteLine("Ingrese la nueva cantidad de habitaciones del apartamento");
                int nuevaCantidadDeHab = int.Parse(Console.ReadLine() ?? string.Empty);
                apartamento.CantHabitaciones = nuevaCantidadDeHab;
            }
            else if (input == "4")
            {
                Console.WriteLine("Ingrese la nueva ubicacion del apartamento: ");
                string nuevaUbicacion = Console.ReadLine() ?? string.Empty;
                apartamento.Ubicacion = nuevaUbicacion;

                Console.WriteLine("Ingrese el nuevo numero del Apartamento: ");
                int nuevoNumero = int.Parse(Console.ReadLine() ?? string.Empty);
                apartamento.Numero = nuevoNumero;

                Console.WriteLine("Ingrese la nueva cantidad de habitaciones del apartamento");
                int nuevaCantidadDeHab = int.Parse(Console.ReadLine() ?? string.Empty);
                apartamento.CantHabitaciones = nuevaCantidadDeHab;

            }
            else 
            {
                Console.WriteLine("La opcion ingresada no es correcta");
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
