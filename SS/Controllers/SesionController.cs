using SS.Models.DTO;
using SS.Servicios;
using System.Security.Claims;
using System.Web.Http;

namespace SS.Controllers
{
    /// <summary>
    /// Controlador de Sesion
    /// </summary>
    public class SesionController : ApiController
    {
        SesionServicio sesionServicio = new SesionServicio();

        /// <summary>
        /// Recibe los datos del usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>Devuelve los datos del usuario</returns>
        [Authorize]
        [Route("SS/Login")]
        [HttpGet]
        public IHttpActionResult Index()
        {
            var identity = (ClaimsIdentity)User.Identity;
            return Ok(sesionServicio.getUsuarioLogeado(identity.Name));
        }
    }
}