using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRefugioDelSol
{
    internal class Estadistica
    {
        public void ListarApartamentosDisponibles(List<Apartamento> ListaApartamentos)
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

        public void MostrarReservasDelDia(DateTime dia, List<Reserva> reservas)
        {
            List<Reserva> reservasDelDia = new List<Reserva>();

            foreach (Reserva reserva in reservas)
            {
                if (reserva.FechaIngreso == dia) 
                {
                    reservasDelDia.Add(reserva);
                }
            }

            if (reservasDelDia.Count > 0)
            {
                Console.WriteLine("Reservas para el día: " + dia );
                foreach (Reserva reserva in reservasDelDia)
                {
                    Console.WriteLine($"Apartamento {reserva.ApartamentoRes.Numero}, Huésped CI: {reserva.HuespedRes.Ci}");
                }
            }
            else
            {
                Console.WriteLine("No hay reservas en el día:" + dia);
            }
        }

        //public void AgregarReservaAHistorial(int ci, Reserva reservaAgregar) { }

        //public void MostrarHistorialReservas(int ci) { }

        public void MostrarDiezAptosMasRerservados(List<Apartamento> listaApartamentos)
        {
            ControladoraApartamentos controladoraApartamentos = new ControladoraApartamentos();
            listaApartamentos.Sort((apto1, apto2) => apto2.CantVecesReservado.CompareTo(apto1.CantVecesReservado));

            Console.WriteLine("Los 10 apartamentos más reservados:");

            int contador = 0;
            foreach (Apartamento apto in listaApartamentos)
            {
                controladoraApartamentos.MostrarApartamento(apto.Numero);
                contador++;
                if (contador == 10)
                {
                    break;
                }
            }
        }

        public void ListarHuespedesPorAlfabeto(List<Huesped> listaHuespedes)
        {
            List<Huesped> huespedesOrdenados = listaHuespedes.OrderBy(h => h.Nombre).ToList();

            if (huespedesOrdenados.Count > 0)
            {
                Console.WriteLine("Huéspedes ordenados alfabéticamente:");
                foreach (Huesped huesped in huespedesOrdenados)
                {
                    Console.WriteLine($"Nombre: {huesped.Nombre}, CI: {huesped.Ci}");
                }
            }else
            {
                Console.WriteLine("No hay huespedes en la lista");
            }
        }
    }
}
