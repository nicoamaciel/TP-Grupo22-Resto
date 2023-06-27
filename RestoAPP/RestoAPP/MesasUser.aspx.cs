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
    public partial class MesasUser : System.Web.UI.Page
    {
        public List<MesasMesero> mesasMeseros { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
          //  Dominio.Login login = Session["Usuario"] != null ? (Dominio.Login)Session["Usuario"] : null;
         //   if (!(login != null && login.Usuario != null))
        //    {
         //       Response.Redirect("AccesoEmpleados.aspx");
        //    }
            if (!IsPostBack)
            {
                NegocioMesas mesas = new NegocioMesas();
                mesasMeseros = mesas.listarMesas("3");
                repRepetidor.DataSource = mesasMeseros;
                repRepetidor.DataBind();
            }
        }
    }
}