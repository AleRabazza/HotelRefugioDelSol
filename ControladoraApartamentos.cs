using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRefugioDelSol
{
    internal class ControladoraApartamentos
    {
        public List<Apartamento> ListaApartamentos {  get; set; }
        public ControladoraApartamentos()
        {
            ListaApartamentos = new List<Apartamento>();
        }

        public bool AgregarApartamento (Apartamento apartamento) 
        {
            ListaApartamentos.Add(apartamento); 
            return true;
        } 
    }
}
