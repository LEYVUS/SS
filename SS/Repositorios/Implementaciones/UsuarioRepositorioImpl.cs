using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SS.Repositorios.Genericos;
using SS.Models.Entidades.SS;
using SS.Repositorios.Interfaces;

namespace SS.Repositorios.Implementaciones
{
    /// <summary>
    /// 
    /// </summary>
    public class UsuarioRepositorioImpl : RepostorioCRUD<Usuario>, IUsuarioRepositorio
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public UsuarioRepositorioImpl(DbContext context) : base(context)
        {
            this.context = context;   
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="correo"></param>
        /// <returns></returns>
        public Usuario BuscarPorCorreo(string correo)
        {
            EntidadesSS context = new EntidadesSS();
            Usuario usuarioUABC;
            var usuario = from u in context.Usuarios
                          where u.Correo == correo
                          select u;
            try
            {
                usuarioUABC = usuario.First<Usuario>();
            }
            catch(Exception ex)
            {
                return null;
            }
        
            return usuarioUABC;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entidad"></param>
        public override void Modificar(Usuario entidad)
        {
            context.Entry(entidad).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}