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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NegocioMesas Mesas = new NegocioMesas();
                DdlMesa.DataSource = Mesas.listarMesasAdmin();
                DdlMesa.DataValueField = "IDmesa";
                DdlMesa.DataTextField = "Descripcion";
                DdlMesa.DataBind();
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
                reserva.IDMesa = int.Parse(DdlMesa.DataValueField);
                reserva.CantidadClientes = int.Parse(TxtCantidad.Text);
                negocioReserva.Agregar(reserva);
            }
            else
            {
                if (txthora != null)
                {
                    reserva.HoraReserva = DateTime.Parse(txthora.Text);
                }
                if (TxtCantidad.Text != null)
                {
                    reserva.CantidadClientes = int.Parse(TxtCantidad.Text);
                }
                if (DdlMesa != null)
                {
                    reserva.IDMesa = int.Parse(DdlMesa.DataValueField);
                }
                negocioReserva.Modificar(reserva);
            }
        }
    }
}