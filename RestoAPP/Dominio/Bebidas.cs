using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Bebidas
    {
        public int ID {get; set;}
	    public decimal Precio {get; set;}
        public decimal TipoBebida{get; set;}
        public string Descripcion {get; set;}
        public string UrlImagen { get; set; }
    }
}
