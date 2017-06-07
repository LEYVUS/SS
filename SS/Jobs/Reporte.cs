using Quartz;
using SS.Componentes;
using SS.Componentes.Constantes;
using SS.Models.Entidades.SS;
using SS.Repositorios.Implementaciones;
using System.Collections.Generic;

namespace SS.Jobs
{
    public class Reporte : IJob
    {
        SolicitudRepositorioImpl solicitudRepositorio;
        UsuarioRepositorioImpl usuarioRepositorioImpl;
        UsuarioUABCRepositorioImpl usuarioUABCRepositorio;

        public void Execute(IJobExecutionContext context)
        {
            //Cambiar estado de aceptado a reporte 
            EntidadesSS contextss = new EntidadesSS();
            solicitudRepositorio = new SolicitudRepositorioImpl(contextss);
            solicitudRepositorio.EstadoReporte();
            usuarioRepositorioImpl = new UsuarioRepositorioImpl(contextss);

            //Buscar solicitudes con estado reporte y enviar solicitudes
            Usuario subdirector = usuarioRepositorioImpl.BuscarPorRol((int)RolEnum.Subdirector);
            List<Solicitud> solicitudes= solicitudRepositorio.BuscarSolicitudPorEstadoReporte();
            usuarioUABCRepositorio = new UsuarioUABCRepositorioImpl();

            Models.Entidades.UABC.Usuario subdirectorCredenciales = usuarioUABCRepositorio.BuscarUsuarioUABC(subdirector.Correo);
            CorreoComponente correo = new CorreoComponente(subdirectorCredenciales.Email,subdirectorCredenciales.Contraseña);
            foreach(Solicitud s in solicitudes)
            {
                correo.MandarCorreo("Sistema de solicitud de salida.Falta subir reporte", "REPORTE", s.Correo_Solicitante);
            }
           
        }
    }
}