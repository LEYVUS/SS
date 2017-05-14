using SS.Models.Entidades.SS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Repositorios.Interfaces
{  
        interface ISolicitudRepositorio
        {
            List<Solicitud> BuscarSolicitudPorRol(Usuario usuario);
        }
}
