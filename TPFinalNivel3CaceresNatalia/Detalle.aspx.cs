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
                string id = Request.QueryString["id"].ToString();

                ArticuloNegocio negocio = new ArticuloNegocio();
                Articulo seleccionado = (negocio.listar("id"))[0];

                Session.Add("artSeleccionado", seleccionado);




            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}