using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class MesasMesero
    {
        public int id {  get; set; }
        public Mesa Tipo { get; set; }
        public Empleados Mesero { get; set; }
        public bool activo { get; set; }
        
    }
}
