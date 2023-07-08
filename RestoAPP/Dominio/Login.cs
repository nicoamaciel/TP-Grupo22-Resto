using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Dominio
{
    public class Login
    {
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public int NivelAcceso { get; set; }
        public int IdUser { get; set; }
        public Login(String user, string pass)
        {
            Usuario = user;
            Contraseña=pass;
        }

    }

    
}
