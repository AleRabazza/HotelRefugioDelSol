using HotelRefugioDelSol;

ControladoraApartamentos apartamentos = new ControladoraApartamentos();
ControladoraHuspedes huespedes = new ControladoraHuspedes();
ControladoraReserva reservas = new ControladoraReserva();
Estadistica estadistica = new Estadistica();

Menu menu = new Menu();
menu.preCarga(apartamentos, huespedes);
menu.MostrarMenu(apartamentos, huespedes, reservas, estadistica);
