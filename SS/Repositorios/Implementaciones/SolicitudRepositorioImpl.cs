using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SS.Repositorios.Genericos;
using SS.Models.Entidades.SS;
using SS.Repositorios.Interfaces;
using SS.Models.DTO.Filtro;
using SS.Componentes;

namespace SS.Repositorios.Implementaciones
{
    public class SolicitudRepositorioImpl : RepostorioCRUD<Solicitud>, ISolicitudRepositorio
    {
        public SolicitudRepositorioImpl(EntidadesSS context) : base(context)
        {
            this.context = context;
        }

        public List<Solicitud> BuscarSolicitudPorCorreo(SolicitudFiltro filtro)
        {
            EntidadesSS context = new EntidadesSS();
            List<Solicitud> solicitudes;
            var solicitud = from s in context.Solicituds where
                            s.Correo_Solicitante == filtro.usuario.Correo
                            select s;
            try
            {
                solicitudes = solicitud
                    .Where(s =>
                        (filtro.Folio == 0) ? s.Id != filtro.Folio : s.Id == filtro.Folio)
                     .Where(s =>
                       (filtro.Nombre == "") ? s.Nombre_Solicitante != filtro.Nombre : s.Evento.Nombre == filtro.Nombre)
                     .Where(s =>
                       (filtro.carrera) ? s.Id_Carrera != 0 : s.Id_Carrera == filtro.Carrera.Id)               
                .ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

            return solicitudes;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public List<Solicitud> BuscarSolicitudPorSubDirector(SolicitudFiltro filtro) { 
            EntidadesSS context = new EntidadesSS();
            List<Solicitud> solicitudes;
            var solicitud = from s in context.Solicituds
                             join v in context.Validacions
                                on s.Id_Validacion equals v.Id
                             where s.Validacion.Subdirector == false 
                             && s.Id_Estado == 1
                             && s.Correo_Solicitante != filtro.usuario.Correo
                            orderby(s.Id) ascending
                            select s ;

            try
            {
                solicitudes = solicitud
                   .Where(s =>
                       (filtro.Folio == 0) ? s.Id != filtro.Folio : s.Id == filtro.Folio )
                   .Where(s =>
                       (filtro.Nombre == "") ? s.Nombre_Solicitante != filtro.Nombre : s.Evento.Nombre == filtro.Nombre)
                   .Where(s =>
                       (filtro.carrera) ? s.Id_Carrera != 0 : s.Id_Carrera == filtro.Carrera.Id)
                     .ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

            return solicitudes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public List<Solicitud> BuscarSolicitudPorDirector(SolicitudFiltro filtro)
        {
         
            EntidadesSS context = new EntidadesSS();
            List<Solicitud> solicitudes;
            var solicitud = from s in context.Solicituds
                            join v in context.Validacions
                               on s.Id_Validacion equals v.Id
                            where s.Validacion.Director == false
                            && s.Id_Estado == 1
                            && s.Correo_Solicitante != filtro.usuario.Correo
                            && s.Validacion.Administrador == true
                            select s;

            try
            {
                solicitudes = solicitud
                   .Where(s =>
                       (filtro.Folio == 0) ? s.Id != filtro.Folio : s.Id == filtro.Folio)
                   .Where(s =>
                       (filtro.Nombre == "") ? s.Nombre_Solicitante != filtro.Nombre : s.Evento.Nombre == filtro.Nombre)
                   .Where(s =>
                       (filtro.carrera) ? s.Id_Carrera != 0 : s.Id_Carrera == filtro.Carrera.Id)
                     .ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

            return solicitudes;
        }

        /// <summary>
        /// Mmodifica la Solicitud
        /// </summary>
        /// <param name="entity"></param>
        public override void Modificar(Solicitud entidad)
        {
            context.Entry(entidad).State = EntityState.Modified;
            context.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public List<Solicitud> BuscarSolicitudPorPosgrado(SolicitudFiltro filtro)
        {
          
            EntidadesSS context = new EntidadesSS();

            List<Solicitud> solicitudes;
            var solicitud = from s in context.Solicituds
                            join v in context.Validacions
                               on s.Id_Validacion equals v.Id
                            join a in context.Actividads
                                on s.Id_Actividad equals a.Id
                            where s.Validacion.Posgrado == false
                            && s.Id_Estado == 1
                            && s.Correo_Solicitante != filtro.usuario.Correo
                            && s.Validacion.Director == true
                            && s.Actividad.Posgrado ==true
                            select s;

            try
            {
                solicitudes = solicitud
                   .Where(s =>
                       (filtro.Folio == 0) ? s.Id != filtro.Folio : s.Id == filtro.Folio)
                   .Where(s =>
                       (filtro.Nombre == "") ? s.Nombre_Solicitante != filtro.Nombre : s.Evento.Nombre == filtro.Nombre)
                   .Where(s =>
                       (filtro.carrera) ? s.Id_Carrera != 0 : s.Id_Carrera == filtro.Carrera.Id)
                     .ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

            return solicitudes;
        }


        public List<Solicitud> buscarSolicitudesPorDocente(SolicitudFiltro filtro) {
            EntidadesSS context = new EntidadesSS();
            List<Solicitud> solicitudes;
            var solicitud = from s in context.Solicituds
                            where (s.Correo_Solicitante == filtro.usuario.Correo && s.Id_Estado != 1 && s.Id_Estado != 6)
                            select s;

            try
            {
                solicitudes = solicitud
                    .Where(s =>
                        (filtro.Folio == 0) ? s.Id != filtro.Folio : s.Id == filtro.Folio)
                    .Where(s =>
                        (filtro.Nombre == "") ? s.Nombre_Solicitante != filtro.Nombre : s.Evento.Nombre == filtro.Nombre)
                    .Where(s =>
                       (filtro.carrera) ? s.Id_Carrera != 0 : s.Id_Carrera == filtro.Carrera.Id)
                      .ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

            return solicitudes;

        }

        public List<Solicitud> buscarSolicitudesPorAdministrador(SolicitudFiltro filtro)
        {
            EntidadesSS context = new EntidadesSS();

            List<Solicitud> solicitudes;
            var solicitud = from s in context.Solicituds
                             join v in context.Validacions
                                on s.Id_Validacion equals v.Id
                             where s.Validacion.Administrador == false
                             && s.Id_Estado == 1
                             && s.Correo_Solicitante != filtro.usuario.Correo
                             && s.Validacion.Subdirector == true
                            orderby (s.Id) ascending
                            select s;

            try
            {
                solicitudes = solicitud
                    .Where(s =>
                        (filtro.Folio == 0) ? s.Id != filtro.Folio : s.Id == filtro.Folio)
                    .Where(s =>
                        (filtro.Nombre == "") ? s.Nombre_Solicitante != filtro.Nombre : s.Evento.Nombre == filtro.Nombre)
                    .Where(s =>
                       (filtro.carrera) ? s.Id_Carrera != 0 : s.Id_Carrera == filtro.Carrera.Id)
                      .ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

            return solicitudes;
        }


        public List<Solicitud> buscarSolicitudesPorCoordinador(SolicitudFiltro filtro)
        {
            EntidadesSS context = new EntidadesSS();
            List<Solicitud> solicitudes;
            var solicitud = from s in context.Solicituds
                            join v in context.Validacions
                             on s.Id_Validacion equals v.Id
                            join c in context.Carreras
                             on s.Id_Carrera equals c.Id
                            join u in context.Usuarios
                            on c.Id_Usuario_Coordinador equals u.Id

                            where (s.Correo_Solicitante != filtro.usuario.Correo && 
                                   s.Id_Estado == 1 && 
                                   s.Validacion.Coordinador == false &&
                                   s.Validacion.Administrador == true 
                                  && s.Carrera.Usuario.Correo == filtro.usuario.Correo)
                            select s;
            try
            {
                solicitudes = solicitud
                     .Where(s =>
                         (filtro.Folio == 0) ? s.Id != filtro.Folio : s.Id == filtro.Folio)
                     .Where(s =>
                         (filtro.Nombre == "") ? s.Nombre_Solicitante != filtro.Nombre : s.Evento.Nombre == filtro.Nombre)
                     .Where(s =>
                        (filtro.carrera) ? s.Id_Carrera != 0 : s.Id_Carrera == filtro.Carrera.Id)
                       .ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

            return solicitudes;

        }

        public List<Solicitud> buscarSolicituHistorial(SolicitudFiltro filtro)
        {
            EntidadesSS context = new EntidadesSS();
            List<Solicitud> solicitudes;
            var solicitud = from s in context.Solicituds
                            select s;

            try
            {
                solicitudes = solicitud
                    .Where(s =>
                        (filtro.Folio == 0) ? s.Id != filtro.Folio : s.Id == filtro.Folio)
                    .Where(s =>
                        (filtro.Nombre == "") ? s.Nombre_Solicitante != filtro.Nombre : s.Evento.Nombre == filtro.Nombre)
                    .Where(s =>
                        (filtro.Correo == "") ? s.Correo_Solicitante != filtro.Correo : s.Correo_Solicitante == filtro.Correo)
                    .Where(s =>
                       (filtro.carrera) ? s.Id_Carrera != 0 : s.Id_Carrera == filtro.Carrera.Id)
                      .ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

            return solicitudes;
        }

        public void EstadoReporte()
        {
            EntidadesSS context = new EntidadesSS();
            List<Solicitud> solicitudes;
            var fechaActual = DateTime.Now;
            var solicitud = from s in context.Solicituds
                            join e in context.Eventoes
                             on s.Id_Evento equals e.Id
                            where (s.Id_Estado == (int)EstadoEnum.Aceptado &&
                                  ((s.Evento.Fecha_Hora_Salida - DateTime.Now).Days >= 5))
                            select s;
      
            try
            {
                solicitudes = solicitud.ToList();
                foreach (Solicitud s in solicitudes)
                {
                    s.Id_Estado = (int)EstadoEnum.Terminado;
                }
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}

