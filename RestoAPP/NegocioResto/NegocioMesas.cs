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
        public List<MesasMesero> listarMesas(string id)
        {
            List<MesasMesero> lista = new List<MesasMesero>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_MesasMesero");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    MesasMesero aux = new MesasMesero();
                    aux.id = (int)datos.Lector["IDMesa"];
                    aux.activo = (bool)datos.Lector["Activo"];
                    aux.Mesero = new Empleados();
                    aux.Mesero.Nombre = (string)datos.Lector["Nombre"];
                    aux.Mesero.Apellido = (string)datos.Lector["Apellido"];
                    aux.Mesero.Cargo = (string)datos.Lector["Cargo"];
                    aux.Tipo = new Mesa();
                    aux.Tipo.TamañoMesa = (int)datos.Lector["TamañoMesa"];
                    aux.Tipo.IdMesa = (int)datos.Lector["IdMesa"];
                    aux.Tipo.Descripcion = (string)datos.Lector["Descripcion"];
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

        public List<MesasMesero> listarMesasAdmin()
        {
            List<MesasMesero> lista = new List<MesasMesero>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_MesasAdmin");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    MesasMesero aux = new MesasMesero();
                    aux.id = (int)datos.Lector["IDMesasMesero"];
                    aux.activo = (bool)datos.Lector["Activo"];
                    aux.Mesero = new Empleados();
                    aux.Mesero.Nombre = (string)datos.Lector["Nombre"];
                    aux.Mesero.Apellido = (string)datos.Lector["Apellido"];
                    aux.Mesero.Cargo = (string)datos.Lector["Cargo"];
                    aux.Tipo = new Mesa();
                    aux.Tipo.TamañoMesa = (int)datos.Lector["TamañoMesa"];
                    aux.Tipo.IdMesa = (int)datos.Lector["IdMesa"];
                    aux.Tipo.Descripcion = (string)datos.Lector["Descripcion"];
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
                datos.setearParametro("@IDMesero", nuevo.IdMesero);
                datos.setearParametro("@activo", nuevo.Activo);
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
                datos.setearParametro("@IDMesero", nuevo.IdMesero);

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
