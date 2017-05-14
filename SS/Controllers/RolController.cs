using SS.Servicios;
using System.Web.Http;

namespace SS.Controllers
{
    /// <summary>
    /// Controlador de Rol
    /// </summary>
    public class RolController : ApiController
    {
        RolServicio rolServicio = new RolServicio();

        /// <summary>
        /// Busca un Rol por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuele el Rol </returns>
        [Authorize]
        [Route("SS/Rol/{id:int}")]
        [HttpGet]
        public IHttpActionResult BuscarRolPorId(int id)
        {
            return Ok(rolServicio.BuscarPorId(id));
        }
    }
}
