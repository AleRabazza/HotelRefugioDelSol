﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRefugioDelSol
{
    internal class ControladoraReserva
    {
        public List<Reserva> ListaReseravas { get; set; }

        public ControladoraReserva() 
        { 
            ListaReseravas = new List<Reserva>();
        }

        public bool AniadirReserva(Reserva reservaAAniadir) { }

        public bool CancelarReserva(int id) { }

        public void MostrarReserva() { }

        public Reserva BuscarReservaPorId(int id) { }

        public int CantDiasHospedado(DateTime fechaIngreso, DateTime fechaOutgreso) { }

        public List BuscarReservasPorHuesped(int cedula)
        {

        }

        public void MostrarReservasPorHuesped(List<Reserva> listaReservas) { }

    }
}
