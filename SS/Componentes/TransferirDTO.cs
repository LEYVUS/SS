using SS.Models.DTO;
using SS.Models.Entidades.SS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SS.Componentes
{
    /// <summary>
    /// 
    /// </summary>
    public static class TransferirDTO
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public static UsuarioDTO TransferirUsuario(Usuario usuario)
        {

            RolDTO rolDTO = new RolDTO(usuario.Rol.Id,
                usuario.Rol.Nombre, usuario.Rol.Descripcion);
            UsuarioDTO usuarioDTO = new UsuarioDTO(usuario.Id,
               "",usuario.Correo, rolDTO);
            return usuarioDTO;
        }

        public static Evento TransferirEvento(EventoDTO eventoDTO)
        {
            Evento evento = new Evento();
            evento.Costo = eventoDTO.Costo;
            evento.Lugar = eventoDTO.Lugar;
            evento.Nombre = eventoDTO.Nombre;
            evento.Id = eventoDTO.Id;
            return evento;
        }

        public static Actividad TransferirActividad(ActividadDTO actividadDTO)
        {
            Actividad actividad = new Actividad();
            actividad.Id = actividadDTO.Id;
            actividad.CACEI= actividadDTO.CACEI;
            actividad.ISO = actividadDTO.ISO;
            actividad.Licenciatura = actividadDTO.Licenciatura;
            actividad.Otro = actividadDTO.Otro;
            actividad.Personal = actividadDTO.Personal;
            actividad.Posgrado = actividadDTO.Posgrado;
            return actividad;
        }

        public static Validacion TransferirValidacion(ValidacionDTO validacionDTO)
        {
            Validacion validacion = new Validacion();
            validacion.Id = validacionDTO.Id;
            validacion.Posgrado = validacionDTO.Posgrado;
            validacion.Subdirector = validacionDTO.Subdirector;
            validacion.Director = validacionDTO.Director;
            validacion.Coordinador = validacionDTO.Coordinador;
            validacion.Administrador = validacionDTO.Administrador;
            return validacion;
        }

        public static Recurso TransferirRecurso(RecursoDTO recursoDTO)
        {
            Recurso recurso = new Recurso();
            recurso.Id = recursoDTO.Id;
            recurso.Combustible = recursoDTO.Combustible;
            recurso.Hospedaje = recursoDTO.Hospedaje;
            recurso.Oficio_Comision = recursoDTO.Oficio_Comision;
            recurso.Otro = recursoDTO.Otro;
            recurso.Transporte = recursoDTO.Transporte;
            recurso.Viatico = recursoDTO.Viatico;
            return recurso;
        }

        public static SolicitudDTO TransferirSolicitud(Solicitud solicitud)
        {
            CategoriaDTO categoriaDTO = new CategoriaDTO(solicitud.Categoria.Id, solicitud.Categoria.Nombre);

            CarreraDTO carreraDTO = new CarreraDTO(solicitud.Carrera.Id, solicitud.Carrera.Nombre, 
                                                    TransferirDTO.TransferirUsuario(solicitud.Carrera.Usuario));

            EventoDTO eventoDTO = new EventoDTO(solicitud.Evento.Id, solicitud.Evento.Nombre, solicitud.Evento.Costo, 
                solicitud.Evento.Lugar, solicitud.Evento.Fecha_Hora_Salida, solicitud.Evento.Fecha_Hora_Regreso);

            RecursoDTO recursoDTO = new RecursoDTO(solicitud.Recurso.Id, solicitud.Recurso.Hospedaje, solicitud.Recurso.Transporte,
                                                   solicitud.Recurso.Combustible, solicitud.Recurso.Viatico, solicitud.Recurso.Oficio_Comision,
                                                   solicitud.Recurso.Otro);

            ActividadDTO actividadDTO = new ActividadDTO(solicitud.Actividad.Id, solicitud.Actividad.CACEI,
                                                        solicitud.Actividad.Licenciatura, solicitud.Actividad.Personal,
                                                        solicitud.Actividad.ISO, solicitud.Actividad.Posgrado,
                                                        solicitud.Actividad.Otro);

            ValidacionDTO validacionDTO = new ValidacionDTO(solicitud.Validacion.Id, solicitud.Validacion.Coordinador, solicitud.Validacion.Subdirector,
                                                            solicitud.Validacion.Administrador, solicitud.Validacion.Director, solicitud.Validacion.Posgrado);

            EstadoDTO estadoDTO = new EstadoDTO(solicitud.Estado.Id, solicitud.Estado.Tipo);

            SolicitudDTO solicitudDTO = new SolicitudDTO(solicitud.Correo_Solicitante, solicitud.Id, solicitud.Folio, solicitud.Nombre_Solicitante, solicitud.Numero_Empleado,
             categoriaDTO, carreraDTO, eventoDTO, recursoDTO, actividadDTO, validacionDTO, estadoDTO, solicitud.Fecha_Creacion, solicitud.Fecha_Modificacion,solicitud.Comentario_Rechazado);


            return solicitudDTO;
        }

        public static RolDTO TransferirRol(Rol rol)
        {
            return new RolDTO(rol.Id,rol.Nombre,rol.Descripcion);
        }


        public static CarreraDTO TransferirCarrera(Carrera carrera)
        {

            return new CarreraDTO(carrera.Id, carrera.Nombre, TransferirDTO.TransferirUsuario(carrera.Usuario));
        }

        public static CategoriaDTO TransferirCategoria(Categoria categoria)
        {
            return new CategoriaDTO(categoria.Id, categoria.Nombre);
        }

        public static EstadoDTO TransferirEstado(Estado estado)
        {
            EstadoDTO estadoDTO = new EstadoDTO(estado.Id, estado.Tipo);

            return estadoDTO;
        }
    }
}