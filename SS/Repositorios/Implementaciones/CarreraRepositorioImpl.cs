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
    public class CarreraRepositorioImpl : RepostorioCRUD<Carrera>, ICarreraRepositorio
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public CarreraRepositorioImpl(DbContext context) : base(context)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Carrera BuscarPorUsuario(int id)
        {
            Carrera carreraEntidad;
            EntidadesSS entidadesSS = new EntidadesSS();

            var carrera = from c in entidadesSS.Carreras
                          where c.Id_Usuario_Coordinador == id
                          select c;
            try
            {
                carreraEntidad = carrera.First<Carrera>();
            }
            catch (Exception ex)
            {
                return null;
            }

            return carreraEntidad;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entidad"></param>
        public override void Modificar(Carrera entidad)
        {
            
        }
    }
}