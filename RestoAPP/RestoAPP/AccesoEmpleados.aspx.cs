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

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Dominio.Login login;
            LecturaUsuario usuario= new LecturaUsuario();
            try
            {
                login = new Dominio.Login(TextUser.Text, TextPass.Text);
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
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
            }

        }
    }
}