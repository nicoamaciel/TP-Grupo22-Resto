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
        public decimal TotalCuentas { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";


            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(id))
                {
                    TxtIDMesa.Text = id;
                    txtComida.Text = "0";
                    TxtBebida.Text = "0";   
                    NegocioPedido negocioPedido = new NegocioPedido();
                    dgvPedidos.DataSource = negocioPedido.Listar(id);
                    dgvPedidos.DataBind();
                    ListaMenu menu = new ListaMenu();
                    ListaBebidas bebidas = new ListaBebidas();

                    DdlBebida.DataSource = bebidas.listarBebidas();
                    DdlBebida.DataValueField = "id";
                    DdlBebida.DataTextField = "Descripcion";
                    DdlBebida.DataBind();

                    ddlCampo.Text = "Todos";
                    DdlCamposBebidas.Text = "Todos";

                    DdlComida.DataSource = menu.listarSP();
                    DdlComida.DataValueField = "ID";
                    DdlComida.DataTextField = "Descripcion";
                    DdlComida.DataBind();
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
            dgvPedidos.DataSource = negocioPedido.Listar(TxtIDMesa.Text);
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
        protected void btnBuscarBebida_Click(object sender, EventArgs e)
        {
            ListaBebidas bebidas = new ListaBebidas();
            DdlBebida.Items.Clear();
            if (DdlCamposBebidas.Text == "todo")
            {

                DdlBebida.DataSource = bebidas.listarBebidas();
                DdlBebida.DataValueField = "id";
                DdlBebida.DataTextField = "Descripcion";
                DdlBebida.DataBind();
            }
            else
            {
                DdlBebida.DataSource = bebidas.BusquedaAvanzada(DdlCamposBebidas.Text, DdlCriterioBebida.Text, TxtBebida.Text);
                DdlBebida.DataValueField = "id";
                DdlBebida.DataTextField = "Descripcion";
                DdlBebida.DataBind();

            }
        }
        protected void BtnFiltrarComida_Click(object sender, EventArgs e)
        {
            ListaMenu menu = new ListaMenu();
            DdlComida.Items.Clear();
            if (ddlCampo.Text == "todo")
            {
                DdlComida.DataSource = menu.listarSP();
                DdlComida.DataValueField = "ID";
                DdlComida.DataTextField = "Descripcion";
                DdlComida.DataBind();
            }
            else
            {
                DdlComida.DataSource = menu.BusquedaAvanzada(ddlCampo.Text, ddlCriterio.Text, txtComida.Text);
                DdlComida.DataValueField = "id";
                DdlComida.DataTextField = "Descripcion";
                DdlComida.DataBind();
            }
        }

        protected void dgvPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = dgvPedidos.SelectedRow;
            NegocioPedido pedido = new NegocioPedido();
             
            ListaMenu menu = new ListaMenu();
            Dominio.Menu menuAux = menu.listar1(DdlComida.SelectedValue);
              
            ListaBebidas bebidas = new ListaBebidas();
            Bebidas bebiAux = bebidas.listaBebida(DdlBebida.SelectedValue);

            string pedidoId = dgvPedidos.DataKeys[row.RowIndex].Value.ToString();
            Pedidos aux = new Pedidos();
            aux.IDPedido = int.Parse(pedidoId);
            aux.Plato=new Dominio.Menu();
            aux.Plato.ID = menuAux.ID;
            aux.Bebida = new Bebidas();
            aux.Bebida.ID = bebiAux.ID;
            aux.Cuenta = menuAux.Precio + bebiAux.Precio;
            pedido.Modificar(aux);
            dgvPedidos.DataBind();

        }

        protected void BtnAgregarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                ListaMenu menu= new ListaMenu();
                Dominio.Menu reg = menu.listar1(DdlComida.SelectedValue);
                ListaBebidas bebidas = new ListaBebidas();
                Bebidas aux = bebidas.listaBebida(DdlBebida.SelectedValue);

                Pedidos pedidos = new Pedidos();
                pedidos.Bebida = new Bebidas();
                pedidos.IDEmpleado = ((Dominio.Login)Session["Usuario"]).IdUser;

                pedidos.Plato = new Dominio.Menu();
                pedidos.Plato.ID = reg.ID;

                pedidos.Bebida= new Bebidas();
                pedidos.Bebida.ID =aux.ID;

                pedidos.IDMesa = int.Parse(TxtIDMesa.Text);
                pedidos.Cuenta = aux.Precio + reg.Precio;
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

        protected void dgvPedidos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = dgvPedidos.Rows[e.RowIndex];
            NegocioPedido pedido = new NegocioPedido();
            string pedidoId = dgvPedidos.DataKeys[e.RowIndex].Value.ToString();
            pedido.Cancelar(pedidoId);
            dgvPedidos.DataBind();
        }

        protected void dgvPedidos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                decimal cuenta = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Cuenta"));
                TotalCuentas += cuenta;
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].ColumnSpan = 6; // Fusionar las celdas para ocupar todo el ancho
                e.Row.Cells[0].Text = "Total:";
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[1].Text = TotalCuentas.ToString("0.00"); // Mostrar el total formateado
            }
        }
    }
}