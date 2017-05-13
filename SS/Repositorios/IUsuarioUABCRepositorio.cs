
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSUABC.Repositorios
{
    interface IUsuarioUABCRepositorio
    {
        SSUABC.Models.EntidadesUsuarioUABC.Usuario BuscarUsuarioUABC(String correo);
        SSUABC.Models.EntidadesUsuarioFIAD.Usuario BuscarUsuarioFIAD(String correo);

    }
}