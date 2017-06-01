using SS.Models.Entidades.FIAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Repositorios.Interfaces
{
    interface IUsuarioFIADRepositorio
    {

        Usuario BuscarUsuarioFIAD(String correo);
    }
}
