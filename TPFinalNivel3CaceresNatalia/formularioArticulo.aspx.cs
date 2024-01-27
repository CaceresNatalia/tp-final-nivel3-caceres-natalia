using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Negocio;
using Helper;

namespace TPFinalNivel3CaceresNatalia
{
    public partial class formulaarioArticulo : System.Web.UI.Page
    {
        public bool confirmaEliminacion { get; set; }
        public bool modificar { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;

            try
            {
                if (!IsPostBack)
                {
                    MarcaNegocio negocioMar = new MarcaNegocio();
                    List<Marca> lista = negocioMar.listar();

                    CategoriaNegocio negocioCat = new CategoriaNegocio();
                    List<Categoria> listaCat = negocioCat.listar();

                    ddlMarca.DataSource = lista;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();

                    ddlCategoria.DataSource = listaCat;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();
                }

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    modificar = true;
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    Articulo seleccionado = (negocio.listar(id))[0];

                    Session.Add("artSeleccionado", seleccionado);

                    txtId.Text = id;
                    txtCodigo.Text = seleccionado.Codigo;
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtPrecio.Text = seleccionado.Precio.ToString();
                    if(IsPostBack && Validaciones.IsImageValid(seleccionado.UrlImagen) && Validaciones.isImageAccesible(seleccionado.UrlImagen))
                        txtImagenUrl.Text = seleccionado.UrlImagen;
                    else
                        txtImagenUrl.Text = "https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png";
                    txtImagenUrl_TextChanged(sender, e);

                }

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {


            try
            {
                Articulo nuevo = new Articulo();
                ArticuloNegocio negocio = new ArticuloNegocio();

                nuevo.Codigo = txtCodigo.Text;
                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.Precio = decimal.Parse(txtPrecio.Text);
                if (Validaciones.IsImageValid(txtImagenUrl.Text) && Validaciones.isImageAccesible(txtImagenUrl.Text))
                    nuevo.UrlImagen = txtImagenUrl.Text;
                else
                    nuevo.UrlImagen = "https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png";


                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    negocio.modificar(nuevo);
                    
                }
                else
                {
                    negocio.agregar(nuevo);
                    
                }

                Response.Redirect("listaArticulos.aspx", false);

            }
            catch (Exception ex)
            {
                txtImagenUrl.Text = "";
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }


        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            confirmaEliminacion = true;
        }

        protected void btnConfirmaEliminacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkCofirmaEliminacion.Checked)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    negocio.eliminar(int.Parse(txtId.Text));
                    Response.Redirect("listaArticulos.aspx", false);
                }
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}