using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Empleados
    {
        public int IDEmpleado { get; set; }
	    public string Codigo { get; set; }
	    public string Descripcion { get; set; }
        public DateTime Turno { get; set; }
        public decimal sueldo { get; set; }
        public string Cargo  { get; set; }
        public string Nombre  { get; set; }
        public string Apellido{ get; set; }
        public int Dni { get; set; }
        public bool Activo { get; set; }
    }
}
