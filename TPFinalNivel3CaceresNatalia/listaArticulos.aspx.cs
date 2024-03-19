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
    public partial class listaArticulos : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            FiltroAvanzado = chkFiltroAvanzado.Checked;

            if (!IsPostBack)
            {
                try
                {
                    cargarDatosDGV();

                }
                catch (Exception ex)
                {

                    Validaciones.catchEx(ex, HttpContext.Current);
                }
            }

        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("formularioArticulo.aspx?id=" + id);
        }

        protected void txtFiltroRapido_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> lista = (List<Articulo>)Session["listaArticulos"];
            List<Articulo> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltroRapido.Text.ToUpper()));
            dgvArticulos.DataSource = listaFiltrada;
            dgvArticulos.DataBind();
        }


        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {

            ddlCriterio.Items.Clear();
            if (ddlCampo.SelectedItem.ToString() == "Precio")
            {
                ddlCriterio.Items.Add("Menor a");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Igual a");
            }
            else if (ddlCampo.SelectedItem.ToString() == "Seleccionar")
                ddlCriterio.Items.Clear();
            else
            {
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
                ddlCriterio.Items.Add("Contiene");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlCampo.SelectedItem.ToString() == "Seleccionar")
                    lblSeleccionar.Text = "Seleccione un campo para filtrar";
                else
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    dgvArticulos.DataSource = negocio.filtrar(ddlCampo.SelectedItem.ToString(),
                        ddlCriterio.SelectedItem.ToString(), txtFiltro.Text);
                    dgvArticulos.DataBind();
                }



            }
            catch (Exception ex)
            {

                Validaciones.catchEx(ex, HttpContext.Current);
            }

        }

        protected void chkFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = chkFiltroAvanzado.Checked;
            txtFiltroRapido.Enabled = !FiltroAvanzado;
        }

        private void cargarDatosDGV()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Session.Add("listaArticulos", negocio.listar());
            dgvArticulos.DataSource = Session["listaArticulos"];
            dgvArticulos.DataBind();
        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.PageIndex = e.NewPageIndex;
            cargarDatosDGV();
        }

        protected void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            txtFiltroRapido.Text = "";
            txtFiltro.Text = "";
            ddlCampo.SelectedIndex = 0;
            ddlCriterio.Items.Clear();
        }
    }
}