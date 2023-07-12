using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NegocioResto;
using Dominio;
/*
    1 admin
    2 cocineros
    3 meseros
*/
namespace RestoAPP
{
    public partial class MasterResto : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!(Page is PantallaMenu || Page is AccesoEmpleados || Page is Error || Page is PantReserva))
            {
                if (!LecturaUsuario.SesionActiva(Session["usuario"]))
                {
                    Response.Redirect("AccesoEmpleados.aspx",false);
                }
                else
                {
                    Dominio.Login login = (Dominio.Login)Session["Usuario"];
                    if((Page is PantallaEmpleados || Page is PantallaCargaEmpleados || Page is PantRecaudacion) &&!(login.NivelAcceso ==1) ){
                        Session.Add("error", "No tiene el Cargo Necesario para acceder");
                        Response.Redirect("Error.aspx");
                    }
                    if((Page is PantallaModMenu || Page is PantModBebidas) && !(login.NivelAcceso < 3))
                    {
                        Session.Add("error", "No tiene el Cargo Necesario para acceder");
                        Response.Redirect("Error.aspx");
                    }
                    if ((Page is MesasUser || Page is PantallaPedidos) && !(login.NivelAcceso == 3 || login.NivelAcceso == 1))
                    {
                        Session.Add("error", "No tiene el Cargo Necesario para acceder");
                        Response.Redirect("Error.aspx");
                    }
                }
                
            }
        }
    }
}