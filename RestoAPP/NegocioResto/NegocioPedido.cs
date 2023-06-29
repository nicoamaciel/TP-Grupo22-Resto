using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioResto
{
    public class NegocioPedido
    {

        public List<Pedidos> Listar(int id)
        {
            List<Pedidos> lista = new List<Pedidos>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_PedidoMostar");
                datos.setearParametro("@idmesa", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Pedidos aux = new Pedidos();
                    aux.Bebida=new Bebidas();
                    aux.Plato = new Menu();
                    aux.IDMesa = (int)datos.Lector["dni"];
                    aux.IDPedido = (int)datos.Lector["IDMesasMesero"]; 
                    aux.Estado = (bool)datos.Lector["activo"];

                    aux.Bebida.ID = (int)datos.Lector["Activo"];
                    aux.Bebida.Descripcion = (string)datos.Lector["Descripcion"]; 
                    aux.Bebida.TipoBebida = (decimal)datos.Lector["TipoBebida"];
                    aux.Bebida.Precio=(decimal)datos.Lector["Precio"];

                    aux.Plato.ID = (int)datos.Lector["idplato"];
                    aux.Plato.TipoPlato = (string)datos.Lector["TipoPlato"];
                    aux.Plato.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Plato.Precio = (decimal)datos.Lector["Precio"];

                    aux.Cuenta = (int)datos.Lector["Cuenta"];

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

        public void Agregar(Pedidos nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_PedidoNuevo");
                datos.setearParametro("@IDMesa", nuevo.IDMesa);
                datos.setearParametro("@IDPlato", nuevo.Plato.ID);
                datos.setearParametro("@IDBebida", nuevo.Bebida.ID);
                datos.setearParametro("@Cuenta", nuevo.Cuenta);
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
        public void Cancelar(string id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearProcedimiento("SP_PedidoCancelar");
                datos.setearParametro("@id", int.Parse(id));
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Pagar(string id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearProcedimiento("SP_PedidoPagado");
                datos.setearParametro("@id", int.Parse(id));
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Modificar(Pedidos nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_PedidoModificar");
                datos.setearParametro("@IDPedido", nuevo.IDPedido);
                datos.setearParametro("@IDBebida", nuevo.Bebida.ID);
                datos.setearParametro("@IDPlato", nuevo.Plato.ID);
                datos.setearParametro("@Cuenta", nuevo.Cuenta);
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
