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

        public string CodApartamento { get; set; }

        public int CantValijas { get; set; }
        public string FormaDeIngreso { get; set; }

        public List<string[]> HistorialReservas { get; set; }

        public Huesped(string nombre, int ci, string codApartamento, int cantValijas, string formaDeIngreso)
        {
            Nombre = nombre;
            Ci = ci;
            CodApartamento = codApartamento;
            CantValijas = cantValijas;
            FormaDeIngreso = formaDeIngreso;
            HistorialReservas = new List<string[]>();
        }

        public Huesped BuscarHuespedPorCi(int ci)
        {
            
        } 
    }
}
