
using SS.Models.Entidades.SS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SS.Repositorios.Interfaces
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