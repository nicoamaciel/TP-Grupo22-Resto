﻿using Dominio;
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
                datos.setearProcedimiento("SP_LoginMostrar");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    if ((string)datos.Lector["usuario"] == login.Usuario && (string)datos.Lector["Contraseña"] == login.Contraseña) {
                        login.NivelAcceso = (int)datos.Lector["NivelAcceso"];
                        login.IdUser = (int)datos.Lector["iduser"];
                        return true;
                    }
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
        public void Modificar(Login nuevo)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearProcedimiento("SP_LoginModificar");
                datos.setearParametro("@iduser", nuevo.IdUser);
                datos.setearParametro("@user", nuevo.Usuario);
                datos.setearParametro("@pass", nuevo.Contraseña);
                datos.setearParametro("@nivel", nuevo.NivelAcceso);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool SesionActiva(object sesion)
            {
                Login login = sesion != null ? (Login)sesion : null;
                if (login!=null && login.Usuario!=null)
                {
                    return true;
                }
                else { 
                    return false; 
                }
            }
        

    }
}

