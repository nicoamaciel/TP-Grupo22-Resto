using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Menu
    {
        public int ID { get; set; }
	    public string TipoPlato { get; set; }
	    public decimal Precio { get; set; }
	    public string UrlImagen { get; set; }
        public string Descripcion { get; set; }
        public string Clase { get; set; }   

    }

}
