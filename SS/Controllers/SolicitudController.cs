using SS.Models.DTO;
using SS.Servicios;
using System.Web.Http;

namespace SS.Controllers
{
    public class SolicitudController : ApiController
    {
        SolicitudServicio servicioSolicitud = new SolicitudServicio();
        /// <summary>
        /// Crea una Solicitud
        /// </summary>
        /// <param name="solicitudDTO"></param>
        /// <returns>Agrega una nueva solicitud</returns>
        [Authorize]
        [Route("SS/Solicitud")]
        [HttpPost]
        public IHttpActionResult CrearSolicitud([FromBody] SolicitudDTO solicitudDTO)
        {
            return Ok(servicioSolicitud.Agregar(solicitudDTO));
        }

        /// <summary>
        /// Lista las Solicitudes
        /// </summary>
        /// <returns>Muestra la lista de solicitudes</returns>
        [Authorize(Roles = "Administrador")]
        [Route("SS/Historial")]
        [HttpGet]
        public IHttpActionResult ListarSolicitud()
        {
            return Ok(servicioSolicitud.BuscarTodos());
        }

        /// <summary>
        /// Lista las Solicitudes del docente en especifico
        /// </summary>
        /// <returns>Muestra la lista de solicitudes</returns>
        [Authorize]
        [Route("SS/Docente")]
        [HttpPost]
        public IHttpActionResult ListarSolicitudPorCorreo([FromBody] UsuarioDTO usuarioDTO)
        {
            return Ok(servicioSolicitud.BuscarSolicitudesPorCorreo(usuarioDTO));
        }

        /// <summary>
        /// Lista las Solicitudes del docente en especifico
        /// </summary>
        /// <returns>Muestra la lista de solicitudes</returns>
        [Authorize]
        [Route("SS/Solicitud/{id:int}")]
        [HttpGet]
        public IHttpActionResult ListarSolicitudPorId([FromBody] int idUsuarioDTO)
        {
            return Ok(servicioSolicitud.BuscarSolicitudPorId(idUsuarioDTO));
        }


        [Authorize]
        [Route("SS/Solicitud/Rol")]
        [HttpPost]
        public IHttpActionResult BuscarSolicitudesPorRol([FromBody]UsuarioDTO usuario)
        {
           return Ok(servicioSolicitud.BuscarSolicitudesPorRols(usuario)); 
        }

    }
}