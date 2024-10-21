using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRefugioDelSol
{
    public class ControladoraHuspedes
    {
        public List<Huesped> ListaHuespedes { get; set; }

        public ControladoraHuspedes()
        {
            ListaHuespedes = new List<Huesped>();
        }

        public void IngresoHuesped(Huesped huesped)
        {
            ListaHuespedes.Add(huesped);
        }

        public bool BajaDeHuesped(int ci)
        {
            Huesped? huespedABorrar = BuscarHuespedPorCi(ci);
            if (huespedABorrar != null)
            {
                ListaHuespedes.Remove(huespedABorrar);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ListarHuespedesPorAlfabeto()
        {
            ListaHuespedes.Sort();
            Console.WriteLine("===== Lista de Huespedes =====");
            Console.WriteLine("");
            foreach (Huesped huesped in ListaHuespedes)
            {
                this.MostrarHuesped(huesped);
            }
            Console.WriteLine("==============================");
    
        }


        

        public Huesped? BuscarHuespedPorCi(int ci)
        {
            if (ListaHuespedes.Count > 0)
            {
                foreach (Huesped huesped in ListaHuespedes)
                {
                    if (huesped.Ci == ci)
                    {
                        return huesped;
                    }
                }
            }
            return null;
        }
        public Huesped ModificarHuesped(Huesped huesped)
        {

        }


        public void MostrarHuesped(Huesped huesped1) 
        {
            Console.WriteLine($"= {huesped1.Nombre} = ( {huesped1.Ci} )");
            Console.WriteLine("");
        }
    }
}
