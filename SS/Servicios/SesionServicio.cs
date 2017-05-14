using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SS.Repositorios.Implementaciones;
using SS.Models.DTO;
using SS.Models.Entidades.SS;
using SS.Componentes;
using System.Security.Claims;

namespace SS.Servicios
{
    /// <summary>
    /// 
    /// </summary>
    public class SesionServicio
    {
       private  UsuarioUABCRepositorioImpl usuarioRepositorioUABC;
        private UsuarioFIADRepositorioImpl usuarioRepositorioFIAD;
       private  UsuarioRepositorioImpl usuarioRepositorioSS;

        /// <summary>
        /// 
        /// </summary>
        public SesionServicio()
        {
            usuarioRepositorioUABC = new UsuarioUABCRepositorioImpl();
            usuarioRepositorioFIAD = new UsuarioFIADRepositorioImpl();
 
            usuarioRepositorioSS= new UsuarioRepositorioImpl(new EntidadesSS());
        }
   
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public MensajeDTO InicioSesion(UsuarioDTO usuario)
        {
            Models.Entidades.UABC.Usuario usuarioUABC = usuarioRepositorioUABC.BuscarUsuarioUABC(usuario.Correo);
            

            if (usuarioUABC != null)
            {
                if (usuario.Contrasenia.Equals(usuarioUABC.Contraseña))
                {
                    Models.Entidades.FIAD.Usuario usuarioFIAD = usuarioRepositorioFIAD.BuscarUsuarioFIAD(usuario.Correo);

                    if (usuarioFIAD != null)
                    {
                        Models.Entidades.SS.Usuario usuarioSS = usuarioRepositorioSS.BuscarPorCorreo(usuario.Correo);
                        
                        if (usuarioSS != null)
                        {
                            UsuarioDTO usuarioAdministrativo = TransferirDTO.TransferirUsuario(usuarioSS);
                            usuarioAdministrativo.Nombre = usuarioUABC.Nombre;
                            usuarioAdministrativo.Apellido = usuarioUABC.Apellido;
                            usuarioAdministrativo.Numero_Empleado = usuarioUABC.Numero_Empleado;
                            return MensajeComponente.mensaje("Se ha iniciado sesion como " + usuarioAdministrativo.Rol.Nombre, usuarioAdministrativo);
                        }
                        else
                        {
                            UsuarioDTO usuarioProfesor = new UsuarioDTO();
                            usuarioProfesor.Nombre = usuarioUABC.Nombre;
                            usuarioProfesor.Apellido = usuarioUABC.Apellido;
                            return MensajeComponente.mensaje("Se ha iniciado sesion como Profesor", usuarioProfesor);
                        }
                    }
                    else
                    {
                        return MensajeComponente.mensaje("El usuario no pertenece a la Facultad de Ingenieria, Arquitectura y Diseño", null);

                    }
                }
                else
                {
                    return MensajeComponente.mensaje("La contraseña introducida es incorrecta", null);

                }
            }
            else
            {
                return MensajeComponente.mensaje("El usuario no pertenece a el dominio de UABC", null);

            }
            

        }

        public UsuarioDTO getUsuarioLogeado(string correo)
        {
            Models.Entidades.UABC.Usuario usuarioUABC = usuarioRepositorioUABC.BuscarUsuarioUABC(correo);
            Usuario usuario = usuarioRepositorioSS.BuscarPorCorreo(correo);
            if(usuario != null)
            {
                return new UsuarioDTO(usuarioUABC.Nombre, correo,TransferirDTO.TransferirRol(usuario.Rol));
            }
                return new UsuarioDTO(usuarioUABC.Nombre,correo,null);
        }

    }
}