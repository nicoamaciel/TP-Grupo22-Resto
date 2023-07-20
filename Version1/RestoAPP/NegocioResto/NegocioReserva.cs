using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioResto
{
    public class NegocioReserva
    {
        public List<Reserva> Listar(int id,DateTime hora)
        {
            List<Reserva> lista = new List<Reserva>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_ReservaMostrar");
                datos.setearParametro("@idmesa", id);
                datos.setearParametro("@hora", hora);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Reserva aux = new Reserva();
                    aux.IDReserva = (int)datos.Lector["IDReserva"];
                    aux.IDMesa = (int)datos.Lector["IDMesa"];
                    aux.CodigoReserva = (int)datos.Lector["CodigoReserva"];
                    aux.HoraReserva = (DateTime)datos.Lector["HoraReserva"];
                    aux.Comentario = (string)datos.Lector["Comentario"];
                    aux.CantidadClientes = (int)datos.Lector["CantidadClientes"];
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

        public void Agregar(Reserva nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_ReservaNueva");
                datos.setearParametro("@TipoPlato", nuevo.IDMesa);
                datos.setearParametro("@Precio", nuevo.HoraReserva);
                datos.setearParametro("@UrlImagen", nuevo.CodigoReserva);
                datos.setearParametro("@Descripcion", nuevo.Comentario);
                datos.setearParametro("@Clase", nuevo.CantidadClientes);

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
                datos.setearProcedimiento("SP_ReservaCancelar");
                datos.setearParametro("@CodigoReserva", int.Parse(id));
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Modificar(Reserva nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_ReservarModificar");
                datos.setearParametro("@TipoPlato", nuevo.IDMesa);
                datos.setearParametro("@Precio", nuevo.HoraReserva);
                datos.setearParametro("@UrlImagen", nuevo.CodigoReserva);
                datos.setearParametro("@Descripcion", nuevo.Comentario);
                datos.setearParametro("@Clase", nuevo.CantidadClientes);

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
        public bool Comprobar(Reserva reserva)
        {
            List<Reserva> lista = new List<Reserva>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT *from Reserva where CodigoReserva="+reserva.CodigoReserva);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    reserva.IDReserva = (int)datos.Lector["IDReserva"];
                    reserva.IDMesa = (int)datos.Lector["IDMesa"];
                    reserva.CodigoReserva = (int)datos.Lector["CodigoReserva"];
                    reserva.HoraReserva = (DateTime)datos.Lector["HoraReserva"];
                    reserva.Comentario = (string)datos.Lector["Comentario"];
                    reserva.CantidadClientes = (int)datos.Lector["CantidadClientes"];
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

        public bool buscar(Reserva reserva)
        {
            List<Reserva> lista = new List<Reserva>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT *FROM Reserva WHERE CodigoReserva="+reserva.CodigoReserva +
                    "and DATEPART(DAY, HoraReserva) = DATEPART(DAY, GETDATE()) AND DATEPART(MONTH, HoraReserva) = DATEPART(MONTH, GETDATE()) " +
                    "AND HoraReserva >= DATEADD(MINUTE, -30, GETDATE()) AND HoraReserva <= DATEADD(MINUTE, 30, GETDATE())");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    reserva.IDReserva = (int)datos.Lector["IDReserva"];
                    reserva.IDMesa = (int)datos.Lector["IDMesa"];
                    reserva.CodigoReserva = (int)datos.Lector["CodigoReserva"];
                    reserva.HoraReserva = (DateTime)datos.Lector["HoraReserva"];
                    reserva.Comentario = (string)datos.Lector["Comentario"];
                    reserva.CantidadClientes = (int)datos.Lector["CantidadClientes"];
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
        public bool buscar(int idmesa)
        {
            List<Reserva> lista = new List<Reserva>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT *FROM Reserva WHERE idmesa=" + idmesa +" and "+
                    "DATEPART(DAY, HoraReserva) = DATEPART(DAY, GETDATE()) AND DATEPART(MONTH, HoraReserva) = DATEPART(MONTH, GETDATE()) " +
                    "AND HoraReserva >= DATEADD(MINUTE, -30, GETDATE()) AND HoraReserva <= DATEADD(MINUTE, 30, GETDATE())");
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
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
