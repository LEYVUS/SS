using SS.Componentes;
using SS.Models.DTO;
using SS.Models.Entidades.SS;
using SS.Repositorios.Implementaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SS.Servicios
{
    /// <summary>
    /// 
    /// </summary>
    public class RolServicio
    {
        private RolRepositorioImpl rolRepositorio = new RolRepositorioImpl(new EntidadesSS());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RolDTO BuscarPorId(int id)
        {
            return TransferirDTO.TransferirRol(rolRepositorio.BuscarPorId(id));
        }
    }
}