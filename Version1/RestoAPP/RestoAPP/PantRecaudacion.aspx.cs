using NegocioResto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RestoAPP
{
    public partial class PantRecaudacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void BtnFiltrar_Click(object sender, EventArgs e)
        {
            NegocioPedido Pedidos = new NegocioPedido();
            Rpt_Pedidos.DataSource = Pedidos.ListarTiempo(DateTime.Parse(txtFecha.Text),TxtMesero.Text,ddlCampo.Text,ddlCriterio.Text);
            Rpt_Pedidos.DataBind();
        }
    }
}