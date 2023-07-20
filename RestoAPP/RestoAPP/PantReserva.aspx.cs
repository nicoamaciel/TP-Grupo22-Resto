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
    public partial class PantReserva : System.Web.UI.Page
    {
        public bool existen { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"] == null)
                {
                    TxtCantidad.Text = "1";
                    NegocioMesas Mesas = new NegocioMesas();
                    DdlMesa.DataSource = Mesas.listarMesasAdmin();
                    DdlMesa.DataValueField = "IDmesa";
                    DdlMesa.DataTextField = "Descripcion";
                    DdlMesa.DataBind();
                }
                else
                {
                    NegocioReserva negocioReserva = new NegocioReserva();
                    if (negocioReserva.Listar() != null)
                    {
                        existen = true;
                        dgvReserva.DataSource = negocioReserva.Listar();
                        dgvReserva.DataBind();
                    }
                    else
                    {
                        existen = false;
                    }
                }
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Reserva reserva = new Reserva();
            NegocioReserva negocioReserva = new NegocioReserva();
            if (TxtCodigo.Text != null)
            {
                reserva.CodigoReserva = int.Parse(TxtCodigo.Text);
            }
            if (negocioReserva.Comprobar(reserva) == false)
            {
                reserva.HoraReserva = DateTime.Parse(txthora.Text);
                reserva.IDMesa = int.Parse(DdlMesa.SelectedValue);
                reserva.CantidadClientes = int.Parse(TxtCantidad.Text);
                reserva.Comentario = txtComentario.Text;
                negocioReserva.Agregar(reserva);
                Response.Redirect("/PantallaMenu.aspx");
            }
            else
            {
                reserva.HoraReserva = DateTime.Parse(txthora.Text);
                reserva.CantidadClientes = int.Parse(TxtCantidad.Text);
                reserva.IDMesa = int.Parse(DdlMesa.SelectedValue);
                negocioReserva.Modificar(reserva);
                Response.Redirect("/PantallaMenu.aspx");
            }
        }
        protected void dgvReserva_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            NegocioReserva reserva = new NegocioReserva();
            string CodigoReserva = dgvReserva.DataKeys[e.RowIndex].Value.ToString();
            reserva.eliminar(CodigoReserva);
            dgvReserva.DataBind();
        }
    }
}