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
        public void ListarHuesped(List<Huesped> huespedes)
        {
            foreach (Huesped huesped in huespedes)
            {
                Console.WriteLine($"== {huesped.Nombre} - ( {huesped.Ci} )");

                Console.WriteLine("");
            }
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
        public void ModificarHuesped(Huesped huesped, string input)
        {
            if (input == "1")
            {
                Console.WriteLine("Ingrese el nuevo nombre del huesped: ");
                string nuevoNombre = Console.ReadLine() ?? string.Empty;
                huesped.Nombre = nuevoNombre;
                Console.Clear();
                Console.WriteLine("Modificado correctamente");
                Console.WriteLine("");

            }
            else if (input == "2")
            {
                Console.WriteLine("Ingrese la nueva cedula del huesped: ");
                int nuevaCedula = int.Parse(Console.ReadLine() ?? string.Empty);
                huesped.Ci = nuevaCedula;
                Console.Clear();
                Console.WriteLine("Modificado correctamente");
                Console.WriteLine("");


            }
            else if (input == "3")
            {
                Console.WriteLine("Ingrese el nuevo nombre del huesped: ");
                string nuevoNombre = Console.ReadLine() ?? string.Empty;
                huesped.Nombre = nuevoNombre;

                Console.WriteLine("Ingrese la nueva cedula del huesped: ");
                int nuevaCedula = int.Parse(Console.ReadLine() ?? string.Empty);
                huesped.Ci = nuevaCedula;
                Console.Clear();
                Console.WriteLine("Modificado correctamente");
                Console.WriteLine("");
            }
            else if (input == "4")
            {
                Console.WriteLine(" ");
            }
            else
            {
                Console.WriteLine("La opcion ingresada no es correcta.");
            }
        }


        public void MostrarHuesped(Huesped huesped1)
        {
            Console.WriteLine($"== {huesped1.Nombre} - ( {huesped1.Ci} )");
            
            Console.WriteLine("");
        }
    }
}
