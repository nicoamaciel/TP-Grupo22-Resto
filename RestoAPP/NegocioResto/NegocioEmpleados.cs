using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
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
                datos.setearConsulta("SELECT IDEmpleado,Codigo,Descripcion,Turno,sueldo,Cargo,Nombre,Apellido,Dni,Activo from Empleados");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Empleados aux = new Empleados();
                    aux.IDEmpleado = (int)datos.Lector["IDEmpleado"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Cargo = (string)datos.Lector["Cargo"];
                    aux.Turno = (DateTime)datos.Lector["Turno"];
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
        public List<Empleados> listarEmpleado(string Dni)
        {
            List<Empleados> lista = new List<Empleados>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT IDEmpleado,Codigo,Descripcion,Turno,sueldo,Cargo,Nombre,Apellido,Dni,Activo from Empleados where Dni=@dni");
                datos.setearParametro("@dni", Dni);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Empleados aux = new Empleados();
                    aux.IDEmpleado = (int)datos.Lector["IDEmpleado"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Cargo = (string)datos.Lector["Cargo"];
                    aux.Turno = (DateTime)datos.Lector["Turno"];
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
    }
}
