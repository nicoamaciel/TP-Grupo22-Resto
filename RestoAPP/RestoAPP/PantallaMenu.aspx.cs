using NegocioResto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
namespace RestoAPP
{
    public partial class PantallaMenu : System.Web.UI.Page
    {
        public List<Dominio.Menu> MostrarMenu { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ListaMenu aux = new ListaMenu();
            MostrarMenu = aux.listarSP();
            repRepetidor.DataSource = MostrarMenu;
            repRepetidor.DataBind();
        }
    }
}