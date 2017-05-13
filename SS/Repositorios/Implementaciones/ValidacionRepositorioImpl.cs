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
    public class ValidacionRepositorioImpl : RepostorioCRUD<Validacion>, IValidacionRepositorio
    {
        public ValidacionRepositorioImpl(DbContext context) : base(context)
        {
        }
   

        public override void Modificar(Validacion entity)
        {
            throw new NotImplementedException();
        }
    }

}