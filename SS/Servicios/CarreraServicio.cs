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
    public class CarreraServicio
    {
        CarreraRepositorioImpl carreraRepositorio = new CarreraRepositorioImpl(new EntidadesSS());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CarreraDTO BuscarPorUsuario(int id)
        {
            Carrera carrera = carreraRepositorio.BuscarPorUsuario(id);
            if(carrera != null)
            {
                return TransferirDTO.TransferirCarrera(carrera);
            }
            return null;
        }

        public List<CarreraDTO> BuscarTodos()
        {
            List<CarreraDTO> carrerasDTO = new List<CarreraDTO>();
            List<Carrera> carreras = carreraRepositorio.BuscarTodos().ToList();
            foreach (Carrera carrera in carreras)
            {
                carrerasDTO.Add(TransferirDTO.TransferirCarrera(carrera));
            }

            return carrerasDTO;
        }

    }
}