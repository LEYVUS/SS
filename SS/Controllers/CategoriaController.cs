using SS.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SS.Controllers
{
    public class CategoriaController : ApiController
    {
        CategoriaServicio categoriaServicio = new CategoriaServicio();

        [Authorize]
        [Route("SS/Categoria")]
        [HttpGet]
        public IHttpActionResult BuscarTodos()
        {
            return Ok(categoriaServicio.BuscarTodos());
        }
    }
}
