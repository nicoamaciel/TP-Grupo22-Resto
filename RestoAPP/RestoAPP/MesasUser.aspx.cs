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
        public bool Reserv { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
                if (!IsPostBack)
                {
                if (Session["Usuario"]!=null) { 
                    Dominio.Login login = (Dominio.Login)Session["Usuario"];
                    if(login.NivelAcceso ==1) {
                        NegocioEmpleados aux = new NegocioEmpleados();
                        DdlMesero.DataSource =aux.listarMeseros("3");
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
                    NegocioReserva reserva = new NegocioReserva();
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
            NegocioReserva reserva = new NegocioReserva();
            if (reserva.buscar(int.Parse(((Button)sender).CommandArgument))==false){
                Response.Redirect("PantallaPedidos.aspx?ID=" + ((Button)sender).CommandArgument);
            }
            else
            {
                string mensaje = "Esta Mesa tiene una reserva Pendiente cerca de este horario";
                ScriptManager.RegisterStartupScript(this, GetType(), "MensajeEmergente", $"alert('{mensaje}');", true);
            }
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
                NegocioPedido pedido = new NegocioPedido();
                pedido.Pagar(((Button)sender).CommandArgument);
                Session.Remove(((Button)sender).CommandArgument);
            
        }

        protected void BtnCancelarPedido_Click(object sender, EventArgs e)
        {
            NegocioPedido pedido = new NegocioPedido();
                pedido.CancelarTodo(((Button)sender).CommandArgument);
                Session.Remove(((Button)sender).CommandArgument);
            
        }

        protected void BtnReserva_Click(object sender, EventArgs e)
        {
            Reserva reserva = new Reserva();
            NegocioReserva negocioReserva = new NegocioReserva();
            reserva.CodigoReserva=int.Parse(TxtReserva.Text);
            if (negocioReserva.buscar(reserva)!=false)
            {
                Response.Redirect("PantallaPedidos.aspx?ID=" + reserva.IDMesa);

            }
            else
            {
                string mensaje = "El código de reserva no existe. Caso contrario por favor, revise su horario.";
                ScriptManager.RegisterStartupScript(this, GetType(), "MensajeEmergente", $"alert('{mensaje}');", true);
            }
        }

        protected void btnCambiarMesas_Click(object sender, EventArgs e)
        {
            Response.Redirect("Mod-AgregarMesas.aspx");

        }

        protected void DdlTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            NegocioEmpleados aux = new NegocioEmpleados();
            DdlMesero.Items.Clear();
            if (DdlTurno.Text == "Ambos Turnos")
            {
                DdlMesero.DataSource = aux.listarMeseros("3");
                DdlMesero.DataValueField = "IdEmpleado";
                DdlMesero.DataTextField = "Nombre";
                DdlMesero.DataBind();
            }
            else
            {
                if (DdlTurno.Text == "Mañana / Tarde")
                {
                    DdlMesero.DataSource = aux.listarMeseros("1");
                    DdlMesero.DataValueField = "IdEmpleado";
                    DdlMesero.DataTextField = "Nombre";
                    DdlMesero.DataBind();
                }
                else
                {
                    DdlMesero.DataSource = aux.listarMeseros("2");
                    DdlMesero.DataValueField = "IdEmpleado";
                    DdlMesero.DataTextField = "Nombre";
                    DdlMesero.DataBind();
                }
            }
        }
    }
}