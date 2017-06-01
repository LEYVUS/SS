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
    public class RecursoRepositorioImpl : RepostorioCRUD<Recurso>, IRecursoRepositorio
    {
        public RecursoRepositorioImpl(DbContext context) : base(context)
        {
        }
   

        public override void Modificar(Recurso entity)
        {
            throw new NotImplementedException();
        }
    }

}