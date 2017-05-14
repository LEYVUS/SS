using Microsoft.Owin.Security.OAuth;
using SS.Models.DTO;
using SS.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace SS
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {

        private SesionServicio sesionServicio = new SesionServicio();
          

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            MensajeDTO mensaje= sesionServicio.InicioSesion(new UsuarioDTO(context.UserName, context.Password));
           

            if (mensaje.Respuesta["Entidad"] != null)
            {
                UsuarioDTO usuario = (UsuarioDTO)mensaje.Respuesta["Entidad"];

                if(usuario.Rol != null)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, usuario.Rol.Nombre));
                    identity.AddClaim(new Claim(context.UserName, context.Password));
                    identity.AddClaim(new Claim(ClaimTypes.Name, usuario.Nombre));
                    context.Validated(identity);
                }

                else
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, "Docente"));
                    identity.AddClaim(new Claim(context.UserName, context.Password));
                    identity.AddClaim(new Claim(ClaimTypes.Name, usuario.Nombre));
                    context.Validated(identity);
                }

                
            }
            
            else
                context.SetError("invalid_grant", (string)mensaje.Respuesta["Mensaje"]);
            return;
        }
    }
}