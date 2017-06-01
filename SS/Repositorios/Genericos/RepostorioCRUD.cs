
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace SS.Repositorios.Genericos
{ 
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="Entity"></typeparam>
    public abstract class RepostorioCRUD<Entity> : IRepositorioGenerico<Entity> where Entity : class  
    {
        protected DbContext context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public RepostorioCRUD(DbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Entity> BuscarTodos()
        {
            return context.Set<Entity>().ToList<Entity>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Entity BuscarPorId(int id)
        {
            return context.Set<Entity>().Find(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void Agregar(Entity entity)
        {

            try
            {
                context.Set<Entity>().Add(entity);
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void Borrar(Entity entity)
        {
            context.Set<Entity>().Remove(entity);
            context.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public abstract void Modificar(Entity entity);
    }
}