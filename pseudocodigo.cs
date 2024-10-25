using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRefugioDelSol
{
    class pseudocodigo
    {
        public List<Apartamento> ApartamentosDisponibles(List<Apartamento>, List<Reserva>, inicioreservadeseada, finreservadeseada)
        {
            List<Apartamento> apartamentosDisponibles = new List<Apartamento>();

            porcada (Reserva res in Reserva)
            {
                si(finReserva < inicioreservadeseada or inicioRes > finfechadeseada){
                    guardamos aptoDeReserva en apartamentosDisponibles;
                } sino 
                    {
                        nos fijamos que el apartamento ocupado en esa fecha no alla sido agregado anteriormente
                    }
            }

        }
    }
}
