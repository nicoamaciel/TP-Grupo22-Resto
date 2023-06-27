using NegocioResto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Dominio;

namespace RestoAPP
{
    public partial class PantallaCargaEmpleados : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            ConfirmaEliminacion = false;
            try
            {
                //configuración inicial de la pantalla.
                if (!IsPostBack)
                {

                    ddlCargo.Items.Add("Mesero");
                    ddlCargo.Items.Add("Encargado");
                    ddlCargo.Items.Add("Cocina");
                    ddlCargo.Items.Add("Administrador");
                }

                //configuración si estamos modificando.
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    NegocioEmpleados negocio = new NegocioEmpleados();
                    Empleados seleccionado = (negocio.listarEmpleado(id))[0];

                    
                    Session.Add("EmpleadoSeleccionado", seleccionado);

                    //pre cargar todos los campos...
                    txtId.Text = id;
                    txtNombre.Text = seleccionado.Nombre;
                    txtApellido.Text = seleccionado.Apellido;
                    txtDNI.Text = Convert.ToString(seleccionado.Dni);
                    TxtTurno.Text = Convert.ToString(seleccionado.Turno);
                    txtSueldo.Text = Convert.ToString(seleccionado.sueldo);
                    TxtCodigo.Text = seleccionado.Codigo;
                    ddlCargo.SelectedValue = seleccionado.Cargo;

                    //configurar acciones
                    if (!seleccionado.Activo)
                        btnInactivar.Text = "Reactivar";
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        protected void btnInactivar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}