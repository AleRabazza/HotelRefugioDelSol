using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRefugioDelSol
{
    public class Estadistica
    {
        public void ListarApartamentosDisponibles(List<Apartamento> ListaApartamentos)
        {
            if (ListaApartamentos.Count > 0)
            {
                Console.WriteLine("Apartamentos disponibles:");
                foreach (Apartamento apto in ListaApartamentos)
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

        public void MostrarDiezAptosMasRerservados(ControladoraApartamentos controladoraApartamentos)
        {
            controladoraApartamentos.ListaApartamentos.Sort((apto1, apto2) => apto2.CantVecesReservado.CompareTo(apto1.CantVecesReservado));

            Console.WriteLine("========== Los 10 apartamentos más reservados ==========");

            int contador = 0;
            foreach (Apartamento apto in controladoraApartamentos.ListaApartamentos)
            {
                controladoraApartamentos.MostrarApartamento(apto.Numero);
                contador++;
                Console.WriteLine("");
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
                Console.WriteLine("===== Lista de Huespedes =====");
                Console.WriteLine("");
                foreach (Huesped huesped in huespedesOrdenados)
                {
                    Console.WriteLine($"Nombre: {huesped.Nombre}, CI: {huesped.Ci}");

                }
                Console.WriteLine("==============================");
            }
            else
            {
                Console.WriteLine("No hay huespedes en la lista");
            }
        }

        public bool CheaquearNumero(string input, out int numero)
        {
            bool res = int.TryParse(input, out numero);
            if (res)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Numero no valido");
                return false;
            }
        }
    }
}
