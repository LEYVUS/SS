using System;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SS.Componentes
{
    public class CorreoComponente
    {

        SmtpClient server = new SmtpClient("smtp.gmail.com", 587);

        public CorreoComponente(String correo, String contrasenia)
        {
            server.Credentials = new System.Net.NetworkCredential(correo, contrasenia);
            server.EnableSsl = true;
        }

        public bool MandarCorreo(String mensaje, String asunto, String destino, String correoRemitente, String nombreRemitente)
        {
            try
            {               
                MailMessage mnsj = new MailMessage();
                mnsj.Subject = asunto;
                mnsj.To.Add(new MailAddress(destino));
                mnsj.From = new MailAddress(correoRemitente, nombreRemitente);
                mnsj.Body = mensaje;
                server.Send(mnsj);

                return true;
            }
            catch (Exception ex)
            {
                return false; 
            }           
        }
    }
}