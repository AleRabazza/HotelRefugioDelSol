using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRefugioDelSol
{
    internal class Huesped
    {
        public string Nombre { get; set; }

        public int Ci { get; set; }

        public List<Reserva> HistorialReservas { get; set; }

        public Huesped(string nombre, int ci)
        {
            Nombre = nombre;
            Ci = ci;
            HistorialReservas = new List<Reserva>();
        }

    }
}
