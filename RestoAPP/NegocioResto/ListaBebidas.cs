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
                datos.setearProcedimiento("SP_BebidasMostrar");
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

        public void Agregar(Bebidas nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_MesasNueva");
                datos.setearParametro("@Precio", nuevo.Precio);
                datos.setearParametro("@TipoBebida", nuevo.TipoBebida);
                datos.setearParametro("@descripcion", nuevo.Descripcion);
                datos.setearParametro("@url", nuevo.UrlImagen);
                datos.ejecutarLectura();
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
        public void eliminar(string id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearProcedimiento("SP_EliminarBebida");
                datos.setearParametro("@id", int.Parse(id));
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Modificar(Bebidas nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_BebidasModificar");
                datos.setearParametro("@Id", nuevo.IDBebida);
                datos.setearParametro("@Precio", nuevo.Precio);
                datos.setearParametro("@TipoBebida", nuevo.TipoBebida);
                datos.setearParametro("@descripcion", nuevo.Descripcion);
                datos.setearParametro("@url", nuevo.UrlImagen);

                datos.ejecutarLectura();
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
