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
    public partial class PantModBebidas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            if (id != "" && !IsPostBack)
            {
                ListaBebidas negocio = new ListaBebidas();
                Bebidas seleccionado = negocio.listaBebida(id);
                txtId.Text = id;
                txtDescripcion.Text = seleccionado.Descripcion;
                txtImagenUrl.Text = seleccionado.UrlImagen;
                txtTipoBebida.Text = Convert.ToString(seleccionado.TipoBebida);
                txtPrecio.Text = Convert.ToString(seleccionado.Precio);
                txtImagenUrl_TextChanged(sender, e);

            }
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                ListaBebidas negocio = new ListaBebidas();
                negocio.eliminar(txtId.Text);
                Response.Redirect("/PantallaMenu.aspx");
                
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ListaBebidas negocio = new ListaBebidas();
            Bebidas seleccionado = new Bebidas();
            if (txtDescripcion.Text != null|| txtTipoBebida.Text != null|| txtPrecio.Text != null) { 
            seleccionado.Descripcion=txtDescripcion.Text;
            seleccionado.UrlImagen=txtImagenUrl.Text ;
            seleccionado.TipoBebida=int.Parse(txtTipoBebida.Text);
            seleccionado.Precio=decimal.Parse(txtPrecio.Text);
            if (txtId.Text!=null)
                    {
                        seleccionado.ID = int.Parse(txtId.Text);
                        negocio.Modificar(seleccionado);
                        string script = "alert('Se ah Modificado Correctamente');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "MensajeEmergente", script, true);
                        Response.Redirect("/PantallaMenu.aspx");

                    }
                    else
                    {
                        negocio.Agregar(seleccionado);
                        string script = "alert('Se ah agregado Correctamente');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "MensajeEmergente", script, true);
                        Response.Redirect("/PantallaMenu.aspx");

                    }
                }
            else
            {
                    Session.Add("Error", "debe completar los campos de Descripcion,Tipo de Bebida y Precio");
                    Response.Redirect("Error.aspx");
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            
                imgBebida.ImageUrl = txtImagenUrl.Text;
            
        }
    }
}