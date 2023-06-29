using Dominio;
using NegocioResto;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;


namespace RestoAPP
{
    public partial class PantallaMenu : System.Web.UI.Page
    {
        public List<Dominio.Menu> MostrarMenu { get; set; }
        public List<Bebidas> MostraBebidas { get; set; }
        protected string Categoria
        {
            get { return ViewState["Categoria"] as string; }
            set { ViewState["Categoria"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Categoria = "menu";
                ListaMenu aux = new ListaMenu();
                MostrarMenu = aux.listarSP();
                repRepetidor.DataSource = MostrarMenu;
                repRepetidor.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ListaMenu aux = new ListaMenu();
            Categoria = "menu";
            MostrarMenu = aux.listarMenuTipo("Entrada");
            repRepetidor.DataSource = MostrarMenu;
            repRepetidor.DataBind();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Categoria = "bebida";
            ListaBebidas aux = new ListaBebidas();
            MostraBebidas = aux.listarBebidas();
            repRepetidor.DataSource = MostraBebidas;
            repRepetidor.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Categoria = "menu";
            ListaMenu aux = new ListaMenu();
            MostrarMenu = aux.listarMenuTipo("Principal");
            repRepetidor.DataSource = MostrarMenu;
            repRepetidor.DataBind();

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Categoria = "menu";
            ListaMenu aux = new ListaMenu();
            MostrarMenu = aux.listarMenuTipo("Postre");
            repRepetidor.DataSource = MostrarMenu;
            repRepetidor.DataBind();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (Categoria == "menu")
            {
                Response.Redirect("/PantallaModMenu.aspx?id=" + ((Button)sender).CommandArgument);
            }
            else
            {
                Response.Redirect("PantModBebidas.aspx?id" + ((Button)sender).CommandArgument);
            }
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            ListaMenu comida = new ListaMenu();
            ListaBebidas bebida = new ListaBebidas();
            if (Categoria == "menu")
            {
                comida.eliminar(((Button)sender).CommandArgument);
            }
            else
            {
                bebida.eliminar(((Button)sender).CommandArgument);
            }

        }
    }
}