using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SS.Models.Entidades.SS;
using SS.Repositorios.Genericos;
using SS.Repositorios.Interfaces;

namespace SS.Repositorios.Implementaciones
{
    public class ActividadRepositorioImpl : RepostorioCRUD<Actividad>, IActividadRepositorio
    {
        public ActividadRepositorioImpl(DbContext context) : base(context)
        {
        }
   

        public override void Modificar(Actividad entity)
        {
            throw new NotImplementedException();
        }
    }

}