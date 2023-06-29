using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using NegocioResto;
using System.Data;

namespace RestoAPP
{
    public partial class AccesoEmpleados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"] != null)
                {
                    Response.Redirect("MiPerfil.aspx");
                }
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            LecturaUsuario usuario= new LecturaUsuario();
            try
            {
                if (TextUser.Text==null || TextPass.Text==null)
                {
                    Session.Add("error", "Debes completar ambos campos...");
                    Response.Redirect("Error.aspx");
                }
                Dominio.Login login = new Dominio.Login(TextUser.Text, TextPass.Text);
                if (usuario.login(login))
                {
                    Session.Add("Usuario", login);                    
                    Response.Redirect("/MiPerfil.aspx");
                }
                else
                {
                    Session.Add("error", "User o Pass incorrectos");
                    Response.Redirect("Error.aspx");
                }

            }
            catch (System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }

        }
    }
}