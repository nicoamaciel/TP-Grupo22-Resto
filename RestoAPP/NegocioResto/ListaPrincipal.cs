using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dominio;

namespace NegocioResto
{
    public class ListaPrincipal
    {
        public List<Menu> listarPrincipal()
        {
            List<Menu> lista = new List<Menu>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT IDPlato,Descripcion,Precio,TipoPlato,UrlImagen,Clase from Menu where Clase = 'Principal'");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Menu aux = new Menu();
                    aux.IDPlato = (int)datos.Lector["IDPlato"];
                    aux.TipoPlato = (string)datos.Lector["TipoPlato"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Clase = (string)datos.Lector["Clase"];
                    aux.UrlImagen = (string)datos.Lector["UrlImagen"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    lista.Add(aux);

                }

                return lista;
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

