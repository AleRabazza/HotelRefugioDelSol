﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRefugioDelSol
{
    public class Apartamento
    {   
        public string Ubicacion { get; set; }

        public int Numero { get; set; }

        public int CantHabitaciones { get; set; }

        public float Precio { get; set; }

        public int CantVecesReservado { get; set; }

        private static int contadorNumeroApartamento = 0;

        public Apartamento(string ubicacion, int CantHabit)
        {
            Ubicacion = ubicacion;
            Numero = GenerarNumero();
            CantHabitaciones = CantHabit;
            Precio = GenerarPrecio(this.Ubicacion);
            CantVecesReservado = 0;
        }
        private int GenerarNumero()
        {
            contadorNumeroApartamento++;
            return contadorNumeroApartamento;
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
