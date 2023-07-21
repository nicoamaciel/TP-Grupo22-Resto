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
        NegocioMesas NegMesa = new NegocioMesas();
        public bool edit { get;set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                edit = false;
                NegocioEmpleados aux = new NegocioEmpleados();
                DdlMesero.DataSource = aux.listarMeseros("3");
                DdlMesero.DataValueField = "IdEmpleado";
                DdlMesero.DataTextField = "Nombre";
                DdlMesero.DataBind();
                CargarGrilla();
            }
            BtnAgregar.OnClientClick = "return validarCantidad();";
        }
        private void CargarGrilla()
        {
            DgvMesas.DataSource = NegMesa.listarMesasAdmin();
            DgvMesas.DataBind();
        }
        protected void DdlTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            NegocioEmpleados aux = new NegocioEmpleados();
            DdlMesero.Items.Clear();
            if (DdlTurnos.Text =="Mostrar Ambos Turnos")
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
            Mesa mesa = new Mesa();
            mesa.TamañoMesa = int.Parse(TxtTamaño.Text);
            mesa.Descripcion = TxtDescripcion.Text;
            mesa.Empleado = new Empleados();
            mesa.Empleado.IDEmpleado = int.Parse(DdlMesero.SelectedValue);
            NegMesa.Agregar(mesa);
            CargarGrilla();
        }
        protected void DgvMesas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string MesaId = DgvMesas.DataKeys[e.RowIndex].Value.ToString();
            NegMesa.eliminar(MesaId);
            CargarGrilla();
        }

        protected void DgvMesas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DgvMesas.EditIndex = e.NewEditIndex;
            edit = true;
            CargarGrilla();
        }
        protected void DgvMesas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            DgvMesas.EditIndex = -1;
            edit = false;
            CargarGrilla();
        }

        protected void DgvMesas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow fila = DgvMesas.Rows[e.RowIndex];
            string MesaId = DgvMesas.DataKeys[e.RowIndex].Value.ToString();

            GridViewRow row = DgvMesas.SelectedRow;
            Mesa mesa = NegMesa.ListarMesa(MesaId);
            mesa.TamañoMesa = int.Parse((fila.FindControl("TxtTamañoDVG") as TextBox).Text.ToUpper());
            mesa.Descripcion = (fila.FindControl("TxtDescripcion") as TextBox).Text.ToUpper();
            mesa.Activo = (fila.FindControl("chkEstado") as CheckBox).Checked;
            mesa.Empleado = new Empleados();
            mesa.Empleado.IDEmpleado = int.Parse(DdlMesero.SelectedValue);
            NegMesa.Modificar(mesa);
            DgvMesas.EditIndex = -1;
            edit = false;
            CargarGrilla();
        }
    }
}