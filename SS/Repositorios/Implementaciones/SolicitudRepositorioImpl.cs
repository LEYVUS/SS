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
    public class SolicitudRepositorioImpl : RepostorioCRUD<Solicitud>, ISolicitudRepositorio
    {
        public SolicitudRepositorioImpl(DbContext context) : base(context)
        {
        }
   

        public override void Modificar(Solicitud entity)
        {
            throw new NotImplementedException();
        }
    }

}