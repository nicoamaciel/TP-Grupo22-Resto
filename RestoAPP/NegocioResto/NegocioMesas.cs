using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioResto
{
    public class NegocioMesas
    {
        public List<Mesa> listarMesas(int id)
        {
            List<Mesa> lista = new List<Mesa>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_MesasMesero");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Mesa aux = new Mesa();
                    aux.IdMesa = (int)datos.Lector["IDMesa"];
                    aux.Activo = (bool)datos.Lector["Activo"];
                    aux.TamañoMesa = (int)datos.Lector["TamañoMesa"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Empleado = new Empleados();
                    aux.Empleado.IDEmpleado = (int)datos.Lector["idmesero"];
                    aux.Empleado.Nombre = (string)datos.Lector["Nombre"];
                    aux.Empleado.Apellido = (string)datos.Lector["Apellido"];
                    aux.Empleado.Cargo = (string)datos.Lector["Cargo"];
                    aux.Empleado.Turno = (int)datos.Lector["turno"];
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

        public List<Mesa> listarMesasAdmin()
        {
            List<Mesa> lista = new List<Mesa>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_MesasAdmin");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Mesa aux = new Mesa();
                    aux.IdMesa = (int)datos.Lector["IDMesa"];
                    aux.Activo = (bool)datos.Lector["Activo"];
                    aux.Empleado = new Empleados();
                    aux.Empleado.Nombre = (string)datos.Lector["Nombre"];
                    aux.Empleado.Apellido = (string)datos.Lector["Apellido"];
                    aux.Empleado.Cargo = (string)datos.Lector["Cargo"];
                    aux.Empleado.Dni = (int)datos.Lector["dni"];
                    aux.TamañoMesa = (int)datos.Lector["TamañoMesa"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Empleado.Turno = (int)datos.Lector["Turno"];
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
        public Mesa ListarMesa(string IDmesa)
        {
            Mesa lista = new Mesa();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_MesasUnica");
                datos.setearParametro("@id", IDmesa);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    lista.IdMesa = (int)datos.Lector["IDMesa"];
                    lista.Activo = (bool)datos.Lector["Activo"];
                    lista.TamañoMesa = (int)datos.Lector["TamañoMesa"];
                    lista.Descripcion = (string)datos.Lector["Descripcion"];
                    lista.Empleado = new Empleados();
                    lista.Empleado.IDEmpleado = (int)datos.Lector["idmesero"];
                    lista.Empleado.Nombre = (string)datos.Lector["Nombre"];
                    lista.Empleado.Apellido = (string)datos.Lector["Apellido"];
                    lista.Empleado.Cargo = (string)datos.Lector["Cargo"];
                    lista.Empleado.Turno = (int)datos.Lector["turno"];
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

        public void Agregar(Mesa nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_MesasNueva");
                datos.setearParametro("@TamañoMesa", nuevo.TamañoMesa);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@IDMesero", nuevo.Empleado.IDEmpleado);
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
                datos.setearProcedimiento("SP_EliminarMesa");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Modificar(Mesa nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_ModificarMesa");
                datos.setearParametro("@IdMesa", nuevo.IdMesa);
                datos.setearParametro("@TamañoMesa", nuevo.TamañoMesa);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@IDMesero", nuevo.Empleado.IDEmpleado);
                datos.setearParametro("@Activo", nuevo.Activo);
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
