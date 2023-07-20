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
    public partial class PantallaModMenu : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ConfirmaEliminacion = false;
            
                //configuración inicial de la pantalla.
                if (!IsPostBack)
                {
                    ddlTipo.Items.Add("Postre");
                    ddlTipo.Items.Add("Entrada");
                    ddlTipo.Items.Add("Principal");
                }
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    ListaMenu negocio = new ListaMenu();
                    Dominio.Menu seleccionado = negocio.listar1(id);
                    txtId.Text = id;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtImagenUrl.Text = seleccionado.UrlImagen;
                    ddlTipo.Text = Convert.ToString(seleccionado.TipoPlato);
                    txtPrecio.Text = Convert.ToString(seleccionado.Precio);
                    txtClase.Text= seleccionado.Clase;
                    txtImagenUrl_TextChanged(sender, e);
                }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion=true;
        }

        protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmaEliminacion.Checked)
                {
                    ListaMenu negocio = new ListaMenu();
                    negocio.eliminar(txtId.Text);
                    Response.Redirect("/PantallaMenu.aspx");
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            ListaMenu negocio = new ListaMenu();
            Dominio.Menu seleccionado = new Dominio.Menu();
            if (txtDescripcion.Text != null || txtClase.Text != null || txtPrecio.Text != null)
            {
                seleccionado.Descripcion = txtDescripcion.Text;
                seleccionado.UrlImagen = txtImagenUrl.Text;
                seleccionado.TipoPlato = ddlTipo.Text;
                seleccionado.Precio = int.Parse(txtPrecio.Text);
                seleccionado.Clase=txtClase.Text;
                if (txtId.Text != null)
                {
                    seleccionado.ID=int.Parse(txtId.Text);
                    negocio.Modificar(seleccionado);
                }
                else
                {
                    negocio.Agregar(seleccionado);
                }
            }
            else
            {

            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgMenu.ImageUrl = txtImagenUrl.Text;
        }
    }
}