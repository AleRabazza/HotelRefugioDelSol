using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRefugioDelSol
{
    public class Huesped
    {
        public string Nombre { get; set; }

        public int Ci { get; set; }
        public Huesped(string nombre, int ci)
        {
            Nombre = nombre;
            Ci = ci;
        }

    }
}
