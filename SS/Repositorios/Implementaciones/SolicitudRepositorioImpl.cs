using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SS.Repositorios.Genericos;
using SS.Models.Entidades.SS;
using SS.Repositorios.Interfaces;
using SSUABC.Repositorios.Predicado;

namespace SS.Repositorios.Implementaciones
{
    public class SolicitudRepositorioImpl : RepostorioCRUD<Solicitud>, ISolicitudRepositorio
    {
        public SolicitudRepositorioImpl(EntidadesSS context) : base(context)
        {
            this.context = context;
        }

        public List<Solicitud> BuscarSolicitudPorRol(Usuario usuario)
        {
            SolicitudPredicado solicitudPredicado = new SolicitudPredicado();
            EntidadesSS context = new EntidadesSS();
            List<Solicitud> solicitudSS;
            var solicitud = from s in context.Solicituds.Where(solicitudPredicado.SolicitudPorRol(usuario)).Where(solicitudPredicado.Docente(usuario))
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
        /// Mmodifica la Solicitud
        /// </summary>
        /// <param name="entity"></param>
        public override void Modificar(Solicitud entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Buscar una solicitud por rol
        /// </summary>

    }
}

