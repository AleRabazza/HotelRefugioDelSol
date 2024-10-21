using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRefugioDelSol
{
    internal class ControladoraApartamentos
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

        public void ModificarApartamento (Apartamento apartamento)
        {
            Apartamento? aptoExistente = BuscarApartamento(apartamento.Numero);
            if (aptoExistente != null)
            {
                aptoExistente.Ubicacion = apartamento.Ubicacion;
                aptoExistente.CantHabitaciones = apartamento.CantHabitaciones;
                aptoExistente.Estado = apartamento.Estado;
                aptoExistente.Precio = apartamento.Precio;
                aptoExistente.CantVecesReservado = apartamento.CantVecesReservado;
                Console.WriteLine($" El Apartamento número {apartamento.Numero} fue modificado con éxito.");
            }
            else
            {
                Console.WriteLine($" El Apartamento número {apartamento.Numero} no se pudo encontrar.");
            }
        }

        public void ListarApartamentosDisponibles()
        {
            List<Apartamento> apartamentosDisponibles = ListaApartamentos.FindAll(apto => apto.Estado == false);

            if (apartamentosDisponibles.Count > 0)
            {
                Console.WriteLine("Apartamentos disponibles:");
                foreach (Apartamento apto in apartamentosDisponibles)
                {
                    Console.WriteLine($"Número: {apto.Numero}, Ubicación: {apto.Ubicacion}, Habitaciones: {apto.CantHabitaciones}, Precio: {apto.Precio} USD");
                }
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
    }
     
}
