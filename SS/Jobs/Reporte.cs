using Quartz;
using SS.Models.Entidades.SS;
using SS.Repositorios.Implementaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SS.Jobs
{
    public class Reporte : IJob
    {
        SolicitudRepositorioImpl solicitudRepositorio;

        public void Execute(IJobExecutionContext context)
        {
            solicitudRepositorio = new SolicitudRepositorioImpl(new EntidadesSS());
            solicitudRepositorio.EstadoReporte();
        }
    }
}