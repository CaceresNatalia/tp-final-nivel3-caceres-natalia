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
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> listaArticulos { get; set; }
        public List<Marca> listaMarcas { get; set; }
        public List<Categoria> listaCategorias { get; set; }
        public List<Articulo> listaFiltrada { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                Session.Add("listaArticulos", negocio.listar());

                ddlMarca.SelectedIndex = -1;

                ddlCategoria.SelectedIndex = -1;

                ddlCategoria.Enabled = false;
                ddlMarca.Enabled = false;
            }


        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {

                int idMarca = ddlMarca.SelectedIndex != -1 ? int.Parse(ddlMarca.SelectedItem.Value) : -1;
                int idCat = ddlCategoria.SelectedIndex != -1 ? int.Parse(ddlCategoria.SelectedItem.Value) : -1;
                string descripcion = txtBuscar.Text;

                Session.Add("listaFiltrada", negocio.buscar(idMarca, idCat, descripcion));
                listaFiltrada = (List<Articulo>)Session["listaFiltrada"];

                if (listaFiltrada.Count == 0)
                    lblAdvertencia.Text = "No se encontraron resultados para la búsqueda";
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }

        }



        protected void btnSeleccionarMarca_Click(object sender, EventArgs e)
        {
            try
            {

                MarcaNegocio negocioMarca = new MarcaNegocio();
                listaMarcas = negocioMarca.listar();

                ddlMarca.Enabled = true;

                ddlMarca.DataSource = listaMarcas;
                ddlMarca.DataValueField = "Id";
                ddlMarca.DataTextField = "Descripcion";
                ddlMarca.DataBind();



            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }



        }

        protected void btnSeleccionarCat_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negocioCategoria = new CategoriaNegocio();
            listaCategorias = negocioCategoria.listar();

            ddlCategoria.Enabled = true;

            ddlCategoria.DataSource = listaCategorias;
            ddlCategoria.DataValueField = "Id";
            ddlCategoria.DataTextField = "Descripcion";
            ddlCategoria.DataBind();

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            ddlCategoria.Items.Clear();
            ddlMarca.Items.Clear();
        }

        protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //protected void btnDetalleModal_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
        //        if (!IsPostBack)
        //        {

        //            ArticuloNegocio negocio = new ArticuloNegocio();
        //            Articulo seleccionado = (negocio.listar(id))[0];

        //            Session.Add("artSeleccionado", seleccionado);

        //            lblCodigoModal.Text = seleccionado.Codigo;
        //            lblCodigoModal.Enabled = false;
        //            lblMarcaModal.Text = (seleccionado.Marca).ToString();
        //            lblMarcaModal.Enabled = false;
        //            lblCategoriaModal.Text = (seleccionado.Categoria).ToString();
        //            lblCategoriaModal.Enabled = false;
        //            lblDescripcionModal.Text = seleccionado.Descripcion;
        //            lblDescripcionModal.Enabled = false;
        //            lblNombreModal.Text = seleccionado.Nombre;
        //            //lblNombre. = true;
        //            //if (Validaciones.IsImageValid(seleccionado.UrlImagen) && Validaciones.isImageAccesible(seleccionado.UrlImagen))
        //            //    imgArticulo.ImageUrl = seleccionado.UrlImagen;
        //            //else
        //            //    imgArticulo.ImageUrl = "https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png";


        //            lblPrecioModal.Text = (seleccionado.Precio).ToString();

        //            // Muestra el modal
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#productoModal').modal();", true);

        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        Session.Add("error", ex);
        //        Response.Redirect("Error.aspx");
        //    }
        //}
    }
}