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

        public List<SolicitudDTO> BuscarSolicitudesPorCorreo(UsuarioDTO usuario)
        {
            List<SolicitudDTO> solicitudesDTO = new List<SolicitudDTO>();
            List<Solicitud> solicitudes = solicitudRepositorio.BuscarSolicitudPorCorreo(TransferirEntidad.TransferirDatosUsuarioDTO(usuario)).ToList();
            foreach (Solicitud solicitud in solicitudes)
            {
                solicitudesDTO.Add(TransferirDTO.TransferirSolicitud(solicitud));
            }

            return solicitudesDTO;
        }

        public SolicitudDTO BuscarSolicitudPorId(int id)
        {
            SolicitudDTO solicitudDTO = new SolicitudDTO();
            Solicitud solicitud = solicitudRepositorio.BuscarPorId(id);
           solicitudDTO =  TransferirDTO.TransferirSolicitud(solicitud);
            return solicitudDTO;
        }

        public List<SolicitudDTO> BuscarSolicitudesPorRols(UsuarioDTO usuario)
        {
            List<SolicitudDTO> solicitudesDTO = new List<SolicitudDTO>();
            List<Solicitud> solicitudes;

            if (usuario.Rol != null)
            {

                switch (usuario.Rol.Descripcion)
                {
                    case "Coordinador":
                        solicitudes = solicitudRepositorio.buscarSolicitudesPorCoordinador(usuario.Correo);
                        break;

                    case "Posgrado":
                        solicitudes = solicitudRepositorio.BuscarSolicitudPorPosgrado(usuario.Correo);
                        break;

                    case "Administrador":
                        solicitudes = solicitudRepositorio.buscarSolicitudesPorAdministrador(usuario.Correo);
                        break;

                    case "Subdirector":
                        solicitudes = solicitudRepositorio.BuscarSolicitudPorSubDirector(usuario.Correo);
                        break;

                    case "Director":
                        solicitudes = solicitudRepositorio.BuscarSolicitudPorDirector(usuario.Correo);
                        break;
                    default:
                        solicitudes = new List<Solicitud>();
                        break;

                }

            }
            else
            {
                solicitudes = solicitudRepositorio.buscarSolicitudesPorDocente(usuario.Correo);
            }

            foreach (Solicitud solicitud in solicitudes)
            {
                solicitudesDTO.Add(TransferirDTO.TransferirSolicitud(solicitud));
            }

            return solicitudesDTO;
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
            return MensajeComponente.mensaje("Error al crear la solicitud", false);
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
                if (solicitudDTO.Correo_Solicitante == "")
                {
                    return false;
                }
                return true;
            }
            return false;
        }
    }

}