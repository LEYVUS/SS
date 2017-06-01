using SS.Models.Entidades.FIAD;
using SS.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SS.Repositorios.Implementaciones
{
    public class UsuarioFIADRepositorioImpl : IUsuarioFIADRepositorio
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="correo"></param>
        /// <returns></returns>
        public Usuario BuscarUsuarioFIAD(string correo)
        {

            EntidadesFIAD context = new EntidadesFIAD();
            SS.Models.Entidades.FIAD.Usuario usuarioFIAD;
            var usuario = from u in context.Usuarios
                          where u.Email == correo
                          select u;
            try
            {
                usuarioFIAD = usuario.First<SS.Models.Entidades.FIAD.Usuario>();
            }
            catch (Exception ex)
            {
                return null;
            }

            return usuarioFIAD;

        }
    }
}