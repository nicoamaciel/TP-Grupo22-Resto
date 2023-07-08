using Dominio;
using NegocioResto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RestoAPP
{
    public partial class PerfilSession : System.Web.UI.Page
    {
        public List<Empleados> ListaEmpleados { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
           if (Session["Usuario"] != null) { 
            if (!IsPostBack)
            {
                Dominio.Login login =(Dominio.Login)Session["Usuario"];
                NegocioEmpleados empleado = new NegocioEmpleados();
                ListaEmpleados = empleado.listarEmpleado(login.IdUser);
            }
            }
            else
            {
                Response.Redirect("AccesoEmpleados.aspx");
            }
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Session.Contents.Remove("Usuario");
            Response.Redirect("AccesoEmpleados.aspx");
        }
    }
}