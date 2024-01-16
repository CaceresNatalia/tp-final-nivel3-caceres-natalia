using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TPFinalNivel3CaceresNatalia
{
    public partial class listaArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    Session.Add("listaArticulos", negocio.listar());
                    dgvArticulos.DataSource = Session["listaArticulos"];
                    dgvArticulos.DataBind();

                }
                catch (Exception ex)
                {

                    Session.Add("Error", ex.ToString());
                    Response.Redirect("Error.aspx");
                }
            }

        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("formularioArticulo.aspx?id=" + id);
        }
    }
}