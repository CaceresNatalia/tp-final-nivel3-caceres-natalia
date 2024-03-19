using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using dominio;
using Helper;

namespace TPFinalNivel3CaceresNatalia
{
    public partial class Detalle : System.Web.UI.Page
    {
        FavoritoNegocio negocio = new FavoritoNegocio();
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
                    if (Validaciones.IsImageValid(seleccionado.UrlImagen) && Validaciones.isImageAccesible(seleccionado.UrlImagen))
                        imgArticulo.ImageUrl = seleccionado.UrlImagen;
                    else
                        imgArticulo.ImageUrl = "https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png";


                    txtPrecio.Text = (seleccionado.Precio).ToString();
                    txtPrecio.ReadOnly = true;

                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnFavoritos_Click(object sender, EventArgs e)
        {
            //Favorito favorito = new Favorito();

            int artId = int.Parse(Request.QueryString["id"]);
            Usuario user = (Usuario)Session["usuario"];
            int userId = user.Id;
            
            
            negocio.agregarFavorito(artId, userId);
            
        }
    }
}