using SS.Models.Entidades.SS;
using System;
using System.Linq.Expressions;

namespace SSUABC.Repositorios.Predicado
{
    public class SolicitudPredicado
    {
        public Expression<Func<Solicitud, bool>> SolicitudPorRol(Usuario usuario)
        {
           if (usuario.Rol != null )
            {

                switch (usuario.Rol.Descripcion)
                {
                    case "Coordinador":
                        return AcademicoCoordinador(usuario);

                    case "Posgrado":
                        return AcademicoCoordinador(usuario);

                    case "Administrador":
                        return AcademicoAdministradora(usuario);

                    case "Subdirector":
                        return AdministradorSubdirector(usuario);

                    case "Director":
                        return AdministradorDirector(usuario);

                    default: return s => true;
                }

            }

           return s => true;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public Expression<Func<Solicitud, bool>> Docente(Usuario usuario)
            {
               return s => (s.Correo_Solicitante == usuario.Correo &&  s.Estado.Id != 1 && s.Estado.Id != 6);
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        private Expression<Func<Solicitud, bool>> AdministradorSubdirector(Usuario usuario)
        {
            return s => (s.Correo_Solicitante != usuario.Correo && s.Estado.Id == 1 && s.Validacion.Subdirector != true );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        private Expression<Func<Solicitud, bool>> AcademicoCoordinador(Usuario usuario)
        {
            return s => (s.Correo_Solicitante != usuario.Correo && s.Estado.Id == 1 && s.Validacion.Coordinador != true 
            && s.Carrera.Usuario.Correo == usuario.Correo
            && s.Validacion.Administrador == true
            );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        private Expression<Func<Solicitud, bool>> AcademicoAdministradora(Usuario usuario)
        {
            return s => (s.Correo_Solicitante != usuario.Correo && s.Estado.Id == 1 && s.Validacion.Administrador != true
            && s.Validacion.Coordinador == true
            );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        private Expression<Func<Solicitud, bool>> AdministradorDirector (Usuario usuario)
        {
            return s => (s.Correo_Solicitante != usuario.Correo && s.Estado.Id == 1 && s.Validacion.Director != true
            && s.Validacion.Administrador == true
            );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        private Expression<Func<Solicitud, bool>> AcademicoPosgrado(Usuario usuario)
        {
            return s => (s.Correo_Solicitante != usuario.Correo && s.Estado.Id == 1 && s.Validacion.Posgrado != true
            && s.Validacion.Director == true
            );
        }
    }
}