using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using NegocioResto;

namespace RestoAPP
{
    public partial class Mod_AgregarMesas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NegocioEmpleados aux = new NegocioEmpleados();
                DdlMesero.DataSource = aux.listarMeseros("3");
                DdlMesero.DataValueField = "IdEmpleado";
                DdlMesero.DataTextField = "Nombre";
                DdlMesero.DataBind();
                NegocioMesas mesas = new NegocioMesas();
                DgvMesas.DataSource = mesas.listarMesasAdmin();
                DgvMesas.DataBind();
            }
            BtnAgregar.OnClientClick = "return validarCantidad();";
        }

        protected void DgvMesas_SelectedIndexChanged(object sender, EventArgs e)
        {

            GridViewRow row = DgvMesas.SelectedRow;
            string MesaId = DgvMesas.DataKeys[row.RowIndex].Value.ToString();
            NegocioMesas negocioMesas = new NegocioMesas();
            Mesa mesa = negocioMesas.ListarMesa(MesaId);
            mesa.TamañoMesa = int.Parse(TxtTamaño.Text);
            mesa.Descripcion = TxtDescripcion.Text;
            mesa.Empleado = new Empleados();
            mesa.Empleado.IDEmpleado = int.Parse(DdlMesero.SelectedValue);
            negocioMesas.Modificar(mesa);
        }

        protected void DgvMesas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            NegocioMesas mesa = new NegocioMesas();
            string MesaId = DgvMesas.DataKeys[e.RowIndex].Value.ToString();
            mesa.eliminar(MesaId);
            DgvMesas.DataBind();
        }

        protected void DgvMesas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = DgvMesas.SelectedRow;
            string MesaId = DgvMesas.DataKeys[row.RowIndex].Value.ToString();
            NegocioMesas Dato = new NegocioMesas();
            Mesa mesa = Dato.ListarMesa(MesaId);
            mesa.Empleado = new Empleados();
            mesa.Empleado.IDEmpleado = int.Parse(DdlMesero.SelectedValue);
            Dato.Modificar(mesa);
            DgvMesas.DataBind();
        }

        protected void DdlTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            NegocioEmpleados aux = new NegocioEmpleados();
            DdlMesero.Items.Clear();
            if (DdlTurnos.Text == "Ambos Turnos")
            {
                DdlMesero.DataSource = aux.listarMeseros("3");
                DdlMesero.DataValueField = "IdEmpleado";
                DdlMesero.DataTextField = "Nombre";
                DdlMesero.DataBind();
            }
            else
            {
                if (DdlTurnos.Text == "8 a 16:00")
                {
                    DdlMesero.DataSource = aux.listarMeseros("1");
                    DdlMesero.DataValueField = "IdEmpleado";
                    DdlMesero.DataTextField = "Nombre";
                    DdlMesero.DataBind();
                }
                else
                {
                    DdlMesero.DataSource = aux.listarMeseros("2");
                    DdlMesero.DataValueField = "IdEmpleado";
                    DdlMesero.DataTextField = "Nombre";
                    DdlMesero.DataBind();
                }
            }
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            NegocioMesas negocioMesas = new NegocioMesas();
            Mesa mesa = new Mesa();
            mesa.TamañoMesa = int.Parse(TxtTamaño.Text);
            mesa.Descripcion = TxtDescripcion.Text;
            mesa.Empleado = new Empleados();
            mesa.Empleado.IDEmpleado = int.Parse(DdlMesero.SelectedValue);
            negocioMesas.Agregar(mesa);
        }
    }
}