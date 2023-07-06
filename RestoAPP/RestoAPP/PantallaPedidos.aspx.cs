using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RestoAPP
{
    public partial class PantallaPedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnPedido_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonListar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListarPedido.aspx");
        }
    }
}