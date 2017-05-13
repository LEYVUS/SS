
using SS.Models.Entidades.UABC;
using SS.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SS.Repositorios.Implementaciones
{
    /// <summary>
    /// 
    /// </summary>
    public class UsuarioUABCRepositorioImpl : IUsuarioUABCRepositorio
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="correo"></param>
        /// <returns></returns>
        public Usuario BuscarUsuarioUABC(string correo)
        {
            SS.Models.Entidades.UABC.Usuario usuarioUABC;
            EntidadesUABC context = new EntidadesUABC();

            var usuario = from u in context.Usuarios
                          where u.Email == correo
                          select u;
            try
            {
                usuarioUABC = usuario.First<Usuario>();
            }
            catch (Exception ex)
            {
                return null;
            }
           
            return usuarioUABC;
                        
        }
    }
}