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
            usuarioRepositorio = new UsuarioRepositorioImpl(new EntidadesSS());
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
           
            Solicitud solicitud = solicitudRepositorio.BuscarPorId(id);
            SolicitudDTO solicitudDTO =  TransferirDTO.TransferirSolicitud(solicitud);

            return solicitudDTO;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public MensajeDTO AceptarSolicitud(UsuarioDTO usuario,int id )
        {
            Solicitud solicitud = solicitudRepositorio.BuscarPorId(id);
            Models.Entidades.UABC.Usuario usuarioUABC = usuarioUABCRepositorio.BuscarUsuarioUABC(solicitud.Correo_Solicitante);
            CorreoComponente correo = new CorreoComponente(usuarioUABC.Email, usuarioUABC.Contraseña);
            Usuario destinatario = null;
            bool solicitudTerminadaRevision = false;

            switch (usuario.Rol.Descripcion)
                {
                    case "Coordinador":
                        solicitud.Validacion.Coordinador = true;
                     destinatario = usuarioRepositorio.BuscarPorRol((int)RolEnum.Director);
                    break;

                    case "Posgrado":
                        solicitud.Validacion.Posgrado = true;
                        solicitudTerminadaRevision = true;
                    break;

                    case "Administradora":
                        solicitud.Validacion.Administrador = true;
                        destinatario = usuarioRepositorio.BuscarPorRol((int)RolEnum.Coordinador);
                        break;
 
                    case "Subdirector":
                        solicitud.Validacion.Subdirector = true;
                        destinatario = usuarioRepositorio.BuscarPorRol((int)RolEnum.Administradora);
                        break;

                    case "Director":
                        solicitud.Validacion.Director = true;
                        if(solicitud.Actividad.Posgrado == true)
                        {
                            destinatario = usuarioRepositorio.BuscarPorRol((int)RolEnum.Posgrado);

                        }else
                        {
                            solicitudTerminadaRevision = true;
                        }
                      break;
            }

            if (solicitudTerminadaRevision)
            {
                correo.MandarCorreo("Sistema Solicitud de Salida" + "Tiene una solicitud pendiente por revisar ", "Solicitud Pendiente", solicitud.Correo_Solicitante);
            }
            
                correo.MandarCorreo("Sistema Solicitud de Salida" + "Tiene una solicitud pendiente por revisar ", "Solicitud Pendiente", destinatario.Correo);
                solicitudRepositorio.Modificar(solicitud);
                return MensajeComponente.mensaje("Se ha aprobado correctamente", true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public MensajeDTO RechazarSolicitud( SolicitudDTO solicitudDTO)
        {
            Solicitud solicitud = solicitudRepositorio.BuscarPorId(solicitudDTO.Id);
            solicitud.Comentario_Rechazado = solicitudDTO.Comentario_Rechazado;
            solicitud.Id_Estado = (int)EstadoEnum.Rechazado;
       //     Models.Entidades.UABC.Usuario usuarioUABC = usuarioUABCRepositorio.BuscarUsuarioUABC(solicitud.Correo_Solicitante);
        //    CorreoComponente correo = new CorreoComponente(usuarioUABC.Email, usuarioUABC.Contraseña);
       //     correo.MandarCorreo("Sistema Solicitud de Salida" + "Se ha rechazado una solicitud", "Solicitud Pendiente", solicitud.Correo_Solicitante);
            solicitudRepositorio.Modificar(solicitud);
            return MensajeComponente.mensaje("Se ha aprobado correctamente", true);
            
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
                        solicitudes = solicitudRepositorio.buscarSolicitudesPorCoordinador(filtro);
                        break;

                    case "Posgrado":
                        solicitudes = solicitudRepositorio.BuscarSolicitudPorPosgrado(filtro);
                        break;

                    case "Administradora":
                        solicitudes = solicitudRepositorio.buscarSolicitudesPorAdministrador(filtro);
                        break;

                    case "Subdirector":
                        solicitudes = solicitudRepositorio.BuscarSolicitudPorSubDirector(filtro);
                        break;

                    case "Director":
                        solicitudes = solicitudRepositorio.BuscarSolicitudPorDirector(filtro);
                        break;
                    default:
                        solicitudes = new List<Solicitud>();
                        break;

                }

            }
            else
            {
                solicitudes = solicitudRepositorio.buscarSolicitudesPorDocente(filtro);
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

                Usuario subdirector = usuarioRepositorio.BuscarPorRol((int)RolEnum.Subdirector);
                //Busca al proximo usuario que su rol es coordinador
                Usuario usarioSS = usuarioRepositorio.BuscarPorRol((int)RolEnum.Subdirector);

                //Envia el correo al sigueinte usuario
                CorreoComponente correo = new CorreoComponente(usuario.Email, usuario.Contraseña);
                if(correo.MandarCorreo("Sistema Solicitud de Salida" + "Tiene una solicitud pendiente por revisar ", "Solicitud Pendiente", subdirector.Correo))
                {
                    solicitudRepositorio.Agregar(solicitud);
                    return MensajeComponente.mensaje("Error al crear la solicitud", false);       
                }

                return MensajeComponente.mensaje("Solicitud creada exitosamente", true);
            }
            return MensajeComponente.mensaje("Error al crear la solicitud", false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="solicitudDTO"></param>
        /// <returns></returns>
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