using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3CaceresNatalia
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = Session["error"].ToString();
        }

        protected void btnError_Click(object sender, EventArgs e)
        {
            if (lblError.Text == "Usuario o password incorrectos" || lblError.Text == "Debes completar ambos campos")
                Response.Redirect("Login.aspx");
        }
    }
}