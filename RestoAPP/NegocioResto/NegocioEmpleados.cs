using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NegocioResto
{
    public class NegocioEmpleados
    {
        public List<Empleados> listarTodosEmpleados()
        {
            List<Empleados> lista = new List<Empleados>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_EmpleadosMostrar");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Empleados aux = new Empleados();
                    aux.IDEmpleado = (int)datos.Lector["IDEmpleado"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Cargo = (string)datos.Lector["Cargo"];
                    aux.Turno = (int)datos.Lector["Turno"];
                    aux.sueldo = (decimal)datos.Lector["sueldo"];
                    aux.Dni = (int)datos.Lector["Dni"];
                    aux.Activo = (bool)datos.Lector["Activo"];

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
        public List<Empleados> listarEmpleado(int id)
        {
            List<Empleados> lista = new List<Empleados>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                
                datos.setearProcedimiento("SP_EmpleadosMostrarID");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Empleados aux = new Empleados();
                    aux.IDEmpleado = (int)datos.Lector["IDEmpleado"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Cargo = (string)datos.Lector["Cargo"];
                    aux.Turno = (int)datos.Lector["Turno"];
                    aux.sueldo = (decimal)datos.Lector["sueldo"];
                    aux.Dni = (int)datos.Lector["Dni"];
                    aux.Activo = (bool)datos.Lector["Activo"];

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
        public List<Empleados> listarMeseros(string turno)
        {
            List<Empleados> lista = new List<Empleados>();
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearProcedimiento("SP_EmpleadosMeseros");
                datos.setearParametro("@Turno", turno);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Empleados aux = new Empleados();
                    aux.IDEmpleado = (int)datos.Lector["IDEmpleado"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Cargo = (string)datos.Lector["Cargo"];
                    aux.Turno = (int)datos.Lector["Turno"];
                    aux.sueldo = (decimal)datos.Lector["sueldo"];
                    aux.Dni = (int)datos.Lector["Dni"];
                    aux.Activo = (bool)datos.Lector["Activo"];

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
        public void Agregar(Empleados nuevo)
        {
            List<Empleados> lista = new List<Empleados>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_EmpleadosNuevo");
                datos.setearParametro("@cargo", nuevo.Cargo);
                datos.setearParametro("@sueldo", nuevo.sueldo);
                datos.setearParametro("@turno", nuevo.Turno);
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@apellido", nuevo.Apellido);
                datos.setearParametro("@codigo", nuevo.Codigo);
                datos.setearParametro("@dni", nuevo.Dni);
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
        public void Modificar(Empleados nuevo)
        {
            List<Empleados> lista = new List<Empleados>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_EmpleadosModificar");
                datos.setearParametro("@ID", nuevo.IDEmpleado);
                datos.setearParametro("@cargo", nuevo.Cargo);
                datos.setearParametro("@sueldo", nuevo.sueldo);
                datos.setearParametro("@turno", nuevo.Turno);
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
                datos.setearProcedimiento("SP_EmpleadosEliminar");
                datos.setearParametro("@id", int.Parse(id));
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
