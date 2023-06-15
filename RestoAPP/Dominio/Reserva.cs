using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Reserva
    {
        public int IDReserva {get;set;}
	    public int IDMesa {get; set;}
        public DateTime HoraReserva {get; set;}
        public int  CodigoReserva {get; set;}
        public string Comentario {get; set;}
	    public int CantidadClientes {get; set;}
    }
}
