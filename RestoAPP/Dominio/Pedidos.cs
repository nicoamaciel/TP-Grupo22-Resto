using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pedidos
    {
        public int IDPedido {get; set;}
	    public int IDMesa {get; set;}
        public Menu Plato { get; set; }
        public Bebidas Bebida { get; set; }
        public decimal Cuenta { get; set; }
        public bool Estado { get; set; }
        public DateTime fecha { get; set; }
    }
}
