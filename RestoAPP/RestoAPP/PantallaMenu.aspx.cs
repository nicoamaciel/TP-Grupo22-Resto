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
        public List<Dominio.Bebidas> MostraBebidas { get; set; }
        public List<Dominio.Menu> MostrarPrincipal { get; set; }
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

        protected void Button5_Click(object sender, EventArgs e)
        {
            ListaBebidas aux = new ListaBebidas();
            MostraBebidas = aux.listarBebidas();
            repRepetidor.DataSource = MostraBebidas;
            repRepetidor.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            ListaPrincipal aux = new ListaPrincipal();
            MostrarPrincipal = aux.listarPrincipal();
            repRepetidor.DataSource = MostrarPrincipal;
            repRepetidor.DataBind();

        }
    }
}