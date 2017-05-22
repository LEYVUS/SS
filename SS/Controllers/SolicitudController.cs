using SS.Models.DTO;
using SS.Models.DTO.Filtro;
using SS.Models.Entidades.SS;
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
        public IHttpActionResult SolicitudPorId( int id)
        {
            return Ok(servicioSolicitud.BuscarSolicitudPorId(id));
        }

        [Authorize]
        [Route("SS/Solicitud/Aceptar/{id:int}")]
        [HttpPost]
        public IHttpActionResult AceptarSolicitud([FromBody]UsuarioDTO usuario,int id)
        {
            return Ok(servicioSolicitud.AceptarSolicitud(usuario,id));
        }

        [Authorize]
        [Route("SS/Solicitud/Rechazar")]
        [HttpPost]
        public IHttpActionResult RechazarSolicitud([FromBody]SolicitudDTO solicitud)
        {
            return Ok(servicioSolicitud.RechazarSolicitud(solicitud));
        }


        [Authorize]
        [Route("SS/Solicitud/Rol/{paginacion:int}")]
        [HttpPost]
        public IHttpActionResult BuscarSolicitudesPorRol([FromBody]SolicitudFiltro filtro, int paginacion )
        {
           return Ok(servicioSolicitud.BuscarSolicitudesPorRols(filtro, paginacion)); 
        }





    }
}