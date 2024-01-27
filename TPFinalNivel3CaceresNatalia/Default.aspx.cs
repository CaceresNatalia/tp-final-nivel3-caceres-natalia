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


        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            ddlCategoria.SelectedIndex = -1;
            ddlMarca.SelectedIndex = -1;
            txtBuscar.Text = "";            
        }
    }
}