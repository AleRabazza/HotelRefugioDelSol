using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRefugioDelSol
{
    internal class ControladoraHuspedes
    {
        public List<Huesped> HuespedesActivos {  get; set; }

        public ControladoraHuspedes() 
        {
            HuespedesActivos = new List<Huesped>();
        }

        public void IngresoHuesped(Huesped huesped);

        public void BajaDeHuesped (int ci) { }

        public void ListarHuespedesPorAlfabeto() { }
    }
}
