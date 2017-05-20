using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SS.Repositorios.Genericos;
using SS.Models.Entidades.SS;
using SS.Repositorios.Interfaces;


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
        public List<Solicitud> BuscarSolicitudPorSubDirector(Usuario usuario)
        {
         
            EntidadesSS context = new EntidadesSS();
            List<Solicitud> solicitudes;
            var solicitud = (from s in context.Solicituds
                             join v in context.Validacions
                                on s.Id_Validacion equals v.Id
                             where s.Validacion.Coordinador == false && s.Id_Estado == 1 && s.Correo_Solicitante != usuario.Correo
                             select new Solicitud
                             { 
                                 Validacion = v
                             });

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
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public List<Solicitud> BuscarSolicitudPorDirector(Usuario usuario)
        {
         
            EntidadesSS context = new EntidadesSS();
            List<Solicitud> solicitudes;
            var solicitud = (from s in context.Solicituds
                             join v in context.Validacions
                                on s.Id_Validacion equals v.Id
                             where s.Validacion.Director == false 
                             && s.Id_Estado == 1 
                             && s.Correo_Solicitante != usuario.Correo
                             && s.Validacion.Administrador == true
                             select new Solicitud
                             {
                                 Validacion = v
                             });

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
        public List<Solicitud> BuscarSolicitudPorPosgrado(Usuario usuario)
        {
          
            EntidadesSS context = new EntidadesSS();

            List<Solicitud> solicitudes;
            var solicitud = (from s in context.Solicituds
                             join v in context.Validacions
                                on s.Id_Validacion equals v.Id
                             where s.Validacion.Posgrado == false 
                             && s.Id_Estado == 1
                             && s.Correo_Solicitante != usuario.Correo
                             && s.Validacion.Director == true
                             select new Solicitud
                             {
                                 Validacion = v
                             });

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

