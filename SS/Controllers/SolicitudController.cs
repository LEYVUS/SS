using SS.Models.DTO;
using SS.Models.DTO.Filtro;
using SS.Models.Entidades.SS;
using SS.Servicios;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
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
        /// 
        /// </summary>
        /// <param name="solicitudDTO"></param>
        /// <returns></returns>
        [Authorize]
        [Route("SS/Solicitud")]
        [HttpPut]
        public IHttpActionResult EditarSolicitud([FromBody] SolicitudDTO solicitudDTO)
        {
            return Ok(servicioSolicitud.EditarSolicitud(solicitudDTO));
        }



        /// <summary>
        /// Lista las Solicitudes
        /// </summary>
        /// <returns>Muestra la lista de solicitudes</returns>
        [Authorize(Roles = "Administrador")]
        [Route("SS/Historial/{paginacion:int}")]
        [HttpPost]
        public IHttpActionResult ListarSolicitud([FromBody]SolicitudFiltro filtro, int paginacion)
        {
            return Ok(servicioSolicitud.BuscarSolicitudesHistorial(filtro,paginacion));
        }

        /// <summary>
        /// Lista las Solicitudes del docente en especifico
        /// </summary>
        /// <returns>Muestra la lista de solicitudes</returns>
        [Authorize]
        [Route("SS/Solicitud/Correo/{paginacion:int}")]
        [HttpPost]
        public IHttpActionResult ListarSolicitudPorCorreo([FromBody] SolicitudFiltro filtro,int paginacion)
        {
            return Ok(servicioSolicitud.BuscarSolicitudesPorCorreo(filtro,paginacion));
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

        [Authorize]
        [Route("SS/Solicitud/Aceptar/Totalmente/{id:int}")]
        [HttpGet]
        public IHttpActionResult AceptarTotalmente(int id)
        {
            var identity = (ClaimsIdentity)User.Identity;
            return Ok(servicioSolicitud.AceptarTotalmente(id, identity.Name));
        }

        [Authorize]
        [Route("SS/Solicitud/Rechazar/Totalmente/{id:int}")]
        [HttpGet]
        public IHttpActionResult RechazarTotalmente(int id)
        {
            var identity = (ClaimsIdentity)User.Identity;
            return Ok(servicioSolicitud.RechazarTotalmente(id, identity.Name));
        }




    }
}