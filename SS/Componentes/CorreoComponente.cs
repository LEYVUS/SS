using System;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;

namespace SS.Componentes
{
    public class CorreoComponente
    {

        string correoRemitente;
        string contraseña;

        public CorreoComponente(String correo, String contrasenia)
        {
            this.contraseña = contrasenia;
            this.correoRemitente = correo;
        }

        public bool MandarCorreo(String mensaje, String asunto, String destino)
        {
            try
            {
                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential(correoRemitente,contraseña),
                    EnableSsl = true
                };
                client.Send(correoRemitente, destino, asunto, mensaje);

                return true;
            }
            catch (Exception ex)
            {
                return false; 
            }           
        }
    }
}