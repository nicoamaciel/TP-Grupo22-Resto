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
        public int IDEntrada { get; set; }
        public int IDPrincipal { get; set; }
	    public int IDPostre { get; set; }
        public int IDBebida { get; set; }
        public int Cuenta { get; set; }
    }
}
