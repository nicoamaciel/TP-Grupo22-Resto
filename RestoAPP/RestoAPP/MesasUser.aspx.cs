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
        public List<Mesa> mesasMeseros { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
                if (!IsPostBack)
                {
                if (Session["Usuario"]!=null) { 
                    Dominio.Login login = (Dominio.Login)Session["Usuario"];
                    if(login.NivelAcceso ==1) {
                        NegocioEmpleados aux = new NegocioEmpleados();
                        DdlMesero.DataSource =aux.listarMeseros();
                        DdlMesero.DataValueField = "IdEmpleado";
                        DdlMesero.DataTextField = "Nombre";
                        DdlMesero.DataBind();
                        NegocioMesas mesas = new NegocioMesas();
                        mesasMeseros = mesas.listarMesasAdmin();
                        repRepetidor.DataSource = mesasMeseros;
                        repRepetidor.DataBind();
                    }
                    else
                    {
                    NegocioMesas mesas = new NegocioMesas();
                    mesasMeseros = mesas.listarMesas(login.IdUser);
                    
                    repRepetidor.DataSource = mesasMeseros;
                    repRepetidor.DataBind();
                    }
                }
                else
                {
                    Response.Redirect("AccesoEmpleados.aspx");
                }
                }
            
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            NegocioMesas mesas = new NegocioMesas();
            mesasMeseros = mesas.listarMesas(int.Parse(DdlMesero.SelectedValue));

            repRepetidor.DataSource = mesasMeseros;
            repRepetidor.DataBind();
        }

        protected void btnMesa_Click(object sender, EventArgs e)
        { 
            Response.Redirect("PantallaPedidos.aspx?ID="+ ((Button)sender).CommandArgument);
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            if (Session[((Button)sender).CommandArgument] != null)
            {
                NegocioPedido pedido = new NegocioPedido();
                pedido.Pagar(((Button)sender).CommandArgument);
                Session.Remove(((Button)sender).CommandArgument);
            }
        }

        protected void BtnCancelarPedido_Click(object sender, EventArgs e)
        {
            if (Session[((Button)sender).CommandArgument] != null)
            {
                NegocioPedido pedido = new NegocioPedido();
                pedido.CancelarTodo(((Button)sender).CommandArgument);
                Session.Remove(((Button)sender).CommandArgument);
            }
        }
    }
}