using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using dominio;

namespace TPFinalNivel3CaceresNatalia
{
    public partial class Detalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (!IsPostBack)
                {
                            
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    Articulo seleccionado = (negocio.listar(id))[0];

                    Session.Add("artSeleccionado", seleccionado);

                    txtCodigo.Text = seleccionado.Codigo;
                    txtCodigo.ReadOnly = true;
                    txtMarca.Text = (seleccionado.Marca).ToString();
                    txtMarca.ReadOnly = true;
                    txtCategoria.Text = (seleccionado.Categoria).ToString();
                    txtCategoria.ReadOnly = true;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtDescripcion.ReadOnly = true;
                    txtNombre.Text = seleccionado.Nombre;
                    txtNombre.ReadOnly = true;
                    imgArticulo.ImageUrl = seleccionado.UrlImagen != null ? seleccionado.UrlImagen : "https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png";
                    
                    txtPrecio.Text = (seleccionado.Precio).ToString();

                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }
    }
}