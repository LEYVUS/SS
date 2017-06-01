using SS.Models.Entidades.SS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Repositorios.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    interface ICarreraRepositorio
    {
        Carrera BuscarPorUsuario(int id);
    }
}
