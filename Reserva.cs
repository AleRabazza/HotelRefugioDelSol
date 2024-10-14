using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRefugioDelSol
{
    internal class Reserva
    {
        private static int UltimoId = 0;

        public int IdReserva { get; set; }

        public Apartamento ApartamentoRes { get; set; }

        public Huesped HuespedRes { get; set; }

        public DateTime FechaIngreso { get; set; }

        public DateTime FechaEgreso { get; set;}

        public float PrecioRes { get; set; }

        public Reserva(Apartamento apartamento, Huesped huesped, DateTime fechaing, DateTime fechaEgreso)
        {
            IdReserva = NuevoId();
            ApartamentoRes = apartamento;
            HuespedRes = huesped;
            FechaIngreso = fechaing;
            FechaEgreso = fechaEgreso;
            PrecioRes = GenerarPrecioRes(apartamento, fechaEgreso, fechaing);
        }

        private int NuevoId()
        {
            UltimoId += 1;
            return UltimoId;
        }

        public float GenerarPrecioRes(Apartamento apartamento, DateTime fechaIngreso, DateTime fechaEgreso) {  }
}
