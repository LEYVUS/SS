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
            Usuario usuario = new Usuario();
            usuario.Id = usuarioDTO.Id;
            usuario.Correo = usuarioDTO.Correo;
            usuario.Id_Rol = usuarioDTO.Rol.Id;
            usuario.Rol = new Rol();
            usuario.Rol.Id = usuarioDTO.Rol.Id;
            //usuario.Rol.Nombre = usuarioDTO.Rol.Nombre;
            //usuario.Rol.Descripcion = usuarioDTO.Rol.Descripcion;
            return usuario;
            
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="solicitudDTO"></param>
        /// <returns></returns>
        public static Solicitud TransferirDatosSolicitudDTO(SolicitudDTO solicitudDTO)
        {
            Solicitud solicitud = new Solicitud(new Actividad(), new Categoria(), new Evento(),new Recurso()
                , new Validacion());
            //solicitud.Id = solicitudDTO.Id;
            solicitud.Nombre_Solicitante = solicitudDTO.Nombre_Solicitante;
            solicitud.Numero_Empleado = solicitudDTO.Numero_Empleado;

            //// Actividad
            //solicitud.Actividad.Id = solicitudDTO.Actividad.Id;
            if (solicitudDTO.Actividad.ISO == null)
                solicitud.Actividad.ISO = false;
            if (solicitudDTO.Actividad.CACEI == null)
                solicitud.Actividad.CACEI = false;
            if (solicitudDTO.Actividad.Licenciatura == null )
            solicitud.Actividad.Licenciatura = false;
            if (solicitudDTO.Actividad.Otro == null)
                solicitud.Actividad.Otro = solicitudDTO.Actividad.Otro;
            if (solicitudDTO.Actividad.Personal == null)
                solicitud.Actividad.Personal = solicitudDTO.Actividad.Personal;
            if (solicitudDTO.Actividad.Licenciatura == null)
                solicitud.Actividad.Posgrado = solicitudDTO.Actividad.Posgrado;

            // Carrera
            //solicitud.Carrera.Id = solicitudDTO.Carrera.Id;
            //solicitud.Carrera.Nombre = solicitudDTO.Carrera.Nombre;
            //solicitud.Carrera.Usuario = TransferirEntidad.TransferirDatosUsuarioDTO(solicitudDTO.Carrera.usuario);

            ////Categoria
            //solicitud.Categoria.Id = solicitudDTO.Categoria.Id;
            //solicitud.Categoria.Nombre = "";

            //Estado
            //solicitud.Estado.Id = solicitudDTO.Estado.Id;
            //solicitud.Estado.Tipo = solicitudDTO.Estado.Tipo;
            //solicitud.Estado.Comentario_Rechazado = solicitudDTO.Estado.Comentario_Rechazado;

            //Evento
            //solicitud.Evento.Id = solicitudDTO.Evento.Id;
            solicitud.Evento.Lugar = "putos";
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
            solicitud.Recurso.Otro= solicitudDTO.Recurso_Solicitado.Otro;

            //Validacion
            //solicitud.Validacion.Id = solicitudDTO.Validacion.Id;
            //solicitud.Validacion.Director = solicitudDTO.Validacion.Director;
            //solicitud.Validacion.Coordinador = solicitudDTO.Validacion.Coordinador;
            //solicitud.Validacion.Administrador = solicitudDTO.Validacion.Administrador;
            //solicitud.Validacion.Posgrado = solicitudDTO.Validacion.Posgrado;

            solicitud.Folio = solicitud.Id.ToString();
            solicitud.Estado.Tipo = "Solicitado";
            solicitud.Validacion.Director = false;
            solicitud.Validacion.Administrador = false;
            solicitud.Validacion.Posgrado = false;
            solicitud.Validacion.Subdirector = false;
            solicitud.Validacion.Coordinador = false;
            solicitud.URL_Reporte = "URL";
            solicitud.Id_Carrera = solicitudDTO.Carrera.Id;
            solicitud.Id_Categoria = solicitudDTO.Categoria.Id;

            return solicitud;
        }
    }
}