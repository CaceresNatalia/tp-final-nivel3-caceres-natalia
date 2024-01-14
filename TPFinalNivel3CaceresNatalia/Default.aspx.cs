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
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> listaArticulos { get; set; }
        public List<Marca> listaMarcas { get; set; }
        public List<Categoria> listaCategorias { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                listaArticulos = negocio.listar();

                MarcaNegocio negocioMarca = new MarcaNegocio();
                listaMarcas = negocioMarca.listar();

                CategoriaNegocio negocioCategoria = new CategoriaNegocio();
                listaCategorias = negocioCategoria.listar();
                

                ddlMarca.DataSource = listaMarcas;
                ddlMarca.DataValueField = "Id";
                ddlMarca.DataTextField = "Descripcion";
                ddlMarca.DataBind();
                

                ddlCategoria.DataSource = listaCategorias;
                ddlCategoria.DataValueField = "Id";
                ddlCategoria.DataTextField = "Descripcion";
                ddlCategoria.DataBind();


            }


        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                try
                {
                    List<Articulo> lista = (List<Articulo>)Session["listaArticulos"];
                    List<Articulo> listaFiltrada = lista.FindAll(x => x.Descripcion.ToUpper().Contains(txtBuscar.Text.ToUpper()));
                    Session.Add("listaFiltrada", listaFiltrada);

                }
                catch (Exception ex)
                {

                    Session.Add("error", ex);
                    Response.Redirect("Error.aspx");
                }
            }
        }

       
    }
}