using SS.Servicios;
using System.Web.Http;

namespace SS.Controllers
{
    /// <summary>
    /// Controller de Carrera
    /// </summary>
    public class CarreraController : ApiController
    {
        CarreraServicio carreraServicio = new CarreraServicio();

        /// <summary>
        /// Busca la carrera por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve la carrera</returns>
        [Authorize]
        [Route("SS/Carrera/{id:int}")]
        [HttpGet]
        public IHttpActionResult BuscarCarreraPorId(int id)
        {
            return Ok(carreraServicio.BuscarPorUsuario(id));
        }

        [Authorize]
        [Route("SS/Carrera")]
        [HttpGet]
        public IHttpActionResult BuscarTodos()
        {
            return Ok(carreraServicio.BuscarTodos());
        }
    }
}
