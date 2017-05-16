using SS.Models.DTO;
using SS.Models.Entidades.SS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SS.Componentes
{
    public static class TransferirEntidad
    {
        public static Usuario TransferirDatosUsuarioDTO(UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO.Rol != null)
            {
                Usuario usuario = new Usuario();
                usuario.Id = usuarioDTO.Id;
                usuario.Correo = usuarioDTO.Correo;
                usuario.Id_Rol = usuarioDTO.Rol.Id;
                usuario.Rol = new Rol();
                usuario.Rol.Id = usuarioDTO.Rol.Id;
                usuario.Rol.Nombre = usuarioDTO.Rol.Nombre;
                usuario.Rol.Descripcion = usuarioDTO.Rol.Descripcion;
                return usuario;
            }
            else
            {
                Usuario usuario = new Usuario();
                usuario.Id = usuarioDTO.Id;
                usuario.Correo = usuarioDTO.Correo;
                usuario.Rol = new Rol();
                return usuario;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="solicitudDTO"></param>
        /// <returns></returns>
        public static Solicitud TransferirDatosSolicitudDTO(SolicitudDTO solicitudDTO)
        {
            Solicitud solicitud = new Solicitud(new Actividad(), new Recurso(), new Validacion(), new Evento());
            //solicitud.Id = solicitudDTO.Id;
            solicitud.Nombre_Solicitante = solicitudDTO.Nombre_Solicitante;
            solicitud.Numero_Empleado = solicitudDTO.Numero_Empleado;
            solicitud.Correo_Solicitante = solicitudDTO.Correo_Solicitante;
            solicitud.Fecha_Creacion = solicitudDTO.Fecha_Creacion;
            solicitud.Fecha_Modificacion = solicitudDTO.Fecha_Modificacion;
            solicitud.Leido = solicitudDTO.Leido;
            solicitud.Comentario_Rechazado = solicitudDTO.Comentario_Rechazado;
            solicitud.Folio = "11";

            //// Actividad
            solicitud.Actividad.CACEI = solicitudDTO.Actividad.CACEI;
            solicitud.Actividad.Licenciatura = solicitudDTO.Actividad.Licenciatura;
            solicitud.Actividad.Personal = solicitudDTO.Actividad.Personal;
            solicitud.Actividad.ISO = solicitudDTO.Actividad.ISO;
            solicitud.Actividad.Posgrado = solicitudDTO.Actividad.Posgrado;
            solicitud.Actividad.Otro = solicitudDTO.Actividad.Otro;

            //Evento
            //solicitud.Evento.Id = solicitudDTO.Evento.Id;
            solicitud.Evento.Lugar = solicitudDTO.Evento.Lugar;
            solicitud.Evento.Nombre = solicitudDTO.Evento.Nombre;
            solicitud.Evento.Fecha_Hora_Salida = solicitudDTO.Evento.Fecha_Hora_Salida;
            solicitud.Evento.Fecha_Hora_Regreso = solicitudDTO.Evento.Fecha_Hora_Regreso;

            //Recurso
            //solicitud.Recurso.Id = solicitudDTO.Recurso_Solicitado.Id;
            solicitud.Recurso.Hospedaje = solicitudDTO.Recurso_Solicitado.Hospedaje;
            solicitud.Recurso.Oficio_Comision = solicitudDTO.Recurso_Solicitado.Oficio_Comision;
            solicitud.Recurso.Transporte = solicitudDTO.Recurso_Solicitado.Transporte;
            solicitud.Recurso.Viatico = solicitudDTO.Recurso_Solicitado.Viatico;
            solicitud.Recurso.Combustible = solicitudDTO.Recurso_Solicitado.Combustible;
            solicitud.Recurso.Otro = solicitudDTO.Recurso_Solicitado.Otro;

            //Validacion
            solicitud.Validacion.Director = solicitudDTO.Validacion.Director;
            solicitud.Validacion.Administrador = solicitudDTO.Validacion.Administrador;
            solicitud.Validacion.Posgrado = solicitudDTO.Validacion.Posgrado;
            solicitud.Validacion.Subdirector = solicitudDTO.Validacion.Subdirector;
            solicitud.Validacion.Coordinador = solicitudDTO.Validacion.Coordinador;
            solicitud.URL_Reporte = null;
            solicitud.Id_Carrera = solicitudDTO.Carrera.Id;
            solicitud.Id_Categoria = solicitudDTO.Categoria.Id;
            solicitud.Id_Estado = 1;
            return solicitud;
        }
    }
}