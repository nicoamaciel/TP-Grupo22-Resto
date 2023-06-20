using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioResto
{
    public class LecturaUsuario
    {
        public bool login(Login login)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Usuario,Contraseña,NivelAcceso from LOGIN Where Usuario=@Usuario and Contraseña=@Contraseña");
                datos.setearParametro("@Usuario", login.Usuario);
                datos.setearParametro("@Contraseña", login.Contraseña);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                   login.NivelAcceso=(int)datos.Lector["NivelAcceso"];
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();

            }
        }
    }
}

