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
        public List<Bebidas> MostraBebidas { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListaMenu aux = new ListaMenu();
                MostrarMenu = aux.listarSP();
                repRepetidor.DataSource = MostrarMenu;
                repRepetidor.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ListaMenu aux = new ListaMenu();
            MostrarMenu = aux.listarMenuTipo("Entrada");
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
            ListaMenu aux = new ListaMenu();
            MostrarMenu = aux.listarMenuTipo("Principal");
            repRepetidor.DataSource = MostrarMenu;
            repRepetidor.DataBind();

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            ListaMenu aux = new ListaMenu();
            MostrarMenu = aux.listarMenuTipo("Postre");
            repRepetidor.DataSource = MostrarMenu;
            repRepetidor.DataBind();
        }
    }
}