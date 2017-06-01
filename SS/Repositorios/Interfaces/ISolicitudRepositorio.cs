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
            List<Solicitud> BuscarSolicitudPorDirector(SolicitudFiltro filtro);
            List<Solicitud> BuscarSolicitudPorPosgrado(SolicitudFiltro filtro);
            List<Solicitud> buscarSolicitudesPorCoordinador(SolicitudFiltro filtro);
            List<Solicitud> buscarSolicitudesPorDocente(SolicitudFiltro filtro);
            List<Solicitud> buscarSolicitudesPorAdministrador(SolicitudFiltro filtro);
            List<Solicitud> buscarSolicituHistorial(SolicitudFiltro filtro);
            List<Solicitud> BuscarSolicitudPorCorreo(SolicitudFiltro filtro);
            void EstadoReporte();
    }
}
