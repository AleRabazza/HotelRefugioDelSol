using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRefugioDelSol
{
    public class ControladoraReserva
    {
        public List<Reserva> ListaReservas { get; set; }

        public ControladoraReserva()
        {
            ListaReservas = new List<Reserva>();
        }

        public bool AniadirReserva(Reserva reservaAAniadir)
        {
            if (reservaAAniadir != null)
            {
                ListaReservas.Add(reservaAAniadir);
                Console.WriteLine("La reserva ha sido añadida correctamente");
                return true;

            }
            else
            {
                Console.WriteLine("La reserva no pudo ser añadida");
                return false;
            }
        }

        public bool CancelarReserva(int id)
        {
            Reserva? reserva = BuscarReservaPorId(id);
            if (reserva != null)
            {
                reserva.EstadoReserva = false;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void MostrarReserva(Reserva reserva1)
        {
            Console.WriteLine($"Id de la reserva : {reserva1.IdReserva}");
            Console.WriteLine($"Apartamento reservado : {reserva1.ApartamentoRes.CodApartamento}");
            Console.WriteLine($"Huesped : {reserva1.HuespedRes.Ci}");
            Console.WriteLine($"Fecha de Ingreso : {reserva1.FechaIngreso.Date.ToString()}");
            Console.WriteLine($"Fecha de Egreso : {reserva1.FechaEgreso.Date.ToString()}");
            Console.WriteLine($"Cantidad de valijas : {reserva1.CantValijas}");
            Console.WriteLine($"Precio reserva : {reserva1.PrecioRes}");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public Reserva? BuscarReservaPorId(int id)
        {
            Reserva? reservaBuscada = ListaReservas.FirstOrDefault(r => r.IdReserva == id);
            return reservaBuscada;
        }

        public List<Reserva> BuscarReservasPorHuesped(int cedula)
        {
            List<Reserva> reservas = ListaReservas.FindAll(r => r.HuespedRes.Ci == cedula);
            return reservas;
        }

        public void MostrarReservasPorHuesped(List<Reserva> listaReservas)
        {
            if (listaReservas.Count > 0)
            {
                foreach (Reserva reserva in listaReservas)
                {
                    MostrarReserva(reserva);
                }
            }
            else
            {
                Console.WriteLine("El huesped no tiene reservas");
            }

        }

        public List<Apartamento> ApartamentosDisponiblesEnFecha(List<Apartamento> aptos, List<Reserva> reservas, DateTime fechaIngreso, DateTime fechaEgreso, ControladoraApartamentos apartamentos)
        {
            List<Apartamento> apartamentosDisponibles = new List<Apartamento>();
            foreach (Reserva reserva in reservas)
            {
                if (reserva.FechaEgreso < fechaIngreso || reserva.FechaIngreso > fechaEgreso)
                {
                    if (!apartamentos.EstaEnLista(apartamentosDisponibles, reserva.ApartamentoRes) ) 
                    {
                        apartamentosDisponibles.Add(reserva.ApartamentoRes);
                    }
                }
                else
                {
                    foreach (Apartamento apto in apartamentosDisponibles)
                    {
                        if (apartamentos.EstaEnLista(apartamentosDisponibles, reserva.ApartamentoRes))
                        {
                            apartamentosDisponibles.Remove(reserva.ApartamentoRes);
                        }
                    }
                }
            }
        }
    }
}
