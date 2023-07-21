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
    public partial class PantallaEmpleados : System.Web.UI.Page
    {
        NegocioEmpleados negocio = new NegocioEmpleados();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDGV();
            }
        }
        public void CargarDGV()
        {
                dgvEmpleados.DataSource = negocio.listarTodosEmpleados();
                dgvEmpleados.DataBind();
        }
        protected void dgvEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvEmpleados.SelectedDataKey.Value.ToString();
            Response.Redirect("PantallaCargaEmpleados.aspx?id="+id);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PantallaCargaEmpleados.aspx");
        }

        protected void dgvEmpleados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            NegocioEmpleados negocioEmpleados = new NegocioEmpleados();
            string id = dgvEmpleados.DataKeys[e.RowIndex].Value.ToString();
            negocioEmpleados.eliminar(id);
            CargarDGV();
        }
    }
}