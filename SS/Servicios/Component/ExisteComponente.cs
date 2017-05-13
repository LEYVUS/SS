using SSUABC.Models.EntidadesSolicitud;
using SSUABC.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSUABC.Servicios.Component
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
            
            Models.EntidadesUsuarioUABC.Usuario usuarioUABC = usuarioRepositorioUABC.BuscarUsuarioUABC(usuarioDTO.Correo);
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
            UsuarioUABCRepositorioImpl usuarioRepositorioUABC = new UsuarioUABCRepositorioImpl();
          
            Models.EntidadesUsuarioFIAD.Usuario usuarioFIAD = usuarioRepositorioUABC.BuscarUsuarioFIAD(usuarioDTO.Correo);
            if (usuarioFIAD != null)
            {
                return true;
            }
            return false;
        }


    }
}