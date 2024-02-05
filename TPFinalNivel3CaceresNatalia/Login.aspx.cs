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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();

            try
            {
                if (!Validaciones.validaTextoVacio(txtEmail.Text) || !Validaciones.validaTextoVacio(txtPassword.Text))
                {
                    Session.Add("Error", "Debes completar ambos campos");
                    Response.Redirect("Error.aspx", false);
                }
                else { 

                usuario.Email = txtEmail.Text;
                usuario.Password = txtPassword.Text;

                if (negocio.Login(usuario))
                {
                    Session.Add("Usuario", usuario);
                    Response.Redirect("MiPerfil.aspx", false);
                }
                else
                {
                    Session.Add("Error", "Usuario o password incorrectos");
                    Response.Redirect("Error.aspx", false);
                }
                }
            }
            catch (System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }

        }


    }
}