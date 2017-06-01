using SS.Servicios;
using System.Web.Http;

namespace SS.Controllers
{
    public class EstadoController : ApiController
    {
       EstadoServicio estadoServio = new EstadoServicio();
       
        [Authorize]
        [Route("SS/Estados")]
        [HttpGet]
        public IHttpActionResult ListarSolicitud()
        {
            return Ok(estadoServio.BuscarTodos());
        }
       
    }
}
