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
        [Authorize]
        [Route("SS/Solicitud")]
        [HttpGet]
        public IHttpActionResult ListarSolicitud()
        {
            return Ok(servicioSolicitud.BuscarTodos());
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