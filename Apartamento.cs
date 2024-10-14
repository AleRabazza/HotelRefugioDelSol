using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRefugioDelSol
{
    public class Apartamento
    {
        public string CodApartamento { get; set; }
        
        public string Ubicacion { get; set; }

        public int Numero {  get; set; }

        public int CantHabitaciones { get; set; }

        public bool Estado {  get; set; }
        public float Precio { get; set; }

        public int CantVecesReservado { get; set; }

        public Apartamento(string ubicacion, int numero, int CantHabit)
        {
            CodApartamento = GenerarCodigoApartamento(this.Ubicacion, this.Numero);
            Ubicacion = ubicacion;
            Numero = numero;
            CantHabitaciones = CantHabit;
            Estado = false;
            Precio = GenerarPrecio(this.Ubicacion);
            CantVecesReservado = 0;
        }

        public string GenerarCodigoApartamento(String ubicacion, int numero) { }

        public float GenerarPrecio(string ubicacion) { }
        
        public float MostrarAreaTotal(int CantHabitaciones) { }
        
        public bool AptoParaMastoctas(float Ubi) { }
    }
}
