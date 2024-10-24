﻿using System;
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
            CodApartamento = GenerarCodigoApartamento(this.Ubicacion ?? string.Empty, this.Numero);
            Ubicacion = ubicacion;
            Numero = numero;
            CantHabitaciones = CantHabit;
            Estado = false;
            Precio = GenerarPrecio(this.Ubicacion);
            CantVecesReservado = 0;
        }

        public string GenerarCodigoApartamento(String ubicacion, int numero) 
        {
            return $"{ubicacion}-{numero}";
        }

        public float GenerarPrecio(string ubicacion)
        {
            float precioBase = 250;
            float porcentajeSobrecosto = 20;
            float sobrecosto = precioBase + (precioBase * porcentajeSobrecosto / 100);
   

            if (ubicacion == "noroeste" || ubicacion == "suroeste")
            {
                return sobrecosto;

            }else
            {
                return precioBase;
            }
        }
        
        public int? MostrarAreaTotal(int CantHabitaciones) {

            if (CantHabitaciones == 4) {
                return 240;
            }else if (CantHabitaciones == 3)
            {
                return 180;
            }else {
                Console.WriteLine("La cantidad de habitaciones fue mal ingresada");
                return null;
            }
        }
    }
}
