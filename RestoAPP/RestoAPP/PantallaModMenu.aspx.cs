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
                    txtImagenUrl_TextChanged(sender, e);
                }
            btnAceptar.OnClientClick = "return validarPrecio();";

        }


        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            ListaMenu negocio = new ListaMenu();
            Dominio.Menu seleccionado = new Dominio.Menu();
            if (txtDescripcion.Text != null || txtPrecio.Text != null)
            {
                string precio = txtPrecio.Text;
                if (decimal.TryParse(precio, out decimal valorDecimal))
                {
                    seleccionado.Descripcion = txtDescripcion.Text;
                    seleccionado.UrlImagen = txtImagenUrl.Text;
                    seleccionado.TipoPlato = ddlTipo.Text;
                    seleccionado.Precio = valorDecimal;
                    seleccionado.Clase = DdlClase.Text;
                    if (txtId.Text != null)
                    {
                        seleccionado.ID = int.Parse(txtId.Text);
                        negocio.Modificar(seleccionado);
                        Response.Redirect("/PantallaMenu.aspx");
                    }
                    else
                    {
                        negocio.Agregar(seleccionado);
                        Response.Redirect("/PantallaMenu.aspx");
                    }
                }
                else
                {
                    string script = "El valor ingresado para el precio no es válido. Por favor, ingrese un número valido.";
                    ScriptManager.RegisterStartupScript(this, GetType(), "MensajeEmergente", script, true);
                }
            }
            else
            {

                string script = "alert('Por favor rellene todos los campos.');";
                ScriptManager.RegisterStartupScript(this, GetType(), "MensajeEmergente", script, true);
            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgMenu.ImageUrl = txtImagenUrl.Text;
        }
    }
}