﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Mesa
    {
        public int IdMesa  {get; set;}
        public int TamañoMesa { get; set; }
        public string Descripcion { get; set; }
        public Empleados Empleado { get; set; }
        public bool Activo { get; set; }

    }
}
