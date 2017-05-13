using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSUABC.Repositorios.Repositorio_Generico
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="Entity"></typeparam>
    interface IRepositorioGenerico<Entidad> where Entidad : class
    {
        IEnumerable<Entidad> BuscarTodos();
        Entidad BuscarPorId(int id);
        void Agregar(Entidad entidad);
        void Borrar(Entidad entidad);
        void Modificar(Entidad entidad);
    }
}
