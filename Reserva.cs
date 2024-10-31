using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRefugioDelSol
{
    public class Reserva
    {
        private static int UltimoId = 0;

        public int IdReserva { get; set; }

        public Apartamento ApartamentoRes { get; set; }

        public Huesped HuespedRes { get; set; }

        public string FormaDeIngreso { get; set; }

        public int CantValijas { get; set; }

        public DateTime FechaIngreso { get; set; }

        public DateTime FechaEgreso { get; set; }

        public float PrecioRes { get; set; }

        public bool EstadoReserva {  get; set; } 

        public Reserva(Apartamento apartamento, Huesped huesped, DateTime fechaing, DateTime fechaEgreso, int cantValijas, string formaDeIngreso)
        {
            IdReserva = NuevoId();
            ApartamentoRes = apartamento;
            HuespedRes = huesped;
            FechaIngreso = fechaing;
            FechaEgreso = fechaEgreso;
            FormaDeIngreso = formaDeIngreso;
            CantValijas = cantValijas;
            PrecioRes = GenerarPrecioRes(apartamento, fechaEgreso, fechaing);
            EstadoReserva = true;
        }

        private int NuevoId()
        {
            UltimoId += 1;
            return UltimoId;
        }

        public float GenerarPrecioRes(Apartamento apartamento, DateTime fechaIngreso, DateTime fechaEgreso) 
        {
       
            int cantDias = (fechaIngreso - fechaEgreso).Days;
            float precio = apartamento.Precio;
            precio = precio * cantDias;

            return precio;
        }
    }
}
