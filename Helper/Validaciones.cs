using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using dominio;

namespace Helper
{
    public class Validaciones
    {
        public static bool IsImageValid(string imagenUrl) {
            try
            {
                //intenta hacer una solicitud web para ver si la url de la
                //imagen es accesible
                using (var webClient = new WebClient())
                {
                    using (webClient.OpenRead(imagenUrl))
                    {

                        return true;
                    }
                }

            }
            catch (Exception)
            {

                return false;
            }
        }

        public static bool isImageAccesible(string imagenUrl)
        {
            try
            {
                using (var webClient = new WebClient())
                {
                    //descarga los datos de la imagen
                    byte[] imageData = webClient.DownloadData(imagenUrl);
                    //verifica si se pudo descargar datos de la imagen
                    return imageData.Length > 0;
                }

            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
