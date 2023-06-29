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
                    aux.IdMesa = (int)datos.Lector["IDMesasMesero"];
                    aux.Activo = (bool)datos.Lector["Activo"];
                    aux.Empleado = new Empleados();
                    aux.Empleado.Nombre = (string)datos.Lector["Nombre"];
                    aux.Empleado.Apellido = (string)datos.Lector["Apellido"];
                    aux.Empleado.Cargo = (string)datos.Lector["Cargo"];
                    aux.Empleado.Dni = (int)datos.Lector["dni"];
                    aux.TamañoMesa = (int)datos.Lector["TamañoMesa"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
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
                datos.setearParametro("@id", int.Parse(id));
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
                datos.setearParametro("@Id", nuevo.IdMesa);
                datos.setearParametro("@TamañoMesa", nuevo.TamañoMesa);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@IDMesero", nuevo.Empleado.IDEmpleado);
                datos.setearParametro("@IDMesero", nuevo.Activo);
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
