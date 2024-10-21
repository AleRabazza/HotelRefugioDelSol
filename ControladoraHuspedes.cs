using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRefugioDelSol
{
    public class ControladoraHuspedes
    {
        public List<Huesped> HuespedesActivos {  get; set; }

        public ControladoraHuspedes() 
        {
            HuespedesActivos = new List<Huesped>();
        }

        public void IngresoHuesped(Huesped huesped);

        public void BajaDeHuesped (int ci) { }

        public void ListarHuespedesPorAlfabeto() { }

        public Huesped? BuscarHuespedPorCi(int ci)
        {

        }
        public Huesped ModificarHuesped(Huesped huesped)
        {

        }


        public void MostrarHuesped(Huesped huesped1) { }
    }
}
