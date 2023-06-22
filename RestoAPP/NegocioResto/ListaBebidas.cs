using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace NegocioResto
{
    public class ListaBebidas
    {
        public List<Bebidas> listarBebidas()
        {
            List<Bebidas> lista = new List<Bebidas>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select IDBebida, Precio, Descripcion, UrlImagen from Bebidas");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Bebidas aux = new Bebidas();
                    aux.IDBebida = (int)datos.Lector["IDBebida"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
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
