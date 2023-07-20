using Dominio;
using NegocioResto;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace RestoAPP
{
    public partial class PerfilSession : System.Web.UI.Page
    {
        public bool Cambiar { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
           if (Session["Usuario"] != null) { 
                if (!IsPostBack)
                {
                    Cambiar=false;
                    Dominio.Login login =(Dominio.Login)Session["Usuario"];
                    NegocioEmpleados empleado = new NegocioEmpleados();
                    repEmpleados.DataSource = empleado.listarEmpleado(login.IdUser);
                    repEmpleados.DataBind();
                }
            }
            else
            {
                Response.Redirect("AccesoEmpleados.aspx");
            }
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Session.Contents.Remove("Usuario");
            Response.Redirect("AccesoEmpleados.aspx");
        }

        protected void BtnCambiar_Click(object sender, EventArgs e)
        {
            Cambiar = true;
            Dominio.Login login = (Dominio.Login)Session["Usuario"];
            txtNombreUsuario.Text = login.Usuario;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Dominio.Login login = (Dominio.Login)Session["Usuario"];
            LecturaUsuario Modificar = new LecturaUsuario(); 
            login.Usuario = txtNombreUsuario.Text;
            if (txtContraseña.Text != "" || txtContraseña.Text != login.Contraseña)
            {
                if (TxtPassNew.Text != "")
                    login.Contraseña = TxtPassNew.Text;

                else
                {
                    string script = "alert('La contraseña no puede estar vacía.');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "MensajeEmergente", script, true);
                }
            }
            else
            {
                string script = "alert('La contraseña no puede estar vacía.');";
                ScriptManager.RegisterStartupScript(this, GetType(), "MensajeEmergente", script, true);
            }
            Modificar.Modificar(login);
            Session.Contents.Remove("Usuario");
            Session.Add("Usuario", login);
            Cambiar = false;
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Cambiar = false;
        }
    }
}