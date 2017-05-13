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
    public class RolRepositorioImpl : RepostorioCRUD<Rol>,IRolRepositorio
    {
   
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public RolRepositorioImpl(EntidadesSS context) : base(context)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ententidadity"></param>
        public override void Modificar(Rol ententidadity)
        {
            
        }
    }
}