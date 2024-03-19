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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario();
                UsuarioNegocio negocio = new UsuarioNegocio();
                EmailService emailService = new EmailService();

                if (!Validaciones.validaTextoVacio(txtEmail.Text) || !Validaciones.validaTextoVacio(txtPassword.Text))
                {
                    Session.Add("Error", "Debes completar ambos campos");
                    Response.Redirect("Error.aspx", false);
                }
                else
                {

                    usuario.Email = txtEmail.Text;
                    usuario.Password = txtPassword.Text;
                    usuario.Id = negocio.agregarNuevo(usuario);
                    Session.Add("usuario", usuario);

                    emailService.armarCorreo(usuario.Email, "Bienvenido usuario", "Hola, te damos la bienvenida a la app...");
                    emailService.enviarEmail();
                    Response.Redirect("Default.aspx", false);
                }
            }
            catch (Exception ex)
            {

                Validaciones.catchEx(ex, HttpContext.Current);
            }
        }
    }
}