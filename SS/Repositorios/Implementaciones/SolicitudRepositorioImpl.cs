using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SS.Repositorios.Genericos;
using SS.Models.Entidades.SS;
using SS.Repositorios.Interfaces;
using SS.Models.DTO.Filtro;

namespace SS.Repositorios.Implementaciones
{
    public class SolicitudRepositorioImpl : RepostorioCRUD<Solicitud>, ISolicitudRepositorio
    {
        public SolicitudRepositorioImpl(EntidadesSS context) : base(context)
        {
            this.context = context;
        }
        public List<Solicitud> BuscarSolicitudPorCorreo(Usuario usuario)
        {
            EntidadesSS context = new EntidadesSS();
            List<Solicitud> solicitudSS;
            var solicitud = from s in context.Solicituds where s.Correo_Solicitante == usuario.Correo
                            select s;
            try
            {
                solicitudSS = solicitud.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

            return solicitudSS;
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
        public List<Solicitud> BuscarSolicitudPorDirector(String correo)
        {
         
            EntidadesSS context = new EntidadesSS();
            List<Solicitud> solicitudes;
            var solicitud = from s in context.Solicituds
                            join v in context.Validacions
                               on s.Id_Validacion equals v.Id
                            where s.Validacion.Director == false
                            && s.Id_Estado == 1
                            && s.Correo_Solicitante != correo
                            && s.Validacion.Administrador == true
                            select s;

            try
            {
                solicitudes = solicitud.ToList();
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
        public override void Modificar(Solicitud entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public List<Solicitud> BuscarSolicitudPorPosgrado(String correo)
        {
          
            EntidadesSS context = new EntidadesSS();

            List<Solicitud> solicitudes;
            var solicitud = from s in context.Solicituds
                            join v in context.Validacions
                               on s.Id_Validacion equals v.Id
                            where s.Validacion.Posgrado == false
                            && s.Id_Estado == 1
                            && s.Correo_Solicitante != correo
                            && s.Validacion.Director == true
                            select s;

            try
            {
                solicitudes = solicitud.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

            return solicitudes;
        }


        public List<Solicitud> buscarSolicitudesPorDocente(String correo) {
            EntidadesSS context = new EntidadesSS();
            List<Solicitud> solicitudes;
            var solicitud = from s in context.Solicituds
                            where (s.Correo_Solicitante == correo && s.Id_Estado != 1 && s.Id_Estado != 6)
                            select s;

            try
            {
                solicitudes = solicitud.ToList();
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
                   // .Where(s =>
               //         (filtro.Folio == 0) ? s.Id != filtro.Folio : s.Id == filtro.Folio)
             //       .Where(s =>
              //          (filtro.Nombre == "") ? s.Nombre_Solicitante != filtro.Nombre : s.Evento.Nombre == filtro.Nombre)
             //       .Where(s =>
             //           (filtro.carrera) ? s.Id_Carrera != 0 : s.Id_Carrera == filtro.Carrera.Id)
                      .ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

            return solicitudes;
        }


        public List<Solicitud> buscarSolicitudesPorCoordinador(String correo)
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

                            where (s.Correo_Solicitante != correo && s.Id_Estado == 1 && s.Validacion.Coordinador == false
                            && s.Validacion.Administrador == true && s.Carrera.Usuario.Correo == correo)
                            select s;

            try
            {
                solicitudes = solicitud.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

            return solicitudes;

        }

    }
}

