using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SS.Componentes;
using SS.Repositorios.Implementaciones;
using SS.Models.Entidades.SS;
using SS.Models.DTO;

namespace SS.Servicios
{
    /// <summary>
    /// 
    /// </summary>
    public class UsuarioServicio
    {
        private UsuarioRepositorioImpl usuarioRepositorio;
        private RolRepositorioImpl rolRepositorioImpl;
        public UsuarioServicio()
        {
            usuarioRepositorio = new UsuarioRepositorioImpl(new EntidadesSS());
            rolRepositorioImpl = new RolRepositorioImpl(new EntidadesSS());
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<UsuarioDTO> BuscarTodos()
        {
            List<UsuarioDTO> usuariosDTO = new List<UsuarioDTO>();
            List<Usuario> usuarios = usuarioRepositorio.BuscarTodos().ToList();
            foreach (Usuario usuario in usuarios)
            {
                usuariosDTO.Add(TransferirDTO.TransferirUsuario(usuario));
            }

            return usuariosDTO;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public UsuarioDTO BuscarPorId(int Id)
        {
            return TransferirDTO.TransferirUsuario(usuarioRepositorio.BuscarPorId(Id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioDTO"></param>
        /// <returns></returns>
        public MensajeDTO Modificar(UsuarioDTO usuarioDTO)
        {
            if(usuarioDTO == null)
                return MensajeComponente.mensaje("No se realizaron cambios", false);
            if (this.UsuarioValido(usuarioDTO))
            {
                if (ExisteComponente.UABC(usuarioDTO) && ExisteComponente.FIAD(usuarioDTO))
                {
                    if (usuarioRepositorio.BuscarPorCorreo(usuarioDTO.Correo) == null)
                    {
                        Usuario usuario = usuarioRepositorio.BuscarPorId(usuarioDTO.Id);
                        usuario.Correo = usuarioDTO.Correo;
                        usuarioRepositorio.Modificar(usuario);
                        return MensajeComponente.mensaje("", true);
                    }
                    return MensajeComponente.mensaje("El correo ya existe en el sistema", false);
                }
                return MensajeComponente.mensaje("El correo no pertenece a UABC", false);
            }
            return MensajeComponente.mensaje("Los datos no son validos", false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioDTO"></param>
        /// <returns></returns>
        private bool UsuarioValido(UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO != null)
            {
                if (usuarioDTO.Correo == null)
                {
                    return false;
                }
                if (usuarioDTO.Id == null)
                {
                    return false;
                }
                if (usuarioDTO.Rol == null)
                {
                    if (usuarioDTO.Rol.Nombre == null)
                    {
                        return false;
                    }
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}