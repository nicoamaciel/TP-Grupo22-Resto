using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
                    aux.ID = (int)datos.Lector["IDBebida"];
                    aux.TipoBebida = (decimal)datos.Lector["TipoBebida"];
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
        public Bebidas listaBebida(string id)
        {
            Bebidas aux = new Bebidas();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_BebidaMostrar");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    aux.ID = (int)datos.Lector["IDBebida"];
                    aux.TipoBebida = (decimal)datos.Lector["TipoBebida"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.UrlImagen = (string)datos.Lector["UrlImagen"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                }

                return aux;
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
        public List<Bebidas> BusquedaAvanzada(string criterio, string tipo, string filtro)
        {
            List<Bebidas> lista = new List<Bebidas>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "Select IDBebida,Precio,TipoBebida,Descripcion,UrlImagen from Bebidas ";
                if (criterio == "Precio")
                {
                    switch (tipo)
                    {
                        case "Mayor a":
                            consulta += "where Precio >" + filtro;
                            break;
                        case "Menor a":
                            consulta += "where Precio < " + filtro;
                            break;
                        default:
                            consulta += "where Precio = " + filtro;
                            break;
                    }
                }
                else if (criterio == "Descripcion")
                {
                    switch (tipo)
                    {
                        case "Comienza con":
                            consulta += "where Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "where Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "where Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Bebidas aux = new Bebidas();
                    aux.ID = (int)datos.Lector["IDBebida"];
                    aux.TipoBebida = (decimal)datos.Lector["TipoBebida"];
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
                datos.setearParametro("@Id", nuevo.ID);
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
