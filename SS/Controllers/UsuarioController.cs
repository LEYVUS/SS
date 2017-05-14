using SS.Models.DTO;
using SS.Servicios;
using System;
using System.Security.Claims;
using System.Web.Http;

namespace SS.Controllers
{
    /// <summary>
    /// Controlador de Usuario
    /// </summary>
    public class UsuarioController : ApiController
    {
        UsuarioServicio servicioUsuario = new UsuarioServicio();

        /// <summary>
        /// En lista Usuarios
        /// </summary>
        /// <returns>Muestra lista de Usuarios</returns>
        [Authorize(Roles = "Administrador")]
        [Route("SS/Usuario")]
        [HttpGet]
        public IHttpActionResult ListarUsuarios()
        {
            return Ok(servicioUsuario.BuscarTodos());
        }

        /// <summary>
        /// Modifica un usuario
        /// </summary>
        /// <param name="usuarioDTO"></param>
        /// <returns>Retorna un mensaje que fue satisfacctoria la modificacion o fue un error</returns>
        [Authorize(Roles = "Administrador")]
        [Route("SS/Usuario")]
        [HttpPut]
        public IHttpActionResult ModificarUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            MensajeDTO mensaje = servicioUsuario.Modificar(usuarioDTO);
            if ((bool)mensaje.Respuesta["Entidad"])
            {
                return Ok(mensaje);
            }
            return InternalServerError(new Exception((string)mensaje.Respuesta["Mensaje"]));
        }

        /// <summary>
        /// Busca un Usuario por Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Muesstra el Usuario</returns>
        [Authorize(Roles = "Administrador")]
        [Route("SS/Usuario/{id:int}")]
        [HttpGet]
        public IHttpActionResult BuscarUsuarioPorId(int Id)
        {
            UsuarioDTO usuarioDTO = servicioUsuario.BuscarPorId(Id);
            if (usuarioDTO != null)
            {
                return Ok(usuarioDTO);
            }
            return NotFound();
        }

        [AllowAnonymous]
        [Route("api/data/forall")]
        [HttpGet]
        public IHttpActionResult Prueba(int Id)
        {
            UsuarioDTO usuarioDTO = servicioUsuario.BuscarPorId(Id);
            if (usuarioDTO != null)
            {
                return Ok(usuarioDTO);
            }
            return NotFound();
        }
    }
}