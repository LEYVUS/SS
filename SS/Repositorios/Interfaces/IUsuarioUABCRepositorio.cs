
using SS.Models.Entidades.UABC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SS.Repositorios.Interfaces
{
    interface IUsuarioUABCRepositorio
    {
        Usuario BuscarUsuarioUABC(String correo);

    }
}