using SS.Componentes;
using SS.Models.DTO;
using SS.Models.Entidades.SS;
using SS.Repositorios.Implementaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SS.Servicios
{
    public class SolicitudServicio
    {
        private SolicitudRepositorioImpl solicitudRepositorio;
        private UsuarioRepositorioImpl usuarioRepositorio;


        public SolicitudServicio()
        {
            solicitudRepositorio = new SolicitudRepositorioImpl(new EntidadesSS());
        }


        public MensajeDTO Agregar(SolicitudDTO solicitudDTO)
        {
            if (this.SolicitudValida(solicitudDTO))
            {
                Solicitud solicitud;

                solicitud = TransferirEntidad.TransferirDatosSolicitudDTO(solicitudDTO);
                solicitudRepositorio.Agregar(solicitud);
                return MensajeComponente.mensaje("Solicitud creada exitosamente", true);
            }
            return MensajeComponente.mensaje("Error al crear la solictud", false);
        }


        public List<SolicitudDTO> BuscarTodos()
        {
            List<SolicitudDTO> solicitudesDTO = new List<SolicitudDTO>();
            List<Solicitud> solicitudes = solicitudRepositorio.BuscarTodos().ToList();
            foreach (Solicitud solicitud in solicitudes)
            {
                solicitudesDTO.Add(TransferirDTO.TransferirSolicitud(solicitud));
            }

            return solicitudesDTO;
        }

        private bool SolicitudValida(SolicitudDTO solicitudDTO)
        {
            if (solicitudDTO != null)
            {
                if (solicitudDTO.Nombre_Solicitante == null)
                {
                    return false;
                }
                if (solicitudDTO.Numero_Empleado == 0)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
    }

}