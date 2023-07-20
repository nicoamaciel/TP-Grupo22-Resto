using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dominio;

namespace NegocioResto
{
    public class ListaMenu
    {
        public List<Menu> listarSP()
        {
            List<Menu> lista = new List<Menu>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_MenuMostrar");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Menu aux = new Menu();
                    aux.ID = (int)datos.Lector["IDPlato"];
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

        public List<Menu> listarMenuTipo(string tipo)
        {
            List<Menu> lista = new List<Menu>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_MenuMostrarClase");
                datos.setearParametro("@clase", tipo);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Menu aux = new Menu();
                    aux.ID = (int)datos.Lector["IDPlato"];
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
        public Menu listar1(string id)
        {
            Menu aux = new Menu();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_MenuID");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    aux.ID = (int)datos.Lector["IDPlato"];
                    aux.TipoPlato = (string)datos.Lector["TipoPlato"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Clase = (string)datos.Lector["Clase"];
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
        public List<Menu> BusquedaAvanzada(string criterio,string tipo,string filtro)
        {
            List<Menu> lista = new List<Menu>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "Select IDPlato,TipoPlato,Descripcion,Clase,UrlImagen,Precio from menu ";
                if(criterio== "Precio")
                {
                    switch(tipo)
                    {
                        case "Mayor a":
                            consulta += "where precio>"+ filtro;
                            break;
                        case "Menor a":
                            consulta += "where Precio < " + filtro;
                            break;
                        default:
                            consulta += "where Precio = " + filtro;
                            break;
                    }
                }
                else if (criterio == "Tipo")
                {
                            consulta += "where clase like '%" + tipo + "%'";
                    
                }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Menu aux = new Menu();
                    aux.ID = (int)datos.Lector["IDPlato"];
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
        public void Agregar(Menu nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_MenuNuevo");
                datos.setearParametro("@TipoPlato", nuevo.TipoPlato);
                datos.setearParametro("@Precio", nuevo.Precio);
                datos.setearParametro("@UrlImagen", nuevo.UrlImagen);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@Clase", nuevo.Clase);

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
                datos.setearProcedimiento("SP_MenuEliminar");
                datos.setearParametro("@id", int.Parse(id));
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Modificar(Menu nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_MenuModificar");
                datos.setearParametro("@IDPlato", nuevo.ID);
                datos.setearParametro("@TipoPlato", nuevo.TipoPlato);
                datos.setearParametro("@Precio", nuevo.Precio);
                datos.setearParametro("@UrlImagen", nuevo.UrlImagen);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@Clase", nuevo.Clase);

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
