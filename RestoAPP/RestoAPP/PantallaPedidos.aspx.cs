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
    public partial class PantallaPedidos : System.Web.UI.Page
    {
        public string id { get;set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";


            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(id))
                {
                    TxtIDMesa.Text = id;
                    NegocioPedido negocioPedido = new NegocioPedido();
                    dgvPedidos.DataSource = negocioPedido.Listar(int.Parse(id));
                    dgvPedidos.DataBind();
                    ListaMenu menu = new ListaMenu();
                    Rpt_Comida.DataSource = menu.listarSP();
                    Rpt_Comida.DataBind();
                    ListaBebidas bebidas = new ListaBebidas();
                    Rpt_Bebida.DataSource = bebidas.listarBebidas();
                    Rpt_Bebida.DataBind();
                    ddlCampo.Text = "Todos";
                    DdlCamposBebidas.Text = "Todos";
                }
                else
                {
                    Session.Add("error", "Necesita una mesa para acceder");
                    Response.Redirect("Error.aspx");
                }
            }
            if (ddlCampo.Text != "Precio")
            {
                if (ddlCampo.Text == "Tipo")
                {
                    BtnFiltrarComida.OnClientClick = "return validarComida();";
                }
                else
                {
                    BtnFiltrarComida.OnClientClick = "return validarComida();";
                }
            }


            if (DdlCamposBebidas.Text != "Todos")
                btnBuscarBebida.OnClientClick = "return validarBebida();";

        }

        protected void ButtonListar_Click(object sender, EventArgs e)
        {
            NegocioPedido negocioPedido = new NegocioPedido();
            dgvPedidos.DataSource = negocioPedido.Listar(int.Parse(TxtIDMesa.Text));
            dgvPedidos.DataBind();
        }
        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if (ddlCampo.SelectedItem.ToString() == "Precio")
            {
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
            }
            else
            {
                if (ddlCampo.SelectedItem.ToString() == "Tipo")
                {
                    ddlCriterio.Items.Add("Principal");
                    ddlCriterio.Items.Add("Postre");
                    ddlCriterio.Items.Add("Entrada");
                }
            }
        }
        protected void DdlCamposBebidas_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlCriterioBebida.Items.Clear();
            if (DdlCamposBebidas.SelectedItem.ToString() == "Precio")
            {
                DdlCriterioBebida.Items.Add("Igual a");
                DdlCriterioBebida.Items.Add("Mayor a");
                DdlCriterioBebida.Items.Add("Menor a");
            }
            else
            {
                if (DdlCamposBebidas.SelectedItem.ToString() == "Descripcion")
                {
                    DdlCriterioBebida.Items.Add("Comienza con");
                    DdlCriterioBebida.Items.Add("Termina con");
                    DdlCriterioBebida.Items.Add("Contiene");
                }
            }

        }
        protected void Rpt_Bebida_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                int id = (int)DataBinder.Eval(e.Item.DataItem, "id");
                CheckBox checkBox = (CheckBox)e.Item.FindControl("CbxBebida");
                checkBox.Attributes.Add("data-id", id.ToString());
                checkBox.Attributes.Add("onclick", "selectOnlyOneBebida(this);");
            }
        }
        protected void Rpt_Comida_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                int id = (int)DataBinder.Eval(e.Item.DataItem, "id");
                CheckBox checkBox = (CheckBox)e.Item.FindControl("CbxComida");
                checkBox.Attributes.Add("data-id", id.ToString());
                checkBox.Attributes.Add("onclick", "selectOnlyOne(this);");
            }
        }
        protected void btnBuscarBebida_Click(object sender, EventArgs e)
        {
            ListaBebidas bebidas = new ListaBebidas();
            if (ddlCampo.Text == "todo")
            {

                Rpt_Bebida.DataSource = bebidas.listarBebidas();
                Rpt_Bebida.DataBind();
            }
            else
            {
                Rpt_Bebida.DataSource = bebidas.BusquedaAvanzada(ddlCampo.Text, ddlCriterio.Text, TxtBebida.Text);
                Rpt_Bebida.DataBind();

            }
        }
        protected void BtnFiltrarComida_Click(object sender, EventArgs e)
        {
            ListaMenu menu = new ListaMenu();
            if (ddlCampo.Text == "todo")
            {

                Rpt_Comida.DataSource = menu.listarSP();
                Rpt_Comida.DataBind();
            }
            else
            {
                Rpt_Comida.DataSource = menu.BusquedaAvanzada(ddlCampo.Text, ddlCriterio.Text, txtComida.Text);
                Rpt_Comida.DataBind();
            }
        }

        protected void dgvPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = dgvPedidos.SelectedRow;
            NegocioPedido pedido = new NegocioPedido();
            if (row.Cells[0].Text == "Modificar")
            {
                ListaMenu menu = new ListaMenu();
                List<Dominio.Menu> reg = menu.listar1(Request.Form["<%= Rpt_Comida.ClientID %>"].ToString());

                ListaBebidas bebidas = new ListaBebidas();
                List<Bebidas> bebiAux = bebidas.listaBebida(Request.Form["<%= Rpt_Bebida.ClientID %>"].ToString());
                string pedidoId = row.Cells[1].Text;
                Pedidos aux = new Pedidos();
                aux.IDPedido = int.Parse(pedidoId);
                aux.Plato.ID = reg[0].ID;
                aux.Bebida.ID = bebiAux[1].ID;
                aux.Cuenta = reg[0].Precio+bebiAux[0].Precio;
                pedido.Modificar(aux);

            }
            else if (row.Cells[0].Text == "Cancelar")
            {
                string pedidoId = row.Cells[1].Text;
                pedido.Cancelar(pedidoId);

            }
        }

        protected void BtnAgregarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                ListaMenu menu = new ListaMenu();
                List<Dominio.Menu> reg = menu.listar1(Request.Form["<%= Rpt_Comida.ClientID %>"].ToString());

                ListaBebidas bebidas = new ListaBebidas();
                List<Bebidas> aux = bebidas.listaBebida(Request.Form["<%= Rpt_Bebida.ClientID %>"].ToString());

                Pedidos pedidos = new Pedidos();
                pedidos.Bebida = new Bebidas();
                pedidos.IDEmpleado = ((Dominio.Login)Session["Usuario"]).IdUser;
                pedidos.Plato = new Dominio.Menu();
                pedidos.Plato.ID = reg[0].ID;
                pedidos.Bebida.ID = aux[0].ID;
                pedidos.IDMesa = int.Parse(TxtIDMesa.Text);
                pedidos.Cuenta = aux[0].Precio + reg[0].Precio;
                NegocioPedido negocioPedido = new NegocioPedido();
                negocioPedido.Agregar(pedidos);
                if (Session[TxtIDMesa.Text] == null)
                {
                    Session.Add(TxtIDMesa.Text, true);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}