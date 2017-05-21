using SS.Models.DTO.Filtro;
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
            List<Solicitud> BuscarSolicitudPorSubDirector(SolicitudFiltro filtro);
            List<Solicitud> BuscarSolicitudPorDirector(String correo);
            List<Solicitud> BuscarSolicitudPorPosgrado(String correo);
            List<Solicitud> buscarSolicitudesPorCoordinador(String correo);
            List<Solicitud> buscarSolicitudesPorDocente(String correo);
            List<Solicitud> buscarSolicitudesPorAdministrador(SolicitudFiltro filtro);
    }
}
