using SS.Componentes;
using SS.Models.DTO;
using SS.Models.Entidades.SS;
using SS.Repositorios.Implementaciones;
using System.Collections.Generic;
using System.Linq;

namespace SS.Servicios
{

    /// <summary>
    /// 
    /// </summary>
    public class EstadoServicio
    {
        /// <summary>
        /// 
        /// </summary>
        private EstadoRepositorioImpl estadoRepositorio;

        /// <summary>
        /// Contructor
        /// </summary>
        public  EstadoServicio()
        {
            estadoRepositorio = new EstadoRepositorioImpl(new EntidadesSS());
        }

        public List<EstadoDTO> BuscarTodos()
        {
            List<EstadoDTO> estadosDTO = new List<EstadoDTO>();
            List<Estado> estados = estadoRepositorio.BuscarTodos().ToList();
            foreach (Estado estado in estados)
            {
                estadosDTO.Add(TransferirDTO.TransferirEstado(estado));
            }

            return estadosDTO;
        }

    }
}