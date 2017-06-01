using SS.Models.DTO;
using SS.Repositorios.Implementaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SS.Componentes
{
    
    /// <summary>
    /// 
    /// </summary>
    public static class ExisteComponente
    {


        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioDTO"></param>
        /// <returns></returns>
        public static  bool UABC(UsuarioDTO usuarioDTO)
        {
            UsuarioUABCRepositorioImpl usuarioRepositorioUABC =new UsuarioUABCRepositorioImpl();
            
            Models.Entidades.UABC.Usuario usuarioUABC = usuarioRepositorioUABC.BuscarUsuarioUABC(usuarioDTO.Correo);
            if (usuarioUABC != null)
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioDTO"></param>
        /// <returns></returns>
        public static bool FIAD(UsuarioDTO usuarioDTO)
        {
            UsuarioFIADRepositorioImpl usuarioRepositorioFIAD = new UsuarioFIADRepositorioImpl();
          
            Models.Entidades.FIAD.Usuario usuarioFIAD = usuarioRepositorioFIAD.BuscarUsuarioFIAD(usuarioDTO.Correo);
            if (usuarioFIAD != null)
            {
                return true;
            }
            return false;
        }


    }
}