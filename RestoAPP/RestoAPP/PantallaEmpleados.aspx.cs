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
        public List<Empleados> Empleados { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NegocioEmpleados negocio = new NegocioEmpleados();
                Empleados = negocio.listarTodosEmpleados();
                dgvEmpleados.DataSource = Empleados;
                dgvEmpleados.DataBind();
            }
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
            dgvEmpleados.DataBind();
        }
    }
}