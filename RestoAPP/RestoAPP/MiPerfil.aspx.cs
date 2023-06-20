using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using NegocioResto;
using System.Data;
using System.Collections;
using System.Drawing.Imaging;

namespace RestoAPP
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        public List<Empleados> ListaEmpleados{get; set;}
        protected void Page_Load(object sender, EventArgs e)
        {
            Dominio.Login login = Session["Usuario"] != null ? (Dominio.Login)Session["Usuario"] : null;
            if (!(login != null && login.Usuario != null))
            {
                Response.Redirect("AccesoEmpleados.aspx");
            }
            if(!IsPostBack)
            {
                NegocioEmpleados empleado = new NegocioEmpleados();
                ListaEmpleados = empleado.listarEmpleado(login.Usuario);
            }
        }
    }
}