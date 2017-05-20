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
            List<Solicitud> BuscarSolicitudPorSubDirector(Usuario usuario);
            List<Solicitud> BuscarSolicitudPorDirector(Usuario usuario);
        List<Solicitud> BuscarSolicitudPorPosgrado(Usuario usuario);
    }
}
