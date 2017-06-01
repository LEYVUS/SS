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
    public class CategoriaServicio
    {
        CategoriaRepositorioImpl categoriaRepositorio = new CategoriaRepositorioImpl(new EntidadesSS());

        public List<CategoriaDTO> BuscarTodos()
        {
            List<CategoriaDTO> categoriasDTO = new List<CategoriaDTO>();
            List<Categoria> categorias = categoriaRepositorio.BuscarTodos().ToList();
            foreach (Categoria categoria in categorias)
            {
                categoriasDTO.Add(TransferirDTO.TransferirCategoria(categoria));
            }

            return categoriasDTO;
        }
    }
}