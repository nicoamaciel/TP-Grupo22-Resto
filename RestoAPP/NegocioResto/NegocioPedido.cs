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

        public List<Pedidos> Listar(string id)
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
                    aux.IDMesa = (int)datos.Lector["IDMesa"];
                    aux.IDPedido = (int)datos.Lector["IDPedido"]; 
                    aux.Estado = (bool)datos.Lector["activo"];
                    aux.fecha = (DateTime)datos.Lector["fecha"];
                    aux.Cuenta = (decimal)datos.Lector["Cuenta"];
                    aux.IDEmpleado = (int)datos.Lector["IDEmpleado"];

                    aux.Bebida.ID = (int)datos.Lector["IdBebida"];
                    aux.Bebida.Descripcion = (string)datos.Lector["Descripcion Bebidas"]; 
                    aux.Bebida.TipoBebida = (decimal)datos.Lector["TipoBebida"];
                    aux.Bebida.Precio=(decimal)datos.Lector["Precio Bebidas"];

                    aux.Plato.ID = (int)datos.Lector["idplato"];
                    aux.Plato.Clase = (string)datos.Lector["clase"];
                    aux.Plato.Descripcion = (string)datos.Lector["Descripcion Comida"];
                    aux.Plato.Precio = (decimal)datos.Lector["Precio Comida"];
                    
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
                datos.setearParametro("@idempleado",nuevo.IDEmpleado);
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
                datos.setearParametro("@idpedido", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CancelarTodo(string id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearProcedimiento("SP_PedidoCancelarTodo");
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
        public List<Pedidos> ListarTiempo(DateTime fecha,string IDEmpleado,string caso,string criterio)
        {
            List<Pedidos> lista = new List<Pedidos>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT  SUM(Z.Cuenta) AS Cuenta, P.fecha,E.Nombre,E.Apellido FROM Pedidos P, Pedidos Z,Empleados E WHERE E.IDEmpleado=P.IDEmpleado AND ";
                
                if (IDEmpleado!=null){ 
                consulta += "P.IDEmpleado="+IDEmpleado +" and";
                }
                if (caso != "DEL DIA")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "  CONVERT(date, P.fecha) >= CONVERT(date, " + fecha + ")";
                            break;
                        case "Menor a":
                            consulta += " CONVERT(date, P.fecha) < CONVERT(date, " + fecha + ")";
                            break;
                        default:
                            consulta += " CONVERT(date, P.fecha) = CONVERT(date, " + fecha + ")";
                            break;
                    }
                }
                else
                {
                    if (caso != "DEL año")
                    {
                        switch (criterio)
                        {
                            case "Mayor a":
                                consulta += " YEAR(P.fecha) >= YEAR(" + fecha + ")";
                                break;
                            case "Menor a":
                                consulta += " YEAR(P.fecha) < YEAR(" + fecha + ")";
                                break;
                            default:
                                consulta += " YEAR(P.fecha) = YEAR(" + fecha + ")";
                                break;
                        }
                        if (caso != "DEL Mes")
                        {
                            switch (criterio)
                            {
                                case "Mayor a":
                                    consulta += " YEAR(P.fecha) = YEAR(" + fecha + ") AND MONTH(P.fecha) >= MONTH(" + fecha + ")";
                                    break;
                                case "Menor a":
                                    consulta += " YEAR(P.fecha) = YEAR(" + fecha + ") AND MONTH(P.fecha) < MONTH(" + fecha + ")";
                                    break;
                                default:
                                    consulta += " YEAR(P.fecha) = YEAR(" + fecha + ") AND MONTH(P.fecha) = MONTH(" + fecha + ")";
                                    break;
                            }
                        }
                    }
                }
                consulta+=("GROUP BY  P.fecha,E.Nombre,E.Apellido;");
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Pedidos aux = new Pedidos();
                    aux.Estado = (bool)datos.Lector["activo"];
                    aux.fecha = (DateTime)datos.Lector["fecha"];
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
    }
}
