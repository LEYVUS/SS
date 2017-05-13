
using SSUABC.Models.EntidadesSolicitud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSUABC.Repositorios
{
    /// <summary>
    /// 
    /// </summary>
    interface IUsuarioRepositorio
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="correo"></param>
        /// <returns></returns>
        Usuario BuscarPorCorreo(String correo);
    }
}