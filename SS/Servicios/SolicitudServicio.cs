using SS.Componentes;
using SS.Componentes.Constantes;
using SS.Models.DTO;
using SS.Models.DTO.Filtro;
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
        private UsuarioUABCRepositorioImpl usuarioUABCRepositorio;

        public SolicitudServicio()
        {
            solicitudRepositorio = new SolicitudRepositorioImpl(new EntidadesSS());
            usuarioUABCRepositorio = new UsuarioUABCRepositorioImpl();
        }

 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SolicitudDTO BuscarSolicitudPorId(int id)
        {
            SolicitudDTO solicitudDTO = new SolicitudDTO();
            Solicitud solicitud = solicitudRepositorio.BuscarPorId(id);
           solicitudDTO =  TransferirDTO.TransferirSolicitud(solicitud);
            return solicitudDTO;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public MensajeDTO BuscarSolicitudesPorRols(SolicitudFiltro filtro,int paginacion)
        {
            List<SolicitudDTO> solicitudesDTO = new List<SolicitudDTO>();
            List<Solicitud> solicitudes;
            MensajeDTO mensaje;
            if ( filtro.usuario.Rol != null)
            {

                if (filtro.Carrera == null)
                {
                    filtro.carrera = true;
                    filtro.Carrera = new CarreraDTO();
                }

                switch (filtro.usuario.Rol.Descripcion)
                {
                    case "Coordinador":
                        solicitudes = solicitudRepositorio.buscarSolicitudesPorCoordinador(filtro.usuario.Correo);
                        break;

                    case "Posgrado":
                        solicitudes = solicitudRepositorio.BuscarSolicitudPorPosgrado(filtro.usuario.Correo);
                        break;

                    case "Administrador":
                        solicitudes = solicitudRepositorio.buscarSolicitudesPorAdministrador(filtro);
                        break;

                    case "Subdirector":
                        solicitudes = solicitudRepositorio.BuscarSolicitudPorSubDirector(filtro);
                        break;

                    case "Director":
                        solicitudes = solicitudRepositorio.BuscarSolicitudPorDirector(filtro.usuario.Correo);
                        break;
                    default:
                        solicitudes = new List<Solicitud>();
                        break;

                }

            }
            else
            {
                solicitudes = solicitudRepositorio.buscarSolicitudesPorDocente(filtro.usuario.Correo);
            }

            foreach (Solicitud solicitud in solicitudes)
            {
                solicitudesDTO.Add(TransferirDTO.TransferirSolicitud(solicitud));
            }
           
            mensaje=MensajeComponente.mensaje("Datos", solicitudesDTO.Skip(paginacion - 10).Take(paginacion));
            mensaje.largo = solicitudesDTO.Count();
            return mensaje;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="solicitudDTO"></param>
        /// <returns></returns>
        public MensajeDTO Agregar(SolicitudDTO solicitudDTO)
        {
            if (this.SolicitudValida(solicitudDTO))
            {
                Solicitud solicitud;
                solicitud = TransferirEntidad.TransferirDatosSolicitudDTO(solicitudDTO);

                //Busca credecniales del usuario logeado
                Models.Entidades.UABC.Usuario usuario = usuarioUABCRepositorio.BuscarUsuarioUABC(solicitud.Correo_Solicitante);

                //Busca al proximo usuario que su rol es coordinador
                Usuario usarioSS = usuarioRepositorio.BuscarPorRol((int)RolEnum.Subdirector);

                //Envia el correo al sigueinte usuario
                CorreoComponente correo = new CorreoComponente(usuario.Email, usuario.Contraseña);
                solicitudRepositorio.Agregar(solicitud);
                correo.MandarCorreo("Sistema Solicitud de Salida/n" + "Tiene una solicitud pendiente por revisar", "Solicitud Pendiente", "daniel.ballesteros@uabc.edu.mx");
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
                if(solicitudDTO.Actividad == null)
                {
                    return false;
                }
                if(solicitudDTO.Validacion == null)
                {
                    return false;
                }
                if(solicitudDTO.Recurso_Solicitado == null)
                {
                    return false;
                }
                if(solicitudDTO.Carrera == null)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
    }

}